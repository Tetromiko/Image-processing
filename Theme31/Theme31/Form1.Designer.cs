namespace Theme31
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.dropField = new System.Windows.Forms.Panel();
            this.inputImage = new System.Windows.Forms.PictureBox();
            this.outputImage = new System.Windows.Forms.PictureBox();
            this.buttons = new System.Windows.Forms.TableLayoutPanel();
            this.gausianBlur = new System.Windows.Forms.Button();
            this.gausian = new System.Windows.Forms.Button();
            this.repulsion = new System.Windows.Forms.Button();
            this.sharpen = new System.Windows.Forms.Button();
            this.blur = new System.Windows.Forms.Button();
            this.grid.SuspendLayout();
            this.dropField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImage)).BeginInit();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(139)))), ((int)(((byte)(158)))));
            this.grid.ColumnCount = 3;
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.grid.Controls.Add(this.dropField, 0, 0);
            this.grid.Controls.Add(this.outputImage, 2, 0);
            this.grid.Controls.Add(this.buttons, 1, 0);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowCount = 1;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.grid.Size = new System.Drawing.Size(982, 441);
            this.grid.TabIndex = 1;
            // 
            // dropField
            // 
            this.dropField.AllowDrop = true;
            this.dropField.Controls.Add(this.inputImage);
            this.dropField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropField.Location = new System.Drawing.Point(3, 3);
            this.dropField.Name = "dropField";
            this.dropField.Size = new System.Drawing.Size(426, 435);
            this.dropField.TabIndex = 3;
            this.dropField.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropField_DragDrop);
            this.dropField.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropField_DragEnter);
            // 
            // inputImage
            // 
            this.inputImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.inputImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("inputImage.BackgroundImage")));
            this.inputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputImage.Location = new System.Drawing.Point(0, 0);
            this.inputImage.Name = "inputImage";
            this.inputImage.Size = new System.Drawing.Size(426, 435);
            this.inputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.inputImage.TabIndex = 1;
            this.inputImage.TabStop = false;
            this.inputImage.Click += new System.EventHandler(this.OpenImage);
            // 
            // outputImage
            // 
            this.outputImage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.outputImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("outputImage.BackgroundImage")));
            this.outputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputImage.Location = new System.Drawing.Point(552, 3);
            this.outputImage.Name = "outputImage";
            this.outputImage.Size = new System.Drawing.Size(427, 435);
            this.outputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.outputImage.TabIndex = 4;
            this.outputImage.TabStop = false;
            this.outputImage.Click += new System.EventHandler(this.SaveImage);
            // 
            // buttons
            // 
            this.buttons.ColumnCount = 1;
            this.buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttons.Controls.Add(this.gausianBlur, 0, 4);
            this.buttons.Controls.Add(this.gausian, 0, 3);
            this.buttons.Controls.Add(this.repulsion, 0, 2);
            this.buttons.Controls.Add(this.sharpen, 0, 1);
            this.buttons.Controls.Add(this.blur, 0, 0);
            this.buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttons.Location = new System.Drawing.Point(435, 3);
            this.buttons.Name = "buttons";
            this.buttons.RowCount = 5;
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttons.Size = new System.Drawing.Size(111, 435);
            this.buttons.TabIndex = 5;
            // 
            // gausianBlur
            // 
            this.gausianBlur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gausianBlur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gausianBlur.Location = new System.Drawing.Point(7, 359);
            this.gausianBlur.Name = "mediane";
            this.gausianBlur.Size = new System.Drawing.Size(96, 64);
            this.gausianBlur.TabIndex = 4;
            this.gausianBlur.Text = "MEDIANE";
            this.gausianBlur.UseVisualStyleBackColor = true;
            this.gausianBlur.Click += new System.EventHandler(this.filter_Click);
            // 
            // gausian
            // 
            this.gausian.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gausian.Location = new System.Drawing.Point(7, 272);
            this.gausian.Name = "gausian";
            this.gausian.Size = new System.Drawing.Size(96, 64);
            this.gausian.TabIndex = 3;
            this.gausian.Text = "GAUSIAN";
            this.gausian.UseVisualStyleBackColor = true;
            this.gausian.Click += new System.EventHandler(this.filter_Click);
            // 
            // repulsion
            // 
            this.repulsion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.repulsion.Location = new System.Drawing.Point(7, 185);
            this.repulsion.Name = "repulsion";
            this.repulsion.Size = new System.Drawing.Size(96, 64);
            this.repulsion.TabIndex = 2;
            this.repulsion.Text = "REPULSION";
            this.repulsion.UseVisualStyleBackColor = true;
            this.repulsion.Click += new System.EventHandler(this.filter_Click);
            // 
            // sharpen
            // 
            this.sharpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sharpen.Location = new System.Drawing.Point(7, 98);
            this.sharpen.Name = "sharpen";
            this.sharpen.Size = new System.Drawing.Size(96, 64);
            this.sharpen.TabIndex = 1;
            this.sharpen.Text = "SHARPEN";
            this.sharpen.UseVisualStyleBackColor = true;
            this.sharpen.Click += new System.EventHandler(this.filter_Click);
            // 
            // blur
            // 
            this.blur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blur.Location = new System.Drawing.Point(7, 11);
            this.blur.Name = "blur";
            this.blur.Size = new System.Drawing.Size(96, 64);
            this.blur.TabIndex = 0;
            this.blur.Text = "BLUR";
            this.blur.UseVisualStyleBackColor = true;
            this.blur.Click += new System.EventHandler(this.filter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 441);
            this.Controls.Add(this.grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Image processing";
            this.ResizeEnd += new System.EventHandler(this.Form1_Resize);
            this.grid.ResumeLayout(false);
            this.dropField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImage)).EndInit();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel grid;
        private Panel dropField;
        private PictureBox inputImage;
        private PictureBox outputImage;
        private TableLayoutPanel buttons;
        private Button gausianBlur;
        private Button gausian;
        private Button repulsion;
        private Button sharpen;
        private Button blur;
    }
}