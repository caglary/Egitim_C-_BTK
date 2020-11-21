using System;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        ProductDal _productDal = new ProductDal();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtUnitPrice.Text) && !string.IsNullOrEmpty(txtStockAmount.Text))
            {
                _productDal.Add(new Product
                {
                    Name = txtName.Text,
                    StockAmount = Convert.ToInt32(txtStockAmount.Text),
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text)
                });
                LoadProducts();
                AddProductFormTemizle();
                MessageBox.Show("Product Added!");
            }
            else
            {
                MessageBox.Show("Fill the Form!");
            }
        }

        private void AddProductFormTemizle()
        {
            foreach (var item in grbAdd.Controls)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Text = "";
                }
            }
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtUpdateUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtUpdateStockAmount.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUpdateName.Text))
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                    Name = txtUpdateName.Text,
                    UnitPrice = Convert.ToDecimal(txtUpdateUnitPrice.Text),
                    StockAmount = Convert.ToInt32(txtUpdateStockAmount.Text)

                };
                _productDal.Update(product);
                LoadProducts();
                UpdateProductFormTemizle();
                MessageBox.Show("Product Updated!");


            }
            else
            {
                MessageBox.Show("Select Product from Table!");
            }
        }

        private void UpdateProductFormTemizle()
        {
            foreach (var item in grbUpdate.Controls)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Text = "";
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            DialogResult dr = MessageBox.Show($"Do you want to delete record with {id} numbers?","Caution",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _productDal.Delete(id);
                LoadProducts();
                MessageBox.Show("Product is Deleted!");
            }

        }
    }
}
