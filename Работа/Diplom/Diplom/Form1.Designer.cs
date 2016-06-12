namespace Diplom
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateShedule = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ModificatedAlgoritm = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numericTypeCount = new System.Windows.Forms.NumericUpDown();
            this.CountTypeDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.ModificatedAlgoritm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTypeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountTypeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateShedule
            // 
            this.CreateShedule.Location = new System.Drawing.Point(575, 263);
            this.CreateShedule.Name = "CreateShedule";
            this.CreateShedule.Size = new System.Drawing.Size(111, 42);
            this.CreateShedule.TabIndex = 0;
            this.CreateShedule.Text = "Построить расписание";
            this.CreateShedule.UseVisualStyleBackColor = true;
            this.CreateShedule.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(595, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "количество типов  заявок";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(93, 365);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(559, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ModificatedAlgoritm);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 346);
            this.tabControl1.TabIndex = 5;
            // 
            // ModificatedAlgoritm
            // 
            this.ModificatedAlgoritm.Controls.Add(this.CountTypeDGV);
            this.ModificatedAlgoritm.Controls.Add(this.numericTypeCount);
            this.ModificatedAlgoritm.Controls.Add(this.CreateShedule);
            this.ModificatedAlgoritm.Controls.Add(this.button2);
            this.ModificatedAlgoritm.Controls.Add(this.label1);
            this.ModificatedAlgoritm.Location = new System.Drawing.Point(4, 22);
            this.ModificatedAlgoritm.Name = "ModificatedAlgoritm";
            this.ModificatedAlgoritm.Padding = new System.Windows.Forms.Padding(3);
            this.ModificatedAlgoritm.Size = new System.Drawing.Size(702, 320);
            this.ModificatedAlgoritm.TabIndex = 0;
            this.ModificatedAlgoritm.Text = "Алгоритм с модификацией составов партий требований";
            this.ModificatedAlgoritm.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(702, 320);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Фиксированные партии";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numericTypeCount
            // 
            this.numericTypeCount.Location = new System.Drawing.Point(6, 58);
            this.numericTypeCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericTypeCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTypeCount.Name = "numericTypeCount";
            this.numericTypeCount.Size = new System.Drawing.Size(120, 20);
            this.numericTypeCount.TabIndex = 4;
            this.numericTypeCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTypeCount.ValueChanged += new System.EventHandler(this.numericTypeCount_ValueChanged);
            // 
            // CountTypeDGV
            // 
            this.CountTypeDGV.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.CountTypeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CountTypeDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.CountTypeDGV.GridColor = System.Drawing.SystemColors.HighlightText;
            this.CountTypeDGV.Location = new System.Drawing.Point(3, 84);
            this.CountTypeDGV.Name = "CountTypeDGV";
            this.CountTypeDGV.RowHeadersVisible = false;
            this.CountTypeDGV.RowHeadersWidth = 35;
            this.CountTypeDGV.Size = new System.Drawing.Size(424, 52);
            this.CountTypeDGV.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "Тип 1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 418);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.ModificatedAlgoritm.ResumeLayout(false);
            this.ModificatedAlgoritm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTypeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountTypeDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateShedule;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ModificatedAlgoritm;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView CountTypeDGV;
        private System.Windows.Forms.NumericUpDown numericTypeCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

