using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace PasswordAuthSystem
{
    public partial class MainWindow : Window
    {
        string thePassword;
        DateTime startTime;

        public MainWindow()
        {
            InitializeComponent();
            startTime = DateTime.Now;
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtLength.Text);

            string vowels = "aeiouAEIOU";
            string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";

            List<char> passwordChars = new List<char>();

            Random random = new Random();

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    passwordChars.Add(consonants[random.Next(consonants.Length)]);
                    continue;
                }
                if (i % 3 == 1)
                {
                    passwordChars.Add(vowels[random.Next(vowels.Length)]);
                    continue;
                }
                if (i % 3 == 2)
                {
                    passwordChars.Add(consonants[random.Next(consonants.Length)]);
                    continue;
                }
            }

            thePassword = new string(passwordChars.ToArray());
            txtPassword.Text = thePassword;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DateTime endTime = DateTime.Now;

            if ((endTime - startTime).TotalSeconds > 15)
            {
                MessageBox.Show("Ви заблоковані на 5 хвилин");
                Thread.Sleep(5 * 60 * 1000);
            }
            if (txtInputPassword.Text == thePassword)
            {
                txtCongrats.Text = "Congrats!";
            }
            else
            {
                txtCongrats.Text = "Try again!";
            }
        }

        private void txtLength_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
