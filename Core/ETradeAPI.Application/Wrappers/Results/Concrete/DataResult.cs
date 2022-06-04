﻿using ETradeAPI.Application.Wrappers.Results.Abstract;

namespace ETradeAPI.Application.Wrappers.Results.Concrete
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
    }
}
