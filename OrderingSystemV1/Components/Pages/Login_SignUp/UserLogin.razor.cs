using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MySql.Data.MySqlClient;

namespace OrderingSystemV1.Components.Pages.Login_SignUp
{
    public partial class UserLogin
    {
        [Inject] protected NavigationManager Navigation { get; set; }

        private string hideInterface = "hidden";
        private string signUpInterface = "";
        private bool isSignupInterfaceOpen = false;

        private string hideValidationInterface = "hidden";
        private string showValidation = "";
        private bool isLoginValid = false;

        private void ShowSignup()
        {
            if(!isSignupInterfaceOpen)
            {
                signUpInterface = "signup-content";
                hideInterface = string.Empty;
            } else
            {
                hideInterface = "hidden";
            }
            isSignupInterfaceOpen = !isSignupInterfaceOpen;
        }

        private async Task CloseSignUp()
        {
            if (isSignupInterfaceOpen)
            {
                signUpInterface = "signup-content-close";
                await Task.Delay(1000);
                hideInterface = "hidden";
            } else
            {
                signUpInterface = "signup-content";
                hideInterface = string.Empty;
            }
            isSignupInterfaceOpen = !isSignupInterfaceOpen;
        }

        private void ValidateLogin ()
        {
            if (!isLoginValid)
            {
                showValidation = "overlay";
                hideValidationInterface = string.Empty;
            }
            else
            {
                showValidation = string.Empty;
                hideValidationInterface = "hidden";
            }
            isLoginValid = !isLoginValid;
        }

        private void CloseValidationLogin()
        {
            if (isLoginValid)
            {
                showValidation = string.Empty;
                hideValidationInterface = "hidden";
            } else
            {
                showValidation = "overlay";
                hideValidationInterface = string.Empty;
            }
            isLoginValid = !isLoginValid;
        }

        //[Inject]
        //IJSRuntime JSRuntime { get; set; } = default!;
        //private async Task showPassword()
        //{
        //    await JSRuntime.InvokeVoidAsync("togglePassword");
        //}

        private LoginModel loginModel = new();
        private string loginError;

        private async Task HandleLogin()
        {
            using var conn = Db.GetConnection();
            await conn.OpenAsync();

            string query = "SELECT COUNT(*) FROM user_accounts WHERE username = @username AND password = @password";
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", loginModel.Username);
            cmd.Parameters.AddWithValue("@password", loginModel.Password);

            var result = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            if (result > 0)
            {
                Navigation.NavigateTo("/test");
            } else
            {
                ValidateLogin();
            }
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

    }
}
