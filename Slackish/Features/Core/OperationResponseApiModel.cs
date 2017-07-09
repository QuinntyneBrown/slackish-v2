using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slackish.Features.Core
{
    public class OperationResponseApiModel<T>
    {
        public OperationResponseApiModel(T data)
        {
            Result = new OperationResponseResultApiModel(data);
        }

        public OperationResponseResultApiModel Result { get; set; }

        public class OperationResponseResultApiModel
        {
            public OperationResponseResultApiModel(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
        }
    }
}
