using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.Services.ErrorHandling;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.ClientBook;
using eKnjiznica.Commons.ViewModels.Clients;
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

namespace eKnjiznica.AdminUI.UI.Clients
{
    public partial class ClientEditForm : Form
    {
        private IApiClient apiClient;
        private MyRegex myRegex;
        private ErrorHandlingUtil errorHandlingUtil;
        public ClientVM Client { get; set; }
        public ClientEditForm(IApiClient apiClient, ErrorHandlingUtil errorHandlingUtil, MyRegex myRegex)
        {
            this.myRegex = myRegex;
            this.errorHandlingUtil = errorHandlingUtil;
            this.apiClient = apiClient;
            AutoValidate = AutoValidate.EnableAllowFocusChange;

            InitializeComponent();

            gvClientBooks.AutoGenerateColumns = false;
            gvClientBooks.Visible = false;
            inputAccountBalance.Maximum = Decimal.MaxValue;
            inputAccountBalance.Minimum = 0;

            inputPayIn.Maximum = Decimal.MaxValue;
            inputPayIn.Minimum = 0;

        }

        private async void ClientEditForm_Load(object sender, EventArgs e)
        {
            if (Client != null)
            {

                cbIsActive.Visible = true;
                btnAction.Text = Commons.Resources.LABEL_UPDATE;

                inputFirstName.Text = Client.FirstName;
                inputLastName.Text = Client.LastName;
                inputUsername.Text = Client.UserName;
                inputUsername.Enabled = false;
                inputEmail.Text = Client.Email;
                inputPhoneNumber.Text = Client.PhoneNumber;
                dtpBirthday.Value = Client.DateOfBirth;
                cbIsActive.Checked = Client.IsActive;
                labelAccountBalance.Visible = true;
                inputAccountBalance.Visible = true;
                inputAccountBalance.Enabled=false;
                inputAccountBalance.Value= Client.AccountBalance;

                inputPayIn.Visible = true;
                lblPayIn.Visible = true;
                btnPayIn.Visible = true;

                await BindBookData();
            }
            else
            {
                cbIsActive.Visible = false;
                btnAction.Text = Commons.Resources.LABEL_ADD;
                inputUsername.Enabled = true;
                inputAccountBalance.Visible = false;
                labelAccountBalance.Visible = false;
                inputPayIn.Visible = false;
                lblPayIn.Visible = false;
                btnPayIn.Visible = false;
            }
        }

        private async Task BindBookData()
        {
            HttpResponseMessage result = await apiClient.GetClientBooks(Client.Id);
            if (!result.IsSuccessStatusCode)
                return;

            gvClientBooks.Visible = true;
            gvClientBooks.DataSource = await result.Content.ReadAsAsync<List<ClientBookVM>>();
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            HttpResponseMessage result = null;
            string error_key = null;
            if (Client != null)
            {
                error_key = "update_client";
                result = await apiClient.UpdateClientAccount(new ClientUpdateVM
                {
                    FirstName = inputFirstName.Text.Trim(),
                    LastName = inputLastName.Text.Trim(),
                    DateOfBirth = dtpBirthday.Value,
                    Email = inputEmail.Text.Trim(),
                    PhoneNumber = inputPhoneNumber.Text.Trim(),
                    Password = inputPassword.Text.Trim(),
                    IsActive = cbIsActive.Checked
                }, Client.Id);

            }
            else
            {
                error_key = "create_client";
                result = await apiClient.CreateClientAccount(new ClientAddVM
                {
                    FirstName = inputFirstName.Text.Trim(),
                    LastName = inputLastName.Text.Trim(),
                    DateOfBirth = dtpBirthday.Value,
                    Email = inputEmail.Text.Trim(),
                    PhoneNumber = inputPhoneNumber.Text.Trim(),
                    Password = inputPassword.Text.Trim(),
                    UserName = inputUsername.Text.Trim(),
                });
            }

            if (!result.IsSuccessStatusCode)
            {
                errorLabel.Text = await errorHandlingUtil.GetErrorMessageAsync(result, error_key);
            }
            else
            {
                errorLabel.Text = "";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private async void btnPayIn_Click(object sender, EventArgs e)
        {
            if (inputPayIn.Value <= 0)
            {
                errorProvider.SetError(inputPayIn, Commons.Resources.ENTER_VALID_AMOUNT);
                return;
            }
            else
            {
                errorProvider.SetError(inputPayIn,null);
            }
            HttpResponseMessage result = null;
            var error_key = "update_client";

            result = await apiClient.MakePayInRequest(inputPayIn.Value,Client.Id);

            if (!result.IsSuccessStatusCode)
            {
                errorLabel.Text = await errorHandlingUtil.GetErrorMessageAsync(result, error_key);
            }
            else
            {
                errorLabel.Text = "";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void inputFirstName_Validating(object sender, CancelEventArgs e)
        {
            var firstName = inputFirstName.Text.Trim();
            if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
            {
                errorProvider.SetError(inputFirstName, Commons.Resources.ERR_FIRST_NAME_REQUIRED);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(inputFirstName, null);
                e.Cancel = false;
            }
        }

        private void inputLastName_Validating(object sender, CancelEventArgs e)
        {
            var lastName = inputLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
            {
                errorProvider.SetError(inputLastName, Commons.Resources.ERR_LAST_NAME_REQUIRED);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(inputLastName, null);
                e.Cancel = false;
            }
        }

        private void inputUsername_Validating(object sender, CancelEventArgs e)
        {
            var username = inputUsername.Text.Trim();
            if (string.IsNullOrEmpty(username) || username.Length < 6)
            {
                errorProvider.SetError(inputUsername, Commons.Resources.ERR_FIELD_USERNAME_INVALID);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(inputUsername, null);
                e.Cancel = false;
            }
        }

        private void inputEmail_Validating(object sender, CancelEventArgs e)
        {
            var email = inputEmail.Text.Trim();
            if (myRegex.IsValidEmail(email))
            {
                errorProvider.SetError(inputEmail, null);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(inputEmail, Commons.Resources.ERR_FIELD_EMAIL_INVALID);
                e.Cancel = true;
            }
        }

        private void inputPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            var phone = inputPhoneNumber.Text.Trim();
            if (myRegex.IsValidPhone(phone))
            {
                errorProvider.SetError(inputPhoneNumber, null);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(inputPhoneNumber, Commons.Resources.ERR_FIELD_PHONE_INVALID);
                e.Cancel = true;
            }
        }

        private void inputPassword_Validating(object sender, CancelEventArgs e)
        {
            var password = inputPassword.Text.Trim();
            if (Client != null && string.IsNullOrEmpty(password))
            {
                errorProvider.SetError(inputPassword, null);
                e.Cancel = false;
            }
            else if (myRegex.ValidatePassword(password))
            {
                errorProvider.SetError(inputPassword, null);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(inputPassword, Commons.Resources.ERR_FIELD_PASSWORD_INVALID);
                e.Cancel = true;
            }
        }


    }
}
