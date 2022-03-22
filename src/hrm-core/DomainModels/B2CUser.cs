using Microsoft.Graph;

namespace hrm_core.DomainModels
{
    public class B2CUser : Microsoft.Graph.User
    {
        public string Password { get; set; }
        public string Subject { get; set; }
        public void SetB2CProfile(string TenantName)
        {
            this.PasswordProfile = new PasswordProfile
            {
                ForceChangePasswordNextSignIn = false,
                Password = Password,
                ODataType = null
            };
            this.PasswordPolicies = "DisablePasswordExpiration,DisableStrongPassword";
            this.Password = null;
            this.ODataType = null;

            foreach (var item in this.Identities)
            {
                if (item.SignInType == "emailAddress" || item.SignInType == "userName")
                {
                    item.Issuer = TenantName;
                }
            }
        }
    }
}
