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
    /// Interaction logic for frmExam.xaml
    /// </summary>
    public partial class frmExam : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;

        public frmExam(bool update, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            try
            {
                konekcija = kon.KreireajKonekciju();
                konekcija.Open();

                string vratiStudenta = @"select StudentID, Name+ ' ' +Surname + ' '+ NumberOfIndex as Student from tblStudent";
                DataTable dtStudent = new DataTable();
                dtStudent.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daStudent = new SqlDataAdapter(vratiStudenta, konekcija);
                daStudent.Fill(dtStudent);
                cbxStudent.ItemsSource = dtStudent.DefaultView;
                dtStudent.Dispose();
                daStudent.Dispose();

                string vratiPredmet = @"select SubjectID, NameOfSubject from tblSubject";
                DataTable dtSubject = new DataTable();
                SqlDataAdapter daSubject = new SqlDataAdapter(vratiPredmet, konekcija);
                daSubject.Fill(dtSubject);
                cbxSubject.ItemsSource = dtSubject.DefaultView;
                dtSubject.Dispose();
                daSubject.Dispose();

                string vratiUcionicu = @"select ClassroomID, NumberOfClassroom from tblClassroom";
                DataTable dtClassroom = new DataTable();
                SqlDataAdapter daClassroom = new SqlDataAdapter(vratiUcionicu, konekcija);
                daClassroom.Fill(dtClassroom);
                cbxClassroom.ItemsSource = dtClassroom.DefaultView;
                dtClassroom.Dispose();
                daClassroom.Dispose();

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
        public frmExam()
        {
            InitializeComponent();

            try
            {
                konekcija = kon.KreireajKonekciju();
                konekcija.Open();

                string vratiStudenta = @"select StudentID, Name+ ' ' +Surname + ' '+ NumberOfIndex as Student from tblStudent";
                DataTable dtStudent = new DataTable();
                dtStudent.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daStudent = new SqlDataAdapter(vratiStudenta, konekcija);
                daStudent.Fill(dtStudent);
                cbxStudent.ItemsSource = dtStudent.DefaultView;
                dtStudent.Dispose();
                daStudent.Dispose();

                string vratiPredmet = @"select SubjectID, NameOfSubject from tblSubject";
                DataTable dtSubject = new DataTable();
                SqlDataAdapter daSubject = new SqlDataAdapter(vratiPredmet, konekcija);
                daSubject.Fill(dtSubject);
                cbxSubject.ItemsSource = dtSubject.DefaultView;
                dtSubject.Dispose();
                daSubject.Dispose();

                string vratiUcionicu = @"select ClassroomID, NumberOfClassroom from tblClassroom";
                DataTable dtClassroom = new DataTable();
                SqlDataAdapter daClassroom = new SqlDataAdapter(vratiUcionicu, konekcija);
                daClassroom.Fill(dtClassroom);
                cbxClassroom.ItemsSource = dtClassroom.DefaultView;
                dtClassroom.Dispose();
                daClassroom.Dispose();

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
                DateTime date = (DateTime)dpDate.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);

                konekcija.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = konekcija

                };
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@Time", SqlDbType.NVarChar).Value = txtTime.Text;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = cbxStudent.SelectedValue;
                cmd.Parameters.Add("@SubjectID", SqlDbType.Int).Value = cbxSubject.SelectedValue;
                cmd.Parameters.Add("@ClassroomID", SqlDbType.Int).Value = cbxClassroom.SelectedValue;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = cbxEmployee.SelectedValue;

                if (this.update)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblExam
                                        Set Date=@Date, Time=@Time, StudentID=@StudentID, EmployeeID=@EmployeeID, SubjectID=@SubjectID, ClassroomID=@ClassroomID Where ExamID=@id";

                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblExam (Date, Time, StudentID, EmployeeID, SubjectID, ClassroomID ) values (@Date, @Time, @StudentID, @EmployeeID, @SubjectID, @ClassroomID);";
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

        private void cbxEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
