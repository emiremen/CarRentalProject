using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<Tip> : IResult
    {
        public Tip Data { get;}
    }
}
