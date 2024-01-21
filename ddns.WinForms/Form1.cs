using System.Net.Http.Json;

namespace ddns
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private HttpClient httpClient = new HttpClient();
        private bool exit = false;
        private ContextMenuStrip contextMenuStrip;
        private bool backgroundNotified = false;
        private ToolStripMenuItem stopMenuItem;
        private ToolStripMenuItem startMenuItem;
        private bool started = false;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
        }

        private async void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Synchronize();
        }

        private async void Synchronize()
        {
            var ip = await GetIp();
            if (ip != Settings.ReadIp())
            {
                UpdateIp();
            }
        }

        private async Task<string> GetIp()
        {
            return await httpClient.GetStringAsync($"{Settings.ReadCredentials().Host}?password={Settings.ReadCredentials().Password}");
        }

        private async void UpdateIp()
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync($"{Settings.ReadCredentials().Host}?username={Settings.ReadCredentials().Username}&password={Settings.ReadCredentials().Password}", "");
                if (started)
                {
                    response.EnsureSuccessStatusCode();
                    ChangeStatusText("Sincronizado", Color.Green);
                    string ip = await response.Content.ReadAsStringAsync();
                    ChangeStatusText("Sincronizado", Color.Green);
                    ChangeIpText(ip);
                    Settings.SaveIp(ip);
                }
            }
            catch
            {
                if (started)
                {
                    ChangeStatusText("Error", Color.Red);
                }
            }
        }
        private void ChangeStatusText(string text, Color color)
        {
            Invoke(() =>
            {
                statusText.ForeColor = color;
                statusText.Text = text;
            });
        }

        private void ChangeIpText(string text)
        {
            Invoke(() =>
            {
                ipText.Text = text;
            });
        }

        private void ChangeNotifyText(string text)
        {
            Invoke(() =>
            {
                notifyIcon1.Text = text;
            });
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            statusText.Text = "";
            ipText.Text = "";
            notifyIcon1.Text = "";

            contextMenuStrip = new ContextMenuStrip();
            stopMenuItem = new ToolStripMenuItem("Detener");
            startMenuItem = new ToolStripMenuItem("Iniciar");
            startMenuItem.Visible = false;
            stopMenuItem.Visible = false;
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Salir");
            stopMenuItem.Click += StopMenuItem_Click;
            startMenuItem.Click += StartMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            contextMenuStrip.Items.Add(startMenuItem);
            contextMenuStrip.Items.Add(stopMenuItem);
            contextMenuStrip.Items.Add(exitMenuItem);
            notifyIcon1.ContextMenuStrip = contextMenuStrip;

            await Task.Yield();
            if (Settings.Initialize())
            {
                Start();
            }
            else
            {
                ChangeStatusText("Detenido", Color.LightYellow);
                ChangeIpText("No configurado");
                Stop();
            }
        }

        private void StartMenuItem_Click(object? sender, EventArgs e)
        {
            Start();
        }

        private void StopMenuItem_Click(object? sender, EventArgs e)
        {
            Stop();
        }

        private void ExitMenuItem_Click(object? sender, EventArgs e)
        {
            Exit();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var config = new authenticationForm();
            if(config.ShowDialog() == DialogResult.OK)
            {
                timer.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            if (!exit)
            {
                e.Cancel = true;
                if(!backgroundNotified)
                {
                    backgroundNotified = true;
                    notifyIcon1.BalloonTipTitle = "En ejecución";
                    notifyIcon1.BalloonTipText = "El programa seguirá ejecutándose en segundo plano.";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(5000);
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Activate();
        }

        private void Stop()
        {
            started = false;
            startMenuItem.Visible = true;
            stopMenuItem.Visible = false;
            iniciarToolStripMenuItem.Visible = true;
            detenerToolStripMenuItem.Visible = false;
            timer.Stop();
            ChangeStatusText("Detenido", SystemColors.ControlText);
        }

        private async void Start()
        {
            try
            {
                if (Settings.IsConfigured())
                {
                    started = true;
                    startMenuItem.Visible = false;
                    stopMenuItem.Visible = true;
                    iniciarToolStripMenuItem.Visible = false;
                    detenerToolStripMenuItem.Visible = true;
                    ChangeStatusText("Iniciando...", SystemColors.ControlText);
                    var response = await httpClient.PostAsJsonAsync($"{Settings.ReadCredentials().Host}?username={Settings.ReadCredentials().Username}&password={Settings.ReadCredentials().Password}", "");
                    response.EnsureSuccessStatusCode();
                    if (started)
                    {
                        string ip = await response.Content.ReadAsStringAsync();
                        ChangeStatusText("Sincronizado", Color.Green);
                        ChangeIpText(ip);
                        ChangeNotifyText(ip);
                        Settings.SaveIp(ip);
                        timer.Start();
                    }

                }
                else
                {
                    started = false;
                    startMenuItem.Visible = true;
                    stopMenuItem.Visible = false;
                    iniciarToolStripMenuItem.Visible = true;
                    detenerToolStripMenuItem.Visible = false;
                    ChangeStatusText("Detenido", Color.LightYellow);
                    ChangeIpText("No configurado");
                }
            }
            catch
            {
                MessageBox.Show("Hay errores en la configuración. Por favor, revisa que la URL sea completa.", "Error en la configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                started = false;
                startMenuItem.Visible = true;
                stopMenuItem.Visible = false;
                iniciarToolStripMenuItem.Visible = true;
                detenerToolStripMenuItem.Visible = false;
                ChangeStatusText("Detenido", Color.LightYellow);
                ChangeIpText("No configurado");
            }
        }

        private void Exit()
        {
            exit = true;
            Close();
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void detenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
}



