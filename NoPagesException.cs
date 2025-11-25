
namespace PdfSearcher {
    internal class NoPagesException : ApplicationException {
        public NoPagesException() {

        }

        public NoPagesException(string? message) : base(message) {

        }
    }
}
