﻿using Mic.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.Repository
{
    public interface IUniversityRepository : IBaseRepository<University>
    {
        int Update(int id, string name, DateTime Destroy_Date);
        int Destroy(int id);

    }
}
