using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSearcher {
    internal class MonthAreNotInOrderException : ApplicationException {
        public MonthAreNotInOrderException() {
        }

        public MonthAreNotInOrderException(string? message) : base(message) {
        }
    }
}
