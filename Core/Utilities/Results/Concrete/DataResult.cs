using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(bool success, string message, T data) : base(success,message)
        {
            this.Data = data;
        }

        public DataResult(bool success, T data) : base(success)
        {
            this.Data = data;
        }
    }
}
