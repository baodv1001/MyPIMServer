﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportService.Infrastructure.Context;
using ImportService.Infrastructure.Entities;
using ImportService.Core.Models;
using ImportService.Core.Interfaces.Repositories;

namespace ImportService.Infrastructure.Repositories
{
    public class ImportRepository : IImportFileRepository
    {
        private readonly ImportDbContext _dbContext;
        private readonly IMapper _mapper;

        public async Task<bool> Import(Core.Models.ImportFile importFile)
        {
            List<object> objs = new List<object>();
            // modified here to handle import 
            
            var dbImportFile = _mapper.Map<Entities.ImportFile>(importFile);
            for (int i = 0; i < objs; i++)
			{
                switch(importFile.ObjectImported == 'Product')
                {
                    case 'Product':
                        Product product = new Product();
                        //convert objs[i] => product at here
                        _dbContext.Products.Add(product);
                        break;
                    case 'Attribute':
                        Attribute attribute = new Attribute();
                        //convert objs[i] => attribute at here
                        _dbContext.Attributes.Add(new Attribute());
                        break;
                    case 'Category':
                        Category category = new Category();
                         //convert objs[i] => category at here
                        _dbContext.Categorys.Add(category);
                        break;
                    case 'Channel':
                        Channel channel = new Channel();
                         //convert objs[i] => channel at here
                        _dbContext.Channels.Add(channel);
                        break;
                    case 'Supplier':
                        Suppiler suppiler = new Suppiler();
                         //convert objs[i] => suppiler at here
                        _dbContext.Suppliers.Add(suppiler);
                        break;
                    default:
                        break;
                }   
			}
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
