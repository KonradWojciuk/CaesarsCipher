using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaesarsCipher
{
   public partial class MainWindow : Window
    {
        private readonly List<char> Alphabet = new()
        {
            'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'Ł', 'M', 'N', 'Ń', 'O', 'Ó', 'P', 'Q', 'R',
            'S', 'Ś', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Ź', 'Ż'
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptText_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Shift.Text, out int shift))
                MessageBox.Show("Incorrect offset value! Enter the whole number.");

            string input = TextToEncrypt.Text;
            EncryptedText.Text = Encrypt(input, shift);
        }

        private void DecryptText_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Shift.Text, out int shift))
                MessageBox.Show("Incorrect offset value! Enter the whole number.");

            string input = TextToDecrypt.Text;
            DecryptedText.Text = Decrypt(input, shift);
        }

        private string Encrypt(string input, int shift)
        {
            input = input.Trim().ToUpper();

            if (string.IsNullOrEmpty(input))
                MessageBox.Show("Text box is empty! Please enter your text.");

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    result += ' ';
                    continue;
                }

                if (!Alphabet.Contains(input[i]))
                {
                    MessageBox.Show("Incorrect characters have been entered or the text contains characters not in the alphabet!");
                    break;
                }
                else
                {
                    int index = Alphabet.IndexOf(input[i]);
                    result += Alphabet[(index + shift) % 35];
                }
                    
            }

            return result;
        }

        private string Decrypt(string input, int shift)
        {
            input = input.Trim().ToUpper();

            if (string.IsNullOrEmpty(input))
                MessageBox.Show("Text box is empty! Please enter your text.");

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    result += ' ';
                    continue;
                }

                if (!Alphabet.Contains(input[i]))
                {
                    MessageBox.Show("Incorrect characters have been entered or the text contains characters not in the alphabet!");
                    break;
                }
                else
                {
                    int indexValue = Alphabet.IndexOf(input[i]);
                    int index = indexValue - shift;
                    result += Alphabet[index < 0 ? (index + 35) % 35 : index % 35];
                }

            }

            return result;
        }
    }
}
