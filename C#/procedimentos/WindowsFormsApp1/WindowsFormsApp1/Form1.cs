using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox2.Visible = false;
            comboBox3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = this.textBox1.Text;
            XDocument node = XDocument.Load(@"C:\Work\stores.xml");
            XElement element = (from x in node.Descendants("store")
                                where ((string)x.Attribute("rollNumer")) == name
                                select x).FirstOrDefault<XElement>();
            string str2 = (string)element.Element("Name");
            string str3 = (string)element.Descendants("Color").FirstOrDefault<XElement>();
            string str4 = (string)element.Element("Sell");
            this.textBox2.Text = str2;
            this.textBox3.Text = str3;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\\Work\\tip.xml");

            XmlNode idNodes = doc.SelectSingleNode("colors/color");
            foreach (XmlNode node1 in idNodes.ChildNodes)

                comboBox1.Items.Add(node1.InnerText);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            comboBox2.Visible = true;

            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                //MessageBox.Show("escolheste o um");
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\\Work\\tip.xml");
                XmlNode idNodes = doc.SelectSingleNode("colors/pos2");
                foreach (XmlNode node1 in idNodes.ChildNodes)
                    comboBox2.Items.Add(node1.InnerText);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                //MessageBox.Show("escolheste o dois");
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\\Work\\tip.xml");
                XmlNode idNodes = doc.SelectSingleNode("colors/pos3");
                foreach (XmlNode node1 in idNodes.ChildNodes)
                    comboBox2.Items.Add(node1.InnerText);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Clear();
                //MessageBox.Show("escolheste o dois");
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\\Work\\tip.xml");
                XmlNode idNodes = doc.SelectSingleNode("colors/pos4");
                foreach (XmlNode node1 in idNodes.ChildNodes)
                    comboBox2.Items.Add(node1.InnerText);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox3.Visible = true;
            if (comboBox2.Text == "Yellow")
            {
                comboBox3.Items.Clear();
                //MessageBox.Show("escolheste o um");
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\\Work\\tip.xml");
                XmlNode idNodes = doc.SelectSingleNode("colors/pos5");
                foreach (XmlNode node1 in idNodes.ChildNodes)
                    comboBox3.Items.Add(node1.InnerText);
            }
            else if (comboBox2.Text == "Scaner")
            {
                //comboBox3.Items.Clear();
                checkedListBox1.Items.Clear();
                //MessageBox.Show("escolheste o um");
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\\Work\\tip.xml");
                XmlNode idNodes = doc.SelectSingleNode("colors/pos21");
                foreach (XmlNode node1 in idNodes.ChildNodes)
                    checkedListBox1.Items.Add(node1.InnerText);
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.Text += textBox1.Text;
            textBox4.Text += Environment.NewLine + comboBox1.SelectedItem;
            textBox4.Text += Environment.NewLine + comboBox2.SelectedItem;
            foreach (string s in checkedListBox1.CheckedItems)
                textBox4.Text += Environment.NewLine + s;


        }
    }
}
