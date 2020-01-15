using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS322_PZ
{
    public partial class Form1 : Form
    {
        MySqlConnection mycon;
        string connectionString = "datasource=localhost;port=3306;username=root;password='';database=cs322_pz";

        public Form1()
        {
            InitializeComponent();
            mycon = new MySqlConnection(connectionString);
           
        }

        private void login_Click(object sender, EventArgs e)
        {

            string query = "SELECT RADNIK_ID, IME, PREZIME, KORISNICKO_IME, SIFRA,ULOGA FROM radnici, uloge WHERE KORISNICKO_IME=@KORISNCKO_IME AND SIFRA=@SIFRA AND radnici.ULOGA_ID = uloge.ULOGA_ID";
            MySqlCommand cmd = new MySqlCommand(query, mycon);
            cmd.Parameters.AddWithValue("@KORISNCKO_IME", textBox1.Text);
            cmd.Parameters.AddWithValue("@SIFRA", textBox2.Text);
            mycon.Open();
           
           
            MySqlDataReader dataReader = cmd.ExecuteReader();
            Radnik radnik = new CS322_PZ.Radnik();
            while (dataReader.Read())
            {

              //  Radnik radnik = new Radnik();
                radnik.Id = Convert.ToInt32(dataReader["RADNIK_ID"].ToString());
                radnik.Ime = dataReader["IME"].ToString();
                radnik.Prezime = dataReader["PREZIME"].ToString();
                radnik.Username = dataReader["KORISNICKO_IME"].ToString();
                radnik.Sifra = dataReader["SIFRA"].ToString();
                radnik.Uloga_naziv = dataReader["ULOGA"].ToString();

            }
            dataReader.Close();

            Parametri.lekar_id = radnik.Id;

            if (radnik.Id != 0) {

                if (radnik.Uloga_naziv.Equals("admin"))
                {
                    AdminRegisterForm adminRegisterFora = new AdminRegisterForm();

                    adminRegisterFora.FormClosed += (s, args) => this.Close();
                    this.Hide();
                    adminRegisterFora.Show();
                }
                else if (radnik.Uloga_naziv.Equals("tehnicar"))
                {
                    TehnicarForm tehnicarForm = new TehnicarForm();

                    tehnicarForm.FormClosed += (s, args) => this.Close();
                    this.Hide();
                    tehnicarForm.Show();
                }
                else if (radnik.Uloga_naziv.Equals("lekar"))
                {
                    LekarForm lekarForm = new LekarForm();

                    lekarForm.FormClosed += (s, args) => this.Close();
                    this.Hide();
                    lekarForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Korisnicki podaci nisu validni!");
            }




            mycon.Close();


           
        }
    }
}
