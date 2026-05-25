namespace ProvaTelecamere
{
    partial class CameraSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView grid;

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.Label lblUtente;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPath;

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.NumericUpDown numPorta;
        private System.Windows.Forms.TextBox txtUtente;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.CheckBox chkAbilitata;

        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.DataGridView();

            this.lblNome = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPorta = new System.Windows.Forms.Label();
            this.lblUtente = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();

            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.numPorta = new System.Windows.Forms.NumericUpDown();
            this.txtUtente = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.chkAbilitata = new System.Windows.Forms.CheckBox();

            this.btnAggiungi = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new System.Drawing.Size(1500, 600);
            this.Text = "Impostazioni Telecamere";

            // GRID
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grid.MultiSelect = false;
            this.grid.ReadOnly = true;
            this.grid.Location = new System.Drawing.Point(10, 10);
            this.grid.Size = new System.Drawing.Size(850, 560);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);

            this.grid.Columns.Add("#", "#");
            this.grid.Columns.Add("Nome", "Nome");
            this.grid.Columns.Add("Ip", "IP");
            this.grid.Columns.Add("Porta", "Porta");
            this.grid.Columns.Add("Utente", "Utente");
            this.grid.Columns.Add("Password", "Password");
            this.grid.Columns.Add("Path", "Path");
            this.grid.Columns.Add("Abilitata", "Abilitata");

            // LABELS
            int x = 880;

            this.lblNome.Text = "Nome:";
            this.lblNome.Location = new System.Drawing.Point(x, 5);
            this.lblNome.AutoSize = true;

            this.lblIp.Text = "IP:";
            this.lblIp.Location = new System.Drawing.Point(x, 45);
            this.lblIp.AutoSize = true;

            this.lblPorta.Text = "Porta:";
            this.lblPorta.Location = new System.Drawing.Point(x, 85);
            this.lblPorta.AutoSize = true;

            this.lblUtente.Text = "Utente:";
            this.lblUtente.Location = new System.Drawing.Point(x, 125);
            this.lblUtente.AutoSize = true;

            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new System.Drawing.Point(x, 165);
            this.lblPassword.AutoSize = true;

            this.lblPath.Text = "Path finale:";
            this.lblPath.Location = new System.Drawing.Point(x, 205);
            this.lblPath.AutoSize = true;

            // INPUTS
            this.txtNome.Location = new System.Drawing.Point(x, 20);
            this.txtNome.Width = 450;

            this.txtIp.Location = new System.Drawing.Point(x, 60);
            this.txtIp.Width = 450;

            this.numPorta.Location = new System.Drawing.Point(x, 100);
            this.numPorta.Maximum = 65535;
            this.numPorta.Value = 554;

            this.txtUtente.Location = new System.Drawing.Point(x, 140);
            this.txtUtente.Width = 450;

            this.txtPassword.Location = new System.Drawing.Point(x, 180);
            this.txtPassword.Width = 450;
            this.txtPassword.PasswordChar = '*';

            this.txtPath.Location = new System.Drawing.Point(x, 220);
            this.txtPath.Width = 450;

            this.chkAbilitata.Text = "Abilitata";
            this.chkAbilitata.Location = new System.Drawing.Point(x, 260);

            // BUTTONS
            int bw = 180;

            this.btnAggiungi.Text = "Aggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(bw, 45);
            this.btnAggiungi.Location = new System.Drawing.Point(x, 310);
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);

            this.btnModifica.Text = "Modifica";
            this.btnModifica.Size = new System.Drawing.Size(bw, 45);
            this.btnModifica.Location = new System.Drawing.Point(x + 200, 310);
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);

            this.btnElimina.Text = "Elimina";
            this.btnElimina.Size = new System.Drawing.Size(bw, 45);
            this.btnElimina.Location = new System.Drawing.Point(x + 400, 310);
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);

            this.btnUp.Text = "▲";
            this.btnUp.Size = new System.Drawing.Size(70, 45);
            this.btnUp.Location = new System.Drawing.Point(x, 370);
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);

            this.btnDown.Text = "▼";
            this.btnDown.Size = new System.Drawing.Size(70, 45);
            this.btnDown.Location = new System.Drawing.Point(x + 80, 370);
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);

            this.btnOK.Text = "OK";
            this.btnOK.Size = new System.Drawing.Size(bw, 45);
            this.btnOK.Location = new System.Drawing.Point(x, 430);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.Size = new System.Drawing.Size(bw, 45);
            this.btnAnnulla.Location = new System.Drawing.Point(x + 200, 430);
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);

            // ADD CONTROLS
            this.Controls.Add(this.grid);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.lblPorta);
            this.Controls.Add(this.lblUtente);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblPath);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.numPorta);
            this.Controls.Add(this.txtUtente);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.chkAbilitata);

            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnnulla);

            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
