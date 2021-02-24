﻿using Business.Abstract;
using Core.Business;
using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager<Dal> : BusinessManagerBase<Color, Dal>, IColorService
        where Dal : class, IEntityRepository<Color>, new()
    {
    }
}
