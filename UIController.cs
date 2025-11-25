using System.Text.RegularExpressions;

namespace PdfSearcher {
    internal class UIController {

        public bool ValidateIfMonthInCorrectForm(string date) {
            String regex = "^\\d{4}\\.\\d{2}$";
            Match matcher = Regex.Match(date, regex);
            if (matcher.Success) {
                return true;
            }
            throw new ArgumentException($"{TextUsed.WRONG_MONTH_EXCEPTION_TEXT}: {date}");
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

        public List<string> CreateMonthListFromStartToEnd(string start, string end) {
            List<string> result = new List<string>();

            ValidateIfMonthInCorrectForm(start);
            if (!String.IsNullOrEmpty(end) && !start.Equals(end)) {
                ValidateIfMonthInCorrectForm(end);
                ValidateIfEndMonthIsAfterStartMonth(start, end);
            } else {
                result.Add(start);
                return result;
            }

            string currentMonth = start;
            bool sameMonth = false;
            while (!sameMonth) {
                if (currentMonth.Equals(end)) {
                    sameMonth = true;
                }
                result.Add(currentMonth);
                currentMonth = IncrementYearMonth(currentMonth);
            }
            return result;
        }

        private bool ValidateIfEndMonthIsAfterStartMonth(string start, string end) {
            var startParts = start.Split('.');
            int startYear = int.Parse(startParts[0]);
            int startMonth = int.Parse(startParts[1]);

            var endParts = end.Split('.');
            int endYear = int.Parse(endParts[0]);
            int endMonth = int.Parse(endParts[1]);

            if (startYear > endYear) throw new MonthAreNotInOrderException(TextUsed.MONTH_NOT_IN_ORDER_EXCEPTION_TEXT);
            if (startYear == endYear && startMonth > endMonth) throw new MonthAreNotInOrderException(TextUsed.MONTH_NOT_IN_ORDER_EXCEPTION_TEXT);
            return true;
        }

        private string IncrementYearMonth(string date) {
            // ym format: "YYYY.MM"
            var parts = date.Split('.');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);

            month++;
            if (month > 12) {
                month = 1;
                year++;
            }

            return $"{year:D4}.{month:D2}";
        }
    }
}
