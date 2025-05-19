namespace FilmveDiziPuanlama
{
    partial class FilmDiziEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtResimLink = new System.Windows.Forms.TextBox();
            this.cmbTür = new System.Windows.Forms.ComboBox();
            this.cmbPuan = new System.Windows.Forms.ComboBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtYil = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Film Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Film Türü";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Çıkış Yılı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Puan";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Resim Linki";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(172, 51);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(121, 22);
            this.txtAd.TabIndex = 5;
            // 
            // txtResimLink
            // 
            this.txtResimLink.Location = new System.Drawing.Point(172, 227);
            this.txtResimLink.Name = "txtResimLink";
            this.txtResimLink.Size = new System.Drawing.Size(121, 22);
            this.txtResimLink.TabIndex = 6;
            // 
            // cmbTür
            // 
            this.cmbTür.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTür.FormattingEnabled = true;
            this.cmbTür.Location = new System.Drawing.Point(172, 92);
            this.cmbTür.Name = "cmbTür";
            this.cmbTür.Size = new System.Drawing.Size(121, 24);
            this.cmbTür.TabIndex = 7;
            // 
            // cmbPuan
            // 
            this.cmbPuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuan.FormattingEnabled = true;
            this.cmbPuan.Location = new System.Drawing.Point(172, 182);
            this.cmbPuan.Name = "cmbPuan";
            this.cmbPuan.Size = new System.Drawing.Size(121, 24);
            this.cmbPuan.TabIndex = 9;
            this.cmbPuan.SelectedIndexChanged += new System.EventHandler(this.cmbPuan_SelectedIndexChanged);
            this.cmbPuan.TextChanged += new System.EventHandler(this.cmbPuan_TextChanged);
            this.cmbPuan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPuan_KeyPress);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(172, 269);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(121, 48);
            this.btnEkle.TabIndex = 10;
            this.btnEkle.Text = "Film/Dizi Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtYil
            // 
            this.txtYil.Location = new System.Drawing.Point(172, 142);
            this.txtYil.Name = "txtYil";
            this.txtYil.Size = new System.Drawing.Size(121, 22);
            this.txtYil.TabIndex = 11;
            this.txtYil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYil_KeyPress);
            // 
            // FilmDiziEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 394);
            this.Controls.Add(this.txtYil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.cmbPuan);
            this.Controls.Add(this.cmbTür);
            this.Controls.Add(this.txtResimLink);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FilmDiziEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilmDiziEkle";
            this.Load += new System.EventHandler(this.FilmDiziEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtResimLink;
        private System.Windows.Forms.ComboBox cmbTür;
        private System.Windows.Forms.ComboBox cmbPuan;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtYil;
    }
}