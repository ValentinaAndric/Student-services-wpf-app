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
    /// Interaction logic for frmStudyProgram.xaml
    /// </summary>
    public partial class frmStudyProgram : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;

        public frmStudyProgram()
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtNameOfStudyProgram.Focus();
           
        }
        public frmStudyProgram(bool update, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtNameOfStudyProgram.Focus();
            this.update = update;
            this.pomocniRed = pomocniRed;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        { try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = konekcija

                };
                cmd.Parameters.Add("@NameOfStudyProgram", SqlDbType.NVarChar).Value = txtNameOfStudyProgram.Text;
                cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = txtDuration.Text;
                if (this.update)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblStudyProgram
                                        Set NameOfStudyProgram=@NameOfStudyProgram, Duration=@Duration Where StudyProgramID= @id";                   
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblStudyProgram (NameOfStudyProgram, Duration) values (@NameOfStudyProgram, @Duration);";
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
