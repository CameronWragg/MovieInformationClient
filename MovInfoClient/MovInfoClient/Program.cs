using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MovInfoClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class dbInfo
    {
        public string title { get; set; }
        public int year { get; set; }
        public string rated { get; set; }
        public string Released { get; set; }
        public string runtime { get; set; }
        public string genre { get; set; }
        public string director { get; set; }
        public string writer { get; set; }
        public string actors { get; set; }
        public string plot { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string awards { get; set; }
        public string poster { get; set; }
        //public string ratings { get; set; }
        public int metascore { get; set; }
        public double imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string type { get; set; }
        public string dvd { get; set; }
        public string boxOffice { get; set; }
        public string production { get; set; }
        public string website { get; set; }
        public string response { get; set; }
    }
}
