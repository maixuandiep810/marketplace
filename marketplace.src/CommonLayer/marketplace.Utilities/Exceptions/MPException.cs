using System;
using marketplace.Utilities.Const;

namespace marketplace.Utilities.Exceptions
{
    public class MPException : Exception
    {
        public ApiResultConst.CODE ApiCode { get; set; }
        public MPException()
        {
        }

        public MPException(string message)
            : base(message)
        {
        }

        public MPException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public MPException(ApiResultConst.CODE apiCode) : base (ApiResultConst.MESSAGE(apiCode))
        {
        }
    }
}