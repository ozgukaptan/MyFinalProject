﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
       
    }
}

// code refactoring