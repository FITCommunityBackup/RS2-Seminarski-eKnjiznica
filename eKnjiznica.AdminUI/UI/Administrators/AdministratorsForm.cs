using eKnjiznica.AdminUI.Properties;
using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.Services.User;
using eKnjiznica.AdminUI.UI.Administrators;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels;
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

namespace eKnjiznica.AdminUI.UI.Administrators
{
    public partial class AdministratorsForm : Form
    {
        private IApiClient apiClient;
        private IUnityContainer unityContainer;
        private IList<AdministratorProfileVM> adminAccounts;
        public AdministratorsForm(IApiClient apiClient, IUnityContainer unityContainer)
        {

            this.apiClient = apiClient;
            this.unityContainer = unityContainer;
            InitializeComponent();

            gvAdministrators.AutoGenerateColumns = false;
            gvAdministrators.AutoSize = true;
            gvAdministrators.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private async void AdministratorsForm_Load(object sender, EventArgs e)
        {
            await BindDataSource();
        }

        private async Task BindDataSource()
        {
            var result = await this.apiClient.LoadAminAccounts(txtUserNameFilter.Text.Trim());
            if (result.IsSuccessStatusCode)
            {
                var re = await result.Content.ReadAsAsync<IList<Commons.ViewModels.AdministratorProfileVM>>();
                adminAccounts = re;
                gvAdministrators.DataSource = re;
            }

        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindDataSource();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (adminAccounts == null || gvAdministrators.CurrentCell == null)
                return;
            var selectedRow = gvAdministrators.CurrentCell.RowIndex;

            var form  = unityContainer.Resolve<AdministratorEditForm>();
            form.Administrator = adminAccounts[selectedRow];
            if(form.ShowDialog()==DialogResult.OK)
            {
                await BindDataSource();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var form = unityContainer.Resolve<AdministratorAddForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindDataSource();
            }
        }
    }
}
