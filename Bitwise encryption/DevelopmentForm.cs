using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitwise_encryption
{
    public partial class DevelopmentForm : Form
    {
        string filePath;
        List<int> allPrimeNumbers = SieveEratosthenes(100);
        int n, ф, e, d;
        public DevelopmentForm()
        {
            InitializeComponent();
        }

        private async void ChooseFileBT_Click(object sender, EventArgs ebay)
        {
            await ChooseFile();
        }

        private void DirectoryBT_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Path.GetDirectoryName(filePath)))
                Process.Start("explorer", Path.GetDirectoryName(filePath));
            else
                MessageBox.Show("Выберите файл", "Просмотр каталога", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task ChooseFile()
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo directory = new DirectoryInfo(folderBrowser.SelectedPath);
                    if (directory.Exists)
                    {
                        string method = "";
                        if (CodeRB.Checked)
                        {
                            method = "закодирован";

                            DirectoryInfo newDirectory = new DirectoryInfo($"{DeleteJunk(directory.FullName)} ({method}ное)");
                            newDirectory.Create();


                            CreateKey();
                            foreach (var item in directory.GetFiles())
                            {
                                filePath = newDirectory.FullName;
                                var data = Crypto(File.ReadAllBytes(item.FullName));
                                WriteAllBytes(item.Name, data, method);
                            }
                            SuckCess(method);
                            KeyTB.Text = $"{e}-{n}-{ф}";
                        }
                        else
                        {
                            method = "декодирован";
                            DirectoryInfo newDirectory = new DirectoryInfo($"{DeleteJunk(directory.FullName)} ({method}ное)");
                            newDirectory.Create();

                            ReadKey();
                            timer.Start();
                            indicatorLabel.Visible = true;
                            await Task.Run(() =>
                            {
                                foreach (var item in directory.GetFiles())
                                {
                                    filePath = newDirectory.FullName;
                                    var data = Decrypto(File.ReadAllBytes(item.FullName));
                                    WriteAllBytes(item.Name, data, "декодирован");
                                }
                                SuckCess("декодирован");
                            });
                            indicatorLabel.Visible = false;
                            timer.Stop();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuckCess(string method)
        {
            MessageBox.Show($"Файлы успешно {method}ы", "Запись в файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static List<int> SieveEratosthenes(int n)
        {
            var numbers = new List<int>();
            for (var i = 2; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }
            return numbers;
        }

        public byte[] Crypto(byte[] bytes)
        {
            byte[] file;

            file = EncryptText(bytes, n, e);
            return file;
        }

        public byte[] Decrypto(byte[] bytes)
        {
            try
            {
                byte[] file;

                file = DecryptText(bytes, n, d);
                return file;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void CreateKey()
        {
            Random simpleNum = new Random();
            int p, q;
            do
            {
                p = PrimeNumber(simpleNum);
                q = PrimeNumber(simpleNum);
                n = p * q;
            }
            while (q == p || n < 255 || n > 255 * 255);

            ф = (p - 1) * (q - 1);
            e = CalculateE(ф);
        }

        private void ReadKey()
        {
            string[] key = KeyTB.Text.Split('-');
            e = Convert.ToInt32(key[0]);
            n = Convert.ToInt32(key[1]);
            ф = Convert.ToInt32(key[2]);
            d = CalculateD(e, ф);
        }

        private static byte[] EncryptText(byte[] bytes, int m, int n)
        {
            long c;
            byte[] file = new byte[bytes.Length * 2];
            for (int j = 0; j < bytes.Length; j++)
            {
                c = Cypher(m, n, bytes[j]);
                BitConverter.GetBytes((ushort)c).CopyTo(file, j * 2);
            }
            return file;
        }

        private static byte[] DecryptText(byte[] bytes, int m, int n)
        {
            try
            {
                long c;
                byte[] file = new byte[(bytes.Length / 2) + 1];
                for (int j = 0; j < bytes.Length / 2; j++)
                {
                    ushort twoBytes = BitConverter.ToUInt16(bytes.Skip(j * 2).Take(2).ToArray(), 0);
                    c = Cypher(m, n, twoBytes);
                    BitConverter.GetBytes((ushort)c).CopyTo(file, j);
                }
                return file;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return null;
            }
            
        }

        private static long Cypher(int m, int n, ushort bytes)
        {
            long c = 1;
            for (int i = 0; i < n; i++)
                c = (bytes * c) % m;
            return c;
        }

        private int CalculateD(int e, int ф)
        {
            int x, y, d = 0;
            for (int i = 2; i < ф; i++)
            {
                if (InverceExponentD(i, ф, out x, out y) == 1)
                {
                    e = i;
                    d = (x % ф + ф) % ф;
                    break;
                }
            }
            return d;
        }

        private int CalculateE(int ф)
        {
            int i = 2;
            while (!IsCoprime(i, ф) && i < ф)
                i++;
            return i;
        }

        private int InverceExponentD(int a, int b, out int x, out int y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            int x1, y1;
            int d = InverceExponentD(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }

        int temp = 1;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (temp < 5)
            {
                indicatorLabel.Text += ".";
            }
            else
            {
                indicatorLabel.Text = "Идёт декодирование.";
                temp = 1;
            }
            temp++;
        }

        private void WriteAllBytes(string fileName, byte[] data, string method)
        {
            try
            {
                fileName = $"{Path.GetFileNameWithoutExtension(DeleteJunk(fileName))} ({method}ное){Path.GetExtension(fileName)}";
                if (!File.Exists(Path.Combine(filePath, fileName)))
                {
                    File.WriteAllBytes(Path.Combine(filePath, fileName), data);
                }
                else
                {
                    File.Delete(Path.Combine(Path.GetDirectoryName(filePath), fileName));
                    File.WriteAllBytes(Path.Combine(filePath, fileName), data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DeleteJunk(string inputString)
        {
            inputString = inputString.Replace(" (закодированное)", "");
            inputString = inputString.Replace(" (декодированное)", "");
            return inputString;
        }

        private int PrimeNumber(Random simpleNum)
        {
            int result = allPrimeNumbers[simpleNum.Next(0, allPrimeNumbers.Count - 1)];
            return result;
        }

        public static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }
    }
}
