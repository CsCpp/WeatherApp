using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Moscow&APPID=ecc5a526d42be4c17efbe2ba1b3b1f6c");
       
        request.Method = "POST";
        request.ContentType = "application/x-www-urlencoded";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s=response.GetResponseStream())
            {
                using(StreamReader reader=new StreamReader(s))
                {
                    answer= await reader.ReadToEndAsync();
                }

            }
            response.Close();
            richTextBox1.Text = answer;
        
        }
    }
}
