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
    /// Interaction logic for frmStudent.xaml
    /// </summary>
    public partial class frmStudent : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;
        public frmStudent(bool update, DataRowView pomocniRed)
        {

            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtName.Focus();
            
            try
            {
                konekcija = kon.KreireajKonekciju();
                konekcija.Open();

                string vratiStudijskiProgram = @"select StudyProgramID, NameOfStudyProgram from tblStudyProgram";
                DataTable dtStudyProgram = new DataTable();
                SqlDataAdapter daStudyProgram = new SqlDataAdapter(vratiStudijskiProgram, konekcija);
                daStudyProgram.Fill(dtStudyProgram);
                cbxStudyProgram.ItemsSource = dtStudyProgram.DefaultView;
                dtStudyProgram.Dispose();
                daStudyProgram.Dispose();
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
        public frmStudent()
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtName.Focus();
            try
            {
                konekcija = kon.KreireajKonekciju();
                konekcija.Open();

                string vratiStudijskiProgram = @"select StudyProgramID, NameOfStudyProgram from tblStudyProgram";
                DataTable dtStudyProgram = new DataTable();
                SqlDataAdapter daStudyProgram = new SqlDataAdapter(vratiStudijskiProgram,konekcija);
                daStudyProgram.Fill(dtStudyProgram);
                cbxStudyProgram.ItemsSource = dtStudyProgram.DefaultView;
                dtStudyProgram.Dispose();
                daStudyProgram.Dispose();
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
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = txtSurname.Text;
                cmd.Parameters.Add("@NumberOfIndex", SqlDbType.NVarChar).Value = txtNumberOfIndex.Text;
                cmd.Parameters.Add("@Adress", SqlDbType.NVarChar).Value = txtAdress.Text;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = txtCity.Text;
                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = txtContact.Text;
                cmd.Parameters.Add("@StudyProgramID", SqlDbType.Int).Value = cbxStudyProgram.SelectedValue;
                if (this.update)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblStudent
                                        Set Name=@Name, Surname=@Surname, NumberOfIndex=@NumberOfIndex, Adress=@Adress, City=@City, Contact=@Contact, StudyProgramID=@StudyProgramID Where StudentID= @id";

                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblStudent (Name, Surname, NumberOfIndex, Adress, City, Contact, StudyProgramID) values (@Name, @Surname, @NumberOfIndex, @Adress, @City, @Contact, @StudyProgramID);";
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
