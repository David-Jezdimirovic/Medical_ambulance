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
   

    public partial class LekarForm : Form
    {
        int lekar_id;
        string connectionString = "datasource=localhost;port=3306;username=root;password='';database=cs322_pz"; //Set your MySQL connection string here.
        MySqlConnection mycon;

        public LekarForm()
        {
            InitializeComponent();
            mycon = new MySqlConnection(connectionString);
        }

        private void LekarForm_Load(object sender, EventArgs e)
        {
            lekar_id = Parametri.lekar_id;

            mycon.Open();
            string query = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.RADNIK_ID = '" + lekar_id + "'  AND pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID"; 
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView1.Columns["PREGLED_ID"].Visible = false;
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["RADNIK_ID"].Visible = false;

            mycon.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //    string date = row.Cells["DATUM"].Value.ToString();
            //    //Parametri.datum = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            //    Parametri.datum = DateTime.Parse(row.Cells["DATUM"].Value.ToString()).ToString("yyyy-MM-dd");
               
            //    MessageBox.Show(Parametri.datum+"");
            //}
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
               Parametri.lekar_id = Convert.ToInt32(row.Cells["RADNIK_ID"].Value.ToString());
                Parametri.pacijent_id = Convert.ToInt32(row.Cells["PACIJENT_ID"].Value.ToString());
                string date = row.Cells["DATUM"].Value.ToString();
                //Parametri.datum =  DateTime.ParseExact(date, "yyyy-MM-dd", null);
                Parametri.datum = DateTime.Parse(row.Cells["DATUM"].Value.ToString()).ToString("yyyy-MM-dd");  //***************************************
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                // naziv_bolesti.Text = row.Cells["NAZIV"].Value.ToString();
                LekarTerapijaForm lekarTerapijaForm= new LekarTerapijaForm();

                lekarTerapijaForm.FormClosed += (s, args) => this.Close();
                this.Hide();
                lekarTerapijaForm.Show();

            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.FormClosed += (s, args) => this.Close();
            this.Hide();
            form1.Show();
        }

        private void danasnji_pregledi_Click(object sender, EventArgs e)
        {
            mycon.Open();
            string query = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.RADNIK_ID = '" + lekar_id + "'  AND pregledi.DATUM = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView1.Columns["PREGLED_ID"].Visible = false;
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["RADNIK_ID"].Visible = false;

            mycon.Close();
        }

        private void svi_pregledi_Click(object sender, EventArgs e)
        {
            mycon.Open();                                                                                  //*************************************
            string query = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATE_FORMAT(DATUM,'%d.%m.%Y.') AS DATUM, VREME FROM pregledi, pacijenti WHERE pregledi.RADNIK_ID = '" + lekar_id + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID";
            //  using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                  
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            this.dataGridView1.Columns["PREGLED_ID"].Visible = false;
            this.dataGridView1.Columns["PACIJENT_ID"].Visible = false;
            this.dataGridView1.Columns["RADNIK_ID"].Visible = false;

            mycon.Close();
        }



        private void search_Click(object sender, EventArgs e)
        {
            string parametar = textBox1.Text.ToString();



            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                mycon.Open();
                string query5 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATE_FORMAT(DATUM,'%d.%m.%Y.') AS DATUM, VREME FROM pregledi JOIN pacijenti ON pregledi.PACIJENT_ID = pacijenti.PACIJENT_ID WHERE pregledi.RADNIK_ID = '" + lekar_id + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID AND pacijenti.IME LIKE '%" + parametar + "%' OR  pacijenti.PREZIME LIKE '%" + parametar + "%'";
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            mycon.Open();
            string query5 = "SELECT PREGLED_ID, RADNIK_ID, pregledi.PACIJENT_ID, pacijenti.IME, pacijenti.PREZIME, DATUM, VREME FROM pregledi JOIN pacijenti ON pregledi.PACIJENT_ID = pacijenti.PACIJENT_ID WHERE pregledi.RADNIK_ID = '" + lekar_id + "' AND pregledi.PACIJENT_ID =  pacijenti.PACIJENT_ID AND pregledi.DATUM LIKE '" + theDate + "'";
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
}
