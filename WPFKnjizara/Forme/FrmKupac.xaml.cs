using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Knjizara.Forme
{
    /// <summary>
    /// Interaction logic for FrmKorisnik2.xaml
    /// </summary>
    public partial class FrmKupac : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKupac(bool azuriraj, DataRowView pomocniRed)

        {
            InitializeComponent();
            txtImeKupca.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKupac()
        {
            InitializeComponent();
            txtImeKupca.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //novi kod
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@imeKupca", SqlDbType.NVarChar).Value = (object)txtImeKupca.Text ?? DBNull.Value;
                cmd.Parameters.Add("@prezimeKupca", SqlDbType.NVarChar).Value = (object)txtPrezimeKupca.Text ?? DBNull.Value;
                cmd.Parameters.Add("@adresaKupca", SqlDbType.NVarChar).Value = (object)txtAdresaKupca.Text ?? DBNull.Value;
                cmd.Parameters.Add("@gradKupca", SqlDbType.NVarChar).Value = (object)txtGradKupca.Text ?? DBNull.Value;
                cmd.Parameters.Add("@kontaktKupca", SqlDbType.NVarChar).Value = (object)txtKontaktKupca.Text ?? DBNull.Value;


                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    if (red != null)
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                        cmd.CommandText = @"update tblKupac2
                                set ImeKupca=@imeKupca, PrezimeKupca=@prezimeKupca, AdresaKupca=@adresaKupca, GradKupca=@gradKupca, KontaktKupca=@kontaktKupca
                                where KupacID=@id";
                    }
                    else
                    {
                        // Obrada situacije gdje je pomocniRed null
                        MessageBox.Show("Greška: Pokušaj ažuriranja nepostojećeg reda.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    cmd.CommandText = @"insert into tblKupac2(ImeKupca, PrezimeKupca, AdresaKupca, GradKupca, KontaktKupca)
                            values(@imeKupca, @prezimeKupca, @adresaKupca, @gradKupca, @kontaktKupca)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Greška u bazi podataka: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null )
                {
                    konekcija.Close();
                }
            }

        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}









