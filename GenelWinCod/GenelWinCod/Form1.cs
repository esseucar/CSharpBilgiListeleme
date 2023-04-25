using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenelWinCod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ProductList();
            CategoryList();
        }
        private void ProductList()
        {
            using (NortwindDbContext context= new NortwindDbContext()) {
                dataGridView1.DataSource = context.Products.ToList();
            }
        }
        private void ProductCategoryIDList(int category)
        {
            using (NortwindDbContext context = new NortwindDbContext())
            {
                dataGridView1.DataSource = context.Products.Where(c=>c.CategoryID == category).ToList();
            }
        }
        private void CategoryList()
        {
            using (NortwindDbContext context = new NortwindDbContext())
            {
                comboBox1.DataSource = context.Categories.ToList();
                comboBox1.DisplayMember = "CategoryName";
                comboBox1.ValueMember="CategoryID";
            }
        }
        private void listProductNameProduct(string key)
        {
            using (NortwindDbContext context = new NortwindDbContext())
            {
                dataGridView1.DataSource = context.Products.Where(p=>p.ProductName.ToLower().Contains(key.ToLower())).ToList();
                //comboBox1.DisplayMember = "CategoryName";
                //comboBox1.ValueMember = "CategoryID";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { ProductCategoryIDList(Convert.ToInt32(comboBox1.SelectedValue));} catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            if(string.IsNullOrEmpty(key))
            {
                ProductList();
            }
            else { listProductNameProduct(textBox1.Text); }
        }
    }
}
