namespace proje
{
    partial class icerikForm
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
            this.grpbox_Kasalar = new System.Windows.Forms.GroupBox();
            this.listv_Kasalar = new System.Windows.Forms.ListView();
            this.btn_kasaSil = new System.Windows.Forms.Button();
            this.btn_kullaniciGuncelle = new System.Windows.Forms.Button();
            this.grpbox_KasaOzellik = new System.Windows.Forms.GroupBox();
            this.btn_onay = new System.Windows.Forms.Button();
            this.lbl_sifre = new System.Windows.Forms.Label();
            this.txtBox_kasaSifre = new System.Windows.Forms.TextBox();
            this.btn_kasaEkle = new System.Windows.Forms.Button();
            this.grpbox_Kasalar.SuspendLayout();
            this.grpbox_KasaOzellik.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbox_Kasalar
            // 
            this.grpbox_Kasalar.Controls.Add(this.listv_Kasalar);
            this.grpbox_Kasalar.Location = new System.Drawing.Point(16, 15);
            this.grpbox_Kasalar.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox_Kasalar.Name = "grpbox_Kasalar";
            this.grpbox_Kasalar.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox_Kasalar.Size = new System.Drawing.Size(360, 444);
            this.grpbox_Kasalar.TabIndex = 0;
            this.grpbox_Kasalar.TabStop = false;
            this.grpbox_Kasalar.Text = "Kasalar : ";
            // 
            // listv_Kasalar
            // 
            this.listv_Kasalar.Location = new System.Drawing.Point(7, 22);
            this.listv_Kasalar.Name = "listv_Kasalar";
            this.listv_Kasalar.Size = new System.Drawing.Size(334, 407);
            this.listv_Kasalar.TabIndex = 0;
            this.listv_Kasalar.UseCompatibleStateImageBehavior = false;
            this.listv_Kasalar.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listv_Kasalar_ItemSelectionChanged);
            this.listv_Kasalar.DoubleClick += new System.EventHandler(this.listv_Kasalar_DoubleClick);
            this.listv_Kasalar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listv_Kasalar_MouseClick);
            // 
            // btn_kasaSil
            // 
            this.btn_kasaSil.Location = new System.Drawing.Point(668, 431);
            this.btn_kasaSil.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kasaSil.Name = "btn_kasaSil";
            this.btn_kasaSil.Size = new System.Drawing.Size(153, 28);
            this.btn_kasaSil.TabIndex = 2;
            this.btn_kasaSil.Text = "Kasayı Sil";
            this.btn_kasaSil.UseVisualStyleBackColor = true;
            this.btn_kasaSil.Click += new System.EventHandler(this.btn_kasaSil_Click);
            // 
            // btn_kullaniciGuncelle
            // 
            this.btn_kullaniciGuncelle.Location = new System.Drawing.Point(851, 431);
            this.btn_kullaniciGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kullaniciGuncelle.Name = "btn_kullaniciGuncelle";
            this.btn_kullaniciGuncelle.Size = new System.Drawing.Size(205, 28);
            this.btn_kullaniciGuncelle.TabIndex = 3;
            this.btn_kullaniciGuncelle.Text = "Kullanıcı Bilgilerini Güncelle";
            this.btn_kullaniciGuncelle.UseVisualStyleBackColor = true;
            // 
            // grpbox_KasaOzellik
            // 
            this.grpbox_KasaOzellik.Controls.Add(this.btn_onay);
            this.grpbox_KasaOzellik.Controls.Add(this.lbl_sifre);
            this.grpbox_KasaOzellik.Controls.Add(this.txtBox_kasaSifre);
            this.grpbox_KasaOzellik.Location = new System.Drawing.Point(460, 15);
            this.grpbox_KasaOzellik.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox_KasaOzellik.Name = "grpbox_KasaOzellik";
            this.grpbox_KasaOzellik.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox_KasaOzellik.Size = new System.Drawing.Size(596, 394);
            this.grpbox_KasaOzellik.TabIndex = 4;
            this.grpbox_KasaOzellik.TabStop = false;
            this.grpbox_KasaOzellik.Text = "Kasa Özellikleri";
            // 
            // btn_onay
            // 
            this.btn_onay.Location = new System.Drawing.Point(292, 107);
            this.btn_onay.Name = "btn_onay";
            this.btn_onay.Size = new System.Drawing.Size(95, 29);
            this.btn_onay.TabIndex = 2;
            this.btn_onay.Text = "Giriş";
            this.btn_onay.UseVisualStyleBackColor = true;
            this.btn_onay.Visible = false;
            this.btn_onay.Click += new System.EventHandler(this.btn_onay_Click);
            // 
            // lbl_sifre
            // 
            this.lbl_sifre.AutoSize = true;
            this.lbl_sifre.Location = new System.Drawing.Point(158, 57);
            this.lbl_sifre.Name = "lbl_sifre";
            this.lbl_sifre.Size = new System.Drawing.Size(37, 17);
            this.lbl_sifre.TabIndex = 1;
            this.lbl_sifre.Text = "Şifre";
            this.lbl_sifre.Visible = false;
            // 
            // txtBox_kasaSifre
            // 
            this.txtBox_kasaSifre.Location = new System.Drawing.Point(237, 57);
            this.txtBox_kasaSifre.Name = "txtBox_kasaSifre";
            this.txtBox_kasaSifre.Size = new System.Drawing.Size(150, 22);
            this.txtBox_kasaSifre.TabIndex = 0;
            this.txtBox_kasaSifre.Visible = false;
            // 
            // btn_kasaEkle
            // 
            this.btn_kasaEkle.Location = new System.Drawing.Point(460, 431);
            this.btn_kasaEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kasaEkle.Name = "btn_kasaEkle";
            this.btn_kasaEkle.Size = new System.Drawing.Size(153, 28);
            this.btn_kasaEkle.TabIndex = 1;
            this.btn_kasaEkle.Text = "Yeni Kasa Ekle";
            this.btn_kasaEkle.UseVisualStyleBackColor = true;
            this.btn_kasaEkle.Click += new System.EventHandler(this.btn_kasaEkle_Click);
            // 
            // icerikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 474);
            this.Controls.Add(this.grpbox_KasaOzellik);
            this.Controls.Add(this.btn_kullaniciGuncelle);
            this.Controls.Add(this.btn_kasaSil);
            this.Controls.Add(this.btn_kasaEkle);
            this.Controls.Add(this.grpbox_Kasalar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "icerikForm";
            this.Text = "icerikForm";
            this.Load += new System.EventHandler(this.icerikForm_Load);
            this.grpbox_Kasalar.ResumeLayout(false);
            this.grpbox_KasaOzellik.ResumeLayout(false);
            this.grpbox_KasaOzellik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbox_Kasalar;
        private System.Windows.Forms.Button btn_kasaSil;
        private System.Windows.Forms.Button btn_kullaniciGuncelle;
        private System.Windows.Forms.GroupBox grpbox_KasaOzellik;
        private System.Windows.Forms.Button btn_kasaEkle;
        private System.Windows.Forms.ListView listv_Kasalar;
        private System.Windows.Forms.Button btn_onay;
        private System.Windows.Forms.Label lbl_sifre;
        private System.Windows.Forms.TextBox txtBox_kasaSifre;
    }
}