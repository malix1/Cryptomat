namespace proje
{
    partial class KasaOlusturma
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
            this.txtbox_kasaAdi = new System.Windows.Forms.TextBox();
            this.lbl_kasaAdi = new System.Windows.Forms.Label();
            this.lbl_kasaSifre = new System.Windows.Forms.Label();
            this.txtbox_kasaSifre = new System.Windows.Forms.TextBox();
            this.btn_olustur = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbYuksek = new System.Windows.Forms.RadioButton();
            this.rbOrta = new System.Windows.Forms.RadioButton();
            this.rbDusuk = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtbox_kasaAdi
            // 
            this.txtbox_kasaAdi.Location = new System.Drawing.Point(186, 72);
            this.txtbox_kasaAdi.Name = "txtbox_kasaAdi";
            this.txtbox_kasaAdi.Size = new System.Drawing.Size(148, 22);
            this.txtbox_kasaAdi.TabIndex = 0;
            // 
            // lbl_kasaAdi
            // 
            this.lbl_kasaAdi.AutoSize = true;
            this.lbl_kasaAdi.Location = new System.Drawing.Point(100, 72);
            this.lbl_kasaAdi.Name = "lbl_kasaAdi";
            this.lbl_kasaAdi.Size = new System.Drawing.Size(68, 17);
            this.lbl_kasaAdi.TabIndex = 1;
            this.lbl_kasaAdi.Text = "Kasa İsmi";
            // 
            // lbl_kasaSifre
            // 
            this.lbl_kasaSifre.AutoSize = true;
            this.lbl_kasaSifre.Location = new System.Drawing.Point(100, 130);
            this.lbl_kasaSifre.Name = "lbl_kasaSifre";
            this.lbl_kasaSifre.Size = new System.Drawing.Size(73, 17);
            this.lbl_kasaSifre.TabIndex = 2;
            this.lbl_kasaSifre.Text = "Kasa Şifre";
            // 
            // txtbox_kasaSifre
            // 
            this.txtbox_kasaSifre.Location = new System.Drawing.Point(186, 130);
            this.txtbox_kasaSifre.Name = "txtbox_kasaSifre";
            this.txtbox_kasaSifre.PasswordChar = '*';
            this.txtbox_kasaSifre.Size = new System.Drawing.Size(148, 22);
            this.txtbox_kasaSifre.TabIndex = 3;
            // 
            // btn_olustur
            // 
            this.btn_olustur.Location = new System.Drawing.Point(202, 250);
            this.btn_olustur.Name = "btn_olustur";
            this.btn_olustur.Size = new System.Drawing.Size(90, 28);
            this.btn_olustur.TabIndex = 4;
            this.btn_olustur.Text = "Oluştur";
            this.btn_olustur.UseVisualStyleBackColor = true;
            this.btn_olustur.Click += new System.EventHandler(this.btn_olustur_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Güvenlik Seviyesi";
            // 
            // rbYuksek
            // 
            this.rbYuksek.AutoSize = true;
            this.rbYuksek.Location = new System.Drawing.Point(186, 192);
            this.rbYuksek.Name = "rbYuksek";
            this.rbYuksek.Size = new System.Drawing.Size(75, 21);
            this.rbYuksek.TabIndex = 6;
            this.rbYuksek.TabStop = true;
            this.rbYuksek.Text = "Yüksek";
            this.rbYuksek.UseVisualStyleBackColor = true;
            // 
            // rbOrta
            // 
            this.rbOrta.AutoSize = true;
            this.rbOrta.Location = new System.Drawing.Point(267, 192);
            this.rbOrta.Name = "rbOrta";
            this.rbOrta.Size = new System.Drawing.Size(57, 21);
            this.rbOrta.TabIndex = 7;
            this.rbOrta.TabStop = true;
            this.rbOrta.Text = "Orta";
            this.rbOrta.UseVisualStyleBackColor = true;
            // 
            // rbDusuk
            // 
            this.rbDusuk.AutoSize = true;
            this.rbDusuk.Location = new System.Drawing.Point(330, 192);
            this.rbDusuk.Name = "rbDusuk";
            this.rbDusuk.Size = new System.Drawing.Size(69, 21);
            this.rbDusuk.TabIndex = 8;
            this.rbDusuk.TabStop = true;
            this.rbDusuk.Text = "Düşük";
            this.rbDusuk.UseVisualStyleBackColor = true;
            // 
            // KasaOlusturma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 306);
            this.Controls.Add(this.rbDusuk);
            this.Controls.Add(this.rbOrta);
            this.Controls.Add(this.rbYuksek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_olustur);
            this.Controls.Add(this.txtbox_kasaSifre);
            this.Controls.Add(this.lbl_kasaSifre);
            this.Controls.Add(this.lbl_kasaAdi);
            this.Controls.Add(this.txtbox_kasaAdi);
            this.Name = "KasaOlusturma";
            this.Text = "KasaOlusturma";
            this.Load += new System.EventHandler(this.KasaOlusturma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_kasaAdi;
        private System.Windows.Forms.Label lbl_kasaAdi;
        private System.Windows.Forms.Label lbl_kasaSifre;
        private System.Windows.Forms.TextBox txtbox_kasaSifre;
        private System.Windows.Forms.Button btn_olustur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbYuksek;
        private System.Windows.Forms.RadioButton rbOrta;
        private System.Windows.Forms.RadioButton rbDusuk;
    }
}