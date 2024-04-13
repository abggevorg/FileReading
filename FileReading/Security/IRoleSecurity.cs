using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadingLBR.Security
{
    public interface IRoleSecurity
    {
  
            bool HasPermission(string role, string filePath);
        
    }
}
