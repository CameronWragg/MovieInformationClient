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
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dService.HideCommandPromptWindow = true;
            dOptions.AddArgument("--headless");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: //OMDb SECTION
                    IWebDriver driver = new FirefoxDriver(dService, dOptions);
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                                driver.Url = ("http://www.omdbapi.com/?t=" + textBox1.Text + getApi.omdbApiKey);
                                break;
                        case 1:
                                driver.Url = ("http://www.omdbapi.com/?i=" + textBox1.Text + getApi.omdbApiKey);
                                break;
                    }

                    currentSource = driver.FindElement(By.Id("json")).Text;
                    try
                    {
                        dbResponse = JsonConvert.DeserializeObject<dbInfo>(currentSource);
                        titleLabel.Text = dbResponse.title;
                        if (dbResponse.poster != null) { pictureBox1.LoadAsync(dbResponse.poster); }
                        releaseLabel.Text = (dbResponse.Released);
                        runtimeLabel.Text = (dbResponse.runtime);
                        genreLabel.Text = (dbResponse.genre);
                        richTextBox1.Text = (dbResponse.plot);

                    }
                    catch
                    {
                        MessageBox.Show("Title not found, or there was an error. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    driver.Quit();
                    break;
                        
                case 1: //TMDb SECTION
                    Uri homeAddr = new Uri("https://api.themoviedb.org/3/");
                    RestRequest tmdbRequest = new RestRequest(Method.GET);
                    tmdbRequest.RequestFormat = DataFormat.Json;
                    IRestResponse tmdbResponse;
                        
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            RestClient tmdbClient = new RestClient(homeAddr + "search/movie" + getApi.tmdbApiKey + "&language=en-US&query=" + textBox1.Text + "&page=1&include_adult=false");
                            tmdbResponse = tmdbClient.Execute(tmdbRequest);
                            MovieSearchResult tmdbResp = JsonConvert.DeserializeObject<MovieSearchResult>(tmdbResponse.Content);

                            titleLabel.Text = tmdbResp.results[0].title;
                            releaseLabel.Text = tmdbResp.results[0].release_date;
                            if (tmdbResp.results[0].poster_path != null)
                            {
                                pictureBox1.LoadAsync("http://image.tmdb.org/t/p/w300//" + tmdbResp.results[0].poster_path);
                            }

                            richTextBox1.Text = tmdbResp.results[0].overview;

                            break;

                        case 1:
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
            listBox1.Items.Add(dbResponse.title);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loadBookmark = listBox1.SelectedItem.ToString();
            textBox1.Text = (loadBookmark);
            buttonQuery_Click(this, new EventArgs());
        }
    }
}
