namespace StatHydre
{
    partial class GraphDisplay
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
            this.graphBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).BeginInit();
            this.SuspendLayout();
            // 
            // graphBox
            // 
            this.graphBox.Location = new System.Drawing.Point(12, 12);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(595, 368);
            this.graphBox.TabIndex = 0;
            this.graphBox.TabStop = false;
            // 
            // GraphDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 392);
            this.Controls.Add(this.graphBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GraphDisplay";
            this.Text = "Graph Display";
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox graphBox;
    }
}