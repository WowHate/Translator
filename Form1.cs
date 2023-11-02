using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTranslate;
using GTranslate.Translators;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Gtranslation (string UntranlatedText, string lang)
        {
            var translator = new GoogleTranslator2();
            if (UntranlatedText.ToString() == "")
            {
                label2.Text = "field empty";
            }
            else
            {
                label2.Text = "";
                var result = translator.TranslateAsync(UntranlatedText, lang).Result;
                var fresult = result.ToString();
                richTextBox3.Text = fresult.ToString();
                var count = fresult.LastIndexOf("', TargetLanguage: ");
                fresult = fresult.Remove(count);
                fresult = fresult.Substring(14);
                richTextBox2.Text = fresult.ToString();
            }
        }

        void Ytranslation(string UntranlatedText, string lang)
        {
            var translator = new YandexTranslator();
            if (UntranlatedText.ToString() == "")
            {
                label2.Text = "field empty";
            }
            else
            {
                label2.Text = "";
                var result = translator.TranslateAsync(UntranlatedText, lang).Result;
                var fresult = result.ToString();
                richTextBox3.Text = fresult.ToString();
                var count = fresult.LastIndexOf("', TargetLanguage: ");
                fresult = fresult.Remove(count);
                fresult = fresult.Substring(14);
                richTextBox2.Text = fresult.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lang;
            if (radioButton1.Checked)
            {
                if (radioButton3.Checked)
                {
                    lang = "ru";
                    Ytranslation(richTextBox1.Text, lang);
                }
                else if (radioButton4.Checked)
                {
                    lang = "en";
                    Ytranslation(richTextBox1.Text, lang);
                }
                else
                {
                    label2.Text = "Choose language";
                }
                
            }
            else if (radioButton2.Checked)
            {
                if (radioButton3.Checked)
                {
                    lang = "ru";
                    Gtranslation(richTextBox1.Text, lang);
                }
                else if (radioButton4.Checked)
                {
                    lang = "en";
                    Gtranslation(richTextBox1.Text, lang);
                }
                else
                {
                    label2.Text = "Choose language";
                }
            }
            else
            {
                label2.Text = "Choose translator";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Text = "";
        }
    }
}
