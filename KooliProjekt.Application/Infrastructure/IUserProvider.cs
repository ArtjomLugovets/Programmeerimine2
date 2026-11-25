using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Infrastructure
{
    public interface IUserProvider
    {
        int? UserId();
    }
}
