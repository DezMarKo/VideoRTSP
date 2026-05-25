using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProvaTelecamere
{
    public partial class CameraSettingsForm : Form
    {
        public List<CameraConfig> ConfigTelecamereAggiornate => _config;
        private List<CameraConfig> _config;

        public CameraSettingsForm(List<CameraConfig> config)
        {
            InitializeComponent();

            _config = config.Select(c => new CameraConfig
            {
                Nome = c.Nome,
                Ip = c.Ip,
                Porta = c.Porta,
                Utente = c.Utente,
                PasswordCriptata = c.PasswordCriptata,
                PathFinale = c.PathFinale,
                Abilitata = c.Abilitata
            }).ToList();

            AggiornaTabella();
        }

        private void AggiornaTabella()
        {
            grid.Rows.Clear();

            for (int i = 0; i < _config.Count; i++)
            {
                var cam = _config[i];

                grid.Rows.Add(
                    i + 1,
                    cam.Nome,
                    cam.Ip,
                    cam.Porta,
                    cam.Utente,
                    "********",
                    cam.PathFinale,
                    cam.Abilitata
                );
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;

            int index = grid.SelectedRows[0].Index;
            var cam = _config[index];

            txtNome.Text = cam.Nome;
            txtIp.Text = cam.Ip;
            numPorta.Value = cam.Porta;
            txtUtente.Text = cam.Utente;
            txtPassword.Text = cam.Password;
            txtPath.Text = cam.PathFinale;
            chkAbilitata.Checked = cam.Abilitata;
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (_config.Count >= 9)
            {
                MessageBox.Show("Puoi aggiungere massimo 9 telecamere.");
                return;
            }

            var cam = new CameraConfig
            {
                Nome = txtNome.Text.Trim(),
                Ip = txtIp.Text.Trim(),
                Porta = (int)numPorta.Value,
                Utente = txtUtente.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                PathFinale = txtPath.Text.Trim(),
                Abilitata = chkAbilitata.Checked
            };

            _config.Add(cam);
            AggiornaTabella();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;

            int index = grid.SelectedRows[0].Index;

            _config[index].Nome = txtNome.Text.Trim();
            _config[index].Ip = txtIp.Text.Trim();
            _config[index].Porta = (int)numPorta.Value;
            _config[index].Utente = txtUtente.Text.Trim();
            _config[index].Password = txtPassword.Text.Trim();
            _config[index].PathFinale = txtPath.Text.Trim();
            _config[index].Abilitata = chkAbilitata.Checked;

            AggiornaTabella();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;

            int index = grid.SelectedRows[0].Index;

            if (MessageBox.Show("Eliminare questa telecamera?", "Conferma",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _config.RemoveAt(index);
                AggiornaTabella();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;

            int index = grid.SelectedRows[0].Index;
            if (index == 0) return;

            var temp = _config[index];
            _config[index] = _config[index - 1];
            _config[index - 1] = temp;

            AggiornaTabella();
            grid.Rows[index - 1].Selected = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;

            int index = grid.SelectedRows[0].Index;
            if (index == _config.Count - 1) return;

            var temp = _config[index];
            _config[index] = _config[index + 1];
            _config[index + 1] = temp;

            AggiornaTabella();
            grid.Rows[index + 1].Selected = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // 🔥 SALVA ANCHE SE CHIUDI CON LA X
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                this.DialogResult = DialogResult.OK;

            base.OnFormClosing(e);
        }
    }
}
