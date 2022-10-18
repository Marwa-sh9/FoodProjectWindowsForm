namespace FoodProjectWindowsForm
{
    partial class Welcom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcom));
            this.label1 = new System.Windows.Forms.Label();
            this.Enter = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(95, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcom";
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.NavajoWhite;
            this.Enter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter.ForeColor = System.Drawing.Color.YellowGreen;
            this.Enter.Location = new System.Drawing.Point(275, 306);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(123, 43);
            this.Enter.TabIndex = 1;
            this.Enter.Text = "Enter";
            this.Enter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            this.Enter.MouseHover += new System.EventHandler(this.Enter_MouseHover);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Maroon;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.YellowGreen;
            this.Exit.Location = new System.Drawing.Point(595, 372);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(80, 42);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Welcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(678, 417);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.label1);
            this.Name = "Welcom";
            this.Text = "Welcom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Button Exit;
    }
}