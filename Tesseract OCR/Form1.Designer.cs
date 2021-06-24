namespace Tesseract_OCR
{
    partial class FormOCRTesseract
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonExtractText = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.richTextBoxTextOut = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonResetImage = new System.Windows.Forms.Button();
            this.buttonConvertRGBToGray = new System.Windows.Forms.Button();
            this.buttonSauvolaTiledBinarization = new System.Windows.Forms.Button();
            this.buttonSauvolaBinarization = new System.Windows.Forms.Button();
            this.buttonOtsuBinarization = new System.Windows.Forms.Button();
            this.buttonDescew = new System.Windows.Forms.Button();
            this.buttonDespeckle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonExtractText);
            this.groupBox1.Controls.Add(this.buttonImport);
            this.groupBox1.Location = new System.Drawing.Point(998, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(6, 115);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(140, 30);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // buttonExtractText
            // 
            this.buttonExtractText.Location = new System.Drawing.Point(6, 68);
            this.buttonExtractText.Name = "buttonExtractText";
            this.buttonExtractText.Size = new System.Drawing.Size(140, 30);
            this.buttonExtractText.TabIndex = 2;
            this.buttonExtractText.Text = "Extract Text";
            this.buttonExtractText.UseVisualStyleBackColor = true;
            this.buttonExtractText.Click += new System.EventHandler(this.ButtonExtractText_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(6, 19);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(140, 30);
            this.buttonImport.TabIndex = 1;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.Location = new System.Drawing.Point(7, 13);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(665, 606);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxImage_Paint);
            this.pictureBoxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseDown);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseMove);
            this.pictureBoxImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseUp);
            // 
            // richTextBoxTextOut
            // 
            this.richTextBoxTextOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxTextOut.Location = new System.Drawing.Point(691, 12);
            this.richTextBoxTextOut.Name = "richTextBoxTextOut";
            this.richTextBoxTextOut.ReadOnly = true;
            this.richTextBoxTextOut.Size = new System.Drawing.Size(301, 628);
            this.richTextBoxTextOut.TabIndex = 2;
            this.richTextBoxTextOut.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBoxImage);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 628);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonDespeckle);
            this.groupBox3.Controls.Add(this.buttonResetImage);
            this.groupBox3.Controls.Add(this.buttonConvertRGBToGray);
            this.groupBox3.Controls.Add(this.buttonSauvolaTiledBinarization);
            this.groupBox3.Controls.Add(this.buttonSauvolaBinarization);
            this.groupBox3.Controls.Add(this.buttonOtsuBinarization);
            this.groupBox3.Controls.Add(this.buttonDescew);
            this.groupBox3.Location = new System.Drawing.Point(998, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 322);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // buttonResetImage
            // 
            this.buttonResetImage.Enabled = false;
            this.buttonResetImage.Location = new System.Drawing.Point(6, 277);
            this.buttonResetImage.Name = "buttonResetImage";
            this.buttonResetImage.Size = new System.Drawing.Size(138, 30);
            this.buttonResetImage.TabIndex = 7;
            this.buttonResetImage.Text = "Reset Image";
            this.buttonResetImage.UseVisualStyleBackColor = true;
            this.buttonResetImage.Click += new System.EventHandler(this.ButtonResetImage_Click);
            // 
            // buttonConvertRGBToGray
            // 
            this.buttonConvertRGBToGray.Enabled = false;
            this.buttonConvertRGBToGray.Location = new System.Drawing.Point(8, 173);
            this.buttonConvertRGBToGray.Name = "buttonConvertRGBToGray";
            this.buttonConvertRGBToGray.Size = new System.Drawing.Size(138, 30);
            this.buttonConvertRGBToGray.TabIndex = 5;
            this.buttonConvertRGBToGray.Text = "Convert RGB ToGray";
            this.buttonConvertRGBToGray.UseVisualStyleBackColor = true;
            this.buttonConvertRGBToGray.Click += new System.EventHandler(this.ButtonConvertRGBToGray_Click);
            // 
            // buttonSauvolaTiledBinarization
            // 
            this.buttonSauvolaTiledBinarization.Enabled = false;
            this.buttonSauvolaTiledBinarization.Location = new System.Drawing.Point(8, 134);
            this.buttonSauvolaTiledBinarization.Name = "buttonSauvolaTiledBinarization";
            this.buttonSauvolaTiledBinarization.Size = new System.Drawing.Size(138, 30);
            this.buttonSauvolaTiledBinarization.TabIndex = 4;
            this.buttonSauvolaTiledBinarization.Text = "Sauvola Tiled Binarization";
            this.buttonSauvolaTiledBinarization.UseVisualStyleBackColor = true;
            this.buttonSauvolaTiledBinarization.Click += new System.EventHandler(this.ButtonSauvolaTiledBinarization_Click);
            // 
            // buttonSauvolaBinarization
            // 
            this.buttonSauvolaBinarization.Enabled = false;
            this.buttonSauvolaBinarization.Location = new System.Drawing.Point(8, 95);
            this.buttonSauvolaBinarization.Name = "buttonSauvolaBinarization";
            this.buttonSauvolaBinarization.Size = new System.Drawing.Size(138, 30);
            this.buttonSauvolaBinarization.TabIndex = 3;
            this.buttonSauvolaBinarization.Text = "Sauvola Binarization";
            this.buttonSauvolaBinarization.UseVisualStyleBackColor = true;
            this.buttonSauvolaBinarization.Click += new System.EventHandler(this.ButtonSauvolaBinarization_Click);
            // 
            // buttonOtsuBinarization
            // 
            this.buttonOtsuBinarization.Enabled = false;
            this.buttonOtsuBinarization.Location = new System.Drawing.Point(8, 56);
            this.buttonOtsuBinarization.Name = "buttonOtsuBinarization";
            this.buttonOtsuBinarization.Size = new System.Drawing.Size(138, 30);
            this.buttonOtsuBinarization.TabIndex = 2;
            this.buttonOtsuBinarization.Text = "Otsu Binarization";
            this.buttonOtsuBinarization.UseVisualStyleBackColor = true;
            this.buttonOtsuBinarization.Click += new System.EventHandler(this.ButtonOtsuBinarization_Click);
            // 
            // buttonDescew
            // 
            this.buttonDescew.Enabled = false;
            this.buttonDescew.Location = new System.Drawing.Point(8, 17);
            this.buttonDescew.Name = "buttonDescew";
            this.buttonDescew.Size = new System.Drawing.Size(138, 30);
            this.buttonDescew.TabIndex = 1;
            this.buttonDescew.Text = "Descew";
            this.buttonDescew.UseVisualStyleBackColor = true;
            this.buttonDescew.Click += new System.EventHandler(this.ButtonDescew_Click);
            // 
            // buttonDespeckle
            // 
            this.buttonDespeckle.Enabled = false;
            this.buttonDespeckle.Location = new System.Drawing.Point(8, 213);
            this.buttonDespeckle.Name = "buttonDespeckle";
            this.buttonDespeckle.Size = new System.Drawing.Size(138, 30);
            this.buttonDespeckle.TabIndex = 8;
            this.buttonDespeckle.Text = "Despeckle";
            this.buttonDespeckle.UseVisualStyleBackColor = true;
            this.buttonDespeckle.Click += new System.EventHandler(this.buttonDespeckle_Click);
            // 
            // FormOCRTesseract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 652);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.richTextBoxTextOut);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormOCRTesseract";
            this.Text = "OCR Tesseract";
            this.Load += new System.EventHandler(this.FormOCRTesseract_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonExtractText;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.RichTextBox richTextBoxTextOut;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSauvolaTiledBinarization;
        private System.Windows.Forms.Button buttonSauvolaBinarization;
        private System.Windows.Forms.Button buttonOtsuBinarization;
        private System.Windows.Forms.Button buttonDescew;
        private System.Windows.Forms.Button buttonConvertRGBToGray;
        private System.Windows.Forms.Button buttonResetImage;
        private System.Windows.Forms.Button buttonDespeckle;
    }
}

