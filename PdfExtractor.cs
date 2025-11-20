using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfSearcher {
    internal class PdfExtractor {

        public void ExtractPdf(List<int> pages, string path) {
            using (PdfDocument document = PdfReader.Open(path, PdfDocumentOpenMode.Import)) {
                var output = new PdfDocument();
                pages.ForEach(p => output.AddPage(document.Pages[p - 1]));
                output.Save(TextUsed.EXPORT_PATH + GetFileNameFromInputPath(path));
            }
        }

        private string GetFileNameFromInputPath(string path) {
            int index = path.LastIndexOf('\\');
            return path.Substring(index, path.Length - index);
        }
    }
}
