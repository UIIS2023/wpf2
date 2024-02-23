using Knjizara.Forme;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
//using WPFKnjizara.Forme; 

namespace Knjizara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Konekcija kon = new Konekcija(); //za sada ovaj objekat referencira na null jer je u sklopu metode
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;       
        string ucitanaTabela;



        #region Select upiti
        static string zanrSelect = @"select ZanrID as ID, NazivZanra as Zanr from tblZanr2";
        static string pisacSelect = @"select PisacID as ID, ImePisca as 'Ime pisca', PrezimePisca as 'Prezime pisca' from tblPisac2";
        static string izdavacSelect = @"select IzdavacID as ID, NazivIzdavaca as Izdavac from tblIzdavac2";
        static string korisnikSelect = @"select KorisnikID as ID, ImeKorisnika as 'Ime korisnika', PrezimeKorisnika as 'Prezime korisnika',
                                        AdresaKorisnika as 'Adresa korisnika', GradKorisnika as 'Grad korisnika', KontaktKorisnika as 'Kontakt korisnika' from tblKorisnik2";
        static string kupacSelect = @"select KupacID as ID, ImeKupca as 'Ime kupca', PrezimeKupca as 'Prezime kupca',
                                        AdresaKupca as 'Adresa kupca', GradKupca as 'Grad kupca', KontaktKupca as 'Kontakt kupca', ClanskaKarta as 'Clanska karta' from tblKupac2";
        static string racunSelect = @"select RacunID as ID, ImeKorisnika as 'Ime korisnika', ImeKupca as 'Ime kupca', DatumProdaje as 'Datum prodaje', CenaProdaje as 'Cena prodaje'
                                        from tblRacun2 join tblKorisnik2 on tblRacun2.KorisnikID = tblKorisnik2.KorisnikID
                                                      join tblKupac2 on tblRacun2.KupacID = tblKupac2.KupacID";
        static string nabavkaSelect = @"select NabavkaID as ID, DatumNabavke as 'Datum nabavke', CenaNabavke as 'Cena nabavke', ImeKorisnika as 'Ime korisnika'
                                        from tblNabavka2 join tblKorisnik2 on tblNabavka2.KorisnikID = tblKorisnik2.KorisnikID";
        static string knjigaSelect = @"select KnjigaID as ID, Naslov, ImePisca as 'Ime pisca', NazivZanra as 'Zanr', NazivIzdavaca as Izdavac,
                                      CenaProdaje as 'Cena prodaje', CenaNabavke as 'Cena nabavke'
                                        from tblKnjiga2 join tblPisac2 on tblKnjiga2.PisacID = tblPisac2.PisacID
                                                       join tblZanr2 on tblKnjiga2.ZanrID = tblZanr2.ZanrID
                                                       join tblIzdavac2 on tblKnjiga2.IzdavacID = tblIzdavac2.IzdavacID
                                                       join tblRacun2 on tblKnjiga2.RacunID = tblRacun2.RacunID
                                                       join tblNabavka2 on tblKnjiga2.NabavkaID = tblNabavka2.NabavkaID";
        #endregion 
          
        #region Select sa uslovom
        string selectUslovZanr = @"select * from tblZanr2 where ZanrID=";
        string selectUslovIzdavac = @"select * from tblIzdavac2 where IzdavacID=";
        string selectUslovPisac = @"select * from tblPisac2 where PisacID=";
        string selectUslovKorisnik = @"select * from tblKorisnik2 where KorisnikID=";
        string selectUslovKupac = @"select * from tblKupac2 where KupacID="; 
        string selectUslovNabavka = @"select * from tblNabavka2 where NabavkaID=";
        string selectUslovRacun = @"select * from tblRacun2 where RacunID=";
        string selectUslovKnjiga = @"select * from tblKnjiga2 where KnjigaID=";
        #endregion

        #region Select delete
        string zanrDelete = @"delete from tblZanr2 where ZanrID=";
        string izdavacDelete = @"delete from tblIzdavac2 where IzdavacID=";
        string pisacDelete = @"delete from tblPisac2 where PisacID=";
        string korisnikDelete = @"delete from tblKorisnik2 where KorisnikID=";
        string kupacDelete = @"delete from tblKupac2 where KupacID=";
        string nabavkaDelete = @"delete from tblNabavka2 where NabavkaID=";
        string racunDelete = @"delete from tblRacun2 where RacunID=";
        string knjigaDelete = @"delete from tblKnjiga2 where KnjigaID=";
        #endregion
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            UcitajPodatke(dataGridCentralni, knjigaSelect);
            konekcija = kon.KreirajKonekciju(); //ovako smo pristupili bazi
            
        } 

        private void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open(); //konekcija sa bazom

                SqlDataAdapter dateAdapter = new SqlDataAdapter(selectUpit, konekcija);   //pomocu njega dobijemo podatke iz baze
                DataTable dt = new DataTable()
                {
                    Locale = CultureInfo.InvariantCulture
                };

                dateAdapter.Fill(dt);

                if (grid != null)  //ako grid postoji
                {
                    grid.ItemsSource = dt.DefaultView; //prikazuje tabelu po redovima i kolonama
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dateAdapter.Dispose();  //oslobadja zauzete resurse 
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno ucitani podaci", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close(); //konekcija se zatvara ako se ne zatvori nece moci da joj se pristupi
                }

            }
        }

        private void btnKnjiga_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, knjigaSelect);
        }

        private void btnZanr_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, zanrSelect);
        }

        private void btnPisac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, pisacSelect);
        }

        private void btnIzdavac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, izdavacSelect);
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        { 
            UcitajPodatke(dataGridCentralni, korisnikSelect);
        }

        private void btnKupac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, kupacSelect);
        }

        private void btnNabavka_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, nabavkaSelect);
        }

        private void btnRacun_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, racunSelect);
        }


          
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(knjigaSelect))
            {
                prozor = new FrmKnjiga();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, knjigaSelect); //refresh
            }
            else if (ucitanaTabela.Equals(zanrSelect))
            {
                prozor = new FrmZanr();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, zanrSelect);
            }
            else if (ucitanaTabela.Equals(izdavacSelect))
            {
                prozor = new FrmIzdavac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, izdavacSelect);
            }
            else if (ucitanaTabela.Equals(pisacSelect))
            {
                prozor = new FrmPisac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, pisacSelect);
            }  
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                prozor = new FrmKorisnik2();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                prozor = new FrmKupac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, kupacSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                prozor = new FrmNabavka();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                prozor = new FrmRacun();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, racunSelect);
            }  
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(zanrSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovZanr);
                UcitajPodatke(dataGridCentralni, zanrSelect);
            }
            else if (ucitanaTabela.Equals(izdavacSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovIzdavac);
                UcitajPodatke(dataGridCentralni, izdavacSelect);
            }
            else if (ucitanaTabela.Equals(pisacSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovPisac);
                UcitajPodatke(dataGridCentralni, pisacSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKorisnik);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKupac);
                UcitajPodatke(dataGridCentralni, kupacSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovNabavka);
                UcitajPodatke(dataGridCentralni, nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovRacun);
                UcitajPodatke(dataGridCentralni, racunSelect);
            }
            else if (ucitanaTabela.Equals(knjigaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKnjiga);
                UcitajPodatke(dataGridCentralni, knjigaSelect);
            }
        }

        private void PopuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0]; //kastovanje
                SqlCommand komanda = new SqlCommand
                {
                    Connection = konekcija
                };
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                komanda.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                komanda.CommandText = selectUslov + "@id";
                SqlDataReader citac = komanda.ExecuteReader();
                komanda.Dispose();

                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(korisnikSelect))
                    {
                        FrmKorisnik2 prozorKorisnik = new FrmKorisnik2(azuriraj, red);
                        prozorKorisnik.txtImeKorisnika.Text = citac["ImeKorisnika"].ToString();
                        prozorKorisnik.txtPrezimeKorisnika.Text = citac["PrezimeKorisnika"].ToString();
                        prozorKorisnik.txtAdresaKorisnika.Text = citac["AdresaKorisnika"].ToString();
                        prozorKorisnik.txtGradKorisnika.Text = citac["GradKorisnika"].ToString();
                        prozorKorisnik.txtKontaktKorisnika.Text = citac["KontaktKorisnika"].ToString();
                        prozorKorisnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kupacSelect))
                    {
                        FrmKupac prozorKupac = new FrmKupac(azuriraj, red);
                        prozorKupac.txtImeKupca.Text = citac["ImeKupca"].ToString();
                        prozorKupac.txtPrezimeKupca.Text = citac["PrezimeKupca"].ToString();
                        prozorKupac.txtAdresaKupca.Text = citac["AdresaKupca"].ToString();
                        prozorKupac.txtGradKupca.Text = citac["GradKupca"].ToString();
                        prozorKupac.txtKontaktKupca.Text = citac["KontaktKupca"].ToString();
                        
                        //novi
                        prozorKupac.cbxClanskaKarta.IsChecked = !Convert.IsDBNull(citac["ClanskaKarta"]) && (bool)citac["ClanskaKarta"];
                        //proverava da li je vrednost DBNull. Ako nije, onda se izvršava drugi deo izraza (bool)citac["ClanskaKarta"]
                        prozorKupac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(zanrSelect))
                    {
                        FrmZanr prozorZanr = new FrmZanr(azuriraj, red);
                        prozorZanr.txtNazivZanra.Text = citac["NazivZanra"].ToString();
                        prozorZanr.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(izdavacSelect))
                    {
                        FrmIzdavac prozorIzdavac = new FrmIzdavac(azuriraj, red);
                        prozorIzdavac.txtNazivIzdavaca.Text = citac["NazivIzdavaca"].ToString();
                        prozorIzdavac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(pisacSelect))
                    {
                        FrmPisac prozorPisac = new FrmPisac(azuriraj, red);
                        prozorPisac.txtImePisca.Text = citac["ImePisca"].ToString();
                        prozorPisac.txtPrezimePisca.Text = citac["PrezimePisca"].ToString();
                        prozorPisac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(nabavkaSelect))
                    {
                        FrmNabavka prozorNabavka = new FrmNabavka(azuriraj, red);
                        prozorNabavka.dpDatumNabavke.SelectedDate = (DateTime)citac["DatumNabavke"];
                        prozorNabavka.txtCenaNabavke.Text = citac["CenaNabavke"].ToString();
                        prozorNabavka.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorNabavka.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(racunSelect))
                    {
                        FrmRacun prozorRacun = new FrmRacun(azuriraj, red);
                        prozorRacun.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorRacun.cbKupac.SelectedValue = citac["KupacID"].ToString();
                        prozorRacun.dpDatumProdaje.SelectedDate = (DateTime)citac["DatumProdaje"];
                        prozorRacun.txtCenaProdaje.Text = citac["CenaProdaje"].ToString();
                        prozorRacun.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(knjigaSelect))
                    {
                        FrmKnjiga prozorKnjiga = new FrmKnjiga(azuriraj, red);
                        
                        prozorKnjiga.txtNaslov.Text = citac["Naslov"].ToString();
                        prozorKnjiga.cbPisac.SelectedValue = citac["PisacID"];
                        prozorKnjiga.cbZanr.SelectedValue = citac["ZanrID"];
                        prozorKnjiga.cbIzdavac.SelectedValue = citac["IzdavacID"];
                        prozorKnjiga.cbRacun.SelectedValue = citac["RacunID"];
                        prozorKnjiga.cbNabavka.SelectedValue = citac["NabavkaID"];
                        prozorKnjiga.ShowDialog();
                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(zanrSelect))
            {
                ObrisiZapis(zanrDelete);
                UcitajPodatke(dataGridCentralni, zanrSelect);
            }
            else if (ucitanaTabela.Equals(izdavacSelect))
            {
                ObrisiZapis(izdavacDelete);
                UcitajPodatke(dataGridCentralni, izdavacSelect);
            }
            else if (ucitanaTabela.Equals(pisacSelect))
            {
                ObrisiZapis(pisacDelete);
                UcitajPodatke(dataGridCentralni, pisacSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                ObrisiZapis(korisnikDelete);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                ObrisiZapis(kupacDelete);
                UcitajPodatke(dataGridCentralni, kupacSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                ObrisiZapis(nabavkaDelete);
                UcitajPodatke(dataGridCentralni, nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                ObrisiZapis(racunDelete);
                UcitajPodatke(dataGridCentralni, racunSelect);
            }
            else if (ucitanaTabela.Equals(knjigaSelect))
            {
                ObrisiZapis(knjigaDelete);
                UcitajPodatke(dataGridCentralni, knjigaSelect);
            }
        }

        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Obaveštenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}



