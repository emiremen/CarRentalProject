using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<Tip> : DataResult<Tip>
    {
        public SuccessDataResult(Tip data, string message):base(data,true,message)
        {

        }
        public SuccessDataResult(Tip data):base(data, true)
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
        {

        }
        public SuccessDataResult():base(default,true)
        {

        }

    }
}
