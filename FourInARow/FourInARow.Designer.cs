namespace FourInARow
{
    partial class FourInARow
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
            this.keyInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // keyInfo
            // 
            this.keyInfo.AutoSize = true;
            this.keyInfo.Location = new System.Drawing.Point(12, 446);
            this.keyInfo.Name = "keyInfo";
            this.keyInfo.Size = new System.Drawing.Size(254, 65);
            this.keyInfo.TabIndex = 0;
            this.keyInfo.Text = "Om te spelen kun je de volgende toetsen gebruiken:\r\n\r\nA: verplaats de steen naar " +
    "links\r\nS: laat de steen vallen\r\nD: verplaats de steen naar rechts";
            // 
            // FourInARow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 520);
            this.Controls.Add(this.keyInfo);
            this.KeyPreview = true;
            this.Name = "FourInARow";
            this.Text = "Vier op een rij - Johnny Borg";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FourInARow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FourInARow_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keyInfo;
    }
}

