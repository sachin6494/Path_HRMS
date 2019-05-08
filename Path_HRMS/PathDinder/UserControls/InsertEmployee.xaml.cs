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
    /// Interaction logic for InsertEmployee.xaml
    /// </summary>
    public partial class InsertEmployee : UserControl
    {

        private static InsertEmployee _instance;
        public static InsertEmployee Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InsertEmployee();
                return _instance;
            }
        }



        public InsertEmployee()
        {
            InitializeComponent();
            fill_Combo_Company();
            fill_Combo_Department();
            fill_Combo_Designation();
        }

        string dbConnection = @"Data Source=DESKTOP-O6H1E28\SQLEXPRESS; Initial Catalog=PATH_HRMS; Persist Security Info=True;User ID=sa;Password=sa@123";

        // --------------Combo box of Company--------

        void fill_Combo_Company()
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                // if (con.State == ConnectionState.Closed)
                con.Open();
                string Query = "SELECT * FROM COMPANY";
                SqlCommand sqlCmd = new SqlCommand(Query, con);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    string company_name = dr.GetString(1);
                    txtCompany.Items.Add(company_name);
                }
                con.Close();
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
                con.Close();
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // -----------------end---------------





        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "INSERT INTO EMPLOYEE(EMPLOYEE_ID,EMPLOYEE_NAME,FATHER_NAME,GENDER_ID,DATE_OF_BIRTH,MOBILE_NO,COMPANY_ID,DEPARTMENT_ID,DESIGNATION_ID) VALUES(@EMPLOYEE_ID,@EMPLOYEE_NAME,@FATHER_NAME,@GENDER_ID,@DATE_OF_BIRTH,@MOBILE_NO,@COMPANY_ID ,@DEPARTMENT_ID,@DESIGNATION_ID)";
                using (SqlCommand sqlCmd = new SqlCommand(query, con))
                {
                    sqlCmd.Parameters.AddWithValue("@EMPLOYEE_ID", txtEmployeeId.Text);
                    sqlCmd.Parameters.AddWithValue("@EMPLOYEE_NAME", txtEmployeeName.Text);
                    sqlCmd.Parameters.AddWithValue("@FATHER_NAME", txtFatherName.Text);
                    sqlCmd.Parameters.AddWithValue("@GENDER_ID", txtGender.Text);
                    sqlCmd.Parameters.AddWithValue("@DATE_OF_BIRTH", txtDOB.Text);
                    sqlCmd.Parameters.AddWithValue("@MOBILE_NO", txtMobile.Text);
                    sqlCmd.Parameters.AddWithValue("@COMPANY_ID", txtCompany.Text);
                    sqlCmd.Parameters.AddWithValue("@DEPARTMENT_ID", txtDepartment.Text);
                    sqlCmd.Parameters.AddWithValue("@DESIGNATION_ID", txtDesignation.Text);
                    
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Row inserted !! ");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btndelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "DELETE FROM EMPLOYEE WHERE EMPLOYEE_ID =   '" + this.txtEmployeeId.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Data has been Deleted");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btnupdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnection);

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "UPDATE EMPLOYEE SET EMPLOYEE_ID = '" + this.txtEmployeeId.Text +"' , EMPLOYEE_NAME = '" + this.txtEmployeeName.Text +"' , FATHER_NAME = '"+ this.txtFatherName.Text + "', GENDER_ID = '" + this.txtGender.Text +"', DATE_OF_BIRTH = '" + this.txtDOB.Text + "', MOBILE_NO = '" + this.txtMobile.Text + "' ,COMPANY_ID = '" + this.txtCompany.Text + "', DEPARTMENT_ID = '" + this.txtDepartment.Text + "', DESIGNATION_ID = '" + this.txtDesignation.Text +"'  WHERE EMPLOYEE_ID = '" + this.txtEmployeeId.Text +"' ";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Data has been Updated");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
