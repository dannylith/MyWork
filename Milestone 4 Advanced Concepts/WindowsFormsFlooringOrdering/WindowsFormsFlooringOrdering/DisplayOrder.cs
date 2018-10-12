using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsFlooringOrdering
{
    public partial class displayOrderFrm : Form
    {
        public displayOrderFrm()
        {
            InitializeComponent();
            displaySearchTxtBx.Select();
        }

        private void displayRichTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void displaySearchbtn_Click(object sender, EventArgs e)
        {
            OrdersFileRepository ordersRepo = new OrdersFileRepository();
            DateTime date;
            if (!DateTime.TryParse(displaySearchTxtBx.Text, out date))
            {
                displayRichTxtBx.Text = "";
                displayRichTxtBx.Text = "Invalid date format.";
                return;
            }
            var orders = ordersRepo.GetAll(date.ToString("MMddyyyy"));
            //File.Create(@".\test.txt").Close();

            if (orders !=  null)
            {

                foreach (var o in orders)
                {
                    displayRichTxtBx.Text = "";
                    displayRichTxtBx.Text += $"Order Number: {o.OrderNumber} | Date: {date.ToString("MM-dd-yyy")}\n";
                    displayRichTxtBx.Text += $"Name: {o.CustomerName}\n";
                    displayRichTxtBx.Text += $"State: {o.State}\n";
                    displayRichTxtBx.Text += $"Product: {o.ProductType}\n";
                    displayRichTxtBx.Text += $"Materials Cost: {o.MaterialCost:c}\n";
                    displayRichTxtBx.Text += $"Labor: {o.LaborCost:c}\n";
                    displayRichTxtBx.Text += $"Tax: {o.Tax:c}\n";
                    displayRichTxtBx.Text += $"Total: {o.Total:c}\n";
                    displayRichTxtBx.Text += "\n\n";
                }
            }
            else
            {
                displayRichTxtBx.Text = "No data to be found.";
            }



        }
    }
}
