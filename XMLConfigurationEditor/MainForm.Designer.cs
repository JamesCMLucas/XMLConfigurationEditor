namespace XMLConfigurationEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTextBox = new System.Windows.Forms.RichTextBox();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.LoadFileButton = new System.Windows.Forms.ToolStripButton();
            this.SaveFileButton = new System.Windows.Forms.ToolStripButton();
            this.buttonTestLoad = new System.Windows.Forms.Button();
            this.buttonTestSave = new System.Windows.Forms.Button();
            this.buttonLoadSchemaTest = new System.Windows.Forms.Button();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTextBox
            // 
            this.MainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTextBox.Location = new System.Drawing.Point(30, 31);
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.Size = new System.Drawing.Size(664, 517);
            this.MainTextBox.TabIndex = 0;
            this.MainTextBox.Text = "";
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFileButton,
            this.SaveFileButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(844, 25);
            this.ToolStrip.TabIndex = 1;
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadFileButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadFileButton.Image")));
            this.LoadFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(23, 22);
            this.LoadFileButton.Text = "Load File";
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveFileButton.Image")));
            this.SaveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(23, 22);
            this.SaveFileButton.Text = "Save File";
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // buttonTestLoad
            // 
            this.buttonTestLoad.Location = new System.Drawing.Point(740, 31);
            this.buttonTestLoad.Name = "buttonTestLoad";
            this.buttonTestLoad.Size = new System.Drawing.Size(75, 53);
            this.buttonTestLoad.TabIndex = 2;
            this.buttonTestLoad.Text = "load books";
            this.buttonTestLoad.UseVisualStyleBackColor = true;
            this.buttonTestLoad.Click += new System.EventHandler(this.buttonTestLoad_Click);
            // 
            // buttonTestSave
            // 
            this.buttonTestSave.Location = new System.Drawing.Point(740, 90);
            this.buttonTestSave.Name = "buttonTestSave";
            this.buttonTestSave.Size = new System.Drawing.Size(75, 53);
            this.buttonTestSave.TabIndex = 3;
            this.buttonTestSave.Text = "save books";
            this.buttonTestSave.UseVisualStyleBackColor = true;
            this.buttonTestSave.Click += new System.EventHandler(this.buttonTestSave_Click);
            // 
            // buttonLoadSchemaTest
            // 
            this.buttonLoadSchemaTest.Location = new System.Drawing.Point(740, 169);
            this.buttonLoadSchemaTest.Name = "buttonLoadSchemaTest";
            this.buttonLoadSchemaTest.Size = new System.Drawing.Size(75, 53);
            this.buttonLoadSchemaTest.TabIndex = 4;
            this.buttonLoadSchemaTest.Text = "load schema";
            this.buttonLoadSchemaTest.UseVisualStyleBackColor = true;
            this.buttonLoadSchemaTest.Click += new System.EventHandler(this.buttonLoadSchemaTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 678);
            this.Controls.Add(this.buttonLoadSchemaTest);
            this.Controls.Add(this.buttonTestSave);
            this.Controls.Add(this.buttonTestLoad);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.MainTextBox);
            this.Name = "MainForm";
            this.Text = "XML Editor";
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MainTextBox;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton LoadFileButton;
        private System.Windows.Forms.ToolStripButton SaveFileButton;
        private System.Windows.Forms.Button buttonTestLoad;
        private System.Windows.Forms.Button buttonTestSave;
        private System.Windows.Forms.Button buttonLoadSchemaTest;
    }
}

