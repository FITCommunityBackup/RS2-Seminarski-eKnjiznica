using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Auctions;
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

namespace eKnjiznica.AdminUI.UI.Auctions
{
    public partial class AuctionsForms : Form
    {
        private IApiClient apiClient;
        private IList<AuctionVM> Auctions;
        private IUnityContainer unityContainer;
        public AuctionsForms(IApiClient apiClient,IUnityContainer unityContainer)
        {
            this.apiClient = apiClient;
            this.unityContainer = unityContainer;
            InitializeComponent();
            gvAuctions.AutoGenerateColumns = false;
        }

        private async void AuctionsForms_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now.AddDays(30);
            await BindData();
        }

        private async Task BindData()
        {
            var dateFrom = dtpFrom.Value;
            var dateTo = dtpTo.Value;
            var result = await apiClient.GetAuctions(dateFrom, dateTo,cbIncludeInactive.Checked);
            if (result.IsSuccessStatusCode)
            {
                Auctions = await result.Content.ReadAsAsync<IList<AuctionVM>>();
                gvAuctions.DataSource = Auctions;
            }
        }

        private async void btnFIlter_Click(object sender, EventArgs e)
        {
            await BindData();
        }



        private async void btnDetails_Click(object sender, EventArgs e)
        {
            if (Auctions == null || gvAuctions.CurrentRow == null)
                return;

            var auction = Auctions[gvAuctions.CurrentRow.Index];

            var form = unityContainer.Resolve<AuctionsEditForm>();
            form.Auction = auction;
            if (form.ShowDialog() == DialogResult.OK)
                await BindData();

        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = unityContainer.Resolve<AuctionsEditForm>();
            if (form.ShowDialog() == DialogResult.OK)
                await BindData();
        }

    }
}
