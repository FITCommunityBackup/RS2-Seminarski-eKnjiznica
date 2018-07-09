using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Auctions;
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

namespace eKnjiznica.AdminUI.UI.Auctions
{
    public partial class AuctionsEditForm : Form
    {
        public AuctionVM Auction { get; set; }
        private IList<BooksVM> Books;
        private IApiClient apiClient;
        public AuctionsEditForm(IApiClient apiClient)
        {
            this.apiClient = apiClient;
            InitializeComponent();

            inputStartPrice.Minimum = 0;
            inputStartPrice.Maximum = Decimal.MaxValue;

            inputCurrentPrice.Minimum = 0;
            inputCurrentPrice.Maximum = Decimal.MaxValue;
            gvBooks.AutoGenerateColumns = false;
        }

        private async void AuctionsEditForm_Load(object sender, EventArgs e)
        {
            if (Auction != null)
            {
                dtpFrom.Value = Auction.StartDate;
                dtpTo.Value = Auction.EndDate;
                inputStartPrice.Value = Auction.StartPrice;
                inputCurrentPrice.Value = Auction.CurrentPrice;
                inputCurrentPrice.Value = Auction.CurrentPrice;
                cbIsActive.Checked = Auction.IsActive;
                inputAuthorName.Text = Auction.AuthorName;
                inputBookTitle.Text = Auction.BookTitle;
                cbIsActive.Enabled = true;
                btnAction.Text = Commons.Resources.LABEL_UPDATE;
            }
            else
            {
                cbIsActive.Enabled = false;
                cbIsActive.Checked = true;
                btnAction.Text = Commons.Resources.LABEL_ADD;

            }
            await BindBookData();
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            BooksVM selectedBook = GetSelectedBook();
            bool result;
            if (Auction == null)
               await CreateNewAuction(selectedBook);
            else
                 await UpdateExistingAuction(selectedBook);

            
        }

        private async Task UpdateExistingAuction(BooksVM selectedBook)
        {
            var result = await apiClient.UpdateAuction(new AuctionUpdateVM
            {
                BookId = selectedBook.Id,
                DateFrom = dtpFrom.Value,
                DateTo = dtpTo.Value,
                IsActive = cbIsActive.Checked,
                StartPrice = inputStartPrice.Value
            }, Auction.Id);

            if (result.IsSuccessStatusCode)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private async Task CreateNewAuction(BooksVM selectedBook)
        {
            var result = await apiClient.CreateAuction(new AuctionCreateVM
            {
                BookId = selectedBook.Id,
                DateFrom = dtpFrom.Value,
                DateTo = dtpTo.Value,
                StartPrice = inputStartPrice.Value
            });

            if (result.IsSuccessStatusCode)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


     

        private BooksVM GetSelectedBook()
        {
            if (gvBooks.CurrentRow == null)
                return null;
            var selectedRow = gvBooks.CurrentCell.RowIndex;
            return Books[selectedRow];
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindBookData();
        }

        private async Task BindBookData()
        {
            var result = await apiClient.GetBooks(inputBookTitle.Text.Trim(), inputAuthorName.Text.Trim(),false);
            if (result.IsSuccessStatusCode)
            {
                Books = await result.Content.ReadAsAsync<IList<BooksVM>>();
                gvBooks.DataSource = Books;
            }
        }

        private void dtpFrom_Validating(object sender, CancelEventArgs e)
        {
            var startDate = dtpFrom.Value;
            var endDate= dtpTo.Value;
            if(startDate>endDate)
            {
                errorProvider1.SetError(dtpFrom, Commons.Resources.ERR_DATE_FROM_MUST_BE_BEFORE_DATE_TO);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dtpFrom, null);
                e.Cancel = false;
            }
        }

        private void dtpTo_Validating(object sender, CancelEventArgs e)
        {
            var startDate = dtpFrom.Value;
            var endDate = dtpTo.Value;
            if (endDate < startDate)
            {
                errorProvider1.SetError(dtpTo, Commons.Resources.ERR_DATE_TO_MUST_BE_AFTER_DATE_FROM);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dtpTo, null);
                e.Cancel = false;
            }
        }

        private void inputStartPrice_Validating(object sender, CancelEventArgs e)
        {
            var startPrice = inputStartPrice.Value;
            if (startPrice<=0)
            {
                errorProvider1.SetError(inputStartPrice, Commons.Resources.ENTER_VALID_AMOUNT);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(inputStartPrice, null);
                e.Cancel = false;
            }
        }

        private void gvBooks_Validating(object sender, CancelEventArgs e)
        {
            if (Books == null || gvBooks.CurrentCell == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(gvBooks, Commons.Resources.ERR_SELECT_ONE_BOOK);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(gvBooks, null);
            }
        }
    }
}
