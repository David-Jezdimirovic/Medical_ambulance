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
    public partial class AdminRegisterForm : Form
    {
        MySqlConnection mycon;
        string con = "datasource=localhost;port=3306;username=root;password='';database=cs322_pz";
        int uloga_id = 0;
        int radnik_id = 0;
        //Uloga uloga2;

        DBConnection db;
        public AdminRegisterForm()
        {
            InitializeComponent();
            
        }

        private void AdminRegisterForm_Load(object sender, EventArgs e)
        {

            db = new DBConnection();
            db.OpenConnection();
            
            mycon = new MySqlConnection(con);
            mycon.Open();

         //   db = new DBConnection();
            List<Uloga> list = new List<Uloga>();
            List<Radnik> radnici = new List<Radnik>();

            //    ListViewItem lvi = new ListViewItem(new string[] {uloga2.Id,uloga2.Naziv });
            //   listView1.Items.Add(lvi);
            string query = "SELECT * FROM uloge";
            
             MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
        //    MySqlCommand cmd = new MySqlCommand(query, mycon);
           

            MySqlDataReader dataReader = cmd.ExecuteReader();
         //    cmd.ExecuteScalar();

            while (dataReader.Read())
            {
                
                Uloga uloga = new Uloga();
                uloga.Id = dataReader["ULOGA_ID"].ToString();
                uloga.Naziv = dataReader["ULOGA"].ToString();
               
                //  lvi.SubItems.Add(uloga.Id);
                // lvi.SubItems.Add(uloga.Naziv);
                listUloge.Items.Add(uloga);
                

                list.Add(uloga);
            }
              dataReader.Close();



            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            BindingSource bind = new BindingSource();
            bind.DataSource = dt;

            dataGridView1.DataSource = bind;
            //  dataGridView1.DataSource = list;
            this.dataGridView1.Columns["ULOGA_ID"].Visible = true;
            //  listView1.DataBindings = list;
            //   adapter.Update(dt);


            //RADI
            //string query2 = "SELECT RADNIK_ID, IME, PREZIME, KORISNICKO_IME, SIFRA, ULOGA FROM radnici, uloge WHERE radnici.ULOGA_ID = uloge.ULOGA_ID";
            //MySqlCommand cmd2 = new MySqlCommand(query2, mycon);
            //MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            //while (dataReader2.Read())
            //{

            //    Radnik radnik = new Radnik();
            //    radnik.Id = Convert.ToInt32(dataReader2["RADNIK_ID"].ToString());
            //    radnik.Ime = dataReader2["IME"].ToString();
            //    radnik.Prezime = dataReader2["PREZIME"].ToString();
            //    radnik.Username = dataReader2["KORISNICKO_IME"].ToString();
            //    radnik.Sifra = dataReader2["SIFRA"].ToString();
            //    radnik.Uloga_naziv = dataReader2["ULOGA"].ToString();

            //}
            //dataReader2.Close();




            //MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            //adapter2.SelectCommand = cmd2;

            //DataTable dt2 = new DataTable();
            //adapter2.Fill(dt2);

            //BindingSource bind2 = new BindingSource();
            //bind2.DataSource = dt2;

            //   dataGridView2.DataSource = bind2;




            //string connectionString = "datasource=localhost;port=3306;username=root;password='';database=cs322_pz"; //Set your MySQL connection string here.
            string query3 = "SELECT RADNIK_ID, IME, PREZIME, KORISNICKO_IME, SIFRA, uloge.ULOGA FROM radnici, uloge WHERE radnici.ULOGA_ID = uloge.ULOGA_ID"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                using (MySqlDataAdapter adapter3 = new MySqlDataAdapter(query3, conn))
                {
                    DataSet ds = new DataSet();
                    adapter3.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }




            mycon.Close();
            db.CloseConnection();


            //   listUloge.Items.Add(lvi);
            //   listUloge.Items.Add(list);
            // listUloge.D = "naziv";
            // listUloge.DataTextField = "naziv";

            listUloge.DisplayMember = "naziv";
//             listUloge.DisplayMember = "id";

             listUloge.ValueMember = "id";

            //    listUloge.DataSource = list;

   

        
        }


        // registracija
        private void button1_Click(object sender, EventArgs e)
        {
            string ime = textBox.Text;
            string prezime = textBox1.Text;
            string username = textBox2.Text;
            string sifra = textBox3.Text;

            if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) ||
                    string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(sifra) || uloga_id == 0 )
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
            if (checkIfUserExists())
            {
                MessageBox.Show("Korisnik sa tim korisnickim imenom vec postoji!");
            }

            try
            {

                if (!string.IsNullOrWhiteSpace(ime) && !string.IsNullOrWhiteSpace(prezime) &&
                    !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(sifra) && uloga_id != 0
                    && !checkIfUserExists())
                {
                    mycon = new MySqlConnection(con);
                    mycon.Open();

                    string query = "INSERT INTO radnici(ULOGA_ID, IME, PREZIME, KORISNICKO_IME, SIFRA) " +
                                 "VALUES(@ULOGA_ID, @IME, @PREZIME, @KORISNICKO_IME, @SIFRA)";

                    MySqlCommand cmd = new MySqlCommand(query, mycon);
                    cmd.Parameters.AddWithValue("@ULOGA_ID", uloga_id);
                    cmd.Parameters.AddWithValue("@IME", ime);
                    cmd.Parameters.AddWithValue("@PREZIME", prezime);
                    cmd.Parameters.AddWithValue("@KORISNICKO_IME", username);
                    cmd.Parameters.AddWithValue("@SIFRA", sifra);

                    cmd.ExecuteNonQuery();
                    // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    //  MySqlCommand cmd = new MySqlCommand(query, mycon);
                    mycon.Close();

                    MessageBox.Show("Radnik uspesno registrovan");
                   // adapter.Update(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string query3 = "SELECT RADNIK_ID, IME, PREZIME, KORISNICKO_IME, SIFRA, uloge.ULOGA FROM radnici, uloge WHERE radnici.ULOGA_ID = uloge.ULOGA_ID"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                using (MySqlDataAdapter adapter3 = new MySqlDataAdapter(query3, conn))
                {
                    DataSet ds = new DataSet();
                    adapter3.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }

        }


        private bool checkIfUserExists()
        {
            mycon = new MySqlConnection(con);
            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM radnici WHERE KORISNICKO_IME=@KORISNCKO_IME", mycon);
            cmd.Parameters.AddWithValue("@KORISNCKO_IME", textBox2.Text);
            mycon.Open();
            int TotalRows = 0;
            TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
            MySqlDataReader dr = cmd.ExecuteReader();
            bool check;
            if (TotalRows > 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            mycon.Close();
            return check;
        }





        private void listUloge_SelectedIndexChanged(object sender, EventArgs e)
        {
            Uloga newItem = (Uloga)listUloge.SelectedItem; // Gets the selected MyType
           textBox1.Text= newItem.Id;
            textBox2.Text = newItem.Naziv;
            // OR
            string username = listUloge.Text; // Gets the selected user name using the DisplayMember property of the listbox
                                            // OR
          //  int userid = (int)listUloge.SelectedValue; // Gets the selected user's userid using the ValueMember property of the listbox

         //   textBox3.Text = username;
          //  textBox.Text = userid.ToString();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString());
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
          //  textBox1.Text = dataGridView1.CurrentCell.Value.ToString();
            string value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
         
        //    uloga2.Naziv = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //   textBox2.Text = value;

            uloga_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //  MessageBox.Show(e.RowIndex.ToString());
      
          
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                radnik_id= Convert.ToInt32(row.Cells[0].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                textBox.Text = row.Cells["IME"].Value.ToString();
                textBox1.Text = row.Cells["PREZIME"].Value.ToString();
                textBox2.Text = row.Cells["KORISNICKO_IME"].Value.ToString();
                textBox3.Text = row.Cells["SIFRA"].Value.ToString();
                string uloga_n = row.Cells["ULOGA"].Value.ToString();
               
                // dataGridView1.Rows[index].Selected = true;
                //  dataGridView1.Rows[index].Selected = true;
                //   dataGridView1.SelectedRows.Clear();
                //  DataGridViewRow row2 = this.dataGridView1.Rows[e.RowIndex];
               // dataGridView1.SelectedRows.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    string a = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (a.Equals(uloga_n))
                    {
                        dataGridView1.Rows[i].Selected = true;
                        uloga_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["ULOGA_ID"].Value.ToString());
                        
                       // break;
                    }
                }
            //    foreach (DataGridViewRow myrow in dataGridView1.Rows)
           //     {
                  //  string a = myrow.Cells[1].Value.ToString();
                   // if ((row3.Cells["ULOGA"].Value.ToString())== uloga_n)
                //   if (a.Equals(uloga_n))
                  //  {
                        //      dataGridView1.Rows[0].Selected = true;
                        // dataGridView1.CurrentRow.Selected = true;
                 //       myrow.Selected = true;
                 //   }
           //     }
                //  tbSurname.Text = row.Cells["surname"].Value.ToString();
            }
        }

        private void updateRadnik_Click(object sender, EventArgs e)
        {
            mycon = new MySqlConnection(con);
            mycon.Open();
            string ime = textBox.Text;
            string prezime = textBox1.Text;
            string username = textBox2.Text;
            string sifra = textBox3.Text;
            string query = "UPDATE radnici SET IME = @IME, PREZIME = @PREZIME, KORISNICKO_IME = @KORISNICKO_IME, SIFRA = @SIFRA, ULOGA_ID = @ULOGA_ID WHERE RADNIK_ID = @RADNIK_ID";
                
            MySqlCommand cmd = new MySqlCommand(query, mycon);
            cmd.Parameters.AddWithValue("@ULOGA_ID", uloga_id);
            cmd.Parameters.AddWithValue("@IME", ime);
            cmd.Parameters.AddWithValue("@PREZIME", prezime);
            cmd.Parameters.AddWithValue("@KORISNICKO_IME", username);
            cmd.Parameters.AddWithValue("@SIFRA", sifra);
            cmd.Parameters.AddWithValue("@RADNIK_ID", radnik_id);

            cmd.ExecuteNonQuery();
            // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            //  MySqlCommand cmd = new MySqlCommand(query, mycon);
            mycon.Close();

            MessageBox.Show("Radnik uspesno azuriran");


            string query3 = "SELECT RADNIK_ID, IME, PREZIME, KORISNICKO_IME, SIFRA, uloge.ULOGA FROM radnici, uloge WHERE radnici.ULOGA_ID = uloge.ULOGA_ID"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                using (MySqlDataAdapter adapter3 = new MySqlDataAdapter(query3, conn))
                {
                    DataSet ds = new DataSet();
                    adapter3.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }

        private void deleteRadnik_Click(object sender, EventArgs e)
        {
            mycon = new MySqlConnection(con);
            mycon.Open();
          
            string query = "DELETE FROM radnici WHERE RADNIK_ID = @RADNIK_ID";

            MySqlCommand cmd = new MySqlCommand(query, mycon);
           
            cmd.Parameters.AddWithValue("@RADNIK_ID", radnik_id);

            cmd.ExecuteNonQuery();
            // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            //  MySqlCommand cmd = new MySqlCommand(query, mycon);
            mycon.Close();

            MessageBox.Show("Radnik uspesno obrisan");


            string query3 = "SELECT RADNIK_ID, IME, PREZIME, KORISNICKO_IME, SIFRA, uloge.ULOGA FROM radnici, uloge WHERE radnici.ULOGA_ID = uloge.ULOGA_ID"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                using (MySqlDataAdapter adapter3 = new MySqlDataAdapter(query3, conn))
                {
                    DataSet ds = new DataSet();
                    adapter3.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }

        private void dodaj_lekove_Click(object sender, EventArgs e)
        {
            ADminDodavanjeLekova adminDodavanjeLekova = new ADminDodavanjeLekova();

            adminDodavanjeLekova.FormClosed += (s, args) => this.Close();
            this.Hide();
            adminDodavanjeLekova.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.FormClosed += (s, args) => this.Close();
            this.Hide();
            form1.Show();
        }
    }
}
