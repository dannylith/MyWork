namespace WindowsFormsFlooringOrdering
{
    partial class displayOrderFrm
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
            this.displayRichTxtBx = new System.Windows.Forms.RichTextBox();
            this.displaySearchbtn = new System.Windows.Forms.Button();
            this.displaySearchTxtBx = new System.Windows.Forms.TextBox();
            this.displaySearchDateLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // displayRichTxtBx
            // 
            this.displayRichTxtBx.Location = new System.Drawing.Point(140, 123);
            this.displayRichTxtBx.Name = "displayRichTxtBx";
            this.displayRichTxtBx.ReadOnly = true;
            this.displayRichTxtBx.Size = new System.Drawing.Size(471, 284);
            this.displayRichTxtBx.TabIndex = 0;
            this.displayRichTxtBx.Text = "";
            this.displayRichTxtBx.TextChanged += new System.EventHandler(this.displayRichTxtBx_TextChanged);
            // 
            // displaySearchbtn
            // 
            this.displaySearchbtn.Location = new System.Drawing.Point(440, 27);
            this.displaySearchbtn.Name = "displaySearchbtn";
            this.displaySearchbtn.Size = new System.Drawing.Size(144, 36);
            this.displaySearchbtn.TabIndex = 1;
            this.displaySearchbtn.Text = "Search";
            this.displaySearchbtn.UseVisualStyleBackColor = true;
            this.displaySearchbtn.Click += new System.EventHandler(this.displaySearchbtn_Click);
            // 
            // displaySearchTxtBx
            // 
            this.displaySearchTxtBx.Location = new System.Drawing.Point(211, 41);
            this.displaySearchTxtBx.Name = "displaySearchTxtBx";
            this.displaySearchTxtBx.Size = new System.Drawing.Size(175, 22);
            this.displaySearchTxtBx.TabIndex = 2;
            // 
            // displaySearchDateLbl
            // 
            this.displaySearchDateLbl.AutoSize = true;
            this.displaySearchDateLbl.Location = new System.Drawing.Point(208, 21);
            this.displaySearchDateLbl.Name = "displaySearchDateLbl";
            this.displaySearchDateLbl.Size = new System.Drawing.Size(91, 17);
            this.displaySearchDateLbl.TabIndex = 3;
            this.displaySearchDateLbl.Text = "Date Search:";
            // 
            // displayOrderFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.displaySearchDateLbl);
            this.Controls.Add(this.displaySearchTxtBx);
            this.Controls.Add(this.displaySearchbtn);
            this.Controls.Add(this.displayRichTxtBx);
            this.Name = "displayOrderFrm";
            this.Text = "Display Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox displayRichTxtBx;
        private System.Windows.Forms.Button displaySearchbtn;
        private System.Windows.Forms.TextBox displaySearchTxtBx;
        private System.Windows.Forms.Label displaySearchDateLbl;
    }
}