namespace PdfSearcher
{
    public partial class MainWindow : Form {
        private SearchLogic _searchLogic;
        private PdfExtractor _pdfExtractor;
       
        public MainWindow() {
            InitializeComponent();
            SetupMainWindowFormText();
            _searchLogic = new SearchLogic();
            _pdfExtractor = new PdfExtractor();
        }

        private void RunSearch(object sender, EventArgs e) {
            try {
                PageSearch();
                PageExport();
                MessageBox.Show(TextUsed.FINISHED_TEXT);
            } catch (ArgumentException ae) {
                MessageBox.Show(ae.Message);
            } catch (FileNotFoundException fnfe) {
                MessageBox.Show(fnfe.Message);
            } catch (DirectoryNotFoundException) {
                MessageBox.Show(TextUsed.DIRECTORY_NOT_FOUND_TEXT);
            } catch (Exception ex) {
                MessageBox.Show(TextUsed.CRITICAL_EXCEPTION_TEXT + ex.Message);
            } finally {
                button1.Enabled = true;
                button1.Text = TextUsed.START_SEARCH;
            }
        }

        private void ResetToDefault(object sender, EventArgs e) {
            textBox1.Text = "";
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

        private void PageSearch() {
            button1.Text = TextUsed.SEARCH_IN_PROGRESS;
            button1.Enabled = false;
            string textResult = _searchLogic.RunSearch(textBox1.Text, textBox2.Text, richTextBox1.Lines);
            WriteResultToTextBox(textResult);
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            richTextBox2.ScrollToCaret();
        }

        private void PageExport() {
            button1.Text = TextUsed.EXPORT_IN_PROGRESS;
            _pdfExtractor.ExtractPdf(_searchLogic.Resultpages, _searchLogic.InputFilePath);
        }

        private void SetupMainWindowFormText() {
            button1.Text = TextUsed.START_SEARCH;
            textBox2.Text = TextUsed.FOLDER_PATH;
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
