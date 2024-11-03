﻿using EPE_AuthLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRoleByIdAsync(int roleId);    
    }
}
