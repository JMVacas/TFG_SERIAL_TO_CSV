using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_SERIAL_TO_CSV
{

    public partial class Form1 : Form
    {
        string[] Port_Names;
        string[] BaudRateItems = { "300", "600", "1200", "2400", "4800", "9600", "14400", "19200"
                , "22800", "38400", "57600", "115200" };
        string[] Colores = { "IR_970", "IR_850", "Rojo", "Naranja", "Amarillo", "Verde", "Azul", "UV" };
        string Data_Received;   // Aqui se guarda un string temporal con todos los datos recibidos
        delegate void StringArgReturningVoidDelegate(string text);
        delegate void IntArgReturningVoidDelegate(int Value);
        delegate void ShowMessageDelegate(IWin32Window win32Window, string Texto, string Titulo, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon);
        bool Finish = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaudRateCombo.Items.AddRange(BaudRateItems);
        }
        private void PuertoCombo_DropDown(object sender, EventArgs e)
        {
            
            Port_Names = SerialPort.GetPortNames();
            PuertoCombo.Items.Clear();
            PuertoCombo.Items.AddRange(Port_Names);
        }

        private void BaudRateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Desencadena el inicio de la recepcion de datos y envio de datos, se instancia la configuracion
        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                Puerto_Serie.Close();
                Barra_De_Progreso.Maximum = 8 * Convert.ToInt32(Input_Iteraciones.Text);
                Puerto_Serie.PortName = PuertoCombo.SelectedItem.ToString();
                Puerto_Serie.BaudRate = Convert.ToInt32(BaudRateCombo.SelectedItem);
                Puerto_Serie.Open();
                if (Puerto_Serie.IsOpen)
                Puerto_Serie.Write("Start");
                Puerto_Serie.DiscardInBuffer();
                Data_Received = "";
            }
            catch (Exception error)
            {

            }
        }
        //Evento que ocurre cada vez que se reciben Datos por UART
        private void Puerto_Serie_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Temporal = "";
            Temporal = Puerto_Serie.ReadLine();//Se lee lo que hay en el buffer
            if (Temporal.Contains("Iteraciones"))
            {
                Puerto_Serie.Write(Input_Iteraciones.Text);
            }
            else if (Temporal.Contains("Ajuste"))
            {
                Puerto_Serie.Write(Input_Ajuste.Text);
            }
            else if (Temporal.Contains("Progreso"))
            {
                Set_Progreso(Convert.ToInt32(Regex.Match(Temporal, @"\d+").Value));                   
            }
            else if (Temporal.Contains("Finished"))
            {
                SetText("Guardar");
                ShowMessageBox(this, "El proceso ha finalizado correctamente", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Finish = true;
            }
            else
            {
                Data_Received += Temporal;
            }
        }
        //Cierra el puerto serie
        private void Parar_Click(object sender, EventArgs e)
        {
            if (Finish)
            {
                Explorer.Guardar(Data_Received);
                Parar.Text = "Parar";
                Finish = false;
            }
            else
            {
                Puerto_Serie.Write("Stop");
                Puerto_Serie.Close();
            }

        }
        //Se escribe el numero de Iteraciones
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               Convert.ToInt32(Input_Iteraciones.Text);
            }
            catch (Exception Error)
            {
                MessageBox.Show(this, "El valor introducido no es un numero" ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Input_Iteraciones.Text = "0";
            }
        }
        
        private void SetText(string text)
        {
            //InvokeRequired compara la ID del hilo es igual que la ID del hilo que la creo,
            //si son diferentes retorna true, es necesario ya que al abrir el puerto COM
            //se instancia un nuevo hilo, si se intenta cambiar el texto desde el captador de 
            // eventos del puerto COM, da un error ya que el hilo es distinto al hilo que lo creo,
            //poir lo tanto esta funcion, se utiliza esta funcion 
            //como delegado para poder modificar el texto.
            if (Parar.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                Parar.Text = text;
            }
        }

        private void Input_Ajuste_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(Input_Ajuste.Text);
            }
            catch (Exception Error)
            {
                MessageBox.Show(this, "El valor introducido no es un numero, recuerde que solo admite comas para introducir los decimales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Input_Ajuste.Text = "0";
            }
        }
        private void Set_Progreso(int Value)
        {
            //Al igual que el metodo SetText, para cambiar el progreso desde la funcion de 
            //PuertoSerie_Data_Received es necesario utilizar delegados
            if (Barra_De_Progreso.InvokeRequired)
            {
                IntArgReturningVoidDelegate d = new IntArgReturningVoidDelegate(Set_Progreso);
                Invoke(d, new object[] { Value });
            }
            else
            {
                try
                {
                    Barra_De_Progreso.Value = Value;
                }
                finally
                {

                }
            }
        }
        private void ShowMessageBox(IWin32Window win32Window, string Texto, string Titulo, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            //Al igual que el metodo SetText, para mostrar el final del proceso desde la funcion de
            //PuertoSerie_Data_Received es necesario utilizar delegados
            if (Barra_De_Progreso.InvokeRequired)
            {
                ShowMessageDelegate d = new ShowMessageDelegate(ShowMessageBox);
                Invoke(d, new object[] { win32Window, Texto, Titulo, messageBoxButtons, messageBoxIcon });
            }
            else
            {
                MessageBox.Show(win32Window, Texto, Titulo, messageBoxButtons, messageBoxIcon);
            }
        }
    }
}
