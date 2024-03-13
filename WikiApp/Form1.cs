using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int ROW = 12;
        static int COL = 4;
        string[,] TwoDimAry = new string[ROW, COL];
        private object columnHeader1Name;
        private object textBoxstructure;

        public object ListVieW1 { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] ROW = { /* Your array values here */ };
            for (int j = 0; j < ROW.Length; j++)
            {
                for (int k = j + 1; k < ROW.Length; k++)
                {
                    if (ROW[j] > ROW[k])
                    {
                        int temp = ROW[j];
                        ROW[j] = ROW[k];
                        ROW[k] = temp;
                    }
                }
            }
            // Display the sorted array in the ListView.
            for (int i = 0; i < ROW.Length; i++)
            {
                ListViewItem item = new ListViewItem(ROW[i].ToString());
                listView1.Items.Add(item);
            }


            {
                ListViewItem listItem = new ListViewItem();
                listView1.Items.Add(listItem);
                listView1.Sort();

                for (int i = 0; i < ROW.Length; i++)
                {
                    Console.Write(ROW[i] + ", ");
                }
                // Pause the program so the output can be viewed.
                Console.ReadLine();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxName.Text) &&
                !string.IsNullOrEmpty(textBoxCategory.Text))

            {
                // Assuming listView1 is your ListView control
                // Create an array to hold the values from the textboxes
                string[] itemValues = new string[] {

            textBoxName.Text,
            textBoxCategory.Text,


        };

                // Create a ListViewItem with the array of values
                ListViewItem item = new ListViewItem(itemValues);


                // Add the ListViewItem to the ListView
                listView1.Items.Add(item);

                // items from textboxes will be clear after being displayed on listview
                textBoxName.Clear();
                textBoxCategory.Clear();

            }



        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {

            try
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBoxName.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBoxCategory.Text;

            }
            catch { }




        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            // initial path set to nothing to ensure no reading or writing until a file is selected
            string path = "";
            // track changed status of textbox
            bool textChanged = false;
            // file loading flag
            bool fileLoading = false;
        }
        //savefiledialog for save bitton

        private void labelCategory_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Enter an integer value for the Binary Search


            List<string> list = new List<string>();
            Console.WriteLine(list.Count);
            //Loop through each item in the ListView
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                // Add the string "" of each ListView item to the list
                list.Add(listView1.Items[i].ToString());
            }
            Console.WriteLine(list.Count);
            // Get text from a TextBox .name the var 'key'
            string key = textBox1.Text;
            Console.WriteLine(key.ToString());
            //find index 'key' in the list
            int index = list.IndexOf(key);
            Console.WriteLine(index.ToString());
            // loop - each item in list , find the item that contains 'key'
            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].Contains("{" + key + "}"))
                {
                    index = i;
                }
            }
            Console.WriteLine(index.ToString());


            //if item found display message below:
            if (index >= 0)
            {
                MessageBox.Show("Success; Item found at [" + index + "] ");
            }
            else
            {
                MessageBox.Show("Search did not find the value", "Not Found");
                textBox1.Text = "";
                textBox1.Focus();

            }
        }

       
    }

}
