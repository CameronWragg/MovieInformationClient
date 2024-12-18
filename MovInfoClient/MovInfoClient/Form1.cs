using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections;
using RestSharp;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace MovInfoClient
{
    public partial class Form1 : Form
    {
        public string currentSource;
        public dbInfo dbResponse;
        public FirefoxDriverService dService = FirefoxDriverService.CreateDefaultService();
        public FirefoxOptions dOptions = new FirefoxOptions();
        public api getApi = new api();

        public List<String> bookmarks;
        private dbSearch dbSearchResult;
        private string search;
        private int pageNo = 1;
        private int totalPages = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dService.HideCommandPromptWindow = true;
            dOptions.AddArgument("--headless");

            if (Properties.Settings.Default.bookmarks != null)
            {
                bookmarks = Properties.Settings.Default.bookmarks;
                updateBookmarks();
            }
            else
            {
                bookmarks = new List<string>();
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: //OMDb SECTION
                    IWebDriver driver = new FirefoxDriver(dService, dOptions);

                    if(textBox1.Text != search)
                    {
                        pageNo = 1;
                    }

                    switch(comboBox1.SelectedIndex)
                    {
                        case 0:
                            driver.Url = ("http://www.omdbapi.com/?apikey=4195df77&s=" + textBox1.Text + "&page=" + pageNo.ToString());
                            break;
                        case 1:
                            driver.Url = ("http://www.omdbapi.com/?apikey=4195df77&t=" + textBox1.Text);
                            break;
                        case 2:
                            driver.Url = ("http://www.omdbapi.com/?apikey=4195df77&i=" + textBox1.Text);
                            break;
                    }
                    
                    currentSource = driver.FindElement(By.Id("json")).Text;
                    
                    if (comboBox1.SelectedIndex == 0)
                    {
                        try
                        {
                            dbSearchResult = JsonConvert.DeserializeObject<dbSearch>(currentSource);

                            search = textBox1.Text;
                            txtResults.Text = dbSearchResult.totalResults.ToString();
                            totalPages = (int)Math.Ceiling((decimal)dbSearchResult.totalResults / 10);

                            listSearchResults.Items.Clear();

                            foreach (dbInfo film in dbSearchResult.search)
                            {
                                listSearchResults.Items.Add(film.title + " (" + film.year + ")");
                            }

                            if (pageNo == 0)
                            {
                                btnSearchBack.Enabled = false;
                            }
                            else
                            {
                                btnSearchBack.Enabled = true;
                            }

                            if (pageNo < totalPages)
                            {
                                btnSearchForward.Enabled = true;
                            }
                            else
                            {
                                btnSearchForward.Enabled = false;
                            }

                            txtPage.Text = pageNo.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("An error occurred. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            dbResponse = JsonConvert.DeserializeObject<dbInfo>(currentSource);
                            titleLabel.Text = dbResponse.title;
                            if (dbResponse.poster != null) { pictureBox1.LoadAsync(dbResponse.poster); }
                            releaseLabel.Text = (dbResponse.Released);
                            runtimeLabel.Text = (dbResponse.runtime);
                            genreLabel.Text = (dbResponse.genre);
                            richTextBox1.Text = dbResponse.plot;
                        }
                        catch
                        {
                            MessageBox.Show("Title not found, or there was an error. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    driver.Quit();
                    break;
                    
                case 1: //TMDb SECTION
                    Uri homeAddr = new Uri("https://api.themoviedb.org/3/");
                    RestRequest tmdbRequest = new RestRequest(Method.GET);
                    RestClient tmdbClient;
                    MovieSearchResult tmdbResp;
                    tmdbRequest.RequestFormat = DataFormat.Json;
                    IRestResponse tmdbResponse;
                        
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            tmdbClient = new RestClient(homeAddr + "search/movie" + getApi.tmdbApiKey + "&language=en-US&query=" + textBox1.Text + "&page=" + pageNo + "&include_adult=false");
                            tmdbResponse = tmdbClient.Execute(tmdbRequest);
                            tmdbResp = JsonConvert.DeserializeObject<MovieSearchResult>(tmdbResponse.Content);

                            search = textBox1.Text;
                            txtResults.Text = tmdbResp.total_results.ToString();
                            totalPages = tmdbResp.total_pages;

                            listSearchResults.Items.Clear();

                            foreach(Movie film in tmdbResp.results)
                            {
                                listSearchResults.Items.Add(film.title + " (" + film.release_date.Substring(0, 4) + ")");
                            }

                            break;
                        case 1:
                            tmdbClient = new RestClient(homeAddr + "search/movie" + getApi.tmdbApiKey + "&language=en-US&query=" + textBox1.Text + "&page=1&include_adult=false");
                            tmdbResponse = tmdbClient.Execute(tmdbRequest);
                            tmdbResp = JsonConvert.DeserializeObject<MovieSearchResult>(tmdbResponse.Content);

                            titleLabel.Text = tmdbResp.results[0].title;
                            releaseLabel.Text = tmdbResp.results[0].release_date;
                            if (tmdbResp.results[0].poster_path != null)
                            {
                                pictureBox1.LoadAsync("http://image.tmdb.org/t/p/w300//" + tmdbResp.results[0].poster_path);
                            }

                            richTextBox1.Text = tmdbResp.results[0].overview;

                            break;
                        case 2:
                            RestClient tmdbIdClient = new RestClient(homeAddr + "find/" + textBox1.Text + getApi.tmdbApiKey + "&language=en-US&external_source=imdb_id");
                            tmdbResponse = tmdbIdClient.Execute(tmdbRequest);
                            MovieResult tmdbIdResp = JsonConvert.DeserializeObject<MovieResult>(tmdbResponse.Content);
                                
                            titleLabel.Text = tmdbIdResp.movie_results[0].title;
                            releaseLabel.Text = tmdbIdResp.movie_results[0].release_date;
                            if (tmdbIdResp.movie_results[0].poster_path != null)
                            {
                                pictureBox1.LoadAsync("http://image.tmdb.org/t/p/w300//" + tmdbIdResp.movie_results[0].poster_path);
                            }

                            richTextBox1.Text = tmdbIdResp.movie_results[0].overview;

                            break;
                    }
                    break;
            }

            if (!bookmarks.Contains(titleLabel.Text))
            {
                button2.Text = "Add to Bookmarks";
            }
            else
            {
                button2.Text = "Remove from Bookmarks";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                buttonQuery_Click(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!bookmarks.Contains(titleLabel.Text))
            { 
                bookmarks.Add(titleLabel.Text);
                button2.Text = "Remove from Bookmarks";
            }
            else
            {
                bookmarks.Remove(titleLabel.Text);
                button2.Text = "Add to Bookmarks";
            }
            updateBookmarks();
        }

        private void listBookmarks_DoubleClick(object sender, EventArgs e)
        {
            string loadBookmark = listBookmarks.SelectedItem.ToString();
            loadBookmark = loadBookmark.Substring(0, loadBookmark.Length);
            textBox1.Text = (loadBookmark);
            comboBox1.SelectedIndex = 1;
            buttonQuery_Click(this, new EventArgs());
        }

        private void listSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loadResult = listSearchResults.SelectedItem.ToString();
            loadResult = loadResult.Substring(0, loadResult.Length - 7);
            textBox1.Text = (loadResult);
            comboBox1.SelectedIndex = 1;
            buttonQuery_Click(this, new EventArgs());
        }

        public void updateBookmarks()
        {
            listBookmarks.Items.Clear();

            foreach(string bmark in bookmarks)
            {
                listBookmarks.Items.Add(bmark);
            }

            Properties.Settings.Default.bookmarks = bookmarks;
            Properties.Settings.Default.Save();
        }
        
        private void btnSearchForward_Click(object sender, EventArgs e)
        {
            pageNo += 1;
            comboBox1.SelectedIndex = 0;
            textBox1.Text = search;
            buttonQuery_Click(this, new EventArgs());
        }

        private void btnSearchBack_Click(object sender, EventArgs e)
        {
            pageNo -= 1;
            comboBox1.SelectedIndex = 0;
            textBox1.Text = search;
            buttonQuery_Click(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            String id = "tt" + r.Next(0, 4633694).ToString("D6");

            comboBox1.SelectedIndex = 2;
            textBox1.Text = id;
            buttonQuery_Click(this, new EventArgs());
        }
    }
}