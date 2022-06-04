using System;
using System.Collections.Generic;
using System.Text;

namespace ETradeAPI.Application.Wrappers.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
