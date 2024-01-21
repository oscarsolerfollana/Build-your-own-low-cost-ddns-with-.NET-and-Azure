using ddns.Models;

namespace ddns
{
    public partial class authenticationForm : Form
    {
        public authenticationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Credentials userCredentials = new Credentials
            {
                Host = host.Text,
                Username = user.Text,
                Password = password.Text
            };

            Settings.SaveCredentials(userCredentials);

            DialogResult = DialogResult.OK;
        }

        private void authenticationForm_Load(object sender, EventArgs e)
        {
            host.Text = Settings.ReadCredentials().Host;
            user.Text = Settings.ReadCredentials().Username;
            password.Text = Settings.ReadCredentials().Password;
            host.SelectionStart = 0;
            host.SelectionLength = host.Text.Length;
        }
    }
}
