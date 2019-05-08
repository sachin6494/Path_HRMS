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
    /// Interaction logic for DesignationMaster.xaml
    /// </summary>
    public partial class DesignationMaster : UserControl
    {

        
        public DesignationMaster()
        {
            InitializeComponent();
        }

        string dbConnection = @"Data Source=DESKTOP-O6H1E28\SQLEXPRESS; Initial Catalog=PATH_HRMS; Persist Security Info=True;User ID=sa;Password=sa@123";

        private void BtnDesigCreate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "INSERT INTO DESIGNATION(DESIGNATION_ID,DESIGNATION_NAME) VALUES(@DESIGNATION_ID,@DESIGNATION_NAME)";
                using (SqlCommand sqlCmd = new SqlCommand(query, con))
                {
                    sqlCmd.Parameters.AddWithValue("@DESIGNATION_ID", txtDesignationId.Text);
                    sqlCmd.Parameters.AddWithValue("@DESIGNATION_NAME", txtDesignationName.Text);
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

        private void BtnDesigDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "DELETE FROM DESIGNATION WHERE DESIGNATION_ID =   '" + this.txtDesignationId.Text + "' ";
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

        private void BtnDesigRefresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "SELECT DESIGNATION_ID,DESIGNATION_NAME FROM DESIGNATION";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();

                //TRANSFER DATA TO DATAGRID
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("DESIGNATION");
                dataAdp.Fill(dt);

                desigDataGrid.ItemsSource = dt.DefaultView;
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
