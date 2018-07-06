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

namespace eKnjiznica.AdminUI.UI.Transactions
{
    public partial class TransactionBooksPurchaseDetails : Form
    {
        public TransactionVM Transaction { get; set; }
        public TransactionBooksPurchaseDetails()
        {
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
    }
}
