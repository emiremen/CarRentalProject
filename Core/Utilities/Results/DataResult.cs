using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class DataResult<Tip> : Result, IDataResult<Tip>
    {
        public DataResult(Tip data, bool success, string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(Tip data, bool success):base(success)
        {
            Data = data;
        }
        public Tip Data { get; }
    }
}
