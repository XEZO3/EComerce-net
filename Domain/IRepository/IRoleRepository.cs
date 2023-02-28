﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IRoleRepository :IReopsitory<Roles>
    {
        int GetIdByName(string RoleName);
        
    }
}
