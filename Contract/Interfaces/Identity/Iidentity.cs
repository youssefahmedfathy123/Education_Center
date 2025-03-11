using Education_Center_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Interfaces.Identity
{
    public interface Iidentity
    {
        Task<Show> Register(Register register);
        Task<Show> Login(Login login);

    }
}


