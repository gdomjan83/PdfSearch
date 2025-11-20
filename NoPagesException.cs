using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSearcher {
    internal class NoPagesException : ApplicationException {
        public NoPagesException() {

        }

        public NoPagesException(string? message) : base(message) {

        }
    }
}
