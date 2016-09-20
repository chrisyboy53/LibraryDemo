using System;
using System.Text;

namespace Homemade.Configuration
{
    public class Database
    {

        public string Server { get; set; }

        public string Catalog { get; set; }

        public bool PersistSecurityInfo { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public bool Encrypted { get; set; }

        public bool MultipleActiveResultSets { get; set; }

        public bool TrustServerCertificate { get; set; }

        public int ConnectionTimeout { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(Server)) {
                throw new Exception("Missing Server name from database config");
            }
            else {
                sb.Append(string.Format("Server={0};", Server));
            }

            if (string.IsNullOrEmpty(Catalog)) {
                throw new Exception("Missing Catalog Name from database config");
            }
            else {
                sb.Append(string.Format("Initial Catalog={0};", Catalog));
            }

            sb.Append(string.Format("Persist Security Info={0};", PersistSecurityInfo ? "True" : "False" ));

            if (!string.IsNullOrEmpty(UserId) && 
                !string.IsNullOrEmpty(Password)) {
                    sb.Append(string.Format("User ID={0};Password={1};", UserId, Password));
                }

            sb.Append(string.Format("MultipleActiveResultSets={0};", MultipleActiveResultSets ? "True" : "False"));
            sb.Append(string.Format("Encrypt={0};", Encrypted ? "True" : "False"));
            sb.Append(string.Format("TrustServerCertificate={0};", TrustServerCertificate ? "True" : "False"));
            sb.Append(string.Format("Connection Timeout={0};", ConnectionTimeout.ToString()));
            

            return sb.ToString();
        }
    }
}