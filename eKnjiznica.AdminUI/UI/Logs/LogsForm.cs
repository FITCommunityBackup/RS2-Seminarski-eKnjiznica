using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels;
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

namespace eKnjiznica.AdminUI.UI.Logs
{
    public partial class LogsForm : Form
    {
        IApiClient apiClient;
        public LogsForm(IApiClient apiClient)
        {
            this.apiClient = apiClient;
            InitializeComponent();
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private async void BindGrid()
        {
            var result = await apiClient.GetAuditLogs();
            if (result.IsSuccessStatusCode)
            {
                gvLogs.DataSource = await result.Content.ReadAsAsync<List<LogsVM>>();
                
            }
        }
    }
}
