using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)//data ve mesaj ver
        {

        }
        public SuccessDataResult(T data):base(data,true)//saddece data ver
        {

        }

        public SuccessDataResult(string message):base(default,true,message)//sadece mesaj ver
        {

        }

        public SuccessDataResult():base(default,true)//hiç bir şey verme
        {

        }

    }
}
