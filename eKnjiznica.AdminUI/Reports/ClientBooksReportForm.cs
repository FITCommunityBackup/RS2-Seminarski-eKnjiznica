using eKnjiznica.Commons.ViewModels.ClientBook;
using eKnjiznica.Commons.ViewModels.Clients;
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
    public partial class ClientBooksReportForm : Form
    {
        public ClientVM Client { get; set; }
        public IList<ClientBookVM> ClientBooks { get; set; }
        
        public ClientBooksReportForm()
        {
            InitializeComponent();
        }

        private void ClientBooksReportForm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("ClientBooksDS", ClientBooks);

            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("client", Client.UserName));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("totalAmount", ClientBooks.Sum(x => x.Price)+""));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("dateNow", DateTime.Now.ToString("dd.MM.yyyy")));
            this.reportViewer1.RefreshReport();
        }
    }
}
