using System.Text;
using UglyToad.PdfPig;

namespace PdfSearcher {
    internal class SearchLogic {

        private string _endResultText;
        private bool _nameNotFoundInFile;
        public List<int> Resultpages {  get; set; }
        public string InputFilePath { get; set; }
        public const string EXCLUDED_TERM = "jegyzék R";
        public const int PAGES_IN_ONE_LINE = 12;        
        public UIController UIController { get; set; }
        public SearchLogic() { 
            UIController = new UIController();
            Resultpages = new List<int>();
            _endResultText = "";
            InputFilePath = "";
        }

        public string RunSearch(string pdfMonthText, string folderPath, string[] names) {
            Resultpages = new List<int>();
            _nameNotFoundInFile = false;
            string pdfMonth = CreateFilePath(pdfMonthText, folderPath);
            UIController.ValidateIfNamesArePresent(names);
            UIController.ValidateIfMonthFileExists(pdfMonth);
            _endResultText += $"{pdfMonthText} hónapban:\n";
            List<string> wordsToSearch = SplitNameList(names);
            SortedDictionary<string, int> result = FindTextInPdf(pdfMonth, wordsToSearch, folderPath);

            return CreateResultPages(result);
        }

        public SortedDictionary<string, int> FindTextInPdf(string pdfPath, List<string> wordsToSearch, string folderPath) {
            List<int> foundPages = new List<int>();
            SortedDictionary<string, int> resultDict = new SortedDictionary<string, int>();

            List<string> searchTermList = CreateLowerCaseListFromSearchTermList(wordsToSearch);
            List<string> foundText = new List<string>();

            using (PdfDocument document = PdfDocument.Open(pdfPath)) {
                int pageNumber = 1;
                SearchDocument(document, pageNumber, searchTermList, resultDict, foundText, foundPages);
                DisplayFeedbackText(foundText, searchTermList);
            }
            return resultDict;
        }

        public void ResetData() {
            Resultpages = new List<int>();
            _endResultText = "";
            _nameNotFoundInFile = false;
        }
        private List<string> CreateLowerCaseListFromSearchTermList(List<string> wordsToSearch) {
            List<string> result = new List<string>();
            wordsToSearch.ForEach(t => result.Add(t.ToLower().Trim()));
            return result;
        }

        private string CreateFilePath(string monthString, string folderPath){
            if (UIController.ValidateIfMonthInCorrectForm(monthString)) {
                InputFilePath = $"{folderPath}\\{monthString}{TextUsed.FILE_EXTENSION}";
                return InputFilePath;
            }
            return string.Empty;
        }

        private void DisplayFeedbackText(List<string> foundText, List<string> searchTermList) {
            foreach (string text in searchTermList) {
                if (foundText.Contains(text)) {
                    _endResultText += ($"{text.ToUpper()}{TextUsed.NAME_FOUND_TEXT}\n");
                } else {
                    _nameNotFoundInFile = true;
                    _endResultText += ($"{text.ToUpper()}{TextUsed.NAME_NOT_FOUND_TEXT}\n");
                }
            }
        }

        private void SearchDocument(PdfDocument document, int pageNumber, List<string> searchTermList, SortedDictionary<string, int> resultDict,
            List<string> foundText, List<int> foundPages) {
            foreach (var page in document.GetPages()) {
                for (int i = 0; i < searchTermList.Count; i++) {
                    string text = page.Text.ToLower();
                    if (!text.Contains(EXCLUDED_TERM.ToLower()) && text.Contains(searchTermList[i])) {
                        string key = searchTermList[i];
                        if (resultDict.ContainsKey(searchTermList[i])) {
                            key = key + pageNumber;
                        }
                        resultDict.Add(key, pageNumber);
                        foundPages.Add(pageNumber);
                        foundText.Add(searchTermList[i]);
                        break;
                    }
                }
                pageNumber++;
            }
        }

        private List<string> SplitNameList(string[] nameLines) {
            List<string> result = new List<string>();
            int lines = nameLines.Length;
            for (int i = 0; i < lines; i++) {
                string line = nameLines[i].Trim();
                if (!String.IsNullOrEmpty(line)) {
                    result.Add(nameLines[i].Trim());
                }
            }
            return result;
        }

        private string BreakTextToChunks(string inputText, int pagesInOneChunk) {
            StringBuilder sb = new StringBuilder();
            int nameCounter = 0;
            for (int i = 0; i < inputText.Length; i++) {
                char letter = inputText[i];
                char period = ',';
                if (letter != period) {
                    sb.Append(letter);
                } else {
                    nameCounter++;
                    //Handle period character at break up text to lines
                    if (nameCounter % pagesInOneChunk == 0) {
                        sb.Append("\n\n");
                    } else {
                        sb.Append(letter);
                    }
                }              
            }
            return sb.ToString() + "\n\n";
        }   
        
        private string CreateResultPages(SortedDictionary<string, int> result) {
            foreach (string key in result.Keys) {
                Resultpages.Add(result[key]);
            }
            string text = $"\n{TextUsed.RESULTS_TEXT}\n\n{string.Join(",", Resultpages)}";
            _endResultText += BreakTextToChunks(text, PAGES_IN_ONE_LINE);
            if (_nameNotFoundInFile) {
                _endResultText += TextUsed.NAME_NOT_FOUND_END_TEXT;
            }
            return _endResultText;
        }
    }
}
