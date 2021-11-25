
namespace CarRental_newFramework
{
    partial class ManageUsers
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnActivateDeactivateUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.lblTitleManageUsers = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(41, 90);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(426, 162);
            this.dgvUsers.TabIndex = 8;
            // 
            // btnActivateDeactivateUser
            // 
            this.btnActivateDeactivateUser.Location = new System.Drawing.Point(317, 272);
            this.btnActivateDeactivateUser.Name = "btnActivateDeactivateUser";
            this.btnActivateDeactivateUser.Size = new System.Drawing.Size(150, 23);
            this.btnActivateDeactivateUser.TabIndex = 4;
            this.btnActivateDeactivateUser.Text = "Activate/Deactivate User";
            this.btnActivateDeactivateUser.UseVisualStyleBackColor = true;
            this.btnActivateDeactivateUser.Click += new System.EventHandler(this.btnActivateDeactivateUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(185, 272);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(98, 23);
            this.btnEditUser.TabIndex = 5;
            this.btnEditUser.Text = "Reset Password";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Location = new System.Drawing.Point(41, 272);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(109, 23);
            this.btnAddNewUser.TabIndex = 6;
            this.btnAddNewUser.Text = "Add User";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // lblTitleManageUsers
            // 
            this.lblTitleManageUsers.AutoSize = true;
            this.lblTitleManageUsers.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleManageUsers.Location = new System.Drawing.Point(139, 21);
            this.lblTitleManageUsers.Name = "lblTitleManageUsers";
            this.lblTitleManageUsers.Size = new System.Drawing.Size(139, 22);
            this.lblTitleManageUsers.TabIndex = 3;
            this.lblTitleManageUsers.Text = "Manage Users";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(41, 54);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 316);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnActivateDeactivateUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.lblTitleManageUsers);
            this.Name = "ManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnActivateDeactivateUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Label lblTitleManageUsers;
        private System.Windows.Forms.Button btnRefresh;
    }
}