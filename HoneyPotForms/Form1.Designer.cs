namespace HoneyPotForms
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Draw_Button = new Button();
            pictureBox1 = new PictureBox();
            UploadButton = new Button();
            Hex_Per_Row = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Hex_Per_Row).BeginInit();
            SuspendLayout();
            // 
            // Draw_Button
            // 
            Draw_Button.Location = new Point(12, 12);
            Draw_Button.Name = "Draw_Button";
            Draw_Button.Size = new Size(75, 23);
            Draw_Button.TabIndex = 0;
            Draw_Button.Text = "Draw";
            Draw_Button.UseVisualStyleBackColor = true;
            Draw_Button.Click += Draw_Button_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(12, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 397);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // UploadButton
            // 
            UploadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UploadButton.Location = new Point(713, 12);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(75, 23);
            UploadButton.TabIndex = 2;
            UploadButton.Text = "Upload";
            UploadButton.UseVisualStyleBackColor = true;
            UploadButton.Click += UploadButton_Click;
            // 
            // Hex_Per_Row
            // 
            Hex_Per_Row.Anchor = AnchorStyles.Top;
            Hex_Per_Row.AutoSize = true;
            Hex_Per_Row.Location = new Point(385, 12);
            Hex_Per_Row.Name = "Hex_Per_Row";
            Hex_Per_Row.Size = new Size(120, 23);
            Hex_Per_Row.TabIndex = 3;
            Hex_Per_Row.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(305, 16);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 4;
            label1.Text = "Hex Per Row";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(Hex_Per_Row);
            Controls.Add(UploadButton);
            Controls.Add(pictureBox1);
            Controls.Add(Draw_Button);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Hex_Per_Row).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Draw_Button;
        private PictureBox pictureBox1;
        private Button UploadButton;
        private NumericUpDown Hex_Per_Row;
        private Label label1;
    }
}
