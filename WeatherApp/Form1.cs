using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;

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
            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Gomel&APPID=ecc5a526d42be4c17efbe2ba1b3b1f6c");
       
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

            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);
            try
            {
                panel1.BackgroundImage = oW.weather[0].Icon;
            }
            catch (Exception) { }

            label1.Text = oW.weather[0].main;
            label2.Text = oW.weather[0].description;
            label3.Text = "Средняя температура: " + oW.main.temp.ToString("0.##") + "°C";
            label6.Text = "Скорость ветра: " + oW.wind.speed.ToString() + "м\\с";
            label7.Text = "Направление ветра: " + oW.wind.deg.ToString();
            label4.Text = "Влажность: " + oW.main.humidity.ToString()+"%";
            label5.Text= "Давление: "+((int)oW.main.pressure).ToString()+ "mm";
            
                    


        }
    }
}
