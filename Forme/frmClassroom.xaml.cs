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
    /// Interaction logic for frmClassroom.xaml
    /// </summary>
    public partial class frmClassroom : Window

    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView pomocniRed;

        public frmClassroom(bool update, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtNumberOfClassroom.Focus();
            this.update = update;
            this.pomocniRed = pomocniRed;
        }
        public frmClassroom()
        {
            InitializeComponent();
            konekcija = kon.KreireajKonekciju();
            txtNumberOfClassroom.Focus();
           
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
                cmd.Parameters.Add("@NumberOfClassroom", SqlDbType.NVarChar).Value = txtNumberOfClassroom.Text;
                if(this.update)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblClassroom
                                        Set NumberOfClassroom=@NumberOfClassroom Where ClassroomID= @id";

                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblClassroom (NumberOfClassroom) values (@NumberOfClassroom);";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Data entry is invalid ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
