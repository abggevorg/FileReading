using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLBR.Security
{
    public class SimpleRoleSecurity : IRoleSecurity
    {
        public bool HasPermission(string role, string filePath)
        {
            switch (role)
            {
                case "admin":
                    // Admin can read everything
                    return true;
                case "user":
                    // Users can only read files that start with user (simple security)
                    string fileName = Path.GetFileName(filePath);
                    return fileName.ToLower().StartsWith("user");

                    
                default:
                    // Default to denying access if role is not recognized
                    return false;
            }
        }
    }
}
