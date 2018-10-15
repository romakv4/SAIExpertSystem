namespace SAIExpertSystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.openFileButton = new System.Windows.Forms.Button();
            this.headerTextBox = new System.Windows.Forms.TextBox();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.hypothesesTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.currentQuestionTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.moreNoButton = new System.Windows.Forms.Button();
            this.dunnoButton = new System.Windows.Forms.Button();
            this.moreYesButton = new System.Windows.Forms.Button();
            this.yesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // headerTextBox
            // 
            this.headerTextBox.Location = new System.Drawing.Point(12, 41);
            this.headerTextBox.Multiline = true;
            this.headerTextBox.Name = "headerTextBox";
            this.headerTextBox.ReadOnly = true;
            this.headerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.headerTextBox.Size = new System.Drawing.Size(776, 50);
            this.headerTextBox.TabIndex = 1;
            // 
            // questionTextBox
            // 
            this.questionTextBox.Location = new System.Drawing.Point(12, 306);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.ReadOnly = true;
            this.questionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.questionTextBox.Size = new System.Drawing.Size(311, 132);
            this.questionTextBox.TabIndex = 2;
            // 
            // hypothesesTextBox
            // 
            this.hypothesesTextBox.Location = new System.Drawing.Point(13, 97);
            this.hypothesesTextBox.Multiline = true;
            this.hypothesesTextBox.Name = "hypothesesTextBox";
            this.hypothesesTextBox.ReadOnly = true;
            this.hypothesesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hypothesesTextBox.Size = new System.Drawing.Size(310, 203);
            this.hypothesesTextBox.TabIndex = 3;
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(93, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // currentQuestionTextBox
            // 
            this.currentQuestionTextBox.Location = new System.Drawing.Point(329, 97);
            this.currentQuestionTextBox.Name = "currentQuestionTextBox";
            this.currentQuestionTextBox.ReadOnly = true;
            this.currentQuestionTextBox.Size = new System.Drawing.Size(458, 20);
            this.currentQuestionTextBox.TabIndex = 5;
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(174, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(329, 123);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 7;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Visible = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // moreNoButton
            // 
            this.moreNoButton.Location = new System.Drawing.Point(421, 123);
            this.moreNoButton.Name = "moreNoButton";
            this.moreNoButton.Size = new System.Drawing.Size(75, 23);
            this.moreNoButton.TabIndex = 8;
            this.moreNoButton.Text = "More no";
            this.moreNoButton.UseVisualStyleBackColor = true;
            this.moreNoButton.Visible = false;
            this.moreNoButton.Click += new System.EventHandler(this.moreNoButton_Click);
            // 
            // dunnoButton
            // 
            this.dunnoButton.Location = new System.Drawing.Point(521, 123);
            this.dunnoButton.Name = "dunnoButton";
            this.dunnoButton.Size = new System.Drawing.Size(75, 23);
            this.dunnoButton.TabIndex = 9;
            this.dunnoButton.Text = "I dunno";
            this.dunnoButton.UseVisualStyleBackColor = true;
            this.dunnoButton.Visible = false;
            this.dunnoButton.Click += new System.EventHandler(this.dunnoButton_Click);
            // 
            // moreYesButton
            // 
            this.moreYesButton.Location = new System.Drawing.Point(617, 123);
            this.moreYesButton.Name = "moreYesButton";
            this.moreYesButton.Size = new System.Drawing.Size(75, 23);
            this.moreYesButton.TabIndex = 10;
            this.moreYesButton.Text = "More yes";
            this.moreYesButton.UseVisualStyleBackColor = true;
            this.moreYesButton.Visible = false;
            this.moreYesButton.Click += new System.EventHandler(this.moreYesButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(712, 123);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 11;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Visible = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.moreYesButton);
            this.Controls.Add(this.dunnoButton);
            this.Controls.Add(this.moreNoButton);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.currentQuestionTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.hypothesesTextBox);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.headerTextBox);
            this.Controls.Add(this.openFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox headerTextBox;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.TextBox hypothesesTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox currentQuestionTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button moreNoButton;
        private System.Windows.Forms.Button dunnoButton;
        private System.Windows.Forms.Button moreYesButton;
        private System.Windows.Forms.Button yesButton;
    }
}

