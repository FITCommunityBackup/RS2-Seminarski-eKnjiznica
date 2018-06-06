using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.ViewModels.Clients;
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

namespace eKnjiznica.AdminUI.UI.Clients
{
    public partial class ClientsForm : Form
    {
        private IApiClient apiClient;
        private IList<ClientVM> clients;
        public ClientsForm(IApiClient apiClient)
        {
            this.apiClient = apiClient;
            InitializeComponent();
        }

        private async void ClientsForm_Load(object sender, EventArgs e)
        {
            await BindDataSource();
        }

        private async Task BindDataSource()
        {
            var result = await this.apiClient.LoadClientAccounts(txtUserNameFilter.Text.Trim(),cbIncludeInactive.Checked);
            if (result.IsSuccessStatusCode)
            {
                clients = await result.Content.ReadAsAsync<IList<ClientVM>>();
                gvClients.DataSource = clients;
            }

        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindDataSource();
        }
    }
}
