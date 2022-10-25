namespace STOK_TAKİP_PROGRAMI
{
    partial class Form5
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKaydıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alışİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dağıtımİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.işlemlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokKaydıToolStripMenuItem,
            this.satışİşlemleriToolStripMenuItem,
            this.alışİşlemleriToolStripMenuItem,
            this.dağıtımİşlemleriToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // stokKaydıToolStripMenuItem
            // 
            this.stokKaydıToolStripMenuItem.Name = "stokKaydıToolStripMenuItem";
            this.stokKaydıToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stokKaydıToolStripMenuItem.Text = "Stok İşlemler";
            this.stokKaydıToolStripMenuItem.Click += new System.EventHandler(this.stokKaydıToolStripMenuItem_Click);
            // 
            // satışİşlemleriToolStripMenuItem
            // 
            this.satışİşlemleriToolStripMenuItem.Name = "satışİşlemleriToolStripMenuItem";
            this.satışİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.satışİşlemleriToolStripMenuItem.Text = "Satış İşlemleri";
            this.satışİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.satışİşlemleriToolStripMenuItem_Click);
            // 
            // alışİşlemleriToolStripMenuItem
            // 
            this.alışİşlemleriToolStripMenuItem.Name = "alışİşlemleriToolStripMenuItem";
            this.alışİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alışİşlemleriToolStripMenuItem.Text = "Alış İşlemleri";
            this.alışİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.alışİşlemleriToolStripMenuItem_Click);
            // 
            // dağıtımİşlemleriToolStripMenuItem
            // 
            this.dağıtımİşlemleriToolStripMenuItem.Name = "dağıtımİşlemleriToolStripMenuItem";
            this.dağıtımİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.dağıtımİşlemleriToolStripMenuItem.Text = "Dağıtım İşlemleri";
            this.dağıtımİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.dağıtımİşlemleriToolStripMenuItem_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 572);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Form5";
            this.Text = "Form5";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKaydıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alışİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dağıtımİşlemleriToolStripMenuItem;
    }
}