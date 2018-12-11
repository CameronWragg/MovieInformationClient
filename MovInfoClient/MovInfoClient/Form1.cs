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

        public List<String> bookmarks;

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

            comboBox1.SelectedItem = "Title";
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new FirefoxDriver(dService, dOptions);
            switch(comboBox1.SelectedItem)
            {
                case "Title":
                    driver.Url = ("http://www.omdbapi.com/?apikey=4195df77&t=" + textBox1.Text);
                    break;
                case "imdbID":
                    driver.Url = ("http://www.omdbapi.com/?apikey=4195df77&i=" + textBox1.Text);
                    break;
                default:
                    driver.Url = ("http://www.omdbapi.com/?apikey=4195df77&t=" + textBox1.Text);
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

                if (!bookmarks.Contains(dbResponse.title))
                {
                    button2.Text = "Add to Bookmarks";
                }
                else
                {
                    button2.Text = "Remove from Bookmarks";
                }

            } catch
            {
                MessageBox.Show("Title not found, or there was an error. Try again", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
            driver.Quit();
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
            if (!bookmarks.Contains(dbResponse.title))
            { 
                bookmarks.Add(dbResponse.title);
                button2.Text = "Remove from Bookmarks";
            }
            else
            {
                bookmarks.Remove(dbResponse.title);
                button2.Text = "Add to Bookmarks";
            }
            updateBookmarks();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loadBookmark = listBox1.SelectedItem.ToString();
            textBox1.Text = (loadBookmark);
            buttonQuery_Click(this, new EventArgs());
        }

        public void updateBookmarks()
        {
            listBox1.Items.Clear();

            foreach(string bmark in bookmarks)
            {
                listBox1.Items.Add(bmark);
            }

            Properties.Settings.Default.bookmarks = bookmarks;
            Properties.Settings.Default.Save();
        }
    }
}
