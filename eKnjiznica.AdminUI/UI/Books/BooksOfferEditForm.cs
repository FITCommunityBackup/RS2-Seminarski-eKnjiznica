using eKnjiznica.AdminUI.Services.API;
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

namespace eKnjiznica.AdminUI.UI.Books
{
    public partial class BooksOfferEditForm : Form
    {
        private IApiClient apiClient;

        public BookOfferVM BookOfferVM { get; set; }

        private IList<BooksVM> Books;

        public BooksOfferEditForm(IApiClient apiClient)
        {
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            this.apiClient = apiClient;

            InitializeComponent();
            gvBooks.AutoGenerateColumns = false;
            gvBooks.AutoSize = true;
            gvBooks.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void toggleForm()
        {
            if (BookOfferVM == null)
            {
                cbIsActive.Visible = false;
                btnAction.Text = Commons.Resources.LABEL_ADD;
            }
            else
            {
                cbIsActive.Visible = true;
                inputAuthorName.Text = BookOfferVM.AuthorName;
                inputBookTitle.Text = BookOfferVM.Title;
                inputPrice.Value = BookOfferVM.Price;
                cbIsActive.Checked = BookOfferVM.IsActive;
                btnAction.Text = Commons.Resources.LABEL_UPDATE;
            }
        }

        private async Task BindData()
        {
            var result = await apiClient.GetBooks(inputBookTitle.Text.Trim(), inputAuthorName.Text.Trim());
            if (result.IsSuccessStatusCode)
            {
                Books = await result.Content.ReadAsAsync<IList<BooksVM>>();
                gvBooks.DataSource = Books;
            }
        }
        private async void BooksOfferEditForm_Load(object sender, EventArgs e)
        {
            toggleForm();

            await BindData();

        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindData();
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            BooksVM selectedBook = GetSelectedBook();
            if (BookOfferVM == null)
                await CreateNewBook(selectedBook);
            else
                await UpdateExistingBook(selectedBook);


        }

        private async Task UpdateExistingBook(BooksVM selectedBook)
        {
            var bookOfferUpdate = new UpdateBookOfferVM
            {
                BookId = selectedBook.Id,
                IsActive = cbIsActive.Checked,
                Price = inputPrice.Value

            };
            var result = await apiClient.UpdateExistingBookOffer(bookOfferUpdate, BookOfferVM.Id);
            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async Task CreateNewBook(BooksVM selectedBook)
        {
            var bookOfferCreate = new CreateBookOfferVM
            {
                BookId = selectedBook.Id,
                Price = inputPrice.Value
            };
            var result = await apiClient.CreateBookOffer(bookOfferCreate);
            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private BooksVM GetSelectedBook()
        {
            var selectedRow = gvBooks.CurrentCell.RowIndex;
            return Books[selectedRow];
        }

        private void gvBooks_Validating(object sender, CancelEventArgs e)
        {
            if (Books==null || gvBooks.CurrentCell == null)
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

        private void inputPrice_Validating(object sender, CancelEventArgs e)
        {
            if (inputPrice.Value <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(inputPrice, Commons.Resources.ERR_ENTER_VALID_PRICE);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(inputPrice, null);
            }
        }
    }
}
