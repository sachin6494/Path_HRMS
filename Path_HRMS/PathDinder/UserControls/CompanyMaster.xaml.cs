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
    /// Interaction logic for CompanyMaster.xaml
    /// </summary>
    public partial class CompanyMaster : UserControl
    {

       
        public CompanyMaster()
        {
            InitializeComponent();
        }

        string dbConnection = @"Data Source=DESKTOP-O6H1E28\SQLEXPRESS; Initial Catalog=PATH_HRMS; Persist Security Info=True;User ID=sa;Password=sa@123";


        private void BtnCompanyCreate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "INSERT INTO COMPANY(COMPANY_ID,COMPANY_NAME,COMPANY_ADDRESS) VALUES(@COMPANY_ID,@COMPANY_NAME,@COMPANY_ADDRESS)";
                using (SqlCommand sqlCmd = new SqlCommand(query, con))
                {
                    sqlCmd.Parameters.AddWithValue("@COMPANY_ID", txtCompanyId.Text);
                    sqlCmd.Parameters.AddWithValue("@COMPANY_NAME", txtCompanyName.Text);
                    sqlCmd.Parameters.AddWithValue("@COMPANY_ADDRESS", txtCompanyAddress.Text);
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

        private void BtnCompanyDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "DELETE FROM COMPANY WHERE COMPANY_ID =   '" + this.txtCompanyId.Text + "' ";
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

        private void BtnCompanyRefresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "SELECT COMPANY_ID,COMPANY_NAME,COMPANY_ADDRESS FROM COMPANY";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();

                //TRANSFER DATA TO DATAGRID
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("COMPANY");
                dataAdp.Fill(dt);

                companyDataGrid.ItemsSource = dt.DefaultView;
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
