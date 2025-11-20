using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PdfSearcher {
    internal class UIController {

        public bool ValidateIfMonthInCorrectForm(string date) {
            String regex = "^\\d{4}\\.\\d{2}$";
            Match matcher = Regex.Match(date, regex);
            if (matcher.Success) {
                return true;
            }
            throw new ArgumentException(TextUsed.WRONG_MONTH_EXCEPTION_TEXT);
        }

        public bool ValidateIfMonthFileExists(string filePath) {
            if (File.Exists(filePath)) {
                return true;
            }
            throw new FileNotFoundException($"{TextUsed.FILE_NOT_FOUND_TEXT_1}\n\n\"{filePath}\"\n\n{TextUsed.FILE_NOT_FOUND_TEXT_2}");
        }

        public bool ValidateIfNamesArePresent(string[] lines) {
            bool isEmpty = true;
            foreach (string line in lines) {
                if (!String.IsNullOrWhiteSpace(line)) {
                    isEmpty = false;
                }
            }
            if (!isEmpty) {
                return true;
            }
            throw new ArgumentException(TextUsed.NAMES_NOT_FOUND_TEXT);
        }
    }
}
