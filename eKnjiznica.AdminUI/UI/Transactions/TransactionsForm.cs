using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.ViewModels;
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

namespace eKnjiznica.AdminUI.UI.Transactions
{
    public partial class TransactionsForm : Form
    {
        private IApiClient apiClient;
        private IList<TransactionVM> transactions;
        public TransactionsForm(IApiClient apiClient)
        {
            this.apiClient = apiClient;
            InitializeComponent();

            gvTransactions.AutoGenerateColumns = false;

        }

        private void gvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void TransactionsForm_Load(object sender, EventArgs e)
        {

            await BindData();
        }

        private async Task BindData()
        {
            var username = txtUserNameFilter.Text.Trim();
            var adminUsername= txtAdminUsername.Text.Trim();

            HttpResponseMessage result = await apiClient.GetTransactions(username,adminUsername);

            if (result.IsSuccessStatusCode){
                transactions = await result.Content.ReadAsAsync<IList<TransactionVM>>();
                gvTransactions.DataSource = transactions;
            }
            
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindData();
        }

        private void gvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4) // column of the enum
            {
                try
                {
                    e.Value = getEnumStringValue((TransactionType)e.Value);
                }
                catch (Exception ex)
                {
                    e.Value = ex.Message;
                }
            }
        }

        private object getEnumStringValue(TransactionType value)
        {
            switch (value)
            {
                case TransactionType.PAY_IN:
                    return Commons.Resources.TRANSACTION_TYPE_PAY_IN;
                case TransactionType.BUY:
                    return Commons.Resources.TRANSACTION_TYPE_BUY;
                default:
                    return "---";
            }
        }
    }
}
