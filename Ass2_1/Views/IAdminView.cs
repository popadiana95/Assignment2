﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    public interface IAdminView
    {
        event Action ViewEmpl;
        event Action AddOEmpl;
        event Action DeleteEmpl;
        event Action UpdateEmpl;
        event Action Report;
    }
}
