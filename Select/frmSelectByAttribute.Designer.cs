namespace Giser_Lu
{
    partial class frmSelectByAttribute
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbx_Layer = new System.Windows.Forms.ComboBox();
            this.cbx_SelectMethod = new System.Windows.Forms.ComboBox();
            this.lst_Field = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_ValueOfField = new System.Windows.Forms.ListBox();
            this.btn_GetValueOfField = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxtBx_SqlExpression = new System.Windows.Forms.RichTextBox();
            this.btn_ClearSqlExpression = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_Layer
            // 
            this.cbx_Layer.FormattingEnabled = true;
            this.cbx_Layer.Location = new System.Drawing.Point(50, 4);
            this.cbx_Layer.Name = "cbx_Layer";
            this.cbx_Layer.Size = new System.Drawing.Size(283, 20);
            this.cbx_Layer.TabIndex = 0;
            this.cbx_Layer.SelectedIndexChanged += new System.EventHandler(this.cbx_Layer_SelectedIndexChanged);
            // 
            // cbx_SelectMethod
            // 
            this.cbx_SelectMethod.FormattingEnabled = true;
            this.cbx_SelectMethod.Items.AddRange(new object[] {
            "创建新的查询",
            "加入现有查询",
            "从现有查询中移去",
            "在现有查询中查询"});
            this.cbx_SelectMethod.Location = new System.Drawing.Point(75, 30);
            this.cbx_SelectMethod.Name = "cbx_SelectMethod";
            this.cbx_SelectMethod.Size = new System.Drawing.Size(258, 20);
            this.cbx_SelectMethod.TabIndex = 1;
            this.cbx_SelectMethod.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectMethod_SelectedIndexChanged);
            // 
            // lst_Field
            // 
            this.lst_Field.FormattingEnabled = true;
            this.lst_Field.ItemHeight = 12;
            this.lst_Field.Location = new System.Drawing.Point(2, 56);
            this.lst_Field.Name = "lst_Field";
            this.lst_Field.Size = new System.Drawing.Size(331, 88);
            this.lst_Field.TabIndex = 2;
            this.lst_Field.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_Field_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "<>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "=";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(44, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(80, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = ">=";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(80, 46);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "<=";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(116, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(37, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Or";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(116, 46);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(37, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Not";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(116, 75);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(37, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "And";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(73, 104);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(37, 23);
            this.button10.TabIndex = 12;
            this.button10.Text = "Like";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(116, 104);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(37, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "Is";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(46, 75);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(29, 23);
            this.button12.TabIndex = 14;
            this.button12.Text = "_";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(80, 75);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(30, 23);
            this.button13.TabIndex = 15;
            this.button13.Text = "%";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(8, 75);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(29, 23);
            this.button14.TabIndex = 16;
            this.button14.Text = "()";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Location = new System.Drawing.Point(2, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 136);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lst_ValueOfField
            // 
            this.lst_ValueOfField.FormattingEnabled = true;
            this.lst_ValueOfField.ItemHeight = 12;
            this.lst_ValueOfField.Location = new System.Drawing.Point(168, 152);
            this.lst_ValueOfField.Name = "lst_ValueOfField";
            this.lst_ValueOfField.Size = new System.Drawing.Size(165, 100);
            this.lst_ValueOfField.TabIndex = 18;
            this.lst_ValueOfField.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_ValueOfField_MouseDoubleClick);
            // 
            // btn_GetValueOfField
            // 
            this.btn_GetValueOfField.Location = new System.Drawing.Point(268, 258);
            this.btn_GetValueOfField.Name = "btn_GetValueOfField";
            this.btn_GetValueOfField.Size = new System.Drawing.Size(65, 23);
            this.btn_GetValueOfField.TabIndex = 19;
            this.btn_GetValueOfField.Text = "字段值";
            this.btn_GetValueOfField.UseVisualStyleBackColor = true;
            this.btn_GetValueOfField.Click += new System.EventHandler(this.btn_GetValueOfField_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(258, 389);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 21;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "图层:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "查询方式:";
            // 
            // rtxtBx_SqlExpression
            // 
            this.rtxtBx_SqlExpression.Location = new System.Drawing.Point(2, 287);
            this.rtxtBx_SqlExpression.Name = "rtxtBx_SqlExpression";
            this.rtxtBx_SqlExpression.Size = new System.Drawing.Size(331, 96);
            this.rtxtBx_SqlExpression.TabIndex = 24;
            this.rtxtBx_SqlExpression.Text = "";
            this.rtxtBx_SqlExpression.Leave += new System.EventHandler(this.rtxtBx_SqlExpression_Leave);
            // 
            // btn_ClearSqlExpression
            // 
            this.btn_ClearSqlExpression.Location = new System.Drawing.Point(2, 386);
            this.btn_ClearSqlExpression.Name = "btn_ClearSqlExpression";
            this.btn_ClearSqlExpression.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearSqlExpression.TabIndex = 25;
            this.btn_ClearSqlExpression.Text = "清空表达式";
            this.btn_ClearSqlExpression.UseVisualStyleBackColor = true;
            this.btn_ClearSqlExpression.Click += new System.EventHandler(this.btn_ClearSqlExpression_Click);
            // 
            // frmSelectByAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 421);
            this.Controls.Add(this.btn_ClearSqlExpression);
            this.Controls.Add(this.rtxtBx_SqlExpression);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_GetValueOfField);
            this.Controls.Add(this.lst_ValueOfField);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lst_Field);
            this.Controls.Add(this.cbx_SelectMethod);
            this.Controls.Add(this.cbx_Layer);
            this.Name = "frmSelectByAttribute";
            this.Text = "frmSelectByAttribute";
            this.Load += new System.EventHandler(this.frmSelectByAttribute_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Layer;
        private System.Windows.Forms.ComboBox cbx_SelectMethod;
        private System.Windows.Forms.ListBox lst_Field;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lst_ValueOfField;
        private System.Windows.Forms.Button btn_GetValueOfField;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxtBx_SqlExpression;
        private System.Windows.Forms.Button btn_ClearSqlExpression;
    }
}