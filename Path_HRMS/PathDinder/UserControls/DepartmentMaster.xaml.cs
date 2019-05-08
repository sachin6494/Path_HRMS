using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PathDinder.UserControls
{
    /// <summary>
    /// Interaction logic for DepartmentMaster.xaml
    /// </summary>
    public partial class DepartmentMaster : UserControl
    {

        public DepartmentMaster()
        {
            InitializeComponent();
        }

        string dbConnection = @"Data Source=DESKTOP-O6H1E28\SQLEXPRESS; Initial Catalog=PATH_HRMS; Persist Security Info=True;User ID=sa;Password=sa@123";


        private void BtnDepartCreate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "INSERT INTO DEPARTMENT(DEPARTMENT_ID,DEPARTMENT_NAME) VALUES(@DEPARTMENT_ID,@DEPARTMENT_NAME)";
                using (SqlCommand sqlCmd = new SqlCommand(query, con))
                {
                    sqlCmd.Parameters.AddWithValue("@DEPARTMENT_ID", txtDepartmentId.Text);
                    sqlCmd.Parameters.AddWithValue("@DEPARTMENT_NAME", txtDepartmentName.Text);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Row inserted !! ");
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDepartDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "DELETE FROM DEPARTMENT WHERE DEPARTMENT_ID =   '" + this.txtDepartmentId.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Data has been Deleted");
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnDepartRefresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM DEPARTMENT";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();

                //TRANSFER DATA TO DATAGRID
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("DEPARTMENT");
                dataAdp.Fill(dt);

                departDataGrid.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
