using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phone_book_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void phone_book_tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phone_book_tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataset);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataset.phone_book_table' table. You can move, or remove it, as needed.
            this.phone_book_tableTableAdapter.Fill_all(this.dataset.phone_book_table);
            this.cancel_butt.Enabled = false;
            this.save_butt.Enabled = false;
            this.customer_groupBox1.Enabled = true;

        }

        private void phone_book_tableBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void phone_book_tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void addnew_butt_Click(object sender, EventArgs e)
        {
 
        }

        private void cancel_butt_Click(object sender, EventArgs e)
        {

        
        }

        private void cancel_save_click(object sender, EventArgs e)
        {

            this.save_butt.Enabled = false;
            this.cancel_butt.Enabled = false;

            this.addnew_butt.Enabled = true;
            this.edit_butt.Enabled = true;
            this.delete_butt.Enabled = true;
            this.panel1.Enabled = false;

            ToolStripButton button = (ToolStripButton)sender;
            if (button.Tag.ToString() == "save")
            {
                this.phone_book_tableBindingSource.EndEdit();
                int response=this.phone_book_tableTableAdapter.Update(this.dataset.phone_book_table);
                if (response > 0)
                {
                    MessageBox.Show(response+" row(s) affected");
                 
                }
                else
                {
                    MessageBox.Show(response + " row(s) affected");
                    return;
                }



            }
            else
            {
                this.phone_book_tableBindingSource.CancelEdit();
                this.dataset.RejectChanges();
            }
        }

        private void addnew_edit_delete_click(object sender, EventArgs e)
        {
            this.panel1.Enabled = true;
            ToolStripButton button =(ToolStripButton) sender;
            if (button.Tag.ToString() == "addnew")
            {
                this.phone_book_tableBindingSource.AddNew();
                this.cust_pictureBox1.Image = phone_book_app.Properties.Resources.no_image;
            }
            else if (button.Tag.ToString() == "edit")
            {
                int count=this.dataset.phone_book_table.Rows.Count;
                if (count==0)
                {
                    MessageBox.Show("Please select record to edit");
                    return;
                }
            }

            else if (button.Tag.ToString() == "delete")
            {
                int count = this.dataset.phone_book_table.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("Please select record to delete");
                    return;
                }
                this.phone_book_tableBindingSource.RemoveCurrent();
                this.panel1.Enabled = false;
            }

            this.addnew_butt.Enabled = false;
            this.edit_butt.Enabled = false;
            this.delete_butt.Enabled = false;

            this.save_butt.Enabled = true;
            this.cancel_butt.Enabled = true;
        


        }

        private void phone_book_tableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();

            var file=this.openFileDialog1.FileName;
            if (file == "openFileDialog1")
            {
                return;
            }
            this.cust_pictureBox1.Image = Image.FromFile(file);
            Console.WriteLine(file);

        }
    }
}
