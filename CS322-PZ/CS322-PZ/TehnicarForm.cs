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


    public partial class TehnicarForm : Form
    {

        MySqlConnection mycon;
        //  DBConnection db;
        int radnik_id = 0;
        int pacijent_id = 0;
        string query7;

        string connectionString = "datasource=localhost;port=3306;username=root;password='';database=cs322_pz"; //Set your MySQL connection string here.

        public TehnicarForm()
        {
            InitializeComponent();
            mycon = new MySqlConnection(connectionString);
        }

        private void TehnicarForm_Load(object sender, EventArgs e)
        {
            string query = "SELECT izabrani_lekar.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, izabrani_lekar.RADNIK_ID, radnici.IME AS LEKAR_IME, radnici.PREZIME AS LEKAR_PREZIME FROM izabrani_lekar, pacijenti, radnici WHERE izabrani_lekar.PACIJENT_ID = pacijenti.PACIJENT_ID AND izabrani_lekar.RADNIK_ID = radnici.RADNIK_ID"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["RADNIK_ID"].Visible = false;



            string query2 = "SELECT RADNIK_ID, IME, PREZIME FROM radnici WHERE ULOGA_ID = (SELECT ULOGA_ID FROM uloge WHERE ULOGA LIKE 'lekar')"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView2.Columns["RADNIK_ID"].Visible = false;
            // this.dataGridView2.Columns["ULOGA_ID"].Visible = false


            //if (checkBox1.Checked)
            //{
            //    query7 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.RADNIK_ID = '" + radnik_id + "'  AND pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID = pacijenti.PACIJENT_ID";
            //}
            //else
            //{
            //    query7 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID";
            //}
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.FormClosed += (s, args) => this.Close();
            this.Hide();
            form1.Show();
        }




        private void unesi_Click(object sender, EventArgs e)
        {
            mycon.Open();

            string ime = textBox2.Text;
            string prezime = textBox3.Text;
            string query = "INSERT INTO pacijenti( IME, PREZIME) " +
                               "VALUES( @IME, @PREZIME)";

            MySqlCommand cmd = new MySqlCommand(query, mycon);
           
            cmd.Parameters.AddWithValue("@IME", ime);
            cmd.Parameters.AddWithValue("@PREZIME", prezime);
            

            cmd.ExecuteNonQuery();


            
            string query2 = "SELECT *  FROM pacijenti WHERE IME=@IME AND PREZIME=@PREZIME";
            MySqlCommand cmd2 = new MySqlCommand(query2, mycon);
            cmd2.Parameters.AddWithValue("@IME", textBox2.Text);
            cmd2.Parameters.AddWithValue("@PREZIME", textBox3.Text);
        

            //int pacijent_id = 0;
            //pacijent_id = Convert.ToInt32(cmd2.ExecuteScalar());
           
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            
            Pacijent p = new Pacijent();
            while (dataReader2.Read())
            {

                //  Radnik radnik = new Radnik();
                p.Id = Convert.ToInt32(dataReader2["PACIJENT_ID"].ToString());
                p.Ime = dataReader2["IME"].ToString();
                p.Prezime = dataReader2["PREZIME"].ToString();
                

            }

            dataReader2.Close();

            pacijent_id = p.Id;

            if (pacijent_id != 0 && radnik_id != 0)
            {


                string query3 = "INSERT INTO izabrani_lekar(RADNIK_ID, PACIJENT_ID) " +
                             "VALUES(@RADNIK_ID, @PACIJENT_ID )";

                MySqlCommand cmd3 = new MySqlCommand(query3, mycon);
                cmd3.Parameters.AddWithValue("@RADNIK_ID", radnik_id);
                cmd3.Parameters.AddWithValue("@PACIJENT_ID", pacijent_id);


                cmd3.ExecuteNonQuery();
                // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                //  MySqlCommand cmd = new MySqlCommand(query, mycon);


                //  MessageBox.Show("Radnik uspesno registrovan");



                string query4 = "INSERT INTO pregledi(RADNIK_ID, PACIJENT_ID, DATUM, VREME) " +
                             "VALUES(@RADNIK_ID, @PACIJENT_ID, @DATUM, @VREME )";

                MySqlCommand cmd4 = new MySqlCommand(query4, mycon);
                cmd4.Parameters.AddWithValue("@RADNIK_ID", radnik_id);
                cmd4.Parameters.AddWithValue("@PACIJENT_ID", pacijent_id);
                cmd4.Parameters.AddWithValue("@DATUM", DateTime.Today.ToString("yyyy-MM-dd"));
                cmd4.Parameters.AddWithValue("@VREME", DateTime.Now.ToString("HH:mm:ss"));



                cmd4.ExecuteNonQuery();
                // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                //  MySqlCommand cmd = new MySqlCommand(query, mycon);


                //  MessageBox.Show("Radnik uspesno registrovan");


                string query5 = "SELECT izabrani_lekar.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, izabrani_lekar.RADNIK_ID, radnici.IME AS LEKAR_IME, radnici.PREZIME AS LEKAR_PREZIME FROM izabrani_lekar, pacijenti, radnici WHERE izabrani_lekar.PACIJENT_ID = pacijenti.PACIJENT_ID AND izabrani_lekar.RADNIK_ID = radnici.RADNIK_ID"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query5, connectionString))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
                this.dataGridView1.Columns["RADNIK_ID"].Visible = false;

                mycon.Close();
                prikazi_danasnje_preglede();
            }


            mycon.Close();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                radnik_id = Convert.ToInt32(row.Cells["RADNIK_ID"].Value.ToString());
                pacijent_id = Convert.ToInt32(row.Cells["PACIJENT_ID"].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                // naziv_bolesti.Text = row.Cells["NAZIV"].Value.ToString();

                prikazi_danasnje_preglede();

            }

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                radnik_id = Convert.ToInt32(row.Cells[0].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                // naziv_bolesti.Text = row.Cells["NAZIV"].Value.ToString();

                prikazi_danasnje_preglede();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mycon.Open();
            string query4 = "INSERT INTO pregledi(RADNIK_ID, PACIJENT_ID, DATUM, VREME) " +
                            "VALUES(@RADNIK_ID, @PACIJENT_ID, @DATUM, @VREME )";

            MySqlCommand cmd4 = new MySqlCommand(query4, mycon);
            cmd4.Parameters.AddWithValue("@RADNIK_ID", radnik_id);
            cmd4.Parameters.AddWithValue("@PACIJENT_ID", pacijent_id);
            cmd4.Parameters.AddWithValue("@DATUM", DateTime.Today.ToString("yyyy-MM-dd"));
            cmd4.Parameters.AddWithValue("@VREME", DateTime.Now.ToString("HH:mm:ss"));



            cmd4.ExecuteNonQuery();
            mycon.Close();

            MessageBox.Show("Pregled dodat");
            prikazi_danasnje_preglede();
        }




        private void search_Click(object sender, EventArgs e)
        {
            string parametar = textBox1.Text.ToString();



            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                mycon.Open();
                string query5 = "SELECT izabrani_lekar.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, izabrani_lekar.RADNIK_ID, radnici.IME AS LEKAR_IME, radnici.PREZIME AS LEKAR_PREZIME " +
                                "FROM izabrani_lekar JOIN pacijenti ON izabrani_lekar.PACIJENT_ID = pacijenti.PACIJENT_ID JOIN radnici ON izabrani_lekar.RADNIK_ID = radnici.RADNIK_ID " +
                                "WHERE pacijenti.IME LIKE '%" + parametar + "%' OR  pacijenti.PREZIME LIKE '%" + parametar + "%'";
                //  using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query5, connectionString))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
                this.dataGridView1.Columns["RADNIK_ID"].Visible = false;

                mycon.Close();
            }
            else {
                mycon.Open();
                string query5 = "SELECT izabrani_lekar.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, izabrani_lekar.RADNIK_ID, radnici.IME AS LEKAR_IME, radnici.PREZIME AS LEKAR_PREZIME FROM izabrani_lekar, pacijenti, radnici WHERE izabrani_lekar.PACIJENT_ID = pacijenti.PACIJENT_ID AND izabrani_lekar.RADNIK_ID = radnici.RADNIK_ID"; // set query to fetch data "Select* from  tabelname"
                //  using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query5, connectionString))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
                this.dataGridView1.Columns["RADNIK_ID"].Visible = false;

                mycon.Close();

            }
        }

        private void svi_pacijenti_Click(object sender, EventArgs e)
        {
            mycon.Open();
            string query5 = "SELECT izabrani_lekar.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, izabrani_lekar.RADNIK_ID, radnici.IME AS LEKAR_IME, radnici.PREZIME AS LEKAR_PREZIME FROM izabrani_lekar, pacijenti, radnici WHERE izabrani_lekar.PACIJENT_ID = pacijenti.PACIJENT_ID AND izabrani_lekar.RADNIK_ID = radnici.RADNIK_ID"; // set query to fetch data "Select* from  tabelname"
                                                                                                                                                                                                                                                                                                                                           //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query5, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["RADNIK_ID"].Visible = false;

            mycon.Close();
        }


        public void prikazi_danasnje_preglede() {


            mycon.Open();

            if (checkBox1.Checked)
            {
                query7 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.RADNIK_ID = '" + radnik_id + "'  AND pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID = pacijenti.PACIJENT_ID";
            }
            else
            {
                query7 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID";
            }
            //     string query7 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.RADNIK_ID = '" + radnik_id + "'  AND pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID";
            //    string query7 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query7, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView3.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView3.Columns["PREGLED_ID"].Visible = false;
            this.dataGridView3.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView3.Columns["RADNIK_ID"].Visible = false;

            mycon.Close();

        }

       
    }
}
