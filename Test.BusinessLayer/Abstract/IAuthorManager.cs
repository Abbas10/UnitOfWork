﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.BusinessLayer
{
    public interface IAuthorManager
    {
         Author GetAuthor(int id);
    }
}
