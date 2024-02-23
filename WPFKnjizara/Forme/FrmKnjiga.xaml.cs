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
    /// Interaction logic for FrmKnjiga.xaml
    /// </summary>
    public partial class FrmKnjiga : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKnjiga(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtNaslov.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }
        public FrmKnjiga()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju(); 
            txtNaslov.Focus();
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                string vratiPisce = @"Select PisacID, ImePisca + ' ' + PrezimePisca as Pisac from tblPisac2 ";
                SqlDataAdapter daPisac = new SqlDataAdapter(vratiPisce, konekcija);
                DataTable dtPisac = new DataTable();
                daPisac.Fill(dtPisac);
                cbPisac.ItemsSource = dtPisac.DefaultView;
                daPisac.Dispose();
                dtPisac.Dispose();

                string vratiZanr = @"Select ZanrID, NazivZanra from tblZanr2";
                SqlDataAdapter daZanr = new SqlDataAdapter(vratiZanr, konekcija);
                DataTable dtZanr = new DataTable();
                daZanr.Fill(dtZanr);
                cbZanr.ItemsSource = dtZanr.DefaultView;
                daZanr.Dispose();
                dtZanr.Dispose();

                string vratiIzdavace = @"Select IzdavacID, NazivIzdavaca from tblIzdavac2";
                SqlDataAdapter daIzdavac = new SqlDataAdapter(vratiIzdavace, konekcija);
                DataTable dtIzdavac = new DataTable();
                daIzdavac.Fill(dtIzdavac);
                cbIzdavac.ItemsSource = dtIzdavac.DefaultView;
                daIzdavac.Dispose();
                dtIzdavac.Dispose();

                string vratiRacune = @"Select RacunID, CenaProdaje from tblRacun2";
                SqlDataAdapter daRacun = new SqlDataAdapter(vratiRacune, konekcija);
                DataTable dtRacun = new DataTable();
                daRacun.Fill(dtRacun);
                cbRacun.ItemsSource = dtRacun.DefaultView;
                daRacun.Dispose();
                dtRacun.Dispose();

                string vratiNabavke = @"Select NabavkaID, CenaNabavke from tblNabavka2";
                SqlDataAdapter daNabavka = new SqlDataAdapter(vratiNabavke, konekcija);
                DataTable dtNabavka = new DataTable();
                daNabavka.Fill(dtNabavka);
                cbNabavka.ItemsSource = dtNabavka.DefaultView;
                daNabavka.Dispose();
                dtNabavka.Dispose();
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
           
            try//novi kod
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@naslov", SqlDbType.NVarChar).Value = txtNaslov.Text;
                cmd.Parameters.Add("@pisacID", SqlDbType.Int).Value = cbPisac.SelectedValue ?? DBNull.Value;//Operator ?? koristi se za proveru da li cbPisac.SelectedValue null.
                                                                                                            //Ako jeste, tada se koristi DBNull.Value kako bi se predstavila NULL
                                                                                                            //vrednost za SQL parametar. Ako nije null, tada se koristi stvarna
                                                                                                            //vrednost iz cbPisac.SelectedValue.
                cmd.Parameters.Add("@zanrID", SqlDbType.Int).Value = cbZanr.SelectedValue ?? DBNull.Value;
                cmd.Parameters.Add("@izdavacID", SqlDbType.Int).Value = cbIzdavac.SelectedValue ?? DBNull.Value;
                cmd.Parameters.Add("@racunID", SqlDbType.Int).Value = cbRacun.SelectedValue ?? DBNull.Value;
                cmd.Parameters.Add("@nabavkaID", SqlDbType.Int).Value = cbNabavka.SelectedValue ?? DBNull.Value;

                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    if (red != null)
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                        cmd.CommandText = @"update tblKnjiga2
                                set Naslov=@naslov, PisacID=@pisacID, ZanrID=@zanrID, IzdavacID=@izdavacID, RacunID=@racunID, NabavkaID=@nabavkaID
                                where KnjigaID=@id";
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
                    cmd.CommandText = @"insert into tblKnjiga2(Naslov, PisacID, ZanrID, IzdavacID, RacunID, NabavkaID)
                            values(@naslov, @pisacID, @zanrID, @izdavacID, @racunID, @nabavkaID)";
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
