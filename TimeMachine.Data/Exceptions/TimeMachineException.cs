using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine.Data.Exceptions
{
    [Serializable]
    public class TimeMachineException : Exception
    {
        public TimeMachineException()
        {
        }

        public TimeMachineException(string message) : base(message)
        {
        }

        public TimeMachineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TimeMachineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
