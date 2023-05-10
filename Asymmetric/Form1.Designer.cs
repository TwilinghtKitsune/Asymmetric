namespace Asymmetric
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
            textKey = new TextBox();
            downloadKey = new Button();
            originalText = new TextBox();
            keyGeneration = new Button();
            finalText = new TextBox();
            downloadText = new Button();
            encoding = new Button();
            decoding = new Button();
            save = new Button();
            SuspendLayout();
            // 
            // textKey
            // 
            textKey.Location = new Point(12, 12);
            textKey.Name = "textKey";
            textKey.Size = new Size(446, 27);
            textKey.TabIndex = 0;
            // 
            // downloadKey
            // 
            downloadKey.Location = new Point(464, 6);
            downloadKey.Name = "downloadKey";
            downloadKey.Size = new Size(263, 38);
            downloadKey.TabIndex = 1;
            downloadKey.Text = "Загрузить открытый ключ";
            downloadKey.UseVisualStyleBackColor = true;
            downloadKey.Click += downloadKey_Click;
            // 
            // originalText
            // 
            originalText.Location = new Point(12, 50);
            originalText.Multiline = true;
            originalText.Name = "originalText";
            originalText.Size = new Size(515, 373);
            originalText.TabIndex = 2;
            // 
            // keyGeneration
            // 
            keyGeneration.Location = new Point(733, 4);
            keyGeneration.Name = "keyGeneration";
            keyGeneration.Size = new Size(156, 40);
            keyGeneration.TabIndex = 4;
            keyGeneration.Text = "Генерация ключа";
            keyGeneration.UseVisualStyleBackColor = true;
            keyGeneration.Click += keyGeneration_Click;
            // 
            // finalText
            // 
            finalText.Location = new Point(533, 51);
            finalText.Multiline = true;
            finalText.Name = "finalText";
            finalText.Size = new Size(515, 373);
            finalText.TabIndex = 5;
            // 
            // downloadText
            // 
            downloadText.Location = new Point(12, 429);
            downloadText.Name = "downloadText";
            downloadText.Size = new Size(214, 40);
            downloadText.TabIndex = 6;
            downloadText.Text = "Загрузить исходный текст";
            downloadText.UseVisualStyleBackColor = true;
            downloadText.Click += downloadText_Click;
            // 
            // encoding
            // 
            encoding.Location = new Point(533, 430);
            encoding.Name = "encoding";
            encoding.Size = new Size(214, 40);
            encoding.TabIndex = 7;
            encoding.Text = "Закодировать";
            encoding.UseVisualStyleBackColor = true;
            encoding.Click += encoding_Click;
            // 
            // decoding
            // 
            decoding.Location = new Point(834, 429);
            decoding.Name = "decoding";
            decoding.Size = new Size(214, 40);
            decoding.TabIndex = 8;
            decoding.Text = "Декодировать";
            decoding.UseVisualStyleBackColor = true;
            decoding.Click += decoding_Click;
            // 
            // save
            // 
            save.Location = new Point(895, 5);
            save.Name = "save";
            save.Size = new Size(156, 40);
            save.TabIndex = 9;
            save.Text = "Сохранить";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 477);
            Controls.Add(save);
            Controls.Add(decoding);
            Controls.Add(encoding);
            Controls.Add(downloadText);
            Controls.Add(finalText);
            Controls.Add(keyGeneration);
            Controls.Add(originalText);
            Controls.Add(downloadKey);
            Controls.Add(textKey);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textKey;
        private Button downloadKey;
        private TextBox originalText;
        private Button keyGeneration;
        private TextBox finalText;
        private Button downloadText;
        private Button encoding;
        private Button decoding;
        private Button save;
    }
}