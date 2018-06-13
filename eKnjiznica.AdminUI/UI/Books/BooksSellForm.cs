using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Books;
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

namespace eKnjiznica.AdminUI.UI.Books
{
    public partial class BooksSellForm : Form
    {
        private IUnityContainer unityContainer;
        private IApiClient apiClient;
        private IList<BookOfferVM> BookOffers;
        public BooksSellForm(IApiClient apiClient,IUnityContainer unityContainer)
        {
            this.apiClient = apiClient;
            this.unityContainer = unityContainer;
            InitializeComponent();
            gvBookOffers.AutoGenerateColumns = false;
            gvBookOffers.AutoSize = true;
            gvBookOffers.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private async void BooksSellForm_Load(object sender, EventArgs e)
        {
            await BindData();
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindData();
        }
        private async Task BindData()
        {
            var result = await apiClient.GetBookOffers(inputBookTitle.Text.Trim(), inputAuthorName.Text.Trim(),cbInactive.Checked);
            if (result.IsSuccessStatusCode)
            {
                BookOffers = await result.Content.ReadAsAsync<IList<BookOfferVM>>();
                gvBookOffers.DataSource = BookOffers;
            }
        }

        private async void btnDetails_Click(object sender, EventArgs e)
        {
            if (BookOffers == null || gvBookOffers.CurrentCell == null)
                return;
            var selectedRow = gvBookOffers.CurrentCell.RowIndex;

            var form = unityContainer.Resolve<BooksOfferEditForm>();
            form.BookOfferVM = BookOffers[selectedRow];
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindData();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var form = unityContainer.Resolve<BooksOfferEditForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindData();
            }
        }
    }
}
