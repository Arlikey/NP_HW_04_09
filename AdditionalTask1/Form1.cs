namespace Gutenberg_Shakespeare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string content = await client.GetStringAsync("https://www.gutenberg.org/cache/epub/1524/pg1524.txt");

            hamletTextBox.Text = content;
        }
    }
}
