using eKnjiznica.AdminUI.Reports;
using eKnjiznica.Commons.ViewModels.TransactionVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace eKnjiznica.AdminUI.UI.Transactions
{
    public partial class TransactionBooksPurchaseDetails : Form
    {
        public TransactionVM Transaction { get; set; }
        IUnityContainer unityContainer;
        public TransactionBooksPurchaseDetails(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            InitializeComponent();
            gvClientBooks.AutoGenerateColumns = false;
        }

        private void TransactionBooksPurchaseDetails_Load(object sender, EventArgs e)
        {

            textAmount.Minimum = Decimal.MinValue;
            textAmount.Maximum = Decimal.MaxValue;

            textAmount.Value = Transaction.Amount;
            dtpDate.Value = Transaction.Date;
            textBuyer.Text = Transaction.ClientUsername;
            gvClientBooks.DataSource = Transaction.BuyedBooks;
        }

     

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var form = unityContainer.Resolve<TransactionReportForm>();
            form.Transaction = Transaction;
            form.Show();
        }
    }
}
