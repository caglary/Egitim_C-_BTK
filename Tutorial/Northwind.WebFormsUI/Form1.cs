using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResolvers.Ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategory.DataSource = _categoryService.GetAll();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";

            cmbAddCategory.DataSource = _categoryService.GetAll();
            cmbAddCategory.DisplayMember = "CategoryName";
            cmbAddCategory.ValueMember = "CategoryId";

            cmbUpdateCategory.DataSource = _categoryService.GetAll();
            cmbUpdateCategory.DisplayMember = "CategoryName";
            cmbUpdateCategory.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cmbCategory.SelectedValue));

            }
            catch (Exception)
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadProducts();

            }
            else
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(txtSearch.Text);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cmbAddCategory.SelectedValue),
                    ProductName = txtAddProductName.Text,
                    QuantityPerUnit = txtAddQuantityPerUnit.Text,
                    UnitPrice = Convert.ToDecimal(txtAddUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(txtAddStock.Text)
                });
                LoadProducts();
                MessageBox.Show("Ürün Kaydedildi!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                _productService.Update(
                    new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                        CategoryId = Convert.ToInt32(cmbUpdateCategory.SelectedValue),
                        ProductName = txtUpdateProductName.Text,
                        QuantityPerUnit = txtUpdateQuantityPerUnit.Text,
                        UnitPrice = Convert.ToDecimal(txtUpdateUnitPrice.Text),
                        UnitsInStock = Convert.ToInt16(txtUpdateStock.Text)
                    });
                LoadProducts();
                MessageBox.Show("Ürün Güncellendi!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            txtUpdateProductName.Text = row.Cells[2].Value.ToString();
            cmbUpdateCategory.SelectedValue = row.Cells[1].Value;
            txtUpdateUnitPrice.Text = row.Cells[3].Value.ToString();
            txtUpdateQuantityPerUnit.Text = row.Cells[5].Value.ToString();
            txtUpdateStock.Text = row.Cells[4].Value.ToString();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)

                    });
                    LoadProducts();
                    MessageBox.Show("Ürün Silindi!");
                }
                catch (Exception exception)
                {
                    //MessageBox.Show(exception.InnerException.InnerException.Message);
                    MessageBox.Show("Silme İşlemi gerçekleşmedi!");


                }

            }

        }
    }
}
