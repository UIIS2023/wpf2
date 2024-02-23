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
    /// Interaction logic for FrmNabavka.xaml
    /// </summary>
    public partial class FrmNabavka : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmNabavka(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }
        public FrmNabavka()
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

                string vratiKorisnike = @"select KorisnikID, ImeKorisnika from tblKorisnik2";
                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnike, konekcija);

                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                daKorisnik.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuće liste nisu popunjene.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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

                DateTime date = (DateTime)dpDatumNabavke.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija 
                };
                cmd.Parameters.Add("@datumNabavke", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@cenaNabavke", SqlDbType.Money).Value = txtCenaNabavke.Text;
                cmd.Parameters.Add("@korisnikId", SqlDbType.Int).Value = cbKorisnik.SelectedValue;

                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    if (red != null) 
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                        cmd.CommandText = @"update tblNabavka2
                                        set DatumNabavke=@datumNabavke, CenaNabavke=@cenaNabavke, KorisnikID=@korisnikId
                                        where NabavkaID=@id";
                    }
                    else
                    {
                        // Obrada situacije gdje je pomocniRed null
                        MessageBox.Show("Greška: Pokušaj ažuriranja nepostojećeg reda.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                  //  pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblNabavka2 (DatumNabavke, CenaNabavke, KorisnikID)
                                        values(@datumNabavke, @cenaNabavke, @korisnikId)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greška prilikom konverzije podataka!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija.Close();
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}