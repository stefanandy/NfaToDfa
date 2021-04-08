namespace UI
{
    partial class Form1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputStringTextBox = new System.Windows.Forms.TextBox();
            this.InputString = new System.Windows.Forms.Label();
            this.automataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.automataOutputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.runNFAButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.runDFAButton = new System.Windows.Forms.Button();
            this.areEqBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputStringTextBox
            // 
            this.inputStringTextBox.Location = new System.Drawing.Point(56, 82);
            this.inputStringTextBox.Name = "inputStringTextBox";
            this.inputStringTextBox.Size = new System.Drawing.Size(277, 26);
            this.inputStringTextBox.TabIndex = 0;
            // 
            // InputString
            // 
            this.InputString.Location = new System.Drawing.Point(60, 46);
            this.InputString.Name = "InputString";
            this.InputString.Size = new System.Drawing.Size(120, 33);
            this.InputString.TabIndex = 1;
            this.InputString.Text = "Input String:";
            // 
            // automataRichTextBox
            // 
            this.automataRichTextBox.Location = new System.Drawing.Point(60, 193);
            this.automataRichTextBox.Name = "automataRichTextBox";
            this.automataRichTextBox.Size = new System.Drawing.Size(272, 250);
            this.automataRichTextBox.TabIndex = 2;
            this.automataRichTextBox.Text = "";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(122, 126);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(125, 46);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "BROWSE";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.automataOutputRichTextBox);
            this.groupBox1.Location = new System.Drawing.Point(576, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 430);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automata Output";
            // 
            // automataOutputRichTextBox
            // 
            this.automataOutputRichTextBox.Location = new System.Drawing.Point(19, 25);
            this.automataOutputRichTextBox.Name = "automataOutputRichTextBox";
            this.automataOutputRichTextBox.Size = new System.Drawing.Size(341, 372);
            this.automataOutputRichTextBox.TabIndex = 0;
            this.automataOutputRichTextBox.Text = "";
            // 
            // runNFAButton
            // 
            this.runNFAButton.Location = new System.Drawing.Point(379, 140);
            this.runNFAButton.Name = "runNFAButton";
            this.runNFAButton.Size = new System.Drawing.Size(147, 42);
            this.runNFAButton.TabIndex = 5;
            this.runNFAButton.Text = " RUN NFA";
            this.runNFAButton.UseVisualStyleBackColor = true;
            this.runNFAButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(400, 226);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(104, 40);
            this.convertButton.TabIndex = 6;
            this.convertButton.Text = "CONVERT";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // runDFAButton
            // 
            this.runDFAButton.Location = new System.Drawing.Point(379, 304);
            this.runDFAButton.Name = "runDFAButton";
            this.runDFAButton.Size = new System.Drawing.Size(147, 40);
            this.runDFAButton.TabIndex = 7;
            this.runDFAButton.Text = "RUN DFA";
            this.runDFAButton.UseVisualStyleBackColor = true;
            this.runDFAButton.Click += new System.EventHandler(this.runDFAButton_Click);
            // 
            // areEqBtn
            // 
            this.areEqBtn.Location = new System.Drawing.Point(363, 382);
            this.areEqBtn.Name = "areEqBtn";
            this.areEqBtn.Size = new System.Drawing.Size(197, 49);
            this.areEqBtn.TabIndex = 8;
            this.areEqBtn.Text = "ARE EQUIVALENT?";
            this.areEqBtn.UseVisualStyleBackColor = true;
            this.areEqBtn.Click += new System.EventHandler(this.areEqBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 519);
            this.Controls.Add(this.areEqBtn);
            this.Controls.Add(this.runDFAButton);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.runNFAButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.automataRichTextBox);
            this.Controls.Add(this.InputString);
            this.Controls.Add(this.inputStringTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button areEqBtn;

        private System.Windows.Forms.Button runDFAButton;

        private System.Windows.Forms.RichTextBox automataOutputRichTextBox;
        private System.Windows.Forms.RichTextBox automataRichTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button runNFAButton;

        private System.Windows.Forms.Label InputString;
        private System.Windows.Forms.TextBox inputStringTextBox;

        #endregion
    }
}