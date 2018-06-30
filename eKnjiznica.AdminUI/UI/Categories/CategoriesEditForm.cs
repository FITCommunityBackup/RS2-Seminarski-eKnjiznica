using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.Category;

namespace eKnjiznica.AdminUI.UI.Categories
{
    public partial class CategoriesEditForm : Form
    {
        public CategoryVM Category { get; internal set; }
        private IApiClient apiClient;
        private ErrorHandlingUtil errorHandlingUtil;

        public CategoriesEditForm(IApiClient apiClient,ErrorHandlingUtil errorHandlingUtil)
        {
            this.apiClient = apiClient;
            this.errorHandlingUtil = errorHandlingUtil;
            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            
            InitializeComponent();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;
            var newCategoryName = inputCategoryName.Text.Trim();

            CategoryUpdateVm categoryUpdateVm = new CategoryUpdateVm
            {
                CategoryName = Category.CategoryName.Equals(newCategoryName) ? null : newCategoryName,
                IsActive = cbActive.Checked
            };

            var result = await apiClient.UpdateCategory(categoryUpdateVm, Category.Id);
            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var error = await errorHandlingUtil.GetErrorMessageAsync(result,"update_category");
                errorProvider1.SetError(inputCategoryName, error);
            }

    }

        private void inputCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(inputCategoryName.Text.Trim()))
            {
                errorProvider1.SetError(inputCategoryName, Commons.Resources.ENTER_VALID_CATEGORY_NAME);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(inputCategoryName, null);
            }

        }

        private void CategoriesEditForm_Load(object sender, EventArgs e)
        {
            this.inputCategoryName.Text = Category.CategoryName;
            this.cbActive.Checked= Category.IsActive;

        }
    }
}
