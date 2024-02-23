using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for FrmIzdavac.xaml
    /// </summary>
    public partial class FrmIzdavac : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView? pomocniRed;

        public FrmIzdavac(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtNazivIzdavaca.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmIzdavac()
        {
            InitializeComponent();
            txtNazivIzdavaca.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand //omogucava nam da dodamo parametre i pozovemo metodu
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@nazivIzdavaca", System.Data.SqlDbType.NVarChar).Value = txtNazivIzdavaca.Text; //@ u navodnicima znaci da posmatra kao varijablu i biramo tip koji ce biti upisan u bazu

                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblIzdavac2 set NazivIzdavaca=@nazivIzdavaca where IzdavacID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblIzdavac2(NazivIzdavaca) values(@nazivIzdavaca)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close(); //this se odnosi na tog izdavaca i zatvara prozor
            }

            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally //sluzi za zatvaranje konekcije
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