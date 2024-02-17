using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace DayZLootEditor
{
    public partial class frmEdit : Form
    {
        //Created a list of strings with all itemType names
        private static List<string> list = new List<string>();

        //creates a list of complexchildrentypes
        private static List<ComplexChildrenType> children = new List<ComplexChildrenType>();

        //creates an update list of objects based on user slection
        private static List<ComplexChildrenType> userComplexList = new List<ComplexChildrenType>();

        //Creates a list for simplechildren items
        private static List<String> userSimpleChildrenList = new List<String>();

        //Creates a method that when called retuns the updated user list
        public List<ComplexChildrenType> UserEditedComplexChildrenList()
        {  return userComplexList; }

        //method that returns simplechildren list
        public List<String> UserEditedSimpleChildrenList()
        { return userSimpleChildrenList; }

        private static bool firstLoad = true;

        public frmEdit()
        {
            InitializeComponent();

            if (firstLoad)
            {
                //Populates item list with external file 
                ReadItemList();

                ComplexChildrenListCreation();

                DataGridPopulation();

                //This is the event \/ it is being attached to this ftn \/, so on form load it ensures that whenever this event is triggered ftn is called
                dgvItems.CurrentCellDirtyStateChanged += dgvItems_CurrentCellDirtyStateChanged;

                dgvItems.EditingControlShowing += DataGridView_EditingControlShowing;

                //change flag so ftns are only called on first form initialization
                firstLoad = false;
            }
        }


        //Reads inventory item txt file from folder, then places into list
        private void ReadItemList()
        {
            string filePath = "ItemSets/InventoryItems.txt";
            
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        list.Add(line);
                    }
                }
                else
                {
                    MessageBox.Show("File path for InventoryItems.txt not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }        
        }

        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Checks if the current control is a TextBox
            if (e.Control is TextBox)
            {
                TextBox textBox = (TextBox)e.Control;

                // Removes any existing event handler to avoid multiple subscriptions
                textBox.KeyPress -= TextBox_KeyPress;

                // Add the TextBox_KeyPress event handler
                textBox.KeyPress += TextBox_KeyPress;
            }
        }

        //ensures that only ints between -1 and 30 can be entered in text boxes
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int minValue = -1;
            int maxValue = 30;

            TextBox textBox = (TextBox)sender;

            // Allow backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Only allow digits, '-' at the beginning, and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '-' && textBox.SelectionStart == 0 && !textBox.Text.Contains('-')))
            {
                e.Handled = true;
                return;
            }

            // Get the current text without the selected portion
            string newText = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);

            // Insert the new character at the correct position
            newText = newText.Insert(textBox.SelectionStart, e.KeyChar.ToString());

            // Check if it's a valid integer or '-' at the beginning
            if (!int.TryParse(newText, out int value) && !(e.KeyChar == '-' && textBox.SelectionStart == 0 && !textBox.Text.Contains('-')))
            {
                e.Handled = true;
                return;
            }

            // Check if it's within the range
            if (value < minValue || value > maxValue)
            {
                e.Handled = true;
                return;
            }
        }

        //Sent: Nil
        //Returned: Nil
        //Description: Sends in data to DGV columns
        private void DataGridPopulation()
        {
            //adds each object in list to a row
            foreach (ComplexChildrenType listItem in children)
            {
                // Create a new row variable from DGVrow ftn
                DataGridViewRow row = new DataGridViewRow();

                // Use a CheckBox cell for the boolean column
                DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
                row.Cells.Add(checkBoxCell);

                // Creates and populates the ItemType cell
                row.Cells.Add(new DataGridViewTextBoxCell { Value = listItem.itemType });

                DataGridViewTextBoxCell quantityCell = new DataGridViewTextBoxCell();
                quantityCell.Value = 0;
                row.Cells.Add(quantityCell);

                // Creates and populates HS cell, all init values should be -1
                row.Cells.Add(new DataGridViewTextBoxCell { Value = listItem.quickBarSlot });

                // Add the row to the DataGridView
                dgvItems.Rows.Add(row);
            }
        }


        //Sent: Nil
        //Return: Nil
        //Description: Creates a string list from all the items, then creates a list of complexchildrentype
        //             objects with item names entered all other values default
        private static void ComplexChildrenListCreation()
        {
            //foreach loop that creates an object of the complexchildrentype for each string in list, then adds each one to complexchildrentype list
            foreach (string item in list)
            {
                if (item != null)
                {
                    //Creates new object sends in itemType as a string, then adds to object list
                    ComplexChildrenType listItem = new ComplexChildrenType(item);
                    children.Add(listItem);
                }
            }
        }

        //Resets all values to default by calling population ftn, repopulates the dgv with og list
        //Also clears all lists
        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvItems.Rows.Clear();
            DataGridPopulation();
            userComplexList.Clear();
            userSimpleChildrenList.Clear();
            txtAddItem.Text = string.Empty;
            nudHSAddItem.Value = -1;
        }

        // Method to simulate the button click event
        public void TriggerResetButtonClick()
        {
            // Call the button click event handler
            btnReset_Click(this, EventArgs.Empty);
        }

        //ftn that changes the value of quantitycol to one if add is clicked, ensures no errors, if user wants to add they need 1 item
        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.IsCurrentCellDirty)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Handle the change in the committed cell value
                DataGridViewCheckBoxCell checkboxCell = dgvItems.CurrentCell as DataGridViewCheckBoxCell;

                if (checkboxCell != null && checkboxCell.OwningColumn.Name == "AddCol")
                {
                    bool isChecked = (bool)checkboxCell.Value;

                    // Update TextBox value based on checkbox state
                    if (isChecked)
                    {
                        dgvItems.CurrentRow.Cells["QuantityCol"].Value = 1;
                    }
                    else
                    {
                        // You can set a different value if the checkbox is unchecked
                        dgvItems.CurrentRow.Cells["QuantityCol"].Value = 0;
                    }

                }
            }
        }

        //Parses user selection and creates new ComplexChildrenType list, then closes the form
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //assigns the dialog result ok to this button click
            this.DialogResult = DialogResult.OK;

            //clears lists so duplicates arent added
            userComplexList.Clear();
            userSimpleChildrenList.Clear();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {

                //creates variables from converted data from dgv
                string itemName = row.Cells["ItemCol"].Value.ToString();
                int hotSlot = Convert.ToInt32(row.Cells["HSCol"].Value);
                bool add = Convert.ToBoolean(row.Cells["AddCol"].Value);
                int quantity = Convert.ToInt32(row.Cells["QuantityCol"].Value);

                ComplexChildrenType userobject = new ComplexChildrenType(itemName, hotSlot);

                if (add && hotSlot > -1)
                {
                    //adds new item for quantity selected - may cause error multiple items same hotslot
                    for (int i = 0; i < quantity; i++)
                    {
                        userComplexList.Add(userobject);
                    }

                }

                if (add && hotSlot == -1)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        userSimpleChildrenList.Add(itemName);
                    }
                }
            }
                     
            /*Tests updated list
            foreach (ComplexChildrenType item in userComplexList)
            {
                MessageBox.Show($"ItemName: {item.itemType}, HotSlot: {item.quickBarSlot}");
            }

            foreach(string itemName in userSimpleChildrenList)
            {
                MessageBox.Show(itemName);
            } */
      
            this.Close();
        }

        //searches through dgv if text in txt matches highlights and hides non matches, searchs in real time
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower(); // Convert to lowercase for case-insensitive comparison
            int columnIndex = 1;


                // Clear any previous selections
                dgvItems.ClearSelection();

                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in dgvItems.Rows)
                {

                    if (row.Cells[columnIndex].Value is string cellValue)
                    {
                        // Check if the cell value matches the search term
                        if (!string.IsNullOrEmpty(searchTerm) && cellValue.ToLower().Contains(searchTerm))
                        {
                            // Highlight the matching row
                            row.Selected = true;
                            row.Visible = true;
                        }
                        //if empty display all results
                        else if (string.IsNullOrEmpty(searchTerm)) 
                        {
                        row.Visible = true;
                        }
                        //if it does not match not vidible in dgv
                        else
                        {
                            row.Visible=false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cell value is not a string.");
                    }
                }
            

        }

        //Whenever text is changed btnclick event triggers, allows real time search results
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        //Clears search box
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        //Adds custom user item to dgv for placement into inventory list, allows user to place multiple of same item into 
        //different hot slots
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string itemName = txtAddItem.Text.Trim();
            int hotslot = Convert.ToInt32(nudHSAddItem.Value);

            //Creates new row for dgv
            DataGridViewRow row = new DataGridViewRow();

            // Use a CheckBox cell for the boolean column
            DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
            checkBoxCell.Value = true; // Set the checkbox to be checked by default
            row.Cells.Add(checkBoxCell);

            // Creates and populates the ItemType cell
            row.Cells.Add(new DataGridViewTextBoxCell { Value = itemName });

            //Creates quantity cell and sets to 1
            DataGridViewTextBoxCell quantityCell = new DataGridViewTextBoxCell();
            quantityCell.Value = 1;
            row.Cells.Add(quantityCell);

            // Creates and populates HS cell
            row.Cells.Add(new DataGridViewTextBoxCell { Value = hotslot });

            // Add the row to the DataGridView
            dgvItems.Rows.Add(row);

            //Shows pic and lbl the calls ftn to start timer
            picCheckMark.Visible = true;
            lblAdded.Visible = true;
            timer1.Start();

        }

        //Stops the timer and hides the lbl and pic
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            picCheckMark.Visible=false;
            lblAdded.Visible=false;
        }

        //resets everything then closes form, empty lists passed back
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
