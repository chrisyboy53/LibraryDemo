using System;
using System.Text;

namespace Homemade.Configuration
{
    public class Database
    {
        public string ConnectionString { get; set; }

        public override string ToString() {
            return ConnectionString;
        }
    }
}