using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace flags
{
    //test bericht 5
    public partial class Form1 : Form
    {
        string[] files = Directory.GetFiles(@"flags/", "*.png");
        Dictionary<string, string> nameCode = new Dictionary<string, string>();
        Dictionary<string, string> countryCodes = new Dictionary<string, string>();
        Random ranNum = new Random();
        string answer;

        public Form1()
        {
            InitializeComponent();
            
            using (var reader = new StreamReader(@"flag_information.csv"))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var code = values[1];
                    var fullCountry = values[0];
                    countryCodes.Add(code, fullCountry);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(inputBox.Text == label1.Text)
            {
                label1.Text = "Yeah! :D";
                label1.Visible = true;
                label2.Text = answer;
                inputBox.Clear();
            }
            else
            {
                label1.Visible = true;
                label1.Text = "Naww :(";
                label2.Text = answer;
                inputBox.Clear();
                
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int num = ranNum.Next(0,files.Length);
            string result = Path.GetFileNameWithoutExtension(files[num]);
            pictureBox1.Image = new Bitmap(files[num]);
            countryCodes.TryGetValue(result.ToUpper(), out answer);
            //inputBox.Text = result;
            label1.Visible = false;
            label1.Text = answer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int num = ranNum.Next(0, files.Length);
            string result = Path.GetFileNameWithoutExtension(files[num]);
            pictureBox1.Image = new Bitmap(files[num]);
            countryCodes.TryGetValue(result.ToUpper(), out answer);
            label1.Visible = false;
            label1.Text = answer;
        }
    }
}