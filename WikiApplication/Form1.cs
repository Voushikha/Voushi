using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WikiApplication
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   listView1.Items.Clear();
            for (int i = 0; i < ROW; i++)
            {
                ListViewItem item = new ListViewItem(TwoDimAry[i, 0]);
                item.SubItems.Add(TwoDimAry[i, 1]);
                item.SubItems.Add(TwoDimAry[i, 2]);
                listView1.Items.Add(item);
                listView1.Sort();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {




        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxName.Text) &&
                !string.IsNullOrEmpty(textBoxCategory.Text))
              //!string.IsNullOrEmpty(textBoxStructure.Text) &&
             // !string.IsNullOrEmpty(textBoxDefinition.Text))
            {
                // Assuming listView1 is your ListView control
                // Create an array to hold the values from the textboxes
                string[] itemValues = new string[] {
            textBoxName.Text,
            textBoxCategory.Text,
         // textBoxStructure.Text,
          //textBoxDefinition.Text
        };

                // Create a ListViewItem with the array of values
                ListViewItem item = new ListViewItem(itemValues);



                // Add the ListViewItem to the ListView
                listView1.Items.Add(item);

                // items from textboxes will be clear after being displayed on listview
                textBoxName.Clear();
                textBoxCategory.Clear();
            //  textBoxStructure.Clear();
             // textBoxDefinition.Clear();
            }

        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            
      // textBoxName.Text
             


            try
            {
                listView1.SelectedItems[0].SubItems[0].Text = textBoxName.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBoxCategory.Text;
          //    listView1.SelectedItems[0].SubItems[2].Text = textBoxStructure.Text;
          //    listView1.SelectedItems[0].SubItems[3].Text = textBoxDefinition.Text;
            }
            catch { }

       
        }
    

    
        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }

        private void LabelCategory_Click(object sender, EventArgs e)
        {
           
        }

        private void labelCategory_Click(object sender, EventArgs e)
        {
     
           

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
