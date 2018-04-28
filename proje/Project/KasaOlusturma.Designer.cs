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
            this.txtbox_kasaSifre.Size = new System.Drawing.Size(148, 22);
            this.txtbox_kasaSifre.TabIndex = 3;
            // 
            // btn_olustur
            // 
            this.btn_olustur.Location = new System.Drawing.Point(234, 186);
            this.btn_olustur.Name = "btn_olustur";
            this.btn_olustur.Size = new System.Drawing.Size(90, 28);
            this.btn_olustur.TabIndex = 4;
            this.btn_olustur.Text = "Oluştur";
            this.btn_olustur.UseVisualStyleBackColor = true;
            this.btn_olustur.Click += new System.EventHandler(this.btn_olustur_Click);
            // 
            // KasaOlusturma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 306);
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
    }
}