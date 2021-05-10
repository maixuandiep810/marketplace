// using System.Collections.Generic;
// using System;
// using marketplace.Utilities.Const;

// namespace marketplace.Utilities.Exceptions
// {
//     public class MPException : Exception
//     {
//         public ApiResultConst.CODE ApiCode { get; set; }
//         public MPException()
//         {
//         }

//         public MPException(string message)
//             : base(message)
//         {
//         }

//         public MPException(string message, Exception inner)
//             : base(message, inner)
//         {
//         }

//         public MPException(ApiResultConst.CODE apiCode) : base(ApiResultConst.MESSAGE(apiCode))
//         {
//             Data["Messages"] = Message;
//         }

//         public MPException(ApiResultConst.CODE apiCode, List<string> mpMessageList) : base(ApiResultConst.MESSAGE(apiCode))
//         {
//             var messagesList = new List<string>();
//             messagesList.Add(Message);
//             messagesList.AddRange(mpMessageList);
//             Data["Messages"] = messagesList;
//         }

//         public MPException(ApiResultConst.CODE apiCode, params string[] messages) : base(ApiResultConst.MESSAGE(apiCode))
//         {
//             var messagesList = new List<string>();
//             foreach (var mess in messages)
//             {
//                 messagesList.Add(mess);
//             }
//             Data["Messages"] = messagesList;
//         }
//     }
// }