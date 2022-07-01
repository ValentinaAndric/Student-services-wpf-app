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
using System.Data;
using System.Data.SqlClient;



namespace Studentska_služba.Forme
{
    /// <summary>
    /// Interaction logic for frmEmployee.xaml
    /// </summary>
    public partial class frmEmployee : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;
        public frmEmployee(bool update, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtEmployeeName.Focus();
            this.update = update;
            this.pomocniRed = pomocniRed;
        }
        public frmEmployee()
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtEmployeeName.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = konekcija

                };
                cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = txtEmployeeName.Text;
                cmd.Parameters.Add("@EmployeeSurname", SqlDbType.NVarChar).Value = txtEmployeeSurname.Text;
                cmd.Parameters.Add("@Counter", SqlDbType.Int).Value = txtCounter.Text;
                if(this.update)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblEmployee
                                        Set EmployeeName=@EmployeeName, EmployeeSurname=@EmployeeSurname, Counter=@Counter Where EmployeeID= @id";

                    this.pomocniRed = null;
                }
                else 
                {
                    cmd.CommandText = @"insert into tblEmployee (EmployeeName, EmployeeSurname, Counter) values (@EmployeeName, @EmployeeSurname, @Counter);";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Data entry is invalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
