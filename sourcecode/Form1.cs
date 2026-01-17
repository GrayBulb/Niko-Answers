using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Niko
{
    public partial class Form1 : Form
    {
        
        private readonly TextBox inputTextBox;
        private readonly Button nikoButton;
        private readonly Random random = new Random();

        private readonly List<string> nikoResponses = new List<string>
        {
            "I think no.",
            "I think yes!",
            "I really don't know..",
            "On your dreams!",
            "Pigs flys.",
            "Maybe ask again later.",
            "Maybe",
            "I have no clue.",
            "Perhaps.",
            "Niko is thinking about why this sperm won?",
            "Only time will tell.",
            "I wouldn't count on it.",
            "Absolutely!",
            "Not in a million years.",
            "It's possible.",
            "Why not?",
            "Never!",
            "Ask again tomorrow.",
            "I'm not sure...",
            "Definitely maybe."
        };

        private readonly List<string> prefixes = new List<string>
        {
            "Niko says: ",
            "I think... ",
            "Hmm, ",
            "Well, ",
            "Listen: "
        };

        private readonly List<string> suffixes = new List<string>
        {
            " ...I agree with this!",
            " ...you should think about it.",
            " ...interesting!",
            " ...maybe.",
            " ...don't ask me again."
        };

        public Form1()
        {
            InitializeComponent();

            // Normal window
            this.Text = "Niko";
            this.Icon = new Icon("niko.ico");
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // normal window with title bar
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // Slightly thicker client area
            this.ClientSize = new Size(280, 80); // compact but not squished

            // TextBox
            inputTextBox = new TextBox
            {
                Location = new Point(10, 10),
                Width = this.ClientSize.Width - 20,
                Height = 20,
                PlaceholderText = "Type text"
            };
            this.Controls.Add(inputTextBox);

            // Button centered below TextBox
            nikoButton = new Button
            {
                Text = "Let Niko Answer",
                Width = 120,
                Height = 25,
                Location = new Point(
                    (this.ClientSize.Width - 120) / 2,
                    inputTextBox.Bottom + 10
                )
            };
            nikoButton.Click += NikoButton_Click;
            this.Controls.Add(nikoButton);
        }

        private void NikoButton_Click(object? sender, EventArgs e)
        {
            string userInput = inputTextBox.Text.Trim();

            if (string.Equals(userInput, "copy me", StringComparison.OrdinalIgnoreCase))
            {
                string prefix = prefixes[random.Next(prefixes.Count)];
                string suffix = suffixes[random.Next(suffixes.Count)];

                MessageBox.Show($"{prefix}{userInput}{suffix}", "Niko copies you");
            }
            else
            {
                int index = random.Next(nikoResponses.Count);
                string response = nikoResponses[index];
                MessageBox.Show(response, "Niko says");
            }
        }
    }
}
