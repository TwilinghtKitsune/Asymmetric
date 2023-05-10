namespace Asymmetric
{
    public partial class Form1 : Form
    {
        byte[] arr;
        public Form1()
        {
            InitializeComponent();
        }

        private void keyGeneration_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicPrivateKey = rsa.ToXmlString(true);
            string publicOnlyKey = rsa.ToXmlString(false);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "txt files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.FileName = "PublicOnlyKey.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(publicOnlyKey);
                }
            }

            textKey.Text = publicOnlyKey; 
            
            using (StreamWriter writer = new StreamWriter("\\Key\\PrKey.key"))
            {
                writer.Write(publicPrivateKey);
            }
            using (StreamWriter writer = new StreamWriter("\\Key\\PuKey.key"))
            {
                writer.Write(publicOnlyKey);
            }
        }

        private void downloadKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog.OpenFile();
                textKey.Text = "";

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textKey.Text = reader.ReadToEnd();
                }
            }
            textKey.Text = textKey.Text.Replace("\r\n", "");
        }

        private void downloadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog.OpenFile();
                originalText.Text = "";

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    originalText.Text = reader.ReadToEnd();
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "EncodedText.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(finalText.Text);
                }
            }
        }

        private string ToString(byte[] byteArr)
        {
            string res = "";
            for(int i = 0; i < byteArr.Length - 1; i += 2)
            {
                res += BitConverter.ToChar(byteArr, i);
            }
            return res;
        }

        private byte[] ToByte(string str)
        {
            byte[] arrByte = new byte[str.Length * 2];
            byte[] arrChar;
            int k = 0;
            for (int i = 0; i < str.Length; i++)
            {
                arrChar = BitConverter.GetBytes(str[i]);
                for (int j = 0; j < 2; j++)
                {
                    arrByte[k] = arrChar[j];
                    k++;
                }
            }
            return arrByte;
        }

        private void encoding_Click(object sender, EventArgs e)
        {
            if (!textKey.Text.Equals("") && !originalText.Text.Equals(""))
            {
                byte[] data = ToByte(originalText.Text);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(textKey.Text);

                byte[] plainbytes = rsa.Encrypt(data, false);

                finalText.Text = ToString(plainbytes);

            }
            else if (textKey.Text.Equals(""))
            {
                MessageBox.Show("Не указан публичный ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Текст для кодирования не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void decoding_Click(object sender, EventArgs e)
        {            
            if (!textKey.Text.Equals("") && !originalText.Text.Equals(""))
            {
                string publicKey;
                string privateKey;
                using (StreamReader reader = new StreamReader("\\Key\\PuKey.key"))
                {
                    publicKey = reader.ReadToEnd();
                }

                if (publicKey.Equals(textKey.Text))
                {
                    using (StreamReader reader = new StreamReader("\\Key\\PrKey.key"))
                    {
                        privateKey = reader.ReadToEnd();
                    }
                    try
                    {
                        byte[] data = ToByte(originalText.Text);
                        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                        rsa.FromXmlString(privateKey);

                        byte[] plainbytes = rsa.Decrypt(data, false);
                        finalText.Text = ToString(plainbytes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Возникла ошибка при декодировании. Невозможно расшифровать данный текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Указанный ключ не является актуальным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
            else if (textKey.Text.Equals(""))
            {
                MessageBox.Show("Не указан публичный ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Текст для декодирования не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}