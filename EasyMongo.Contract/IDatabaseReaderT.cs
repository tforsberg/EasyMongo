﻿using System;
using System.Collections.Generic;
using EasyMongo;
using MongoDB.Bson;
using MongoDB.Driver;
using EasyMongo.Contract.Deprecated;

namespace EasyMongo.Contract
{
    public interface IDatabaseReader<T> : IReader<T>, IReaderTask<T> where T : class
    {
    }
}
