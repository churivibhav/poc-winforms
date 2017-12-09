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
using Data.Models;
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

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            var product = new Product
            {
                Id = random.Next(1, 100),
                Code = "ABCD",
                Name = "ABCD ABCD",
                SalesRate = Convert.ToDecimal(random.NextDouble())
            };
            var content = new StringContent(JsonConvert.SerializeObject(product));
            await _httpClient.PostAsync("http://localhost:8080/api/Product", content);

        }
    }
}
