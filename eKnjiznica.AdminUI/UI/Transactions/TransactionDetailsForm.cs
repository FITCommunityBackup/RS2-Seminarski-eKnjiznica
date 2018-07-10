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
    public partial class TransactionDetailsForm : Form
    {
        public TransactionVM Transaction { get; set; }
        private IUnityContainer unityContainer;
        public TransactionDetailsForm(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            InitializeComponent();
            
        }

      
        private void TransactionDetailsForm_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            textAmount.Minimum = Decimal.MinValue;
            textAmount.Maximum = Decimal.MaxValue;

            textAdmin.Text = Transaction.AdminUsername;
            textAmount.Value = Transaction.Amount;
            dtpDate.Value = Transaction.Date;
            textBuyer.Text = Transaction.ClientUsername;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var form = unityContainer.Resolve<TransactionReportForm>();
            form.Transaction = Transaction;
            form.Show();
        }
    }
}
