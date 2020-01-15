namespace CS322_PZ
{
    partial class ADminDodavanjeLekova
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.naziv_leka = new System.Windows.Forms.TextBox();
            this.doza_leka = new System.Windows.Forms.TextBox();
            this.naziv_bolesti = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.insert_Lek = new System.Windows.Forms.Button();
            this.update_lek = new System.Windows.Forms.Button();
            this.delete_lek = new System.Windows.Forms.Button();
            this.insert_bolest = new System.Windows.Forms.Button();
            this.update_bolest = new System.Windows.Forms.Button();
            this.delete_bolest = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.nazad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(360, 146);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(532, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(333, 150);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // naziv_leka
            // 
            this.naziv_leka.Location = new System.Drawing.Point(85, 185);
            this.naziv_leka.Name = "naziv_leka";
            this.naziv_leka.Size = new System.Drawing.Size(287, 20);
            this.naziv_leka.TabIndex = 2;
            // 
            // doza_leka
            // 
            this.doza_leka.Location = new System.Drawing.Point(85, 221);
            this.doza_leka.Name = "doza_leka";
            this.doza_leka.Size = new System.Drawing.Size(287, 20);
            this.doza_leka.TabIndex = 3;
            // 
            // naziv_bolesti
            // 
            this.naziv_bolesti.Location = new System.Drawing.Point(605, 178);
            this.naziv_bolesti.Name = "naziv_bolesti";
            this.naziv_bolesti.Size = new System.Drawing.Size(260, 20);
            this.naziv_bolesti.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv leka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Doza leka:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Naziv bolesti:";
            // 
            // insert_Lek
            // 
            this.insert_Lek.Location = new System.Drawing.Point(85, 266);
            this.insert_Lek.Name = "insert_Lek";
            this.insert_Lek.Size = new System.Drawing.Size(75, 23);
            this.insert_Lek.TabIndex = 8;
            this.insert_Lek.Text = "Insert";
            this.insert_Lek.UseVisualStyleBackColor = true;
            this.insert_Lek.Click += new System.EventHandler(this.insert_Lek_Click);
            // 
            // update_lek
            // 
            this.update_lek.Location = new System.Drawing.Point(191, 264);
            this.update_lek.Name = "update_lek";
            this.update_lek.Size = new System.Drawing.Size(73, 25);
            this.update_lek.TabIndex = 9;
            this.update_lek.Text = "Update";
            this.update_lek.UseVisualStyleBackColor = true;
            this.update_lek.Click += new System.EventHandler(this.update_lek_Click);
            // 
            // delete_lek
            // 
            this.delete_lek.Location = new System.Drawing.Point(297, 264);
            this.delete_lek.Name = "delete_lek";
            this.delete_lek.Size = new System.Drawing.Size(75, 23);
            this.delete_lek.TabIndex = 10;
            this.delete_lek.Text = "Delete";
            this.delete_lek.UseVisualStyleBackColor = true;
            this.delete_lek.Click += new System.EventHandler(this.delete_lek_Click);
            // 
            // insert_bolest
            // 
            this.insert_bolest.Location = new System.Drawing.Point(605, 224);
            this.insert_bolest.Name = "insert_bolest";
            this.insert_bolest.Size = new System.Drawing.Size(75, 23);
            this.insert_bolest.TabIndex = 11;
            this.insert_bolest.Text = "Insert";
            this.insert_bolest.UseVisualStyleBackColor = true;
            this.insert_bolest.Click += new System.EventHandler(this.insert_bolest_Click);
            // 
            // update_bolest
            // 
            this.update_bolest.Location = new System.Drawing.Point(701, 224);
            this.update_bolest.Name = "update_bolest";
            this.update_bolest.Size = new System.Drawing.Size(75, 23);
            this.update_bolest.TabIndex = 12;
            this.update_bolest.Text = "update";
            this.update_bolest.UseVisualStyleBackColor = true;
            this.update_bolest.Click += new System.EventHandler(this.update_bolest_Click);
            // 
            // delete_bolest
            // 
            this.delete_bolest.Location = new System.Drawing.Point(790, 224);
            this.delete_bolest.Name = "delete_bolest";
            this.delete_bolest.Size = new System.Drawing.Size(75, 23);
            this.delete_bolest.TabIndex = 13;
            this.delete_bolest.Text = "Delete";
            this.delete_bolest.UseVisualStyleBackColor = true;
            this.delete_bolest.Click += new System.EventHandler(this.delete_bolest_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(790, 294);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 14;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // nazad
            // 
            this.nazad.Location = new System.Drawing.Point(701, 294);
            this.nazad.Name = "nazad";
            this.nazad.Size = new System.Drawing.Size(75, 23);
            this.nazad.TabIndex = 15;
            this.nazad.Text = "Nazad";
            this.nazad.UseVisualStyleBackColor = true;
            this.nazad.Click += new System.EventHandler(this.nazad_Click);
            // 
            // ADminDodavanjeLekova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 338);
            this.Controls.Add(this.nazad);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.delete_bolest);
            this.Controls.Add(this.update_bolest);
            this.Controls.Add(this.insert_bolest);
            this.Controls.Add(this.delete_lek);
            this.Controls.Add(this.update_lek);
            this.Controls.Add(this.insert_Lek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.naziv_bolesti);
            this.Controls.Add(this.doza_leka);
            this.Controls.Add(this.naziv_leka);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ADminDodavanjeLekova";
            this.Text = "ADminDodavanjeLekova";
            this.Load += new System.EventHandler(this.ADminDodavanjeLekova_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox naziv_leka;
        private System.Windows.Forms.TextBox doza_leka;
        private System.Windows.Forms.TextBox naziv_bolesti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button insert_Lek;
        private System.Windows.Forms.Button update_lek;
        private System.Windows.Forms.Button delete_lek;
        private System.Windows.Forms.Button insert_bolest;
        private System.Windows.Forms.Button update_bolest;
        private System.Windows.Forms.Button delete_bolest;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button nazad;
    }
}