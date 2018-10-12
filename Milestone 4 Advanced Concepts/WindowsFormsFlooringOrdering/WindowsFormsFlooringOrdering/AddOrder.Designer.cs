namespace WindowsFormsFlooringOrdering
{
    partial class AddOrderFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OrderNumLbl = new System.Windows.Forms.Label();
            this.CustomerNameLbl = new System.Windows.Forms.Label();
            this.stateLbl = new System.Windows.Forms.Label();
            this.productTypeLbl = new System.Windows.Forms.Label();
            this.orderDateLbl = new System.Windows.Forms.Label();
            this.productRichTxtBx = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.errorMsgOrderDateLbl = new System.Windows.Forms.Label();
            this.errorMsgNameLbl = new System.Windows.Forms.Label();
            this.errorMsgStateLbl = new System.Windows.Forms.Label();
            this.errorMsgProductLbl = new System.Windows.Forms.Label();
            this.addOrderSubmitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OrderNumLbl
            // 
            this.OrderNumLbl.AutoSize = true;
            this.OrderNumLbl.Location = new System.Drawing.Point(60, 59);
            this.OrderNumLbl.Name = "OrderNumLbl";
            this.OrderNumLbl.Size = new System.Drawing.Size(107, 17);
            this.OrderNumLbl.TabIndex = 0;
            this.OrderNumLbl.Text = "Order Number: ";
            // 
            // CustomerNameLbl
            // 
            this.CustomerNameLbl.AutoSize = true;
            this.CustomerNameLbl.Location = new System.Drawing.Point(60, 145);
            this.CustomerNameLbl.Name = "CustomerNameLbl";
            this.CustomerNameLbl.Size = new System.Drawing.Size(117, 17);
            this.CustomerNameLbl.TabIndex = 1;
            this.CustomerNameLbl.Text = "Customer Name: ";
            // 
            // stateLbl
            // 
            this.stateLbl.AutoSize = true;
            this.stateLbl.Location = new System.Drawing.Point(60, 185);
            this.stateLbl.Name = "stateLbl";
            this.stateLbl.Size = new System.Drawing.Size(49, 17);
            this.stateLbl.TabIndex = 2;
            this.stateLbl.Text = "State: ";
            // 
            // productTypeLbl
            // 
            this.productTypeLbl.AutoSize = true;
            this.productTypeLbl.Location = new System.Drawing.Point(60, 233);
            this.productTypeLbl.Name = "productTypeLbl";
            this.productTypeLbl.Size = new System.Drawing.Size(101, 17);
            this.productTypeLbl.TabIndex = 3;
            this.productTypeLbl.Text = "Product Type: ";
            // 
            // orderDateLbl
            // 
            this.orderDateLbl.AutoSize = true;
            this.orderDateLbl.Location = new System.Drawing.Point(60, 102);
            this.orderDateLbl.Name = "orderDateLbl";
            this.orderDateLbl.Size = new System.Drawing.Size(87, 17);
            this.orderDateLbl.TabIndex = 4;
            this.orderDateLbl.Text = "Order Date: ";
            // 
            // productRichTxtBx
            // 
            this.productRichTxtBx.Location = new System.Drawing.Point(61, 272);
            this.productRichTxtBx.Name = "productRichTxtBx";
            this.productRichTxtBx.ReadOnly = true;
            this.productRichTxtBx.Size = new System.Drawing.Size(596, 145);
            this.productRichTxtBx.TabIndex = 5;
            this.productRichTxtBx.Text = "";
            this.productRichTxtBx.TextChanged += new System.EventHandler(this.productRichTxtBx_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(206, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 22);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(206, 142);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(151, 22);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(206, 180);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(47, 22);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(206, 230);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(151, 22);
            this.textBox4.TabIndex = 9;
            // 
            // errorMsgOrderDateLbl
            // 
            this.errorMsgOrderDateLbl.AutoSize = true;
            this.errorMsgOrderDateLbl.Location = new System.Drawing.Point(420, 107);
            this.errorMsgOrderDateLbl.Name = "errorMsgOrderDateLbl";
            this.errorMsgOrderDateLbl.Size = new System.Drawing.Size(101, 17);
            this.errorMsgOrderDateLbl.TabIndex = 10;
            this.errorMsgOrderDateLbl.Text = "Error Message";
            this.errorMsgOrderDateLbl.Visible = false;
            // 
            // errorMsgNameLbl
            // 
            this.errorMsgNameLbl.AutoSize = true;
            this.errorMsgNameLbl.Location = new System.Drawing.Point(420, 147);
            this.errorMsgNameLbl.Name = "errorMsgNameLbl";
            this.errorMsgNameLbl.Size = new System.Drawing.Size(101, 17);
            this.errorMsgNameLbl.TabIndex = 11;
            this.errorMsgNameLbl.Text = "Error Message";
            this.errorMsgNameLbl.Visible = false;
            // 
            // errorMsgStateLbl
            // 
            this.errorMsgStateLbl.AutoSize = true;
            this.errorMsgStateLbl.Location = new System.Drawing.Point(420, 185);
            this.errorMsgStateLbl.Name = "errorMsgStateLbl";
            this.errorMsgStateLbl.Size = new System.Drawing.Size(101, 17);
            this.errorMsgStateLbl.TabIndex = 12;
            this.errorMsgStateLbl.Text = "Error Message";
            this.errorMsgStateLbl.Visible = false;
            // 
            // errorMsgProductLbl
            // 
            this.errorMsgProductLbl.AutoSize = true;
            this.errorMsgProductLbl.Location = new System.Drawing.Point(420, 235);
            this.errorMsgProductLbl.Name = "errorMsgProductLbl";
            this.errorMsgProductLbl.Size = new System.Drawing.Size(101, 17);
            this.errorMsgProductLbl.TabIndex = 13;
            this.errorMsgProductLbl.Text = "Error Message";
            this.errorMsgProductLbl.Visible = false;
            // 
            // addOrderSubmitBtn
            // 
            this.addOrderSubmitBtn.Location = new System.Drawing.Point(663, 372);
            this.addOrderSubmitBtn.Name = "addOrderSubmitBtn";
            this.addOrderSubmitBtn.Size = new System.Drawing.Size(125, 54);
            this.addOrderSubmitBtn.TabIndex = 14;
            this.addOrderSubmitBtn.Text = "Submit";
            this.addOrderSubmitBtn.UseVisualStyleBackColor = true;
            // 
            // AddOrderFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addOrderSubmitBtn);
            this.Controls.Add(this.errorMsgProductLbl);
            this.Controls.Add(this.errorMsgStateLbl);
            this.Controls.Add(this.errorMsgNameLbl);
            this.Controls.Add(this.errorMsgOrderDateLbl);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.productRichTxtBx);
            this.Controls.Add(this.orderDateLbl);
            this.Controls.Add(this.productTypeLbl);
            this.Controls.Add(this.stateLbl);
            this.Controls.Add(this.CustomerNameLbl);
            this.Controls.Add(this.OrderNumLbl);
            this.Name = "AddOrderFrm";
            this.Text = "AddOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OrderNumLbl;
        private System.Windows.Forms.Label CustomerNameLbl;
        private System.Windows.Forms.Label stateLbl;
        private System.Windows.Forms.Label productTypeLbl;
        private System.Windows.Forms.Label orderDateLbl;
        private System.Windows.Forms.RichTextBox productRichTxtBx;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label errorMsgOrderDateLbl;
        private System.Windows.Forms.Label errorMsgNameLbl;
        private System.Windows.Forms.Label errorMsgStateLbl;
        private System.Windows.Forms.Label errorMsgProductLbl;
        private System.Windows.Forms.Button addOrderSubmitBtn;
    }
}