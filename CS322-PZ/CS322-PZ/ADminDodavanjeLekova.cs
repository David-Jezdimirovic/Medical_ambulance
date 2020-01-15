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
    public partial class ADminDodavanjeLekova : Form
    {

        MySqlConnection mycon;
        DBConnection db;


        string connectionString = "datasource=localhost;port=3306;username=root;password='';database=cs322_pz"; //Set your MySQL connection string here.
        int lek_id = 0;
        int bolest_id = 0;
         
        public ADminDodavanjeLekova()
        {
            InitializeComponent();
            db = new DBConnection();
         //   db.OpenConnection();

            mycon = new MySqlConnection(connectionString);
         //   mycon.Open();
        }


        private void ADminDodavanjeLekova_Load(object sender, EventArgs e)
        {
           
            string query = "SELECT * FROM lekovi"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }


            string query2 = "SELECT * FROM bolesti"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                lek_id = Convert.ToInt32(row.Cells[0].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                naziv_leka.Text = row.Cells["NAZIV"].Value.ToString();
                doza_leka.Text = row.Cells["DOZA"].Value.ToString();
            }
         }

        private void insert_Lek_Click(object sender, EventArgs e)
        {
            string naziv = naziv_leka.Text;
            string doza = doza_leka.Text;
          

            if (string.IsNullOrWhiteSpace(naziv) || string.IsNullOrWhiteSpace(doza) )
                    
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }

            try
            {

                if (!string.IsNullOrWhiteSpace(naziv) && !string.IsNullOrWhiteSpace(doza) )
                {
                  //  mycon = new MySqlConnection(con);
                    mycon.Open();
                   

                    string query = "INSERT INTO lekovi( NAZIV, DOZA) " +
                                 "VALUES(@NAZIV, @DOZA)";

                    MySqlCommand cmd = new MySqlCommand(query, mycon);
                    cmd.Parameters.AddWithValue("@NAZIV", naziv);
                    cmd.Parameters.AddWithValue("@DOZA", doza);
                   

                    cmd.ExecuteNonQuery();
                    // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    //  MySqlCommand cmd = new MySqlCommand(query, mycon);
                    mycon.Close();

                    MessageBox.Show("Lek uspesno registrovan");
                    // adapter.Update(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ponovo popunjava tabelu
            string query2 = "SELECT * FROM lekovi"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void update_lek_Click(object sender, EventArgs e)
        {
            string naziv = naziv_leka.Text;
            string doza = doza_leka.Text;


            if (string.IsNullOrWhiteSpace(naziv) || string.IsNullOrWhiteSpace(doza) || lek_id == 0)

            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }

            try
            {

                if (!string.IsNullOrWhiteSpace(naziv) && !string.IsNullOrWhiteSpace(doza) && lek_id != 0)
                {
                    //  mycon = new MySqlConnection(con);
                    mycon.Open();


                    string query = "UPDATE lekovi SET NAZIV = @NAZIV, DOZA = @DOZA WHERE LEK_ID = @LEK_ID";

                    MySqlCommand cmd = new MySqlCommand(query, mycon);
                    cmd.Parameters.AddWithValue("@LEK_ID", lek_id);
                    cmd.Parameters.AddWithValue("@NAZIV", naziv);
                    cmd.Parameters.AddWithValue("@DOZA", doza);


                    cmd.ExecuteNonQuery();
                    // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    //  MySqlCommand cmd = new MySqlCommand(query, mycon);
                    mycon.Close();

                    MessageBox.Show("Lek uspesno azuriran");
                    // adapter.Update(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ponovo popunjava tabelu
            string query2 = "SELECT * FROM lekovi"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }


        }

        private void delete_lek_Click(object sender, EventArgs e)
        {
            try
            {

                if ( lek_id != 0)
                {
                    //  mycon = new MySqlConnection(con);
                    mycon.Open();


                    string query = "DELETE FROM lekovi WHERE LEK_ID = @LEK_ID";

                    MySqlCommand cmd = new MySqlCommand(query, mycon);
                    cmd.Parameters.AddWithValue("@LEK_ID", lek_id);
                   
                    cmd.ExecuteNonQuery();
                    // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    //  MySqlCommand cmd = new MySqlCommand(query, mycon);
                    mycon.Close();

                    MessageBox.Show("Lek uspesno obrisan");
                    // adapter.Update(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // ponovo popunjava tabelu
            string query2 = "SELECT * FROM lekovi"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                bolest_id = Convert.ToInt32(row.Cells[0].Value.ToString());
                //Shared.user_id = int.Parse(row.Cells["id"].Value.ToString());

                naziv_bolesti.Text = row.Cells["NAZIV"].Value.ToString();
                
            }
        }

        private void insert_bolest_Click(object sender, EventArgs e)
        {

            string naziv = naziv_bolesti.Text;
            


            if (string.IsNullOrWhiteSpace(naziv) )

            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }

            try
            {

                if (!string.IsNullOrWhiteSpace(naziv) )
                {
                    //  mycon = new MySqlConnection(con);

                    db.OpenConnection();

                    string query = "INSERT INTO bolesti(NAZIV) VALUES(@NAZIV)";

                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    
                    cmd.Parameters.AddWithValue("@NAZIV", naziv);
                    


                    cmd.ExecuteNonQuery();

                    

                    MessageBox.Show("Bolest uspesno uneta");
                    // adapter.Update(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                    db.CloseConnection();

            string query2 = "SELECT * FROM bolesti"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }

        private void update_bolest_Click(object sender, EventArgs e)
        {
            string naziv = naziv_bolesti.Text;
            


            if (string.IsNullOrWhiteSpace(naziv)  || bolest_id == 0)

            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }

            try
            {

                if (!string.IsNullOrWhiteSpace(naziv)  && bolest_id != 0)
                {
                    //  mycon = new MySqlConnection(con);
                    db.OpenConnection();


                    string query = "UPDATE bolesti SET NAZIV = @NAZIV WHERE BOLEST_ID = @BOLEST_ID";

                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@BOLEST_ID", bolest_id);
                    cmd.Parameters.AddWithValue("@NAZIV", naziv);
                    


                    cmd.ExecuteNonQuery();
                    // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    //  MySqlCommand cmd = new MySqlCommand(query, mycon);
                    

                    MessageBox.Show("Bolest uspesno azurirana");
                    // adapter.Update(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             db.CloseConnection();

            string query2 = "SELECT * FROM bolesti"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }

        private void delete_bolest_Click(object sender, EventArgs e)
        {


            try
            {

                if (bolest_id != 0)
                {
                    //  mycon = new MySqlConnection(con);
                    db.OpenConnection();


                    string query = "DELETE FROM bolesti WHERE BOLEST_ID = @BOLEST_ID";

                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@BOLEST_ID", bolest_id);

                    cmd.ExecuteNonQuery();
                    // MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    //  MySqlCommand cmd = new MySqlCommand(query, mycon);
                    

                    MessageBox.Show("Bolest uspesno obrisana");
                    // adapter.Update(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.CloseConnection();

            string query2 = "SELECT * FROM bolesti"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query2, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }



        private void nazad_Click(object sender, EventArgs e)
        {
            AdminRegisterForm adminRegister = new AdminRegisterForm();

            adminRegister.FormClosed += (s, args) => this.Close();
            this.Hide();
            adminRegister.Show();
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
