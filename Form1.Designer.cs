namespace ProvaTelecamere
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem telecamereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem riavviaToolStripMenuItem;

        private System.Windows.Forms.Panel panelContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.telecamereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riavviaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.panelContainer = new System.Windows.Forms.Panel();

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // MENU
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.telecamereToolStripMenuItem,
                this.riavviaToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);

            // TELECAMERE
            this.telecamereToolStripMenuItem.Text = "Telecamere";
            this.telecamereToolStripMenuItem.Click += new System.EventHandler(this.telecamereToolStripMenuItem_Click);


            // PANEL CONTAINER
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 24);
            this.panelContainer.BackColor = System.Drawing.Color.Black;

            // FORM
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Visualizzatore Telecamere";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
