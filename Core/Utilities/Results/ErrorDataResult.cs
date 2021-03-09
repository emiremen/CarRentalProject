using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<Tip> : DataResult<Tip>
    {
        public ErrorDataResult(Tip data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(Tip data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
