using System;
using System.Collections.Generic;
using System.Text;
using HarvestManagerSystem.model;
using HarvestManagerSystem.database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;


namespace HarvestManagerSystem.view
{
    class DataLive
    {

        private static DataLive sDataLive = new DataLive();
        private DataLive()
        {

        }

        public static DataLive getInstance()
        {
            if(sDataLive == null)
            {
                sDataLive = new DataLive();
            }
            return sDataLive;
        }

        EmployeeDAO employeeDAO = EmployeeDAO.getInstance();

        public static BindingList<Employee> list = new BindingList<Employee>();


        public List<Employee> EMPLOYEE_LIST_LIVE_DATA = new List<Employee>();
        public static ObservableCollection<Employee> EMPLOYEE_LIVE_DATA = new ObservableCollection<Employee>();

        public void DisplayEmployeeData()
        {

        }
    }
}
