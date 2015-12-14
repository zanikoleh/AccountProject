﻿using AccountProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProject.Core.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactionOnUser(string userName);
    }
}
