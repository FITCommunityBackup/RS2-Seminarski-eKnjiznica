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
    public partial class TransactionDetailsForm : Form
    {
        public TransactionVM Transaction { get; set; }
        public TransactionDetailsForm()
        {
            InitializeComponent();
            
        }

      
        private void TransactionDetailsForm_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            textAmount.Minimum = 0;
            textAmount.Maximum = Decimal.MaxValue;

            textAdmin.Text = Transaction.AdminUsername;
            textAmount.Value = Transaction.Amount;
            dtpDate.Value = Transaction.Date;
            textBuyer.Text = Transaction.ClientUsername;
        }

    }
}
