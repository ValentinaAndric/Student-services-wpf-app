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
using System.Globalization;

namespace Studentska_služba.Forme
{
    /// <summary>
    /// Interaction logic for frmPaymentSlip.xaml
    /// </summary>
    public partial class frmPaymentSlip : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;

        public frmPaymentSlip(bool update, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtBankAccountNumber.Focus();

            try
            {
                konekcija = kon.KreireajKonekciju();
                konekcija.Open();

                string vratiStudenta = @"select StudentID, Name+ ' ' +Surname + ' '+ NumberOfIndex as Student from tblStudent";
                DataTable dtStudent = new DataTable();
                SqlDataAdapter daStudent = new SqlDataAdapter(vratiStudenta, konekcija);
                dtStudent.Locale = CultureInfo.InvariantCulture;
                daStudent.Fill(dtStudent);
                cbxStudent.ItemsSource = dtStudent.DefaultView;
                dtStudent.Dispose();
                daStudent.Dispose();

                string vratiZaposlenog = @"select EmployeeID, EmployeeName+ ' '+ EmployeeSurname as Employee from tblEmployee";
                DataTable dtEmployee = new DataTable();
                dtEmployee.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daEmployee = new SqlDataAdapter(vratiZaposlenog, konekcija);
                daEmployee.Fill(dtEmployee);
                cbxEmployee.ItemsSource = dtEmployee.DefaultView;
                dtEmployee.Dispose();
                daEmployee.Dispose();


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
            this.update = update;
            this.pomocniRed = pomocniRed;
        }

        public frmPaymentSlip()
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtBankAccountNumber.Focus();

            try
            {
                konekcija = kon.KreireajKonekciju();
                konekcija.Open();

                string vratiStudenta = @"select StudentID, Name+ ' ' +Surname + ' '+ NumberOfIndex as Student from tblStudent";
                DataTable dtStudent = new DataTable();
                SqlDataAdapter daStudent = new SqlDataAdapter(vratiStudenta, konekcija);
                dtStudent.Locale = CultureInfo.InvariantCulture;
                daStudent.Fill(dtStudent);
                cbxStudent.ItemsSource = dtStudent.DefaultView;
                dtStudent.Dispose();
                daStudent.Dispose();

                string vratiZaposlenog = @"select EmployeeID, EmployeeName+ ' '+ EmployeeSurname as Employee from tblEmployee";
                DataTable dtEmployee = new DataTable();
                dtEmployee.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daEmployee = new SqlDataAdapter(vratiZaposlenog, konekcija);
                daEmployee.Fill(dtEmployee);
                cbxEmployee.ItemsSource = dtEmployee.DefaultView;
                dtEmployee.Dispose();
                daEmployee.Dispose();


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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = konekcija

                };
                cmd.Parameters.Add("@BankAccountNumber", SqlDbType.NVarChar).Value = txtBankAccountNumber.Text;
                cmd.Parameters.Add("@Sum", SqlDbType.NVarChar).Value = txtSum.Text;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = cbxStudent.SelectedValue;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = cbxEmployee.SelectedValue;

                if (this.update)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblPaymentSlip
                                        Set BankAccountNumber=@BankAccountNumber, Sum=@Sum, StudentID=@StudentID, EmployeeID=@EmployeeID Where PaymentSlipID= @id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblPaymentSlip (BankAccountNumber, Sum, StudentID, EmployeeID) values (@BankAccountNumber, @Sum, @StudentID, @EmployeeID);";
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
