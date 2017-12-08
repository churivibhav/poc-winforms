using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Newtonsoft.Json;

namespace Client
{
    public partial class ClientMain : Form
    {
        private HttpClient _httpClient;
        public ClientMain()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/Product");
            var jsonValue = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Product>>(jsonValue);
            dgvItems.DataSource = data;
        }

        private void ClientMain_Load(object sender, EventArgs e)
        {
        }
    }
}
