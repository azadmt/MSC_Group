using System.Runtime.Serialization;

namespace OrderManagement.Domain
{
    [Serializable]
    internal class CanNotCreateOrderWithoutOrderItemsException : Exception
    {
        public CanNotCreateOrderWithoutOrderItemsException()
        {
        }

        public CanNotCreateOrderWithoutOrderItemsException(string? message) : base(message)
        {
        }

        public CanNotCreateOrderWithoutOrderItemsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CanNotCreateOrderWithoutOrderItemsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}