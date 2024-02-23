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
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik2 : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKorisnik2(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        
        public FrmKorisnik2()
        {
            InitializeComponent(); 
            txtImeKorisnika.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@imeKorisnika", SqlDbType.NVarChar).Value = txtImeKorisnika.Text;
                cmd.Parameters.Add("@prezimeKorisnika", SqlDbType.NVarChar).Value = txtPrezimeKorisnika.Text;
                cmd.Parameters.Add("@adresaKorisnika", SqlDbType.NVarChar).Value = txtAdresaKorisnika.Text;
                cmd.Parameters.Add("@gradKorisnika", SqlDbType.NVarChar).Value = txtGradKorisnika.Text;
                cmd.Parameters.Add("@kontaktKorisnika", SqlDbType.NVarChar).Value = txtKontaktKorisnika.Text;

                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKorisnik2
                                            set ImeKorisnika=@imeKorisnika, PrezimeKorisnika=@prezimeKorisnika, AdresaKorisnika=@adresaKorisnika, 
                                            GradKorisnika=@gradKorisnika, KontaktKorisnika=@kontaktKorisnika
                                            where KorisnikID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKorisnik2 (ImeKorisnika, PrezimeKorisnika, AdresaKorisnika, GradKorisnika, KontaktKorisnika)
                                    values(@imeKorisnika, @prezimeKorisnika, @adresaKorisnika, @gradKorisnika, @kontaktKorisnika)";

                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
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