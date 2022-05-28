using System.Runtime.Serialization;

namespace MagicExceptions
{
    [Serializable]
    public class DrawFromEmptyLibrary : Exception
    {
        public DrawFromEmptyLibrary()
        {
        }

        public DrawFromEmptyLibrary(string? message) : base(message)
        {
        }

        public DrawFromEmptyLibrary(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DrawFromEmptyLibrary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}