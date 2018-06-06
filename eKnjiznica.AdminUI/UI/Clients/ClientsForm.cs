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
using Unity;

namespace eKnjiznica.AdminUI.UI.Clients
{
    public partial class ClientsForm : Form
    {
        private IApiClient apiClient;
        private IList<ClientVM> clients;
        private IUnityContainer unityContainer;
        public ClientsForm(IApiClient apiClient,IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            this.apiClient = apiClient;

            InitializeComponent();

            gvClients.AutoGenerateColumns = false;
            gvClients.AutoSize = true;
            gvClients.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
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

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = unityContainer.Resolve<ClientEditForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindDataSource();
            }
        }

        private async void btnDetails_Click(object sender, EventArgs e)
        {
            if (clients == null || gvClients.CurrentCell == null)
                return;
            var selectedRow = gvClients.CurrentCell.RowIndex;

            var form = unityContainer.Resolve<ClientEditForm>();
            form.Client= clients[selectedRow];
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindDataSource();
            }

        }
    }
}
