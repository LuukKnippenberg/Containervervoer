namespace Containervervoer
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblLength = new System.Windows.Forms.Label();
            this.nupLength = new System.Windows.Forms.NumericUpDown();
            this.nupWidth = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnAddContainer = new System.Windows.Forms.Button();
            this.btnVisualize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(35, 39);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 2;
            this.lblLength.Text = "Length";
            // 
            // nupLength
            // 
            this.nupLength.Location = new System.Drawing.Point(38, 55);
            this.nupLength.Name = "nupLength";
            this.nupLength.Size = new System.Drawing.Size(58, 20);
            this.nupLength.TabIndex = 3;
            // 
            // nupWidth
            // 
            this.nupWidth.Location = new System.Drawing.Point(102, 55);
            this.nupWidth.Name = "nupWidth";
            this.nupWidth.Size = new System.Drawing.Size(59, 20);
            this.nupWidth.TabIndex = 5;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(99, 39);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 4;
            this.lblWidth.Text = "Width";
            // 
            // btnAddContainer
            // 
            this.btnAddContainer.Location = new System.Drawing.Point(246, 82);
            this.btnAddContainer.Name = "btnAddContainer";
            this.btnAddContainer.Size = new System.Drawing.Size(97, 23);
            this.btnAddContainer.TabIndex = 8;
            this.btnAddContainer.Text = "AddContainer";
            this.btnAddContainer.UseVisualStyleBackColor = true;
            this.btnAddContainer.Click += new System.EventHandler(this.btnAddContainer_Click);
            // 
            // btnVisualize
            // 
            this.btnVisualize.Location = new System.Drawing.Point(349, 82);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(63, 23);
            this.btnVisualize.TabIndex = 9;
            this.btnVisualize.Text = "Visualize";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVisualize);
            this.Controls.Add(this.btnAddContainer);
            this.Controls.Add(this.nupWidth);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.nupLength);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nupLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.NumericUpDown nupLength;
        private System.Windows.Forms.NumericUpDown nupWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Button btnAddContainer;
        private System.Windows.Forms.Button btnVisualize;
    }
}

