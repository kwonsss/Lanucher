using System;
using System.Windows.Forms;

namespace Lanucher
{
    public partial class MainForm : Form
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;

        public MainForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
        }

        private void InitializeNotifyIcon()
        {
            // 컨텍스트 메뉴
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("프로그램 열기", null, (s, e) => ShowMainForm());
            contextMenuStrip.Items.Add("종료", null, (s, e) => Application.Exit());

            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Text = "Lanucher",
                ContextMenuStrip = contextMenuStrip,
                Visible = true
            };

            notifyIcon.DoubleClick += (s, e) => ShowMainForm();
        }

        private void ShowMainForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
