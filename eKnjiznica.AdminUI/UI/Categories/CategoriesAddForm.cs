using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKnjiznica.AdminUI.UI.Categories
{
    public partial class CategoriesAddForm : Form
    {
        private IApiClient apiClient;
        private ErrorHandlingUtil errorHandlingUtil;
        public CategoriesAddForm(IApiClient apiClient,ErrorHandlingUtil errorHandlingUtil)
        {
            this.apiClient = apiClient;
            this.errorHandlingUtil = errorHandlingUtil;
            InitializeComponent();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
                return;

            CategoryAddVM category = new CategoryAddVM
            {
              CategoryName=  inputCategoryName.Text.Trim()
            };
            var result = await apiClient.CreateCategory(category);
            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var errorString = await errorHandlingUtil.GetErrorMessageAsync(result, "create_category");
                errorProvider.SetError(inputCategoryName, errorString);
            }

        }

        private void inputCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(inputCategoryName.Text.Trim()))
            {
                errorProvider.SetError(inputCategoryName, Commons.Resources.ENTER_VALID_CATEGORY_NAME);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(inputCategoryName, null);
            }
        }
    }
}
