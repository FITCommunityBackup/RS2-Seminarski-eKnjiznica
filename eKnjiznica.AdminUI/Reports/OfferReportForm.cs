using eKnjiznica.Commons.ViewModels.Books;
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
    public partial class OfferReportForm : Form
    {

        public IList<BookOfferVM> BookOffers { get; set; }
        public OfferReportForm()
        {
            InitializeComponent();
        }

        private void OfferReportForm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("OfferDS", BookOffers);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("dateNow", DateTime.Now.ToString("dd.MM.yyyy")));
            this.reportViewer1.RefreshReport();
        }
    }
}
