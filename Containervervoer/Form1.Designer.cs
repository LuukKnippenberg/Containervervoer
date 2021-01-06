using System.Windows.Forms;

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
            this.lblLength = new System.Windows.Forms.Label();
            this.nupLength = new System.Windows.Forms.NumericUpDown();
            this.nupWidth = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnAddContainer = new System.Windows.Forms.Button();
            this.lvContainers = new System.Windows.Forms.ListView();
            this.nupWeight = new System.Windows.Forms.NumericUpDown();
            this.lblWeight = new System.Windows.Forms.Label();
            this.gbBoatControls = new System.Windows.Forms.GroupBox();
            this.gbContainerControls = new System.Windows.Forms.GroupBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.nupAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWeight)).BeginInit();
            this.gbBoatControls.SuspendLayout();
            this.gbContainerControls.SuspendLayout();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(17, 29);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 2;
            this.lblLength.Text = "Length";
            // 
            // nupLength
            // 
            this.nupLength.Location = new System.Drawing.Point(20, 45);
            this.nupLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupLength.Name = "nupLength";
            this.nupLength.Size = new System.Drawing.Size(58, 20);
            this.nupLength.TabIndex = 3;
            this.nupLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nupWidth
            // 
            this.nupWidth.Location = new System.Drawing.Point(84, 45);
            this.nupWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupWidth.Name = "nupWidth";
            this.nupWidth.Size = new System.Drawing.Size(59, 20);
            this.nupWidth.TabIndex = 5;
            this.nupWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(81, 29);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 4;
            this.lblWidth.Text = "Width";
            // 
            // btnAddContainer
            // 
            this.btnAddContainer.Location = new System.Drawing.Point(125, 202);
            this.btnAddContainer.Name = "btnAddContainer";
            this.btnAddContainer.Size = new System.Drawing.Size(97, 23);
            this.btnAddContainer.TabIndex = 8;
            this.btnAddContainer.Text = "AddContainer";
            this.btnAddContainer.UseVisualStyleBackColor = true;
            this.btnAddContainer.Click += new System.EventHandler(this.btnAddContainer_Click);
            // 
            // lvContainers
            // 
            this.lvContainers.HideSelection = false;
            this.lvContainers.Location = new System.Drawing.Point(246, 12);
            this.lvContainers.Name = "lvContainers";
            this.lvContainers.Size = new System.Drawing.Size(285, 426);
            this.lvContainers.TabIndex = 10;
            this.lvContainers.UseCompatibleStateImageBehavior = false;
            // 
            // nupWeight
            // 
            this.nupWeight.Location = new System.Drawing.Point(19, 42);
            this.nupWeight.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupWeight.Name = "nupWeight";
            this.nupWeight.Size = new System.Drawing.Size(59, 20);
            this.nupWeight.TabIndex = 11;
            this.nupWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(19, 26);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 12;
            this.lblWeight.Text = "Weight";
            // 
            // gbBoatControls
            // 
            this.gbBoatControls.Controls.Add(this.lblLength);
            this.gbBoatControls.Controls.Add(this.nupLength);
            this.gbBoatControls.Controls.Add(this.lblWidth);
            this.gbBoatControls.Controls.Add(this.nupWidth);
            this.gbBoatControls.Location = new System.Drawing.Point(12, 12);
            this.gbBoatControls.Name = "gbBoatControls";
            this.gbBoatControls.Size = new System.Drawing.Size(228, 107);
            this.gbBoatControls.TabIndex = 13;
            this.gbBoatControls.TabStop = false;
            this.gbBoatControls.Text = "Boat";
            // 
            // gbContainerControls
            // 
            this.gbContainerControls.Controls.Add(this.nupAmount);
            this.gbContainerControls.Controls.Add(this.label1);
            this.gbContainerControls.Controls.Add(this.cbType);
            this.gbContainerControls.Controls.Add(this.lblType);
            this.gbContainerControls.Controls.Add(this.nupWeight);
            this.gbContainerControls.Controls.Add(this.btnAddContainer);
            this.gbContainerControls.Controls.Add(this.lblWeight);
            this.gbContainerControls.Location = new System.Drawing.Point(12, 207);
            this.gbContainerControls.Name = "gbContainerControls";
            this.gbContainerControls.Size = new System.Drawing.Size(228, 231);
            this.gbContainerControls.TabIndex = 14;
            this.gbContainerControls.TabStop = false;
            this.gbContainerControls.Text = "Container";
            // 
            // cbType
            // 
            this.cbType.DisplayMember = "Text";
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(19, 90);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 14;
            this.cbType.ValueMember = "ID";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(19, 74);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "Type";
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnReset);
            this.gbControls.Controls.Add(this.btnVisualize);
            this.gbControls.Location = new System.Drawing.Point(560, 328);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(228, 104);
            this.gbControls.TabIndex = 14;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(66, 78);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnVisualize
            // 
            this.btnVisualize.Location = new System.Drawing.Point(147, 78);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(75, 23);
            this.btnVisualize.TabIndex = 0;
            this.btnVisualize.Text = "Visualize";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // nupAmount
            // 
            this.nupAmount.Location = new System.Drawing.Point(19, 138);
            this.nupAmount.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupAmount.Name = "nupAmount";
            this.nupAmount.Size = new System.Drawing.Size(59, 20);
            this.nupAmount.TabIndex = 15;
            this.nupAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Amount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.gbContainerControls);
            this.Controls.Add(this.gbBoatControls);
            this.Controls.Add(this.lvContainers);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nupLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWeight)).EndInit();
            this.gbBoatControls.ResumeLayout(false);
            this.gbBoatControls.PerformLayout();
            this.gbContainerControls.ResumeLayout(false);
            this.gbContainerControls.PerformLayout();
            this.gbControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.NumericUpDown nupLength;
        private System.Windows.Forms.NumericUpDown nupWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.ListView lvContainers;
        private System.Windows.Forms.NumericUpDown nupWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.GroupBox gbBoatControls;
        private System.Windows.Forms.GroupBox gbContainerControls;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnAddContainer;
        private GroupBox gbControls;
        private Button btnVisualize;
        private Button btnReset;
        private NumericUpDown nupAmount;
        private Label label1;
    }
}

