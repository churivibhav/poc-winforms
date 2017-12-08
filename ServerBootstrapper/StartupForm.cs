using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Owin.Hosting;
using ServerBootstrapper.Properties;

namespace ServerBootstrapper
{
    public partial class StartupForm : Form
    {
        private IDisposable _webapp;
        public StartupForm()
        {
            InitializeComponent();
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            _webapp = WebApp.Start<Server.Startup>(txtServiceUrl.Text);
            lblServiceStatus.Text = Resources.StartupForm_btnStartService_Click_Started;
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            _webapp.Dispose();
            lblServiceStatus.Text = "Stopped";
        }
    }
}
