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
    /// Interaction logic for frmSubject.xaml
    /// </summary>
    public partial class frmSubject : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;
        public frmSubject(bool update, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtNameOfSubject.Focus();
            this.update = update;
            this.pomocniRed = pomocniRed;
        }
        public frmSubject()
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtNameOfSubject.Focus();
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
                cmd.Parameters.Add("@NameOfSubject", SqlDbType.NVarChar).Value = txtNameOfSubject.Text;
                cmd.Parameters.Add("@Professor", SqlDbType.NVarChar).Value = txtProfessor.Text;
                cmd.Parameters.Add("@ESPB", SqlDbType.Int).Value = txtESPB.Text;
                if (this.update)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblSubject
                                        Set NameOfSubject=@NameOfSubject, Professor=@Professor, ESPB=@ESPB Where SubjectID= @id";

                    this.pomocniRed = null;
                }
               else
                {
                    cmd.CommandText = @"insert into tblSubject (NameOfSubject, Professor, ESPB) values (@NameOfSubject, @Professor, @ESPB);";
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
