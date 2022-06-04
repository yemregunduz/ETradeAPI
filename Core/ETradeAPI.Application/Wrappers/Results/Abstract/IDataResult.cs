using System;
using System.Collections.Generic;
using System.Text;

namespace ETradeAPI.Application.Wrappers.Results.Abstract
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
