﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        void Save();
        void Dispose();
    }
}
