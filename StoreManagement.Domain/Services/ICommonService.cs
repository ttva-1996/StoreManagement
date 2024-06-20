using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain.Services
{
    public interface ICommonService
    {
        void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);

        bool VerifyPasswordHash(string password, string storedHash, string storedSalt);
    }
}
