using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort.Exceptions
{
    /// <summary>
    /// NotInOrderException is thrown when an array of integers is not in ascending order,
    /// when it is expected.
    /// </summary>
    public class NotInOrderException : ApplicationException
    {
        private int? ErrorIndex;
        private int? ErrorNumber;

        public NotInOrderException() { }

        public NotInOrderException(int errorIndex, int errorNumber)
        {
            ErrorIndex = errorIndex;
            ErrorNumber = errorNumber;
        }

        public NotInOrderException(string message)
            : base(message) { }
        
        public NotInOrderException(string message, Exception inner)
            : base(message, inner) { }

        protected NotInOrderException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public override string Message
        {
            get
            {
                if (ErrorIndex.HasValue && ErrorNumber.HasValue)
                {
                    return string.Format("Array is unsorted, as evident at index {0} ({1}).", ErrorIndex, ErrorNumber);
                }
                else if (base.Message == "Error in the application.")
                {
                    return "Array is unsorted.";
                }
                else 
                {
                    return base.Message;
                }
            }
        }
    }
}
