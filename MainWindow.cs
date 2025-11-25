namespace PdfSearcher
{
    public partial class MainWindow : Form {
        private SearchLogic _searchLogic;
        private PdfExtractor _pdfExtractor;
        private UIController _uiController;
       
        public MainWindow() {
            InitializeComponent();
            SetupMainWindowFormText();
            _searchLogic = new SearchLogic();
            _pdfExtractor = new PdfExtractor();
            _uiController = new UIController();
        }

        private void RunSearch(object sender, EventArgs e) {
            try {
                List<string> months = CreateMonthList(textBox1.Text, textBox3.Text);
                _searchLogic.ResetData();
                months.ForEach(m => SearchAndExport(m));
                MessageBox.Show(TextUsed.FINISHED_TEXT);
            } catch (ArgumentException ae) {
                MessageBox.Show(ae.Message);
            } catch (MonthAreNotInOrderException mnioe) {
                MessageBox.Show(mnioe.Message);            
            } catch (FileNotFoundException fnfe) {
                MessageBox.Show(fnfe.Message);
            } catch (DirectoryNotFoundException) {
                MessageBox.Show(TextUsed.DIRECTORY_NOT_FOUND_TEXT);
            } catch (NoPagesException aoore) {
                MessageBox.Show(aoore.Message);            
            } catch (Exception ex) {
                MessageBox.Show(TextUsed.CRITICAL_EXCEPTION_TEXT + ex.Message);
            } finally {
                button1.Enabled = true;
                button1.Text = TextUsed.START_SEARCH;
            }
        }

        private void SearchAndExport(string month) {            
            PageSearch(month);
            List<int> resultPages = _searchLogic.Resultpages;
            string exportPath = _searchLogic.InputFilePath;
            PageExport(resultPages, exportPath);            
        }

        private List<string> CreateMonthList(string startMonth, string endMonth) {
            return _uiController.CreateMonthListFromStartToEnd(startMonth, endMonth);
        }

        private void ResetToDefault(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            textBox2.Text = TextUsed.FOLDER_PATH;
            _searchLogic.ResetData();
        }

        private void WriteResultToTextBox(string text) {
            richTextBox2.Text = text;
        }
        private void ShowHelp(object sender, EventArgs e) {
            MessageBox.Show(TextUsed.HELP_TEXT);
        }

        private void PageSearch(string month) {
            button1.Text = TextUsed.SEARCH_IN_PROGRESS;
            button1.Enabled = false;
            string textResult = _searchLogic.RunSearch(month, textBox2.Text, richTextBox1.Lines);
            WriteResultToTextBox(textResult);
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            richTextBox2.ScrollToCaret();
        }

        private void PageExport(List<int> resultPages, string filePath) {
            button1.Text = TextUsed.EXPORT_IN_PROGRESS;
            _pdfExtractor.ExtractPdf(resultPages, filePath);
        }

        private void SetupMainWindowFormText() {
            button1.Text = TextUsed.START_SEARCH;
            textBox2.Text = TextUsed.FOLDER_PATH;
            textBox1.PlaceholderText = TextUsed.START_MONTH_PLACEHOLDER;
            textBox3.PlaceholderText = TextUsed.END_MONTH_PLACEHOLDER;
            label1.Text = TextUsed.MONTH_INPUT;
            label2.Text = TextUsed.PATH_LABEL;
            label3.Text = TextUsed.NAMES_LABEL;
            label4.Text = TextUsed.RESULTS_LABEL;
            button2.Text = TextUsed.DEFAULT_LABEL;
            label5.Text = TextUsed.VERSION_LABEL + TextUsed.VERSION;
            button3.Text = TextUsed.HELP_LABEL;
            Text = TextUsed.WINDOWS_TITLE;
            button4.Text = TextUsed.OPEN_FOLDER_TEXT;
        }

        private void OpenSaveDirectory(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("explorer.exe", @TextUsed.EXPORT_PATH);
            } catch {
                MessageBox.Show(TextUsed.DIRECTORY_NOT_OPENED_TEXT);
            }
        }

        private void label3_Click(object sender, EventArgs e) {
            
        }

        private void label1_Click(object sender, EventArgs e) {
            
        }
    }
}
