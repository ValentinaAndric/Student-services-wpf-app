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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Studentska_služba.Forme;

namespace Studentska_služba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;
        string loadedTable;

        #region Select upiti
        static string studyprogramsSelect = @"Select StudyProgramID as 'ID', NameOfStudyProgram as 'Name of study program', Duration from tblStudyProgram";
        static string studentsSelect = @"Select StudentID as 'ID', Name + ' ' + Surname as 'Name and surname of the student', NumberOfIndex as 'Number of index', Adress, City, Contact, NameOfStudyProgram as 'Name of study program' from tblStudent 
                                                   inner join tblStudyProgram on tblStudent.StudyProgramID = tblStudyProgram.StudyProgramID";
        static string employeesSelect = @"Select EmployeeID as 'ID', EmployeeName + ' ' + EmployeeSurname as 'Name and surname of the employee', Counter from tblEmployee";
        static string paymentslipsSelect = @"Select PaymentSlipID as 'ID', BankAccountNumber as 'Bank account number', Sum, EmployeeName+ ' ' + EmployeeSurname as 'Name and surname of the employee', Name + ' ' +Surname as 'Name and surname of the student' from tblPaymentSlip
                                                   inner join tblStudent on tblPaymentSlip.StudentID= tblStudent.StudentID
                                                   inner join tblEmployee on tblPaymentSlip.EmployeeID= tblEmployee.EmployeeID";
        static string examsSelect = @"Select ExamID as 'ID', Date, Time, Name+ ' ' + Surname as 'Student', EmployeeName + ' ' + EmployeeSurname as 'Employee who performs exam registration', NameOfSubject as 'Name of subject' , NumberOfClassroom as 'Number of classroom'
                                       from tblExam inner join tblStudent on tblExam.StudentID = tblStudent.StudentID
                                                    inner join tblEmployee on tblExam.EmployeeID= tblEmployee.EmployeeID
                                                    inner join tblSubject on tblExam.SubjectID= tblSubject.SubjectID
                                                    inner join tblClassroom on tblExam.ClassroomID= tblClassroom.ClassroomID";
        static string subjectsSelect = @"Select SubjectID as 'ID', NameOfSubject as 'Name of subject', Professor, ESPB from tblSubject";
        static string classroomsSelect = @"Select ClassroomID as 'ID', NumberOfClassroom as 'Number of classroom' from tblClassroom";
        #endregion

        #region Select sa uslovom
        string selectConditionStudyPrograms = @"select * from tblStudyProgram where StudyProgramID=";
        string selectConditionStudents = @"select * from tblStudent where StudentID=";
        string selectConditionExams = @"select * from tblExam where ExamID=";
        string selectConditionPaymentSlips = @"select * from tblPaymentSlip where PaymentSlipID=";
        string selectConditionClassrooms = @"select * from tblClassroom where ClassroomID=";
        string selectConditionEmployees = @"select * from tblEmployee where EmployeeID=";
        string selectConditionSubjects = @"select * from tblSubject where SubjectID=";
        #endregion

        #region Delete upit
        string StudyProgramsDelete = @"delete from tblStudyProgram  where StudyProgramID=";
        string StudentsDelete = @"delete from tblStudent  where StudentID=";
        string ExamsDelete = @"delete from tblExam where ExamID=";
        string PaymentSlipsDelete = @"delete from tblPaymenSlip  where PaymentSlipID=";
        string ClassroomsDelete = @"delete from tblClassroom  where ClassroomID=";
        string EmployeesDelete = @"delete from tblEmployee  where EmployeeID=";
        string SubjectsDelete = @"delete from tblSubject  where SubjectID=";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            loadData(dataGridCentral, studyprogramsSelect);
            
        }
        public void loadData(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(dt);
                if (grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }
                loadedTable = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();
                     
            }
            catch(SqlException)
            {
                MessageBox.Show("Data entered unsuccessfully", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija.Close();
            }

        }

        private void btnStudyPrograms_Click(object sender, RoutedEventArgs e)
        {
            loadData(dataGridCentral, studyprogramsSelect);
        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            loadData(dataGridCentral, studentsSelect);
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            loadData(dataGridCentral, employeesSelect);
        }

        private void btnPaymentSlips_Click(object sender, RoutedEventArgs e)
        {
            loadData(dataGridCentral, paymentslipsSelect);
        }

        private void btnExams_Click(object sender, RoutedEventArgs e)
        {
            loadData(dataGridCentral, examsSelect);
        }

        private void btnSubjects_Click(object sender, RoutedEventArgs e)
        {
            loadData(dataGridCentral, subjectsSelect);
        }

        private void btnClassrooms_Click(object sender, RoutedEventArgs e)
        {
            loadData(dataGridCentral, classroomsSelect);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Window wnd;
            if (loadedTable.Equals(studyprogramsSelect, StringComparison.Ordinal))
            {
                wnd = new frmStudyProgram();
                wnd.ShowDialog();
                loadData(dataGridCentral, studyprogramsSelect);
            }
            else if (loadedTable.Equals(studentsSelect, StringComparison.Ordinal))
            {
                wnd = new frmStudent();
                wnd.ShowDialog();
                loadData(dataGridCentral, studentsSelect);
            }
            else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
            {
                wnd = new frmEmployee();
                wnd.ShowDialog();
                loadData(dataGridCentral, employeesSelect);
            }
            else if (loadedTable.Equals(paymentslipsSelect, StringComparison.Ordinal))
            {
                wnd = new frmPaymentSlip();
                wnd.ShowDialog();
                loadData(dataGridCentral, paymentslipsSelect);
            }
            else if (loadedTable.Equals(examsSelect, StringComparison.Ordinal))
            {
                wnd = new frmExam();
                wnd.ShowDialog();
                loadData(dataGridCentral, examsSelect);
            }
            else if (loadedTable.Equals(subjectsSelect, StringComparison.Ordinal))
            {
                wnd = new frmSubject();
                wnd.ShowDialog();
                loadData(dataGridCentral, subjectsSelect);
            }
            else if (loadedTable.Equals(classroomsSelect, StringComparison.Ordinal))
            {
                wnd = new frmClassroom();
                wnd.ShowDialog();
                loadData(dataGridCentral, classroomsSelect);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (loadedTable.Equals(studyprogramsSelect, StringComparison.Ordinal))
            {
                PopuniFormu(dataGridCentral, selectConditionStudyPrograms);
                loadData(dataGridCentral, studyprogramsSelect);
            }
            else if (loadedTable.Equals(studentsSelect, StringComparison.Ordinal))
            {
                PopuniFormu(dataGridCentral, selectConditionStudents);
                loadData(dataGridCentral, studentsSelect);
            }
            else if (loadedTable.Equals(classroomsSelect, StringComparison.Ordinal))
            {
                PopuniFormu(dataGridCentral, selectConditionClassrooms);
                loadData(dataGridCentral, classroomsSelect);
            }
            else if (loadedTable.Equals(subjectsSelect, StringComparison.Ordinal))
            {
                PopuniFormu(dataGridCentral, selectConditionSubjects);
                loadData(dataGridCentral, subjectsSelect);
            }
            else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
            {
                PopuniFormu(dataGridCentral, selectConditionEmployees);
                loadData(dataGridCentral, employeesSelect);
            }
            else if (loadedTable.Equals(examsSelect, StringComparison.Ordinal))
            {
                PopuniFormu(dataGridCentral, selectConditionExams);
                loadData(dataGridCentral, examsSelect);
            }
            else if (loadedTable.Equals(paymentslipsSelect, StringComparison.Ordinal))
            {
                PopuniFormu(dataGridCentral, selectConditionPaymentSlips);
                loadData(dataGridCentral, paymentslipsSelect);
            }
        }
        void PopuniFormu(DataGrid grid, string selectCondition)
        {
            try
            {
                konekcija.Open();
                update = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                pomocniRed = red;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectCondition + "@id";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (loadedTable.Equals(studyprogramsSelect, StringComparison.Ordinal))
                    {
                        frmStudyProgram windowStudyProgram = new frmStudyProgram(update, pomocniRed);

                        windowStudyProgram.txtNameOfStudyProgram.Text = reader["NameOfStudyProgram"].ToString();
                        windowStudyProgram.txtDuration.Text = reader["Duration"].ToString();
                        windowStudyProgram.ShowDialog();
                    }
                   else if (loadedTable.Equals(studentsSelect, StringComparison.Ordinal))
                    {
                        frmStudent windowStudent = new frmStudent(update, pomocniRed);

                        windowStudent.txtName.Text = reader["Name"].ToString();
                        windowStudent.txtSurname.Text = reader["Surname"].ToString();
                        windowStudent.txtNumberOfIndex.Text = reader["NumberOfIndex"].ToString();
                        windowStudent.txtAdress.Text = reader["Adress"].ToString();
                        windowStudent.txtCity.Text = reader["City"].ToString();
                        windowStudent.txtContact.Text = reader["Contact"].ToString();
                        windowStudent.cbxStudyProgram.SelectedValue = reader["StudyProgramID"].ToString();
                        windowStudent.ShowDialog();
                    }
                    else if(loadedTable.Equals(classroomsSelect, StringComparison.Ordinal))
                    {
                        frmClassroom windowClassroom = new frmClassroom(update, pomocniRed);

                        windowClassroom.txtNumberOfClassroom.Text = reader["NumberOfClassroom"].ToString();
                        windowClassroom.ShowDialog();
                    }
                    else if (loadedTable.Equals(subjectsSelect, StringComparison.Ordinal))
                    {
                        frmSubject windowSubject = new frmSubject(update, pomocniRed);

                        windowSubject.txtNameOfSubject.Text = reader["NameOfSubject"].ToString();
                        windowSubject.txtProfessor.Text = reader["Professor"].ToString();
                        windowSubject.txtESPB.Text = reader["ESPB"].ToString();
                        windowSubject.ShowDialog();
                    }
                    else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
                    {
                        frmEmployee windowEmployee = new frmEmployee(update, pomocniRed);

                        windowEmployee.txtEmployeeName.Text = reader["EmployeeName"].ToString();
                        windowEmployee.txtEmployeeSurname.Text = reader["EmployeeSurname"].ToString();
                        windowEmployee.txtCounter.Text = reader["Counter"].ToString();
                        windowEmployee.ShowDialog();
                    }
                    else if (loadedTable.Equals(examsSelect, StringComparison.Ordinal))
                    {
                        frmExam windowExam = new frmExam(update, pomocniRed);

                        windowExam.cbxStudent.SelectedValue = reader["StudentID"].ToString();
                        windowExam.cbxSubject.SelectedValue = reader["SubjectID"].ToString();
                        windowExam.cbxClassroom.SelectedValue = reader["ClassroomID"].ToString();
                        windowExam.dpDate.SelectedDate = (DateTime)reader["Date"];
                        windowExam.txtTime.Text = reader["Time"].ToString();
                        windowExam.cbxEmployee.SelectedValue = reader["EmployeeID"].ToString();
                        windowExam.ShowDialog();
                    }
                    else if (loadedTable.Equals(paymentslipsSelect, StringComparison.Ordinal))
                    {
                        frmPaymentSlip windowPaymentSlip = new frmPaymentSlip(update, pomocniRed);

                        windowPaymentSlip.txtBankAccountNumber.Text = reader["BankAccountNumber"].ToString();
                        windowPaymentSlip.txtSum.Text = reader["Sum"].ToString();
                        windowPaymentSlip.cbxStudent.SelectedValue = reader["StudentID"].ToString();
                        windowPaymentSlip.cbxEmployee.SelectedValue = reader["EmployeeID"].ToString();                     
                        windowPaymentSlip.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You didn't select a row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                update = false;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (loadedTable.Equals(studyprogramsSelect, StringComparison.Ordinal))
            {
                ObrisiZapis(dataGridCentral, StudyProgramsDelete);
                loadData(dataGridCentral, studyprogramsSelect);
            }
            else if (loadedTable.Equals(studentsSelect, StringComparison.Ordinal))
            {
                ObrisiZapis(dataGridCentral, StudentsDelete);
                loadData(dataGridCentral, studentsSelect);
            }
            else if (loadedTable.Equals(classroomsSelect, StringComparison.Ordinal))
            {
                ObrisiZapis(dataGridCentral, ClassroomsDelete);
                loadData(dataGridCentral, classroomsSelect);
            }
            else if (loadedTable.Equals(subjectsSelect, StringComparison.Ordinal))
            {
                ObrisiZapis(dataGridCentral, SubjectsDelete);
                loadData(dataGridCentral, subjectsSelect);
            }
            else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
            {
                ObrisiZapis(dataGridCentral, EmployeesDelete);
                loadData(dataGridCentral, employeesSelect);
            }
            else if (loadedTable.Equals(examsSelect, StringComparison.Ordinal))
            {
                ObrisiZapis(dataGridCentral, ExamsDelete);
                loadData(dataGridCentral, examsSelect);
            }
            else if (loadedTable.Equals(paymentslipsSelect, StringComparison.Ordinal))
            {
                ObrisiZapis(dataGridCentral, PaymentSlipsDelete);
                loadData(dataGridCentral, paymentslipsSelect);
            }
        }

        private void ObrisiZapis(DataGrid grid, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(rezultat==MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand
                    {
                        Connection = konekcija

                    };
                    komanda.Parameters.Add("id", SqlDbType.Int).Value = red["ID"];
                    komanda.CommandText = deleteUpit + "@id";
                    komanda.ExecuteNonQuery();
                    komanda.Dispose();
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("You didn't select a row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(SqlException)
            {
                MessageBox.Show("You cann't delete this data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija!=null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
