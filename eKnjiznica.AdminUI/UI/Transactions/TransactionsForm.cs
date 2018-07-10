using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
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
using Unity;

namespace eKnjiznica.AdminUI.UI.Transactions
{
    public partial class TransactionsForm : Form
    {
        private IApiClient apiClient;
        private IList<TransactionVM> transactions;
        private IUnityContainer unityContainer;
        public TransactionsForm(IApiClient apiClient,IUnityContainer unityContainer)
        {
            this.apiClient = apiClient;
            this.unityContainer = unityContainer;
            InitializeComponent();

            gvTransactions.AutoGenerateColumns = false;

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

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (transactions == null || gvTransactions.CurrentCell == null)
                return;
            var selectedRow = gvTransactions.CurrentCell.RowIndex;
            var transaction = transactions[selectedRow];
            switch (transaction.TransactionType)
            {
                case TransactionType.PAY_IN:
                    displayPayInForm(transaction);
                    break;
                case TransactionType.BUY:
                    displayBuyInForm(transaction);
                    break;
            }
         
        }

        private void displayBuyInForm(TransactionVM transaction)
        {
            var form = unityContainer.Resolve<TransactionBooksPurchaseDetails>();
            form.Transaction = transaction;
            form.Show();
        }

        private void displayPayInForm(TransactionVM transaction)
        {
            var form = unityContainer.Resolve<TransactionDetailsForm>();
            form.Transaction = transaction;

            form.Show();
        }
    }
}
