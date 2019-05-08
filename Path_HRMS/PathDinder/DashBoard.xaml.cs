using PathDinder.UserControls;
using PathFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PathDinder
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        UserControls.Home home = new Home();
        UserControls.InsertEmployee insertEmployee = new InsertEmployee();        
        UserControls.CompanyMaster companyMaster = new CompanyMaster();
        UserControls.DepartmentMaster departmentMaster = new DepartmentMaster();        
        UserControls.DesignationMaster designationMaster = new DesignationMaster();

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {

            Login log = new Login();
            log.Show();
            this.Close();
        }

        
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Add(home);
            main.Children.Remove(companyMaster);
            main.Children.Remove(departmentMaster);
            main.Children.Remove(designationMaster);
            main.Children.Remove(insertEmployee);
            //this.Close();
        }

        private void Btn_Company_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Add(companyMaster);
            main.Children.Remove(home);
            main.Children.Remove(departmentMaster);
            main.Children.Remove(designationMaster);
            main.Children.Remove(insertEmployee);
            //this.Close();
        }

        private void Btn_Employee_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Add(insertEmployee);
            main.Children.Remove(home);
            main.Children.Remove(companyMaster);
            main.Children.Remove(departmentMaster);
            main.Children.Remove(designationMaster);
            //this.Close();
        }

        private void Btn_Department_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Add(departmentMaster);
            main.Children.Remove(home);
            main.Children.Remove(companyMaster);
            main.Children.Remove(designationMaster);
            main.Children.Remove(insertEmployee);
            //this.Close();
        }

        private void Btn_Designation_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Add(designationMaster);
            main.Children.Remove(home);
            main.Children.Remove(companyMaster);
            main.Children.Remove(departmentMaster);
            main.Children.Remove(insertEmployee);
            //this.Close();
        }

        private void Btn_Report_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
