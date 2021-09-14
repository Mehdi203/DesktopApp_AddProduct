/*
 * MainForm
 * Code by Mehdi Noroozi
 * Date September 14, 2021
 * 
 * */

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSupport_App.Models;

namespace TechSupport_App

{
    public partial class ProductsForm : Form
    {
        private TechSupportContext context = new TechSupportContext(); //Create a new object called context
        private Product selectedProduct; //created a single product from Product class


        public ProductsForm()
        {
            InitializeComponent();
        }

        //Load the form
        private void ProductsForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                selectedProduct = context.Products.First();   // Load the first Product
                // Load all product codes 
                Object[] pIds = context.Products.Select(p => (Object)p.ProductCode).ToArray();
                comboBox_Code.Items.AddRange(pIds); 

                DisplayProduct(); // Display the product data


            }
            catch (SqlException sqlException)
            {
                string errorMessage = "";
                foreach (SqlError error in sqlException.Errors)
                {
                    errorMessage += "ERROR CODE:  " + error.Number +
                                    " " + error.Message + "\n";
                }
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = "DB error: " + ex.Message + "\n";
                MessageBox.Show(errorMessage);
            }

        }


        //Method to display the products
        private void DisplayProduct()
        {
            if (selectedProduct is null) return;
            comboBox_Code.SelectedItem = selectedProduct.ProductCode;
            textBox_Name.Text = selectedProduct.Name;
            textBox_Version.Text = selectedProduct.Version.ToString("0.0");
            textBox_Date.Text = selectedProduct.ReleaseDate.ToString();
            button_Mod.Enabled = true;
            button_Add.Enabled = true;
        }

        private void ClearControls()
        {
            
            textBox_Name.Text = "";
            textBox_Version.Text = "";
            textBox_Date.Text = "";
            button_Mod.Enabled = false;
            button_Add.Enabled = false;
            
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            var addModifyForm = new AddModifyProductForm()
            {
                AddProduct = true //AddProduct is a property defined in the addmodify form. if it's true, it means we want to add a product
            };

            DialogResult result = addModifyForm.ShowDialog();

            if (result == DialogResult.OK)
            {

                try
                {
                    selectedProduct = addModifyForm.Product;
                    context.Products.Add(selectedProduct);
                    context.SaveChanges();
                    comboBox_Code.Items.Add(selectedProduct.ProductCode);
                    this.DisplayProduct();
                    //this.DisplayCustomer();
                }
                catch (DbUpdateException ex)
                {
                    this.HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    this.HandleGeneralError(ex);
                }
            }
        }

        //Method defined to edit product
        private void ModifyProduct()
        {
            var addModifyProductForm = new AddModifyProductForm()
            {
                AddProduct = false, //AddProduct is a property defined in the addmodify form. if it's false, it means we want to modify a product
                Product = selectedProduct
            };
            DialogResult result = addModifyProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedProduct = addModifyProductForm.Product;
                    context.SaveChanges();
                    DisplayProduct();
                }
 
                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        //Method defined to delete product

        private void DeleteProduct()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedProduct.ProductCode.Trim()}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    context.Products.Remove(selectedProduct);//delete product from the database
                    comboBox_Code.Items.Remove(selectedProduct.ProductCode); // remove the product code from combobox
                    context.SaveChanges(true);
                    this.ClearControls();
                }

                catch (DbUpdateException ex)
                {
                    HandleDataError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }



        //Modify button
        private void button_Mod_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
                ModifyProduct();
        }

        //Delete button
        private void button_Del_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
                DeleteProduct();
        }

        //Display product when the product code is seletced from the combo box
        private void comboBox_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox_Code.SelectedItem.ToString();
            selectedProduct = context.Products.Find(id);   // Load product 
            DisplayProduct();

        }

        //Exception handler to show data error
        private void HandleDataError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE: " + error.Number + " " +
                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }

        //Exception handler to show general error
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        //Exit button

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

