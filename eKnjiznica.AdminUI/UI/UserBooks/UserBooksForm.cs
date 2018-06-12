using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.UI.Transactions;
using eKnjiznica.Commons.ViewModels.ClientBook;
using eKnjiznica.Commons.ViewModels.TransactionVM;
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

namespace eKnjiznica.AdminUI.UI.UserBooks
{
    public partial class UserBooksForm : Form
    {
        private IApiClient apiClient;
        private IList<ClientBookVM> ClientBooks;
        private IUnityContainer unityContainer;
        public UserBooksForm(IApiClient apiClient,IUnityContainer unityContainer)
        {
            this.apiClient = apiClient;
            this.unityContainer = unityContainer;

            InitializeComponent();
            gvClientBooks.AutoGenerateColumns = false;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindData();
        }

        private async void UserBooksForm_Load(object sender, EventArgs e)
        {
            await BindData();

        }

        private async Task BindData()
        {
            var result = await apiClient
                .GetPurchaces(inputBookTitle.Text.Trim(), inputAuthor.Text.Trim(), inputClient.Text.Trim());

            if (!result.IsSuccessStatusCode)
                return;

            ClientBooks = await result.Content.ReadAsAsync<IList<ClientBookVM>>();
            gvClientBooks.DataSource = ClientBooks;
        }

        private async void btnDetails_Click(object sender, EventArgs e)
        {
            if (ClientBooks == null || gvClientBooks.CurrentCell == null)
                return;
            var selectedRow = gvClientBooks.CurrentCell.RowIndex;

            var result = await apiClient.GetTransaction(ClientBooks[selectedRow].TransactionId);
            if (!result.IsSuccessStatusCode)
                return;

            var form = unityContainer.Resolve<TransactionBooksPurchaseDetails>();


            form.Transaction = await result.Content.ReadAsAsync<TransactionVM>();
            form.Show();
        }
    }
}
