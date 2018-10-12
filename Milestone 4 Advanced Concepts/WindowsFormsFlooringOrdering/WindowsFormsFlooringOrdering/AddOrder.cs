using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.BLL;

namespace WindowsFormsFlooringOrdering
{
    public partial class AddOrderFrm : Form
    {
        public AddOrderFrm()
        {
            InitializeComponent();
            ProductsFileRepository productRepo = new ProductsFileRepository();
            var productList = productRepo.GetAll();
            productRichTxtBx.Text = $"{"Product",-12}  {"Price Per Square Ft",-20}  Labor Cost Per Square Ft\n";
            foreach (var p in productList)
            {
                productRichTxtBx.Text += $"{p.ProductType,-15}{p.CostPerSquareFoot,-20:c}{p.LaborCostPerSquareFoot:c}";
                productRichTxtBx.Text += "\n";
            }
        }

        private void productRichTxtBx_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
