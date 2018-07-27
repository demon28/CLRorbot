using System;

namespace gateio.api
{
    public class BotException : Exception
    {
        public BotException() : this("1000")
        {

        }

        public BotException(string code) : this(code, "")
        {
        }

        public BotException(string code, string detail)
        {
            Code = code;
            Detail = detail;
        }

        public string Code { get; set; }


        public override string Message
        {
            get
            {
                return Error.GetErrorByCode(Code);
            }
        }


        public string Detail { get; set; }

    }
}