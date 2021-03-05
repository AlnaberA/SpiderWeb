
namespace HackWebV2.Menu_Tools
{
    partial class GetSourceForm
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
            this.htmlView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // htmlView
            // 
            this.htmlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlView.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htmlView.Location = new System.Drawing.Point(12, 12);
            this.htmlView.MaxLength = 0;
            this.htmlView.Multiline = true;
            this.htmlView.Name = "htmlView";
            this.htmlView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htmlView.Size = new System.Drawing.Size(1144, 715);
            this.htmlView.TabIndex = 0;
            // 
            // GetSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 739);
            this.Controls.Add(this.htmlView);
            this.Name = "GetSourceForm";
            this.Text = "GetSourceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox htmlView;
    }
}