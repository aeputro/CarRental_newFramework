
namespace CarRental_newFramework
{
    partial class ResetPassword
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
            this.lblTitleResetPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tConfirmedPassword = new System.Windows.Forms.TextBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitleResetPassword
            // 
            this.lblTitleResetPassword.AutoSize = true;
            this.lblTitleResetPassword.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleResetPassword.Location = new System.Drawing.Point(58, 9);
            this.lblTitleResetPassword.Name = "lblTitleResetPassword";
            this.lblTitleResetPassword.Size = new System.Drawing.Size(172, 28);
            this.lblTitleResetPassword.TabIndex = 2;
            this.lblTitleResetPassword.Text = "Reset Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "New Password";
            // 
            // tNewPassword
            // 
            this.tNewPassword.Location = new System.Drawing.Point(35, 79);
            this.tNewPassword.Name = "tNewPassword";
            this.tNewPassword.PasswordChar = '*';
            this.tNewPassword.Size = new System.Drawing.Size(211, 20);
            this.tNewPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Confirm Password";
            // 
            // tConfirmedPassword
            // 
            this.tConfirmedPassword.Location = new System.Drawing.Point(35, 140);
            this.tConfirmedPassword.Name = "tConfirmedPassword";
            this.tConfirmedPassword.PasswordChar = '*';
            this.tConfirmedPassword.Size = new System.Drawing.Size(211, 20);
            this.tConfirmedPassword.TabIndex = 2;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(77, 186);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(126, 23);
            this.btnResetPassword.TabIndex = 3;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 237);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.tConfirmedPassword);
            this.Controls.Add(this.tNewPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitleResetPassword);
            this.Name = "ResetPassword";
            this.Text = "ResetPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleResetPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tConfirmedPassword;
        private System.Windows.Forms.Button btnResetPassword;
    }
}