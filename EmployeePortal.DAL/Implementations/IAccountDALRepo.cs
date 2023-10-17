﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Implementations
{
    public interface IAccountDALRepo
    {
        bool ValidateUserCredentials(string username, string password);
    }
}
