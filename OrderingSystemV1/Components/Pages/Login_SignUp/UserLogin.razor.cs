using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace OrderingSystemV1.Components.Pages.Login_SignUp
{
    public partial class UserLogin
    {
        private string showSignup = "hidden";
        private string signUpInterface = "";
        private bool isSignupInterfaceOpen = false;

        private void ShowSignup()
        {
            if(!isSignupInterfaceOpen)
            {
                signUpInterface = "signup-content";
                showSignup = string.Empty;
            } else
            {
                showSignup = "hidden";
            }
            isSignupInterfaceOpen = !isSignupInterfaceOpen;
        }

        private async Task CloseSignUp()
        {
            if (isSignupInterfaceOpen)
            {
                signUpInterface = "signup-content-close";
                await Task.Delay(1000);
                showSignup = "hidden";
            } else
            {
                signUpInterface = "signup-content";
                showSignup = string.Empty;
            }
            isSignupInterfaceOpen = !isSignupInterfaceOpen;
        }
    }
}
