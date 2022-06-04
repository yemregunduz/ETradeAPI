﻿using System;


namespace ETradeAPI.Application.Wrappers.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
