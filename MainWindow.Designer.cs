
namespace PdfSearcher
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            richTextBox2 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            label5 = new Label();
            button3 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(230, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(104, 23);
            textBox1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(45, 98);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(275, 318);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(42, 444);
            button1.Name = "button1";
            button1.Size = new Size(138, 32);
            button1.TabIndex = 2;
            button1.Text = "Keresés indítása";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RunSearch;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(42, 524);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(528, 23);
            textBox2.TabIndex = 3;
            textBox2.Text = "\\\\GMFTS.uni-pannon.hu\\munkahely\\Közös Dokumentumok\\!Szervezetek\\Pénzügyi Főosztály\\Projekt és keretgazdálkodási Csoport\\bérkarton\\Digitális projekt bérkartonok";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(389, 98);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(405, 318);
            richTextBox2.TabIndex = 4;
            richTextBox2.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 34);
            label1.Name = "label1";
            label1.Size = new Size(156, 15);
            label1.TabIndex = 5;
            label1.Text = "Hónap (formátum: 2025.09):";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 506);
            label2.Name = "label2";
            label2.Size = new Size(466, 15);
            label2.TabIndex = 6;
            label2.Text = "Elérési útvonal (csak akkor módosítandó, ha más mappába kerülnek a bérkarton fájlok):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 80);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 7;
            label3.Text = "Keresni kívánt nevek:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(389, 80);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 8;
            label4.Text = "Eredmény:";
            // 
            // button2
            // 
            button2.Location = new Point(389, 444);
            button2.Name = "button2";
            button2.Size = new Size(121, 32);
            button2.TabIndex = 9;
            button2.Text = "Visszaállítás";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ResetToDefault;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(735, 9);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 10;
            label5.Text = "Verzió: 1.0";
            // 
            // button3
            // 
            button3.Location = new Point(719, 34);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "Súgó";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ShowHelp;
            // 
            // button4
            // 
            button4.Location = new Point(563, 444);
            button4.Name = "button4";
            button4.Size = new Size(177, 32);
            button4.TabIndex = 12;
            button4.Text = "Mentés mappa megnyitása";
            button4.UseVisualStyleBackColor = true;
            button4.Click += OpenSaveDirectory;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 577);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox2);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PDF kereső";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button button1;
        private TextBox textBox2;
        private RichTextBox richTextBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button2;
        private Label label5;
        private Button button3;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button4;
    }
}
