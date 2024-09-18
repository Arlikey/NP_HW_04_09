using HtmlAgilityPack;
using System.Security.Policy;

namespace Gutenberg_PopularBooks
{
    public partial class Form1 : Form
    {
        private List<Book> books;

        public Form1()
        {
            InitializeComponent();
            LoadBooks();
        }

        private async void LoadBooks()
        {
            string url = "https://www.gutenberg.org/browse/scores/top";
            books = await GetBooksAsync(url);

            bookListBox.Items.Clear();
            foreach (var book in books)
            {
                bookListBox.Items.Add(book.Title);
            }
        }

        private async Task<List<Book>> GetBooksAsync(string url)
        {
            List<Book> books = new List<Book>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string pageHtml = await response.Content.ReadAsStringAsync();

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(pageHtml);

                var bookNodes = doc.DocumentNode.SelectNodes("//ol[1]//li/a");

                foreach (var node in bookNodes)
                {
                    string title = node.InnerText;
                    string bookUrl = "https://www.gutenberg.org" + node.GetAttributeValue("href", "");

                    if (bookUrl.Contains("/ebooks/"))
                    {
                        books.Add(new Book { Title = title, BookUrl = bookUrl });
                    }
                }
            }
            return books;
        }

        private async void bookListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookListBox.SelectedIndex != -1)
            {
                int index = bookListBox.SelectedIndex;
                var selectedBook = books[index];
                string bookTextUrl = await GetBookTextUrlAsync(selectedBook.BookUrl);

                string bookText = await LoadBookTextAsync(bookTextUrl);
                bookTextBox.Text = bookText;
            }
        }

        private async Task<string> GetBookTextUrlAsync(string bookPageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(bookPageUrl);
                response.EnsureSuccessStatusCode();
                string pageHtml = await response.Content.ReadAsStringAsync();

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(pageHtml);

                var textNode = doc.DocumentNode.SelectSingleNode("//a[contains(@href, '.txt')]");
                if (textNode != null)
                {
                    string textUrl = "https://www.gutenberg.org" + textNode.GetAttributeValue("href", "");
                    response = await client.GetAsync(textUrl);
                    string html = await response.Content.ReadAsStringAsync();
                    doc.LoadHtml(html);
                    textNode = doc.DocumentNode.SelectSingleNode("//a[contains(@href, '.txt')]");
                    if (textNode != null)
                    {
                        textUrl = textNode.GetAttributeValue("href", "");
                        return textUrl;
                    }
                }

                return string.Empty;
            }
        }

        private async Task<string> LoadBookTextAsync(string url)
        {
            if (string.IsNullOrEmpty(url)) return "Текст книги не найден.";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string BookUrl { get; set; }
    }
}
