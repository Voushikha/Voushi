//23/03/2024
//30077230
//vOUSHIKHA BALKISSOON
//AT1
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WikiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int ROW = 12; //maximum no of data 
        static int COL = 4; // name , category ,structure , definitions
        int ptr = 0;
        string[,] TwoDimAry = new string[ROW, COL];

        private object columnHeader1Name;
        private object textBoxstructure;
        private void ButtonAdd_Click(object sender, EventArgs e)
        {

            AddArray();
            Clear_TextBoxes();
            Sort();

            // Display the sorted array in the ListView
            listView1.Items.Clear(); // Clear existing items
            for (int i = 0; i < ptr; i++)
            {
                ListViewItem item = new ListViewItem(TwoDimAry[i, 0]); // Name
                item.SubItems.Add(TwoDimAry[i, 1]); // Category
                listView1.Items.Add(item);
            }
        }

        private void AddArray()
        {
            if (ptr < ROW)
            {
                try
                {
                    TwoDimAry[ptr, 0] = textBoxName.Text;
                    TwoDimAry[ptr, 1] = textBoxCategory.Text;
                    TwoDimAry[ptr, 2] = textBoxStructure.Text;
                    TwoDimAry[ptr, 3] = textBoxDefn.Text;

                    ptr++;
                }
                catch
                {
                    MessageBox.Show("An error occurred.");
                }
            }
            else
            {
                MessageBox.Show("Array is full!");
            }
            Sort();
        }

        // Bubble Sort method to sort by Title
        private void Sort()
        {
            for (int x = 1; x < ROW; x++)
            {
                for (int i = 0; i < ROW - 1; i++)
                {
                    if (!(string.IsNullOrEmpty(TwoDimAry[i + 1, 0])))
                    {
                        if (string.Compare(TwoDimAry[i, 0], TwoDimAry[i + 1, 0]) == 1)
                        {
                            Swap(i);
                        }
                    }
                }
            }
        }
        // Swap Routine
        private void Swap(int indx)
        {
            string temp;
            for (int i = 0; i < COL; i++)
            {
                temp = TwoDimAry[indx, i];
                TwoDimAry[indx, i] = TwoDimAry[indx + 1, i];
                TwoDimAry[indx + 1, i] = temp;
            }
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

        //    for (int i = 0; i < ROW.Length; i++)
        //    {
        //        // Convert the integer to a string and capitalize the first letter.
        //        string itemText = ROW[i].ToString();
        //        itemText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(itemText);

        //        ListViewItem item = new ListViewItem(ROW[i].ToString());
        //        listView1.Items.Add(item);
        //    }


        //    {
        //        ListViewItem listItem = new ListViewItem();
        //        listView1.Items.Add(listItem);
        //        listView1.Sort();

        //        for (int i = 0; i < ROW.Length; i++)
        //        {
        //            Console.Write(ROW[i] + ", ");
        //        }
        //        // Pause the program so the output can be viewed.
        //        Console.ReadLine();
        //    }
        }
        private void Display()
        {
            for (int i = 0; i < ptr; i++)
            {
                ListViewItem listItem = new ListViewItem(TwoDimAry[i, 0]);
                listItem.SubItems.Add(TwoDimAry[i, 1]);
                listView1.Items.Add(listItem);

                Sort();
            }


        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear_TextBoxes();
        }
        private void Clear_TextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefn.Clear();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int selectedIndex = selectedItem.Index;

                if (selectedIndex >= 0 && selectedIndex < ptr)
                {
                    try
                    {
                        // Update the selected item in the ListView
                        selectedItem.SubItems[0].Text = textBoxName.Text; // Update Name
                        selectedItem.SubItems[1].Text = textBoxCategory.Text; // Update Category
                        selectedItem.SubItems[2].Text = textBoxStructure.Text; // Update Structure
                        selectedItem.SubItems[3].Text = textBoxDefn.Text; // Update Definition


                        //Clear textboxes after editing
                        Clear_TextBoxes();

                        // Update the corresponding entry in the TwoDimArray
                        TwoDimAry[selectedIndex, 0] = textBoxName.Text.Trim(); // Remove leading/trailing spaces
                        TwoDimAry[selectedIndex, 1] = textBoxCategory.Text.Trim();
                        TwoDimAry[selectedIndex, 2] = textBoxStructure.Text.Trim();
                        TwoDimAry[selectedIndex, 3] = textBoxDefn.Text.Trim();

                        //Clear textboxes after editing
                        Clear_TextBoxes();

                        // Sort the array after editing
                        Display();
                        Sort();

                        MessageBox.Show("Item updated successfully and array sorted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //essageBox.Show($"Error updating item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Invalid index selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Please select an item to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this entry?",
              "Confirmation",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    // Check if there is a selected item
                   
                    {
                        // Remove the selected item from the ListView
                        //listView1.Items.RemoveAt(listView1.SelectedIndices[0]);

                        int selectedIndex = listView1.SelectedItems[0].Index;
                        //EMPTY ARRAY
                        TwoDimAry[selectedIndex, 0] = "";
                        TwoDimAry[selectedIndex, 1] = "";
                        TwoDimAry[selectedIndex, 2] = "";
                        TwoDimAry[selectedIndex, 3] = "";

                        ptr--;


                        // Remove the selected item from the ListView
                        listView1.Items.RemoveAt(listView1.SelectedIndices[0]);

                        Sort();

                     // Display();

                    }

                }

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Sort();
            // Allow the user to select the destination file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Definitions File";
            saveFileDialog.FileName = "definitions.dat";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Write the sorted data into the selected binary file
                try
                {
                    using (BinaryWriter writer = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create)))
                    {
                        for (int i = 0; i < ptr; i++)
                        {
                            writer.Write(TwoDimAry[i, 0]); // Name
                            writer.Write(TwoDimAry[i, 1]); // Category
                            writer.Write(TwoDimAry[i, 2]); // Structure
                            writer.Write(TwoDimAry[i, 3]); // Definition
                        }
                    }

                    MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Binary Search
        private void buttonSearch_Click(object sender, EventArgs e)

        {
            // Ensure the search text is not empty
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            // Convert the first column of TwoDimAry to a list for binary search
            List<string> list = new List<string>();
            for (int i = 0; i < TwoDimAry.GetLength(0); i++)
            {
                list.Add(TwoDimAry[i, 0]); // Assuming the search is based on the first column
            }

            // Perform binary search
            string findThis = textBox1.Text;
            int first = 0;
            int last = listView1.Items.Count - 1;
            bool isFound = false;

            while (first <= last)
            {
                int mid = (first + last) / 2;
                if (findThis.CompareTo(list[mid]) == 0)
                {
                    isFound = true;
                    break;
                }
                else if (findThis.CompareTo(list[mid]) < 0)
                {
                    last = mid - 1;
                }
                else
                {
                    first = mid + 1;
                }
            }

            if (isFound)
            {
                MessageBox.Show($"Found at element [{list.IndexOf(findThis)}]");
            }
            else
            {
                MessageBox.Show("NOT found");
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        //load
        private void ButtonLoad_Click(object sender, EventArgs e)
        {

            {
                // Open file dialog for user to select the data file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*";
                openFileDialog.Title = "Open Definitions File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    // Clear existing data before loading new data
                    listView1.Items.Clear();

                    // Read data from the selected file and populate ListView
                    try
                    {
                        using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
                        {
                            // Read data and populate ListView until the end of the file
                            while (reader.BaseStream.Position != reader.BaseStream.Length)
                            {
                                string name = reader.ReadString();
                                string category = reader.ReadString();
                                string structure = reader.ReadString();
                                string definition = reader.ReadString();

                                // Add the data to the 2D array
                                TwoDimAry[ptr, 0] = name;
                                TwoDimAry[ptr, 1] = category;
                                TwoDimAry[ptr, 2] = structure;
                                TwoDimAry[ptr, 3] = definition;
                                ptr++;

                                // Add the data to the ListView
                                ListViewItem item = new ListViewItem(name);
                                item.SubItems.Add(category);
                                listView1.Items.Add(item);
                            }
                        }

                        MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        
                // method to display item from listview to textboxes
        private void listView1_MouseClick(object sender, MouseEventArgs e)
                {
                    // Check if the left mouse button is clicked
                    if (e.Button == MouseButtons.Left)
                    {
               
                // Get the item that was clicked
                ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);

                        // Check if an item was clicked
                        if (clickedItem != null)
                        {
                    
                            // Find the clicked definition based on its Name
                            for (int i = 0; i < ptr; i++)
                            {
                                if (TwoDimAry[i, 0] == clickedItem.Text) // Check if the Name matches
                                {
                                    // Display all information in the appropriate text boxes
                                    textBoxName.Text = TwoDimAry[i, 0]; // Name
                                    textBoxCategory.Text = TwoDimAry[i, 1]; // Category
                                    textBoxStructure.Text = TwoDimAry[i, 2]; // Structure
                                    textBoxDefn.Text = TwoDimAry[i, 3]; // Definition
                                    return; // Exit the loop once the definition is found and displayed
                                }
                            }
                        }
                        else
                        {
                            // If no item was clicked, clear all text boxes
                            Clear_TextBoxes();
                        }
                    }
                }
    }
}
    



         






