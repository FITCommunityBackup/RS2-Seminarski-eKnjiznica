using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eKnjiznica.AdminUI.Services;
using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Category;

namespace eKnjiznica.AdminUI.UI.Books
{
    public partial class BooksEditForm : Form
    {

        public BooksVM Book { get; set; }
        public List<CategoryVM> Categories { get; set; }
        private IApiClient ApiClient;
        private ImageHelper imageHelper;
        private string fileLocation;
        private string fileName;
        private byte[] uploadImage;
        private string imageName;
        public BooksEditForm(IApiClient apiClient, ImageHelper imageHelper)
        {
            this.ApiClient = apiClient;
            this.imageHelper = imageHelper;
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            InitializeComponent();
        }

        private void toggleForm()
        {
            pbLoading.Visible = false;

            if (Book == null)
            {
                btnAction.Text = Commons.Resources.LABEL_ADD;
                cbIsActive.Visible = false;
                btnDownload.Visible = false;
            }
            else
            {
                btnDownload.Visible = string.IsNullOrEmpty(Book.FileLocation) ? false : true;
                cbIsActive.Visible = true;
                btnAction.Text = Commons.Resources.LABEL_UPDATE;

                inputBookName.Text = Book.BookTitle;
                inputAuthor.Text = Book.AuthorName;
                inputDescription.Text = Book.Description;
                cbIsActive.Checked = Book.IsActive;
                dtpReleaseDate.Value = Book.ReleaseDate;
                if (Book.ImageLocation != null)
                {
                    pictureBox.Load(ConfigurationManager.AppSettings["ApiUrl"] + "/" + Book.ImageLocation);
                }
            }
        }


        private async Task UploadExistingBook()
        {
            HttpResponseMessage result = await ApiClient.UpdateBook(new UpdateBookVM
            {

                AuthorName = inputAuthor.Text.Trim(),
                BookDescription = inputDescription.Text.Trim(),
                ReleaseDate = dtpReleaseDate.Value,
                BookTitle = inputBookName.Text.Trim(),
                CategoriesId = GetSelectedCategories(),
                IsActive = cbIsActive.Checked
            }, Book.Id);

            if (!result.IsSuccessStatusCode)
            {
                return;
            }
            var fileUploadResult = true;
            if (fileLocation != null)
            {
                var stream = new FileStream(fileLocation, FileMode.Open);
                var uploadResult = await ApiClient.UploadFile(stream, fileName, Book.Id);
                fileUploadResult = uploadResult.IsSuccessStatusCode;
            }
            var imageUplaodResult = true;
            if (uploadImage != null)
            {
                var r = await ApiClient.UploadBookPicture(uploadImage, imageName, Book.Id);
                imageUplaodResult = r.IsSuccessStatusCode;
            }

            if (fileUploadResult && imageUplaodResult)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async Task CreateNewBook()
        {
            HttpResponseMessage result = await ApiClient.CreateBook(new CreateBookVM
            {
                AuthorName = inputAuthor.Text.Trim(),
                BookDescription = inputDescription.Text.Trim(),
                ReleaseDate = dtpReleaseDate.Value,
                BookTitle = inputBookName.Text.Trim(),
                CategoriesId = GetSelectedCategories()
            });

            if (!result.IsSuccessStatusCode)
            {
                return;
            }

            var createdBook = await result.Content.ReadAsAsync<BooksVM>();

            var uploadPicture = await ApiClient.UploadBookPicture(uploadImage, imageName, createdBook.Id);

            var stream = new FileStream(fileLocation, FileMode.Open);
            var uploadResult = await ApiClient.UploadFile(stream, fileName, createdBook.Id);
            if (uploadResult.IsSuccessStatusCode && uploadPicture.IsSuccessStatusCode)
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF Knjiga |*.pdf"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time

            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                fileLocation = dialog.FileName; // get name of file
                fileName = dialog.SafeFileName;
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            var result = await ApiClient.GetBookFile(Book.Id);
            if (!result.IsSuccessStatusCode)
            {
                MessageBox.Show(Commons.Resources.ERR_DOWNLOADING_BOOK_FILE);
                return;
            }
            var data = await result.Content.ReadAsByteArrayAsync();

            var tempFolder = Path.GetTempPath();
            var filename = Path.Combine(tempFolder, Book.FileName);
            File.WriteAllBytes(filename, data);
            System.Diagnostics.Process.Start(filename);
        }
        private async void btnAction_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;
            pbLoading.Visible = true;

            if (Book == null)
                await CreateNewBook();
            else
                await UploadExistingBook();
            pbLoading.Visible = false;

        }

        #region Validation
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

        #endregion

        private void dodajSlikuButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Slika |*.BMP;*.JPG;*.JPEG;*.PNG;*img"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time

            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                inputPicture.Text = dialog.FileName;

                Image originalImage = Image.FromFile(inputPicture.Text);
                Image imageForUpload = GetImageForUpload(originalImage);

                MemoryStream ms = new MemoryStream();
                imageForUpload.Save(ms, originalImage.RawFormat);
                uploadImage = ms.ToArray();

                imageName = dialog.SafeFileName;
            }
            else
            {
                uploadImage = null;
            }
        }

        private Image GetImageForUpload(Image orgImage)
        {
            int resizedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgWidth"]);
            int resizedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgHeight"]);
            int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
            int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

            if (orgImage.Width > resizedImgWidth)
            {
                Image resizedImg = imageHelper.ResizeImage(orgImage, new Size(resizedImgWidth, resizedImgHeight));

                if (resizedImg.Width > croppedImgWidth && resizedImg.Height > croppedImgHeight)
                {
                    int croppedXPosition = (resizedImg.Width - croppedImgWidth) / 2;
                    int croppedYPosition = (resizedImg.Height - croppedImgHeight) / 2;

                    Image croppedImg = imageHelper.CropImage(resizedImg, new Rectangle(croppedXPosition, croppedYPosition, croppedImgWidth, croppedImgHeight));
                    pictureBox.Image = croppedImg;

                    return croppedImg;
                }
                return resizedImg;
            }
            return orgImage;
        }

        private void inputPicture_Validating(object sender, CancelEventArgs e)
        {
            if (Book == null && uploadImage == null)
            {
                errorProvider.SetError(inputPicture, Commons.Resources.ERR_UPLOAD_PICTURE);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(inputPicture, null);
                e.Cancel = false;
            }
        }

        private void btnUpload_Validating(object sender, CancelEventArgs e)
        {
            if (Book == null && fileLocation == null)
            {
                errorProvider.SetError(btnUpload, Commons.Resources.ERR_UPLOAD_BOOK);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(btnUpload, null);
                e.Cancel = false;
            }
        }
    }
}
