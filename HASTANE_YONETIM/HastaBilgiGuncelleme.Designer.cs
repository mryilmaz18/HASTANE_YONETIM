
namespace HASTANE_YONETIM
{
    partial class HastaBilgiGuncelleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HastaBilgiGuncelleme));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBilgiGuncelle = new System.Windows.Forms.Button();
            this.comboCinsiyet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTel = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textSoyad = new System.Windows.Forms.TextBox();
            this.label_Soyad = new System.Windows.Forms.Label();
            this.textAd = new System.Windows.Forms.TextBox();
            this.label_Ad = new System.Windows.Forms.Label();
            this.textSifre = new System.Windows.Forms.TextBox();
            this.maskedTC = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 35);
            this.label1.TabIndex = 60;
            this.label1.Text = "HASTA BİLGİ GÜNCELLEME EKRANI";
            // 
            // buttonBilgiGuncelle
            // 
            this.buttonBilgiGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonBilgiGuncelle.Location = new System.Drawing.Point(262, 360);
            this.buttonBilgiGuncelle.Name = "buttonBilgiGuncelle";
            this.buttonBilgiGuncelle.Size = new System.Drawing.Size(156, 27);
            this.buttonBilgiGuncelle.TabIndex = 53;
            this.buttonBilgiGuncelle.Text = "Bilgilerimi Güncelle";
            this.buttonBilgiGuncelle.UseVisualStyleBackColor = true;
            this.buttonBilgiGuncelle.Click += new System.EventHandler(this.buttonBilgiGuncelle_Click);
            // 
            // comboCinsiyet
            // 
            this.comboCinsiyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboCinsiyet.FormattingEnabled = true;
            this.comboCinsiyet.Items.AddRange(new object[] {
            "Kadın ",
            "Erkek"});
            this.comboCinsiyet.Location = new System.Drawing.Point(181, 322);
            this.comboCinsiyet.Name = "comboCinsiyet";
            this.comboCinsiyet.Size = new System.Drawing.Size(162, 32);
            this.comboCinsiyet.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(90, 325);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 59;
            this.label5.Text = "Cinsiyet:";
            // 
            // maskedTel
            // 
            this.maskedTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTel.Location = new System.Drawing.Point(181, 226);
            this.maskedTel.Mask = "(999) 000-0000";
            this.maskedTel.Name = "maskedTel";
            this.maskedTel.Size = new System.Drawing.Size(162, 29);
            this.maskedTel.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(61, 228);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 24);
            this.label4.TabIndex = 58;
            this.label4.Text = "Telefon No:";
            // 
            // textSoyad
            // 
            this.textSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textSoyad.Location = new System.Drawing.Point(181, 128);
            this.textSoyad.Name = "textSoyad";
            this.textSoyad.Size = new System.Drawing.Size(162, 29);
            this.textSoyad.TabIndex = 48;
            // 
            // label_Soyad
            // 
            this.label_Soyad.AutoSize = true;
            this.label_Soyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Soyad.Location = new System.Drawing.Point(102, 132);
            this.label_Soyad.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Soyad.Name = "label_Soyad";
            this.label_Soyad.Size = new System.Drawing.Size(68, 24);
            this.label_Soyad.TabIndex = 57;
            this.label_Soyad.Text = "Soyad:";
            // 
            // textAd
            // 
            this.textAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textAd.Location = new System.Drawing.Point(181, 79);
            this.textAd.Name = "textAd";
            this.textAd.Size = new System.Drawing.Size(162, 29);
            this.textAd.TabIndex = 47;
            // 
            // label_Ad
            // 
            this.label_Ad.AutoSize = true;
            this.label_Ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_Ad.Location = new System.Drawing.Point(131, 82);
            this.label_Ad.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Ad.Name = "label_Ad";
            this.label_Ad.Size = new System.Drawing.Size(39, 24);
            this.label_Ad.TabIndex = 56;
            this.label_Ad.Text = "Ad:";
            // 
            // textSifre
            // 
            this.textSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textSifre.Location = new System.Drawing.Point(181, 275);
            this.textSifre.Name = "textSifre";
            this.textSifre.Size = new System.Drawing.Size(162, 29);
            this.textSifre.TabIndex = 51;
            // 
            // maskedTC
            // 
            this.maskedTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTC.Location = new System.Drawing.Point(181, 177);
            this.maskedTC.Mask = "00000000000";
            this.maskedTC.Name = "maskedTC";
            this.maskedTC.Size = new System.Drawing.Size(162, 29);
            this.maskedTC.TabIndex = 49;
            this.maskedTC.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(118, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 55;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(46, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 24);
            this.label2.TabIndex = 54;
            this.label2.Text = "TC Kimlik No:";
            // 
            // HastaBilgiGuncelleme
            // 
            this.AcceptButton = this.buttonBilgiGuncelle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(525, 416);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBilgiGuncelle);
            this.Controls.Add(this.comboCinsiyet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textSoyad);
            this.Controls.Add(this.label_Soyad);
            this.Controls.Add(this.textAd);
            this.Controls.Add(this.label_Ad);
            this.Controls.Add(this.textSifre);
            this.Controls.Add(this.maskedTC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HastaBilgiGuncelleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HastaBilgiGuncelleme";
            this.Load += new System.EventHandler(this.HastaBilgiGuncelleme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBilgiGuncelle;
        private System.Windows.Forms.ComboBox comboCinsiyet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textSoyad;
        private System.Windows.Forms.Label label_Soyad;
        private System.Windows.Forms.TextBox textAd;
        private System.Windows.Forms.Label label_Ad;
        private System.Windows.Forms.TextBox textSifre;
        private System.Windows.Forms.MaskedTextBox maskedTC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}