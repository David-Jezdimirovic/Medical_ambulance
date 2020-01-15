namespace CS322_PZ
{
    partial class LekarForm
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
            this.logout = new System.Windows.Forms.Button();
            this.danasnji_pregledi = new System.Windows.Forms.Button();
            this.svi_pregledi = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(411, 209);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(12, 271);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 1;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // danasnji_pregledi
            // 
            this.danasnji_pregledi.Location = new System.Drawing.Point(470, 47);
            this.danasnji_pregledi.Name = "danasnji_pregledi";
            this.danasnji_pregledi.Size = new System.Drawing.Size(150, 23);
            this.danasnji_pregledi.TabIndex = 2;
            this.danasnji_pregledi.Text = "Danasnji pregledi";
            this.danasnji_pregledi.UseVisualStyleBackColor = true;
            this.danasnji_pregledi.Click += new System.EventHandler(this.danasnji_pregledi_Click);
            // 
            // svi_pregledi
            // 
            this.svi_pregledi.Location = new System.Drawing.Point(470, 90);
            this.svi_pregledi.Name = "svi_pregledi";
            this.svi_pregledi.Size = new System.Drawing.Size(150, 23);
            this.svi_pregledi.TabIndex = 3;
            this.svi_pregledi.Text = "Svi pregledi";
            this.svi_pregledi.UseVisualStyleBackColor = true;
            this.svi_pregledi.Click += new System.EventHandler(this.svi_pregledi_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(252, 12);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 4;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 20);
            this.textBox1.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(445, 135);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // LekarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 306);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.svi_pregledi);
            this.Controls.Add(this.danasnji_pregledi);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LekarForm";
            this.Text = "LekarForm";
            this.Load += new System.EventHandler(this.LekarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button danasnji_pregledi;
        private System.Windows.Forms.Button svi_pregledi;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}