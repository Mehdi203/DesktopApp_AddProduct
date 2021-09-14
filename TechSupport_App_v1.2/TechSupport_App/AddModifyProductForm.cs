/*
 * Add/edit form
 * Code by Mehdi Noroozi
 * Date September 14, 2021
 * 
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSupport_App.Models;

namespace TechSupport_App
{
    public partial class AddModifyProductForm : Form
    {
        //defined 2 proeprties for this form
        public Product Product { get; set; }
        public bool AddProduct { get; set; } //to control add/modify action


        public AddModifyProductForm()
        {
            InitializeComponent();
        }

        //Loading the form: It's either to modify or add a product
        private void AddModifyProductForm_Load(object sender, EventArgs e)
        {
            //if AddProduct is true it means we're adding 
            if (this.AddProduct)
            {
                this.Text = "Add Product";
                textBox_Code.ReadOnly = false;
            }
            else//if AddProduct is false it means we're editing 
            {
                this.Text = "Modify Product";
                textBox_Code.ReadOnly = true;
                this.DisplayProduct();
            }

        }

        //to display product 
        private void DisplayProduct()
        {
            textBox_Code.Text = Product.ProductCode;
            textBox_Name.Text = Product.Name;
            textBox_Version.Text = Product.Version.ToString("0.00");
            textBox_Date.Text = Product.ReleaseDate.ToString();

        }

        //accept button
        private void button_Accept_Click(object sender, EventArgs e)
        {
            if (this.IsValidData())
            {
                if (this.AddProduct)
                {
                    // initialize the Product property with new Products object
                    this.Product = new Product();
                }
                
                this.LoadProductData();
                this.DialogResult = DialogResult.OK;
            }

        }

        //check if the data input is valid
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(textBox_Code.Text, textBox_Code.Tag.ToString());//required field
            errorMessage += Validator.IsWithinNumber(textBox_Code.Text, textBox_Code.Tag.ToString(), 1, 10);//Limit the number of characters to varchar(10) for product name
            errorMessage += Validator.IsPresent(textBox_Name.Text, textBox_Name.Tag.ToString()); //required field
            errorMessage += Validator.IsWithinNumber(textBox_Name.Text, textBox_Name.Tag.ToString(), 1, 50); //Limit the number of characters to varchar(50) for product name
            errorMessage += Validator.IsPresent(textBox_Version.Text, textBox_Version.Tag.ToString());//required field
            errorMessage += Validator.IsPresent(textBox_Date.Text, textBox_Date.Tag.ToString());//required field
            errorMessage += Validator.IsDecimal(textBox_Version.Text, textBox_Version.Tag.ToString());//version should be decimal
            errorMessage += Validator.IsDate(textBox_Date.Text, textBox_Date.Tag.ToString()); //check for correct date format


            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        //load data
        private void LoadProductData()
        {
            
            Product.ProductCode = textBox_Code.Text;
            Product.Name = textBox_Name.Text;
            Product.Version = Convert.ToDecimal(textBox_Version.Text);
            Product.ReleaseDate = Convert.ToDateTime(textBox_Date.Text);
           

        }

    }
}
