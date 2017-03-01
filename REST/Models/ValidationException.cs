using System;
using System.Collections.Generic;

namespace REST.Models
{
    public class ValidationException : Exception
    {
        public IList<string> Errors { get; set; }
        public ValidationException()
        {
            this.Errors = new List<string>();
        }

        public ValidationException(string message) : this()
        {
            this.Errors.Add(message);
        }
    }
}