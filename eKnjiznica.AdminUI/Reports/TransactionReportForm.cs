using eKnjiznica.Commons.ViewModels.TransactionVM;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKnjiznica.AdminUI.Reports
{
    public partial class TransactionReportForm : Form
    {
        public TransactionVM Transaction { get; set; }
        public TransactionReportForm()
        {
            InitializeComponent();
        }

        private void TransactionReportForm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("TransactionDS",Transaction.BuyedBooks);

            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("buyer",Transaction.ClientUsername));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("transactionDate",Transaction.Date.ToString("dd.MM.yyyy")));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("totalPrice",Transaction.Amount+""));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("dateNow",DateTime.Now.ToString("dd.MM.yyyy")));
            this.reportViewer1.RefreshReport();
        }
    }
}
