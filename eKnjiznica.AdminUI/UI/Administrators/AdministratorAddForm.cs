using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKnjiznica.AdminUI.UI.Administrators
{
    public partial class AdministratorAddForm : Form
    {
        private IApiClient apiClient;
        private MyRegex myRegex;
        public AdministratorAddForm(IApiClient apiClient,MyRegex myRegex)
        {
            this.apiClient = apiClient;
            this.AutoValidate = AutoValidate.Disable;
            this.myRegex = myRegex;

            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            InitializeComponent();

        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;
            AdminAddVM adminAdd = new AdminAddVM
            {
                FirstName = inputName.Text.Trim(),
                LastName = inputLastName.Text.Trim(),
                Email = inputEmail.Text.Trim(),
                Password = inputPassword.Text.Trim(),
                Username = inputUserName.Text.Trim(),
                PhoneNumber = inputPhone.Text.Trim()
            };

           var result= await apiClient.CreateAdminAccount(adminAdd);

            if (result.IsSuccessStatusCode)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                
            }
        }

        private void AdministratorAddForm_Load(object sender, EventArgs e)
        {

        }

        #region Validation
        private void inputName_Validating(object sender, CancelEventArgs e)
        {
            var name = inputName.Text.Trim();
            if (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(inputName, Commons.Resources.ERR_FIRST_NAME_REQUIRED);
            }
            else
            {
                errorProvider.SetError(inputName, null);
            }

        }

        private void inputLastName_Validating(object sender, CancelEventArgs e)
        {
            var lastName= inputLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(inputLastName, Commons.Resources.ERR_LAST_NAME_REQUIRED);
            }
            else
            {
                errorProvider.SetError(inputLastName, null);

            }
        }

        private void inputEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!myRegex.IsValidEmail(inputEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(inputEmail, Commons.Resources.ERR_FIELD_EMAIL_INVALID);
            }
            else
            {
                errorProvider.SetError(inputEmail, null);

            }
        }

        private void inputUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(inputUserName.Text.Trim()) || inputUserName.Text.Trim().Length<=5)
            {
                e.Cancel = true;
                errorProvider.SetError(inputUserName, Commons.Resources.ERR_FIELD_USERNAME_INVALID);
            }
            else
            {
                errorProvider.SetError(inputUserName, null);

            }
        }

        private void inputPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!myRegex.ValidatePassword(inputPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(inputPassword, Commons.Resources.ERR_FIELD_PASSWORD_INVALID);
            }
            else
            {
                errorProvider.SetError(inputPassword, null);

            }
        }

        private void inputPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!myRegex.IsValidPhone(inputPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(inputPhone, Commons.Resources.ERR_FIELD_PHONE_INVALID);
            }
            else
            {
                errorProvider.SetError(inputPhone, null);
            }
        }
        #endregion

    }
}
