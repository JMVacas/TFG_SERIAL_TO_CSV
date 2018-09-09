using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_SERIAL_TO_CSV
{
    //Clase que se utiliza para exportar los datos a un fichero .csv
    public static class Explorer
    {
        private static string _DataToWrite;
        public static void Guardar(string DataToWrite)
        {
            SaveFileDialog DataToCSV = new SaveFileDialog();
            _DataToWrite = DataToWrite;
            DataToCSV.Filter= "CSV files (*.csv)|*.csv";
            DataToCSV.FilterIndex = 0;
            DataToCSV.RestoreDirectory = true;
            DataToCSV.Title = "Guardar resultados de la prueba";
         
            if (DataToCSV.ShowDialog()  == DialogResult.OK)
            {
                    using (StreamWriter Archivo_CSV = new StreamWriter(DataToCSV.FileName))
                    {
                        Archivo_CSV.Write(_DataToWrite);
                        DataToWrite = "";
                    }
                   
            }
        }
    }
}
