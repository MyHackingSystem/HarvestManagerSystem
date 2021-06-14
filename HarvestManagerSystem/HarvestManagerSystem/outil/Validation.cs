using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExcelDataReader;
using HarvestManagerSystem.model;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;       //Microsoft Excel 14 object in references-> COM tab
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading.Tasks;


namespace HarvestManagerSystem.outil
{
    class Validation
    {
        public static void ValidateNumberEntred(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static bool isNumeric(string txt)
        {
            Regex regex = new Regex(@"^[0-9]+\.?[0-9]*$");
            return regex.Match(txt).Success;
        }


        public static List<HarvestQuantity> readHarvestFile()
        {
            List<HarvestQuantity> HarvesterList = new List<HarvestQuantity>();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Office Files|*.xlsx;*.xls;", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                    DataSet result = reader.AsDataSet();
                    DataTable tbl = result.Tables[0];

                    foreach (DataRow row in tbl.Rows)
                    {
                        if (row.ItemArray[0].ToString() == "ID") continue;
                        HarvestQuantity hq = new HarvestQuantity();
                        try
                        {
                            hq.Employee.EmployeeId = (row.ItemArray[0].ToString() != null && !row.ItemArray[0].ToString().Equals("")) ? Convert.ToInt32(row.ItemArray[0].ToString()) : -1;
                            hq.Employee.FirstName = row.ItemArray[1].ToString();
                            hq.AllQuantity = (row.ItemArray[7].ToString() != null && !row.ItemArray[7].ToString().Equals("")) ? Convert.ToDouble(row.ItemArray[7].ToString()) : 0;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        if (hq.AllQuantity > 0 && hq.Employee.EmployeeId > 0) HarvesterList.Add(hq);
                    }
                    reader.Close();
                }
            }
            return HarvesterList;
        }

        public static bool ScrambledEquals(List<int> x, List<int> y)
        {
            return !x.Except(y).Any();
        }

    }

}
