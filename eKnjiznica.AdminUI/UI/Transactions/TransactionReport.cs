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
    public partial class TransactionReport : Form
    {
        public TransactionVM Transaction { get; set; }
        public TransactionReport()
        {
            InitializeComponent();
        }

        private void TransactionReport_Load(object sender, EventArgs e)
        {

        }
    }
}
