using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using WPF_Example.Data;
using WPF_Example.Models;

namespace WPF_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<Post> Items { get; set; }
        public ObservableCollection<Book> Items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Items = new();
            DataContext = this;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //var httpClient = new HttpClient();
            //var result = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            //var posts = JsonSerializer.Deserialize<List<Post>>(result);

            //foreach (var post in posts)
            //{
            //    Items.Add(post);
            //    Thread.Sleep(100);
            //}

            var context = new AppDbContext();
            //var books = context.Books.ToList();
            //var books = await context.Books.ToListAsync();

            var books = context.Books.AsParallel().ToList();


            foreach (var book in books)
            {
                Items.Add(book);

            }

        }

        #region First Example

        //private void DoSomething()
        //{
        //    Thread.Sleep(2000);
        //    Dispatcher.Invoke(() => { lbl.Content = "salam"; });
        //}

        //private async Task<string> DoSomethingAsync()
        //{
        //    //await Task.Delay(2000);
        //    //var result = "salam";

        //    HttpClient client = new();
        //    var result = await client.GetStringAsync("https://lb.itstep.org/");

        //    return result;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Thread thread = new Thread(DoSomething);
        //    thread.Start();
        //}

        //private async void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var result = await DoSomethingAsync();
        //    //lbl.Content = result;
        //}

        #endregion
    }
}