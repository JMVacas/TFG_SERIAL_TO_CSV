using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
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
        string Data_Received;
        delegate void StringArgReturningVoidDelegate(string text);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaudRateCombo.Items.AddRange(BaudRateItems);
        }


        private void Seleccion_Puerto_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                Puerto_Serie.Close();
                Puerto_Serie.PortName = PuertoCombo.SelectedItem.ToString();
                Puerto_Serie.BaudRate = Convert.ToInt32(BaudRateCombo.SelectedItem.ToString());
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

        private void Puerto_Serie_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            Data_Received+= Puerto_Serie.ReadLine();
            if (Data_Received =="OK\r")
            {
                Data_Received = "";
                Puerto_Serie.Write(textBox1.Text);
            }
            if (Data_Received.Contains("Finished"))
            {
                SetText("Guardar");
            }

        }

        private void Parar_Click(object sender, EventArgs e)
        {
            Puerto_Serie.Close();
            if (Data_Received.Contains("Finished"))
            {
                Explorer.Guardar(Data_Received);
                Parar.Text = "Parar";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               Convert.ToInt32(textBox1.Text);
            }
            catch (Exception Error)
            {
                MessageBox.Show(this, "El valor introducido no es un numero" ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0";
            }
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (textBox1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                Parar.Text = text;
            }
        }
    }
}
