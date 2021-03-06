﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using MongoDB.Driver;
using EasyMongo.Contract;

namespace EasyMongo
{
    public class Writer : IWriter
    {
        private IDatabaseConnection _databaseConnection;

        public Writer(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void Write<T>(string collectionName, T entry)
        {
            var collection = _databaseConnection.GetCollection<T>(collectionName);
            collection.Save(entry);
        }
    }

    public class Writer<T> : IWriter<T>
    {
        private IWriter _writer;

        public Writer(IWriter writer)
        {
            _writer = writer;
        }

        public void Write(string collectionName, T entry)
        {
            _writer.Write<T>(collectionName, entry);
        }
    }
}
