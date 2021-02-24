using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }

        public DataResult(bool success, string message, T data):base(success, message)
        {
            Data = data;
        }

        public DataResult(bool success, T data):base(success)
        {
            Data = data;
        }
    }
}
