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
    /// Interaction logic for FrmRacun.xaml
    /// </summary>
    public partial class FrmRacun : Window
    {


        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmRacun(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }
        public FrmRacun()
        {
            InitializeComponent();
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                string vratiKorisnike = @"Select KorisnikID, ImeKorisnika from tblKorisnik2";
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnike, konekcija);
                DataTable dtKorisnik = new DataTable();
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                daKorisnik.Dispose();
                dtKorisnik.Dispose();

                string vratiKupce = @"Select KupacID, ImeKupca from tblKupac2";
                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupce, konekcija);
                DataTable dtKupac = new DataTable();
                daKupac.Fill(dtKupac);
                cbKupac.ItemsSource = dtKupac.DefaultView;
                daKupac.Dispose();
                dtKupac.Dispose();

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

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                DateTime date = (DateTime)dpDatumProdaje.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@kupacID", SqlDbType.Int).Value = cbKupac.SelectedValue;
                cmd.Parameters.Add("@datumProdaje", SqlDbType.DateTime).Value = datum;

                decimal cenaProdaje;
                if (decimal.TryParse(txtCenaProdaje.Text, out cenaProdaje))
                {
                    cmd.Parameters.Add("@cenaProdaje", SqlDbType.Money).Value = cenaProdaje;
                }
                else
                {                  
                    MessageBox.Show("Unesite validan broj za cenu prodaje.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Prekida izvršavanje funkcije 
                }

                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblRacun2
                            set KorisnikID=@korisnikID, KupacID=@kupacID, DatumProdaje=@datumProdaje, CenaProdaje=@cenaProdaje
                            where RacunID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblRacun2(KorisnikID, KupacID, DatumProdaje, CenaProdaje)
                            values(@korisnikID, @kupacID, @datumProdaje, @cenaProdaje)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                // Tretman grešaka - prikaži poruku, zapiši u log, ili preduzmi druge korake
                MessageBox.Show("Došlo je do greške: " + ex.Message);
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