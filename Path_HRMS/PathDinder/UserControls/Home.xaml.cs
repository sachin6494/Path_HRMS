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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
      
        public Home()
        {
            InitializeComponent();
            fill_Combo();
            fill_Combo_Company();
            fill_Combo_Department();
            fill_Combo_Designation();
            fill_Combo_Gender();
        }


        string dbConnection = @"Data Source=DESKTOP-O6H1E28\SQLEXPRESS; Initial Catalog=PATH_HRMS; Persist Security Info=True;User ID=sa;Password=sa@123";



        // combo for Employee Data-------------
        void fill_Combo()
        {
            //string dbConnection = ConfigurationManager.ConnectionStrings["DBCS"].connectionString;
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
               // if (con.State == ConnectionState.Closed)
                    con.Open();
                string Query = "SELECT * FROM EMPLOYEE";
                SqlCommand sqlCmd = new SqlCommand(Query, con);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    string employee_name = dr.GetString(1);
                    combo.Items.Add(employee_name);
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ----------End---------------

        void fill_Combo_Company()
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                // DataTable dt = objUtility.SelectCompanyDesignation(Convert.ToInt32(COMPANY_ID))
                con.Open();
                string Query = "SELECT * FROM COMPANY";
                SqlCommand sqlCmd = new SqlCommand(Query, con);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    string company_name = dr.GetString(1);
                    txtCompany.Items.Add(company_name);
                    
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // -----------------end---------------

        //---------------- Combo for Department-----------------
        void fill_Combo_Department()
        {

          
        SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                // if (con.State == ConnectionState.Closed)
                con.Open();
                string Query = "SELECT * FROM DEPARTMENT";
                SqlCommand sqlCmd = new SqlCommand(Query, con);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    string department_name = dr.GetString(1);
                    txtDepartment.Items.Add(department_name);
                   
                    
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // -----------------end---------------

        // ----------- Combo box for Designation------------------

        void fill_Combo_Designation()
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                // if (con.State == ConnectionState.Closed)
                con.Open();
                string Query = "SELECT * FROM DESIGNATION";
                SqlCommand sqlCmd = new SqlCommand(Query, con);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    string designation_name = dr.GetString(1);
                    txtDesignation.Items.Add(designation_name);
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // -----------------end---------------

        // ----------- Combo box for Gender------------------



        void fill_Combo_Gender()
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                // if (con.State == ConnectionState.Closed)
                con.Open();
                string Query = "SELECT * FROM GENDER";
                SqlCommand sqlCmd = new SqlCommand(Query, con);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    string gender_name = dr.GetString(1);
                    txtGender.Items.Add(gender_name);

                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // -----------------end---------------




        private void BtncreateEmp_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection(dbConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //string query = "INSERT INTO EMPLOYEE(EMPLOYEE_ID,EMPLOYEE_NAME,FATHER_NAME,GENDER_TYPE,DATE_OF_BIRTH,MOBILE_NO,COMPANY_NAME,DEPARTMENT_NAME,DESIGNATION_NAME,SALARY) VALUES(@EMPLOYEE_ID,@EMPLOYEE_NAME,@FATHER_NAME,@GENDER_TYPE,@DATE_OF_BIRTH,@MOBILE_NO,@COMPANY_NAME ,@DEPARTMENT_NAME,@DESIGNATION_NAME,@SALARY)";
                string query = "Insert_Employee_Details";
                using (SqlCommand sqlCmd = new SqlCommand(query, con))
                {
                    //cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToUInt32(TextBox1.Text);
                    sqlCmd.Parameters.AddWithValue("@EMPLOYEE_ID", SqlDbType.Int).Value = txtEmployeeId.Text;
                    //sqlCmd.Parameters.AddWithValue("@EMPLOYEE_ID", txtEmployeeId.Text);
                    sqlCmd.Parameters.AddWithValue("@EMPLOYEE_NAME", txtEmployeeName.Text);
                    sqlCmd.Parameters.AddWithValue("@FATHER_NAME", txtFatherName.Text);
                    sqlCmd.Parameters.AddWithValue("@GENDER_TYPE", txtGender.Text);
                    sqlCmd.Parameters.AddWithValue("@DATE_OF_BIRTH", txtDOB.Text);
                    sqlCmd.Parameters.AddWithValue("@MOBILE_NO", txtMobile.Text);
                    sqlCmd.Parameters.AddWithValue("@COMPANY_NAME", txtCompany.Text);
                    sqlCmd.Parameters.AddWithValue("@DEPARTMENT_NAME", txtDepartment.Text);
                    sqlCmd.Parameters.AddWithValue("@DESIGNATION_NAME", txtDesignation.Text);
                    sqlCmd.Parameters.AddWithValue("@MONTHLY_CTC", txtSalary.Text);

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

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "UPDATE EMPLOYEE SET EMPLOYEE_ID = '" + this.txtEmployeeId.Text + "' , EMPLOYEE_NAME = '" + this.txtEmployeeName.Text + "' , FATHER_NAME = '" + this.txtFatherName.Text + "', GENDER_TYPE = '" + this.txtGender.Text + "', DATE_OF_BIRTH = '" + this.txtDOB.Text + "', MOBILE_NO = '" + this.txtMobile.Text + "' ,COMPANY_NAME = '" + this.txtCompany.Text + "', DEPARTMENT_NAME = '" + this.txtDepartment.Text + "', DESIGNATION_NAME = '" + this.txtDesignation.Text + "'  WHERE EMPLOYEE_ID = '" + this.txtEmployeeId.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Data has been Updated");
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "DELETE FROM EMPLOYEE WHERE EMPLOYEE_ID = '" + this.txtEmployeeId.Text + "' ";
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

        private void BtnReferesh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "SELECT * FROM EMPLOYEE";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();

                //TRANSFER DATA TO DATAGRID
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("EMPLOYEE");
                dataAdp.Fill(dt);

                dataGrid.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void combo_dropDownClosed(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                // DataTable dt = objUtility.SelectCompanyDesignation(Convert.ToInt32(COMPANY_ID))
                con.Open();
                string Query = "SELECT * FROM EMPLOYEE WHERE EMPLOYEE_NAME = '" + combo.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(Query, con);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    string EMPLOYEE_ID = dr.GetInt32(0).ToString();
                    string EMPLOYEE_NAME = dr.GetString(1);
                    string FATHER_NAME = dr.GetString(2);
                    string GENDER_TYPE = dr.GetString(3);
                    string DATE_OF_BIRTH = dr.GetDateTime(4).ToString();
                    string MOBILE_NO = dr.GetString(5);
                    string COMPANY_NAME  = dr.GetString(6);
                    string DEPARTMENT_NAME = dr.GetString(7);
                    string DESIGNATION_NAME = dr.GetString(8);
                    txtEmployeeId.Text = EMPLOYEE_ID;
                    txtEmployeeName.Text = EMPLOYEE_NAME;
                     txtFatherName.Text = FATHER_NAME;
                     txtGender.Text = GENDER_TYPE;
                     txtDOB.Text = DATE_OF_BIRTH;
                     txtMobile.Text = MOBILE_NO;
                     txtCompany.Text = COMPANY_NAME;
                     txtDepartment.Text = DEPARTMENT_NAME;
                     txtDesignation.Text = DESIGNATION_NAME;

                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
