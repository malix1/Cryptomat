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
            this.btn_kasaKitle = new System.Windows.Forms.Button();
            this.grpbox_KasaOzellik = new System.Windows.Forms.GroupBox();
            this.btn_onay = new System.Windows.Forms.Button();
            this.lbl_sifre = new System.Windows.Forms.Label();
            this.txtBox_kasaSifre = new System.Windows.Forms.TextBox();
            this.btn_kasaEkle = new System.Windows.Forms.Button();
            this.btn_yedekAl = new System.Windows.Forms.Button();
            this.txt_yedekKasaAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btn_kasaSil.Location = new System.Drawing.Point(575, 433);
            this.btn_kasaSil.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kasaSil.Name = "btn_kasaSil";
            this.btn_kasaSil.Size = new System.Drawing.Size(141, 28);
            this.btn_kasaSil.TabIndex = 2;
            this.btn_kasaSil.Text = "Kasayı Sil";
            this.btn_kasaSil.UseVisualStyleBackColor = true;
            this.btn_kasaSil.Click += new System.EventHandler(this.btn_kasaSil_Click);
            // 
            // btn_kasaKitle
            // 
            this.btn_kasaKitle.Location = new System.Drawing.Point(724, 433);
            this.btn_kasaKitle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kasaKitle.Name = "btn_kasaKitle";
            this.btn_kasaKitle.Size = new System.Drawing.Size(127, 28);
            this.btn_kasaKitle.TabIndex = 3;
            this.btn_kasaKitle.Text = "Kasayı Kilitle";
            this.btn_kasaKitle.UseVisualStyleBackColor = true;
            this.btn_kasaKitle.Click += new System.EventHandler(this.btn_kasaKitle_Click);
            // 
            // grpbox_KasaOzellik
            // 
            this.grpbox_KasaOzellik.Controls.Add(this.btn_onay);
            this.grpbox_KasaOzellik.Controls.Add(this.lbl_sifre);
            this.grpbox_KasaOzellik.Controls.Add(this.txtBox_kasaSifre);
            this.grpbox_KasaOzellik.Location = new System.Drawing.Point(428, 15);
            this.grpbox_KasaOzellik.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox_KasaOzellik.Name = "grpbox_KasaOzellik";
            this.grpbox_KasaOzellik.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox_KasaOzellik.Size = new System.Drawing.Size(572, 350);
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
            this.txtBox_kasaSifre.Text = "memetali1";
            this.txtBox_kasaSifre.Visible = false;
            // 
            // btn_kasaEkle
            // 
            this.btn_kasaEkle.Location = new System.Drawing.Point(428, 431);
            this.btn_kasaEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kasaEkle.Name = "btn_kasaEkle";
            this.btn_kasaEkle.Size = new System.Drawing.Size(139, 28);
            this.btn_kasaEkle.TabIndex = 1;
            this.btn_kasaEkle.Text = "Yeni Kasa Ekle";
            this.btn_kasaEkle.UseVisualStyleBackColor = true;
            this.btn_kasaEkle.Click += new System.EventHandler(this.btn_kasaEkle_Click);
            // 
            // btn_yedekAl
            // 
            this.btn_yedekAl.Location = new System.Drawing.Point(859, 433);
            this.btn_yedekAl.Margin = new System.Windows.Forms.Padding(4);
            this.btn_yedekAl.Name = "btn_yedekAl";
            this.btn_yedekAl.Size = new System.Drawing.Size(141, 28);
            this.btn_yedekAl.TabIndex = 6;
            this.btn_yedekAl.Text = "Yedek Alma";
            this.btn_yedekAl.UseVisualStyleBackColor = true;
            this.btn_yedekAl.Click += new System.EventHandler(this.btn_yedekAl_Click);
            // 
            // txt_yedekKasaAdi
            // 
            this.txt_yedekKasaAdi.Location = new System.Drawing.Point(859, 404);
            this.txt_yedekKasaAdi.Name = "txt_yedekKasaAdi";
            this.txt_yedekKasaAdi.Size = new System.Drawing.Size(141, 22);
            this.txt_yedekKasaAdi.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(808, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Yedek Almak İstediğiniz Kasa";
            // 
            // icerikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 474);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_yedekKasaAdi);
            this.Controls.Add(this.btn_yedekAl);
            this.Controls.Add(this.grpbox_KasaOzellik);
            this.Controls.Add(this.btn_kasaKitle);
            this.Controls.Add(this.btn_kasaSil);
            this.Controls.Add(this.btn_kasaEkle);
            this.Controls.Add(this.grpbox_Kasalar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "icerikForm";
            this.Text = "Cryptomat";
            this.Load += new System.EventHandler(this.icerikForm_Load);
            this.grpbox_Kasalar.ResumeLayout(false);
            this.grpbox_KasaOzellik.ResumeLayout(false);
            this.grpbox_KasaOzellik.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbox_Kasalar;
        private System.Windows.Forms.Button btn_kasaSil;
        private System.Windows.Forms.Button btn_kasaKitle;
        private System.Windows.Forms.GroupBox grpbox_KasaOzellik;
        private System.Windows.Forms.Button btn_kasaEkle;
        private System.Windows.Forms.Button btn_onay;
        private System.Windows.Forms.Label lbl_sifre;
        private System.Windows.Forms.TextBox txtBox_kasaSifre;
        public System.Windows.Forms.ListView listv_Kasalar;
        private System.Windows.Forms.Button btn_yedekAl;
        private System.Windows.Forms.TextBox txt_yedekKasaAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}