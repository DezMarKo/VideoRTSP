using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProvaTelecamere
{
    public partial class Form1 : Form
    {
        private TableLayoutPanel grid;
        private LibVLC libvlc;
        private List<MediaPlayer> players = new();

        private List<CameraConfig> _configTelecamere;

        public Form1()
        {
            InitializeComponent();
            Core.Initialize();

            libvlc = new LibVLC("--rtsp-tcp", "--network-caching=300");

            _configTelecamere = CameraStorage.Load();

            CreaGriglia();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RicaricaTelecamere();
        }

        // -------------------------------
        // GRIGLIA VIDEO
        // -------------------------------
        private void CreaGriglia()
        {
            grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            };

            panelContainer.Controls.Add(grid);
        }

        private void RicaricaTelecamere()
        {
            var urls = _configTelecamere
                .Where(c => c.Abilitata)
                .Select(c => c.GetRtspUrl())
                .Where(u => !string.IsNullOrWhiteSpace(u))
                .ToList();

            MostraTelecamere(urls);
        }

        private (int rows, int cols) CalcolaGriglia(int n)
        {
            if (n <= 1) return (1, 1);
            if (n == 2) return (1, 2);
            if (n <= 4) return (2, 2);
            if (n <= 6) return (2, 3);
            if (n <= 9) return (3, 3);
            return (4, 4);
        } //AGGIUNGERE VALORI A GRIGLIA PER MAGGIOR NUMERO DI TELECAMERE

        private void MostraTelecamere(List<string> urls)
        {
            grid.Controls.Clear();
            players.Clear();

            var (rows, cols) = CalcolaGriglia(urls.Count);

            grid.RowCount = rows;
            grid.ColumnCount = cols;

            grid.RowStyles.Clear();
            grid.ColumnStyles.Clear();

            for (int r = 0; r < rows; r++)
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));

            for (int c = 0; c < cols; c++)
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            int index = 0;

            foreach (var url in urls)
            {
                var panel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.Black
                };

                grid.Controls.Add(panel, index % cols, index / cols);

                _ = CaricaTelecamera(url, panel);

                index++;
            }
        }

        // -------------------------------
        // CARICAMENTO TELECAMERA
        // -------------------------------
        private async Task CaricaTelecamera(string url, Panel panel)
        {
            try
            {
                var player = new MediaPlayer(libvlc);
                players.Add(player);

                var view = new VideoView
                {
                    Dock = DockStyle.Fill,
                    MediaPlayer = player
                };

                SafeUI(() => panel.Controls.Add(view));

                using var media = new Media(libvlc, url, FromType.FromLocation);
                player.Play(media);

                player.EncounteredError += (s, e) =>
                {
                    MostraErroreElegante(panel, url);
                };

                player.Stopped += (s, e) =>
                {
                    MostraErroreElegante(panel, url);
                };

                await Task.Delay(2000);

                if (!player.IsPlaying)
                    MostraErroreElegante(panel, url);
            }
            catch
            {
                MostraErroreElegante(panel, url);
            }
        }

        // -------------------------------
        // RIQUADRO ERRORE
        // -------------------------------
        private void MostraErroreElegante(Panel panel, string url)
        {
            SafeUI(() =>
            {
                panel.Controls.Clear();

                var container = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 3,
                    BackColor = Color.Black
                };

                container.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
                container.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
                container.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

                var lbl = new Label
                {
                    Text = "CONNESSIONE PERSA",
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var btn = new Button
                {
                    Text = "RICONNETTI",
                    Width = 180,
                    Height = 45,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    BackColor = Color.FromArgb(40, 40, 40),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                btn.FlatAppearance.BorderSize = 0;

                btn.Click += async (s, e) =>
                {
                    panel.Controls.Clear();
                    await Task.Delay(200);
                    _ = CaricaTelecamera(url, panel);
                };

                var btnPanel = new Panel { Dock = DockStyle.Fill };
                btnPanel.Controls.Add(btn);
                btn.Anchor = AnchorStyles.None;
                btn.Left = (btnPanel.Width - btn.Width) / 2;
                btn.Top = (btnPanel.Height - btn.Height) / 2;

                container.Controls.Add(new Panel(), 0, 0);
                container.Controls.Add(lbl, 0, 1);
                container.Controls.Add(btnPanel, 0, 2);

                panel.Controls.Add(container);
            });
        }

        private void SafeUI(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        // -------------------------------
        // MENU TELECAMERE
        // -------------------------------
        private void telecamereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var frm = new CameraSettingsForm(_configTelecamere);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _configTelecamere = frm.ConfigTelecamereAggiornate;
                CameraStorage.Save(_configTelecamere);
                RicaricaTelecamere();
            }
        }

     
    }
}
