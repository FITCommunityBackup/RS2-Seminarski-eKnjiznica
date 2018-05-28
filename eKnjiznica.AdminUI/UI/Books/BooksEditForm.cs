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
using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Category;

namespace eKnjiznica.AdminUI.UI.Books
{
    public partial class BooksEditForm : Form
    {

        public BooksVM Book { get; set; }
        public List<CategoryVM> Categories { get; set; }

        private IApiClient ApiClient;

        public BooksEditForm(IApiClient apiClient)
        {
            this.ApiClient = apiClient;
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            InitializeComponent();
        }

        private void toggleForm()
        {
            if (Book == null)
            {
                btnAction.Text = Commons.Resources.LABEL_ADD;
                cbIsActive.Visible = false;
            }
            else
            {
                cbIsActive.Visible = true;
                btnAction.Text = Commons.Resources.LABEL_UPDATE;

                inputBookName.Text = Book.BookTitle;
                inputAuthor.Text = Book.AuthorName;
                inputDescription.Text = Book.Description;
                cbIsActive.Checked = Book.IsActive;
                dtpReleaseDate.Value = Book.ReleaseDate;
            }
        }

        private async void BooksEditForm_Load(object sender, EventArgs e)
        {
            toggleForm();

            var result = await ApiClient.GetCategories(null, false);
            if (!result.IsSuccessStatusCode)
                return;

            Categories = await result.Content.ReadAsAsync<List<CategoryVM>>();
            foreach (var item in Categories)
            {
                cbCategories.Items.Add(item.CategoryName, isChecked: Book != null ? Book.Categories.Any(x => x.Id == item.Id) : false);
            }
        }

        private void inputBookName_Validating(object sender, CancelEventArgs e)
        {
            var text = inputBookName.Text.Trim();
            if (string.IsNullOrEmpty(text) || text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(inputBookName, Commons.Resources.ERR_BOOK_NAME_REQUIRED);
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(inputBookName, null);
            }
        }

        private void inputAuthor_Validating(object sender, CancelEventArgs e)
        {
            var text = inputAuthor.Text.Trim();
            if (string.IsNullOrEmpty(text) || text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(inputAuthor, Commons.Resources.ERR_AUTHOR_NAME_REQUIRED);
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(inputAuthor, null);
            }
        }

        private void inputDescription_Validating(object sender, CancelEventArgs e)
        {


        }

        private void cbCategories_Validating(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < cbCategories.Items.Count; i++)
            {
                if (cbCategories.GetItemChecked(i))
                {
                    e.Cancel = false;
                    errorProvider.SetError(cbCategories, null);
                    return;
                }
            }
            e.Cancel = true;
            errorProvider.SetError(cbCategories, Commons.Resources.ERR_SELECT_ONE_CATEGORY);
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            HttpResponseMessage result;
            if (Book == null)
            {
                result = await ApiClient.CreateBook(new CreateBookVM
                {
                    AuthorName = inputAuthor.Text.Trim(),
                    BookDescription = inputDescription.Text.Trim(),
                    ReleaseDate = dtpReleaseDate.Value,
                    BookTitle = inputBookName.Text.Trim(),
                    CategoriesId = GetSelectedCategories()
                });
            }
            else
            {
                result = await ApiClient.UpdateBook(new UpdateBookVM
                {

                    AuthorName = inputAuthor.Text.Trim(),
                    BookDescription = inputDescription.Text.Trim(),
                    ReleaseDate = dtpReleaseDate.Value,
                    BookTitle = inputBookName.Text.Trim(),
                    CategoriesId = GetSelectedCategories(),
                    IsActive = cbIsActive.Checked
                }, Book.Id);
            }

            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private List<int> GetSelectedCategories()
        {
            List<int> categoriesId = new List<int>();
            foreach (int indexChecked in cbCategories.CheckedIndices)
            {
                if (cbCategories.GetItemCheckState(indexChecked) == CheckState.Checked)
                    categoriesId.Add(Categories[indexChecked].Id);
            }
            return categoriesId;
        }
    }
}
