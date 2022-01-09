﻿using ImportService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportService.Core.Interfaces.Services
{
    public interface IImportService
    {
        Task<bool> Import(ImportFile importFile);

    }
}
