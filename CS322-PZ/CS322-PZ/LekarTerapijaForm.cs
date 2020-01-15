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
    public partial class LekarTerapijaForm : Form
    {

        MySqlConnection mycon;
        string connectionString = "datasource=localhost;port=3306;username=root;password='';database=cs322_pz"; //Set your MySQL connection string here.
        int bolest_id = 0;
        int lek_id = 0;
        int lek_id2 = 0;


        public LekarTerapijaForm()
        {
            InitializeComponent();
            mycon = new MySqlConnection(connectionString);
            this.unesi_dijagnozu.Visible = false;
        }

        private void LekarTerapijaForm_Load(object sender, EventArgs e)
        {
            mycon.Open();
           //  string query = "SELECT boluje_od.BOLUJE_OD_ID, boluje_od.PACIJENT_ID, boluje_od.BOLEST_ID, bolesti.NAZIV FROM boluje_od JOIN bolesti ON boluje_od.BOLEST_ID = bolesti.BOLEST_ID WHERE boluje_od.PACIJENT_ID = '" + Parametri.pacijent_id + "'";
            string query = "SELECT terapija.TERAPIJA_ID, pacijenti.PACIJENT_ID, bolesti.BOLEST_ID, bolesti.NAZIV, terapija.DATUM FROM terapija JOIN bolesti ON terapija.BOLEST_ID = bolesti.BOLEST_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.DATUM LIKE '" + Parametri.datum + "' GROUP BY terapija.BOLEST_ID";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
          //   this.dataGridView1.Columns["BOLUJE_OD_ID"].Visible = false;
            this.dataGridView1.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["BOLEST_ID"].Visible = false;




            string query3 = "SELECT * FROM bolesti" ;
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query3, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView3.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView3.Columns["BOLEST_ID"].Visible = false;



            string query4 = "SELECT * FROM lekovi";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query4, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView4.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView4.Columns["LEK_ID"].Visible = false;



            mycon.Close();

        }

        private void Nazad_Click(object sender, EventArgs e)
        {
            LekarForm lekarForm = new LekarForm();

            lekarForm.FormClosed += (s, args) => this.Close();
            this.Hide();
            lekarForm.Show();
        }

       

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.FormClosed += (s, args) => this.Close();
            this.Hide();
            form1.Show();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                bolest_id = Convert.ToInt32(row.Cells["BOLEST_ID"].Value.ToString());
                // Parametri.pacijent_id = Convert.ToInt32(row.Cells["PACIJENT_ID"].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                // naziv_bolesti.Text = row.Cells["NAZIV"].Value.ToString();
            }

            mycon.Open();
           //  string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE,terapija.DATUM FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN boluje_od ON boluje_od.PACIJENT_ID = terapija.PACIJENT_ID AND boluje_od.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "'AND  terapija.DATUM = '" + Parametri.datum +"'"; //GROUP BY terapija.DATUM";
            //string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID JOIN bolesti ON  terapija.BOLEST_ID = bolesti.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "' GROUP BY terapija.DATUM";
            string query2 = "SELECT terapija.TERAPIJA_ID, terapija.LEK_ID, lekovi.NAZIV, lekovi.DOZA, TRAJANJE,terapija.DATUM FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON pacijenti.PACIJENT_ID = terapija.PACIJENT_ID JOIN bolesti ON bolesti.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "' AND terapija.DATUM LIKE '" + Parametri.datum + "'"; //2020 -01-05";
            //  using (mysqlconnection conn = new mysqlconnection(connectionstring))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView2.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView2.Columns["LEK_ID"].Visible = false;
            mycon.Close();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                lek_id2 = Convert.ToInt32(row.Cells["LEK_ID"].Value.ToString());
                
            }
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                bolest_id = Convert.ToInt32(row.Cells["BOLEST_ID"].Value.ToString());
                // Parametri.pacijent_id = Convert.ToInt32(row.Cells["PACIJENT_ID"].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                // naziv_bolesti.Text = row.Cells["NAZIV"].Value.ToString();
            }

             

        }


        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];
                lek_id = Convert.ToInt32(row.Cells["LEK_ID"].Value.ToString());
                // Parametri.pacijent_id = Convert.ToInt32(row.Cells["PACIJENT_ID"].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                // naziv_bolesti.Text = row.Cells["NAZIV"].Value.ToString();
            }

        }


        private void unesi_dijagnozu_Click(object sender, EventArgs e)
        {

            mycon.Open();

            string query = "INSERT INTO boluje_od(PACIJENT_ID, BOLEST_ID) " +
                                "VALUES(@PACIJENT_ID, @BOLEST_ID)";

            MySqlCommand cmd = new MySqlCommand(query, mycon);
            cmd.Parameters.AddWithValue("@PACIJENT_ID", Parametri.pacijent_id);
            cmd.Parameters.AddWithValue("@BOLEST_ID", bolest_id);
           
            cmd.ExecuteNonQuery();

                string query2 = "SELECT boluje_od.BOLUJE_OD_ID, boluje_od.PACIJENT_ID, boluje_od.BOLEST_ID, bolesti.NAZIV FROM boluje_od JOIN bolesti ON boluje_od.BOLEST_ID = bolesti.BOLEST_ID WHERE boluje_od.PACIJENT_ID = '" + Parametri.pacijent_id + "'";
           // string query2 = "SELECT terapija.TERAPIJA_ID, pacijenti.PACIJENT_ID, bolesti.BOLEST_ID, bolesti.NAZIV FROM terapija JOIN bolesti ON terapija.BOLEST_ID = bolesti.BOLEST_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' GROUP BY terapija.BOLEST_ID";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            // this.dataGridView1.Columns["BOLUJE_OD_ID"].Visible = false;
            this.dataGridView1.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["BOLEST_ID"].Visible = false;

            mycon.Close();

        }




        private void unesi_lek_Click(object sender, EventArgs e)
        {
            mycon.Open();

            int period = Convert.ToInt32(textBox1.Text);
            string query = "INSERT INTO terapija(PACIJENT_ID, BOLEST_ID, LEK_ID, TRAJANJE, DATUM) " +
                                "VALUES(@PACIJENT_ID, @BOLEST_ID, @LEK_ID, @TRAJANJE, @DATUM)";

            MySqlCommand cmd = new MySqlCommand(query, mycon);
            cmd.Parameters.AddWithValue("@PACIJENT_ID", Parametri.pacijent_id);
            cmd.Parameters.AddWithValue("@BOLEST_ID", bolest_id);
            cmd.Parameters.AddWithValue("@LEK_ID", lek_id);
            cmd.Parameters.AddWithValue("@TRAJANJE", period);
            cmd.Parameters.AddWithValue("@DATUM",Parametri.datum);
            // cmd.Parameters.AddWithValue("@DATUM", DateTime.Today.ToString("yyyy-MM-dd"));

            cmd.ExecuteNonQuery();


            //    string query3 = "SELECT boluje_od.BOLUJE_OD_ID, boluje_od.PACIJENT_ID, boluje_od.BOLEST_ID, bolesti.NAZIV FROM boluje_od JOIN bolesti ON boluje_od.BOLEST_ID = bolesti.BOLEST_ID WHERE boluje_od.PACIJENT_ID = '" + Parametri.pacijent_id + "'";
            string query3 = "SELECT terapija.TERAPIJA_ID, pacijenti.PACIJENT_ID, bolesti.BOLEST_ID, bolesti.NAZIV, terapija.DATUM FROM terapija JOIN bolesti ON terapija.BOLEST_ID = bolesti.BOLEST_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.DATUM LIKE '" + Parametri.datum + "' GROUP BY terapija.BOLEST_ID";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query3, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            //  this.dataGridView1.Columns["BOLUJE_OD_ID"].Visible = false;
            this.dataGridView1.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["BOLEST_ID"].Visible = false;



            // string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN boluje_od ON boluje_od.PACIJENT_ID = terapija.PACIJENT_ID AND boluje_od.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "'";
            //string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID JOIN bolesti ON  terapija.BOLEST_ID = bolesti.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "'";
            string query2 = "SELECT terapija.TERAPIJA_ID, terapija.LEK_ID, lekovi.NAZIV, lekovi.DOZA, TRAJANJE,terapija.DATUM FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON pacijenti.PACIJENT_ID = terapija.PACIJENT_ID JOIN bolesti ON bolesti.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "' AND terapija.DATUM LIKE '" + Parametri.datum + "'"; //2020 -01-05";
            //  using (mysqlconnection conn = new mysqlconnection(connectionstring))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView2.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView2.Columns["LEK_ID"].Visible = false;
            // this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            // this.dataGridView1.Columns["BOLEST_ID"].Visible = false;


            mycon.Close();
        }

        private void obrisi_dijagnozu_Click(object sender, EventArgs e)
        {
            mycon.Open();
            string query = "DELETE FROM terapija WHERE PACIJENT_ID = @PACIJENT_ID AND BOLEST_ID = @BOLEST_ID AND DATUM = @DATUM";

            MySqlCommand cmd = new MySqlCommand(query, mycon);

            cmd.Parameters.AddWithValue("@PACIJENT_ID", Parametri.pacijent_id);
            cmd.Parameters.AddWithValue("@BOLEST_ID", bolest_id);
            cmd.Parameters.AddWithValue("@DATUM", Parametri.datum);

            cmd.ExecuteNonQuery();


            //    string query3 = "SELECT boluje_od.BOLUJE_OD_ID, boluje_od.PACIJENT_ID, boluje_od.BOLEST_ID, bolesti.NAZIV FROM boluje_od JOIN bolesti ON boluje_od.BOLEST_ID = bolesti.BOLEST_ID WHERE boluje_od.PACIJENT_ID = '" + Parametri.pacijent_id + "'";
            string query3 = "SELECT terapija.TERAPIJA_ID, pacijenti.PACIJENT_ID, bolesti.BOLEST_ID, bolesti.NAZIV, terapija.DATUM FROM terapija JOIN bolesti ON terapija.BOLEST_ID = bolesti.BOLEST_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.DATUM LIKE '" + Parametri.datum + "' GROUP BY terapija.BOLEST_ID";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query3, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            //  this.dataGridView1.Columns["BOLUJE_OD_ID"].Visible = false;
            this.dataGridView1.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["BOLEST_ID"].Visible = false;



            // string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN boluje_od ON boluje_od.PACIJENT_ID = terapija.PACIJENT_ID AND boluje_od.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "'";
            //string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID JOIN bolesti ON  terapija.BOLEST_ID = bolesti.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "'";
            string query2 = "SELECT terapija.TERAPIJA_ID, terapija.LEK_ID, lekovi.NAZIV, lekovi.DOZA, TRAJANJE,terapija.DATUM FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON pacijenti.PACIJENT_ID = terapija.PACIJENT_ID JOIN bolesti ON bolesti.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "' AND terapija.DATUM LIKE '" + Parametri.datum + "'"; //2020 -01-05";
            //  using (mysqlconnection conn = new mysqlconnection(connectionstring))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView2.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView2.Columns["LEK_ID"].Visible = false;
            // this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            // this.dataGridView1.Columns["BOLEST_ID"].Visible = false;



            mycon.Close();
        }

        private void obrisi_lek_Click(object sender, EventArgs e)
        {
            mycon.Open();
            string query = "DELETE FROM terapija WHERE PACIJENT_ID = @PACIJENT_ID AND BOLEST_ID = @BOLEST_ID AND DATUM = @DATUM AND LEK_ID = @LEK_ID";

            MySqlCommand cmd = new MySqlCommand(query, mycon);

            cmd.Parameters.AddWithValue("@PACIJENT_ID", Parametri.pacijent_id);
            cmd.Parameters.AddWithValue("@BOLEST_ID", bolest_id);
            cmd.Parameters.AddWithValue("@DATUM", Parametri.datum);
            cmd.Parameters.AddWithValue("@LEK_ID", lek_id2);

            cmd.ExecuteNonQuery();

            // string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN boluje_od ON boluje_od.PACIJENT_ID = terapija.PACIJENT_ID AND boluje_od.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "'";
            //string query2 = "SELECT terapija.TERAPIJA_ID, lekovi.NAZIV, TRAJANJE FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON terapija.PACIJENT_ID = pacijenti.PACIJENT_ID JOIN bolesti ON  terapija.BOLEST_ID = bolesti.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "'";
            string query2 = "SELECT terapija.TERAPIJA_ID, terapija.LEK_ID, lekovi.NAZIV, lekovi.DOZA, TRAJANJE,terapija.DATUM FROM terapija JOIN lekovi ON terapija.LEK_ID = lekovi.LEK_ID JOIN pacijenti ON pacijenti.PACIJENT_ID = terapija.PACIJENT_ID JOIN bolesti ON bolesti.BOLEST_ID = terapija.BOLEST_ID WHERE terapija.PACIJENT_ID = '" + Parametri.pacijent_id + "' AND terapija.BOLEST_ID = '" + bolest_id + "' AND terapija.DATUM LIKE '" + Parametri.datum + "'"; //2020 -01-05";
            //  using (mysqlconnection conn = new mysqlconnection(connectionstring))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView2.Columns["TERAPIJA_ID"].Visible = false;
            this.dataGridView2.Columns["LEK_ID"].Visible = false;
            // this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            // this.dataGridView1.Columns["BOLEST_ID"].Visible = false;


            mycon.Close();
        }

       
    }
}
