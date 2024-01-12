
namespace EnumStudy
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DepartmentLabel = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Label();
            this.RefreshLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AddLabel = new System.Windows.Forms.Label();
            this.DeleteLabel = new System.Windows.Forms.Label();
            this.ModifyLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.EmployeeList = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1432, 35);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.DepartmentLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CloseBtn, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.RefreshLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.DeleteLabel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ModifyLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LoginLabel, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(965, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 31);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // DepartmentLabel
            // 
            this.DepartmentLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentLabel.AutoSize = true;
            this.DepartmentLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DepartmentLabel.Location = new System.Drawing.Point(3, 5);
            this.DepartmentLabel.Name = "DepartmentLabel";
            this.DepartmentLabel.Size = new System.Drawing.Size(42, 21);
            this.DepartmentLabel.TabIndex = 1;
            this.DepartmentLabel.Text = "부서";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CloseBtn.AutoSize = true;
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.Location = new System.Drawing.Point(423, 5);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(42, 21);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "닫기";
            // 
            // RefreshLabel
            // 
            this.RefreshLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RefreshLabel.AutoSize = true;
            this.RefreshLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshLabel.Location = new System.Drawing.Point(51, 5);
            this.RefreshLabel.Name = "RefreshLabel";
            this.RefreshLabel.Size = new System.Drawing.Size(42, 21);
            this.RefreshLabel.TabIndex = 1;
            this.RefreshLabel.Text = "조회";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Location = new System.Drawing.Point(343, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "자료변환";
            // 
            // AddLabel
            // 
            this.AddLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddLabel.AutoSize = true;
            this.AddLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddLabel.Location = new System.Drawing.Point(99, 5);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(42, 21);
            this.AddLabel.TabIndex = 1;
            this.AddLabel.Text = "추가";
            // 
            // DeleteLabel
            // 
            this.DeleteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteLabel.AutoSize = true;
            this.DeleteLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteLabel.Location = new System.Drawing.Point(295, 5);
            this.DeleteLabel.Name = "DeleteLabel";
            this.DeleteLabel.Size = new System.Drawing.Size(42, 21);
            this.DeleteLabel.TabIndex = 1;
            this.DeleteLabel.Text = "삭제";
            // 
            // ModifyLabel
            // 
            this.ModifyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ModifyLabel.AutoSize = true;
            this.ModifyLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModifyLabel.Location = new System.Drawing.Point(147, 5);
            this.ModifyLabel.Name = "ModifyLabel";
            this.ModifyLabel.Size = new System.Drawing.Size(42, 21);
            this.ModifyLabel.TabIndex = 1;
            this.ModifyLabel.Text = "수정";
            // 
            // LoginLabel
            // 
            this.LoginLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginLabel.Location = new System.Drawing.Point(195, 5);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(94, 21);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "로그인 정보";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Title.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Title.Location = new System.Drawing.Point(39, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(84, 25);
            this.Title.TabIndex = 0;
            this.Title.Text = "부서사원";
            this.Title.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // EmployeeList
            // 
            this.EmployeeList.BackgroundColor = System.Drawing.Color.White;
            this.EmployeeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmployeeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.EmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeList.Location = new System.Drawing.Point(16, 50);
            this.EmployeeList.Name = "EmployeeList";
            this.EmployeeList.RowTemplate.Height = 23;
            this.EmployeeList.Size = new System.Drawing.Size(1248, 696);
            this.EmployeeList.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::EnumStudy.Properties.Resources.ic_person_24px;
            this.panel2.Location = new System.Drawing.Point(17, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 16);
            this.panel2.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1431, 788);
            this.Controls.Add(this.EmployeeList);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1447, 827);
            this.MinimumSize = new System.Drawing.Size(1447, 827);
            this.Name = "Main";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label DepartmentLabel;
        private System.Windows.Forms.Label CloseBtn;
        private System.Windows.Forms.Label RefreshLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label AddLabel;
        private System.Windows.Forms.Label DeleteLabel;
        private System.Windows.Forms.Label ModifyLabel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.DataGridView EmployeeList;
    }
}

