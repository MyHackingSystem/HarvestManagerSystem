using System;
using System.Collections.Generic;
using System.Text;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;
using System.Windows.Forms;


namespace HarvestManagerSystem.common
{
    class Common
    {
        private static SupplierDAO supplierDAO = SupplierDAO.getInstance();
        private static EmployeeDAO employeeDAO = EmployeeDAO.getInstance();
        
        public static Dictionary<string, Supplier> SupplierNameList(ComboBox cb)
        {
            List<string> NamesList = new List<string>();
            Dictionary<string, Supplier> mSupplierDictionary = new Dictionary<string, Supplier>();
            mSupplierDictionary.Clear();
            try
            {
                mSupplierDictionary = supplierDAO.SupplierDictionary();
                NamesList.AddRange(mSupplierDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cb.DataSource = NamesList;
            }
            return mSupplierDictionary;
        }

        public static Dictionary<string, Employee> EmployeeNameList(ComboBox cb)
        {
            List<string> NamesList = new List<string>();
            Dictionary<string, Employee> mDictionary = new Dictionary<string, Employee>();
            mDictionary.Clear();
            try
            {
                mDictionary = employeeDAO.EmployeeDictionary(); 
                NamesList.AddRange(mDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cb.DataSource = NamesList;
            }
            return mDictionary;
        }

        public static Dictionary<string, Farm> FarmNameList(ComboBox cb)
        {
            FarmDAO farmDAO = FarmDAO.getInstance();
            List<string> NamesList = new List<string>();
            Dictionary<string, Farm> mDictionary = new Dictionary<string, Farm>();
            mDictionary.Clear();
            try
            {
                mDictionary = farmDAO.FarmDictionary();
                NamesList.AddRange(mDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cb.DataSource = NamesList;
            }
            return mDictionary;
        }

        public static Dictionary<string, Product> ProductNameList(ComboBox cb)
        {
            ProductDAO dao = ProductDAO.getInstance();
            Dictionary<string, Product> mDictionary = new Dictionary<string, Product>();
            List<string> NamesList = new List<string>();
            mDictionary.Clear();
            try
            {
                mDictionary = dao.ProductDictionary();
                NamesList.AddRange(mDictionary.Keys);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (NamesList != null)
            {
                cb.DataSource = NamesList;
            }
            return mDictionary;
        }
    }
}
