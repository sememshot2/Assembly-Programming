namespace Bitwise_encryption
{
    partial class DevelopmentForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChooseFileBT = new System.Windows.Forms.Button();
            this.CodeRB = new System.Windows.Forms.RadioButton();
            this.DecodeRB = new System.Windows.Forms.RadioButton();
            this.DirectoryBT = new System.Windows.Forms.Button();
            this.KeyTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.indicatorLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ChooseFileBT
            // 
            this.ChooseFileBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseFileBT.Location = new System.Drawing.Point(27, 80);
            this.ChooseFileBT.Margin = new System.Windows.Forms.Padding(6);
            this.ChooseFileBT.Name = "ChooseFileBT";
            this.ChooseFileBT.Size = new System.Drawing.Size(138, 42);
            this.ChooseFileBT.TabIndex = 32;
            this.ChooseFileBT.Text = "Выбрать папку";
            this.ChooseFileBT.UseVisualStyleBackColor = true;
            this.ChooseFileBT.Click += new System.EventHandler(this.ChooseFileBT_Click);
            // 
            // CodeRB
            // 
            this.CodeRB.AutoSize = true;
            this.CodeRB.Checked = true;
            this.CodeRB.Location = new System.Drawing.Point(174, 78);
            this.CodeRB.Name = "CodeRB";
            this.CodeRB.Size = new System.Drawing.Size(120, 24);
            this.CodeRB.TabIndex = 35;
            this.CodeRB.TabStop = true;
            this.CodeRB.Text = "Кодировать";
            this.CodeRB.UseVisualStyleBackColor = true;
            // 
            // DecodeRB
            // 
            this.DecodeRB.AutoSize = true;
            this.DecodeRB.Location = new System.Drawing.Point(174, 102);
            this.DecodeRB.Name = "DecodeRB";
            this.DecodeRB.Size = new System.Drawing.Size(139, 24);
            this.DecodeRB.TabIndex = 36;
            this.DecodeRB.Text = "Декодировать";
            this.DecodeRB.UseVisualStyleBackColor = true;
            // 
            // DirectoryBT
            // 
            this.DirectoryBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirectoryBT.Location = new System.Drawing.Point(27, 129);
            this.DirectoryBT.Margin = new System.Windows.Forms.Padding(6);
            this.DirectoryBT.Name = "DirectoryBT";
            this.DirectoryBT.Size = new System.Drawing.Size(138, 58);
            this.DirectoryBT.TabIndex = 37;
            this.DirectoryBT.Text = "Открыть директорию сохранения";
            this.DirectoryBT.UseVisualStyleBackColor = true;
            this.DirectoryBT.Click += new System.EventHandler(this.DirectoryBT_Click);
            // 
            // KeyTB
            // 
            this.KeyTB.Location = new System.Drawing.Point(27, 45);
            this.KeyTB.Name = "KeyTB";
            this.KeyTB.Size = new System.Drawing.Size(286, 26);
            this.KeyTB.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Открытый ключ";
            // 
            // indicatorLabel
            // 
            this.indicatorLabel.AutoSize = true;
            this.indicatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.indicatorLabel.Location = new System.Drawing.Point(174, 147);
            this.indicatorLabel.Name = "indicatorLabel";
            this.indicatorLabel.Size = new System.Drawing.Size(149, 16);
            this.indicatorLabel.TabIndex = 40;
            this.indicatorLabel.Text = "Идёт декодирование.";
            this.indicatorLabel.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // DevelopmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 211);
            this.Controls.Add(this.indicatorLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyTB);
            this.Controls.Add(this.DirectoryBT);
            this.Controls.Add(this.DecodeRB);
            this.Controls.Add(this.CodeRB);
            this.Controls.Add(this.ChooseFileBT);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevelopmentForm";
            this.Text = "Побитовое шифрование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ChooseFileBT;
        private System.Windows.Forms.RadioButton CodeRB;
        private System.Windows.Forms.RadioButton DecodeRB;
        private System.Windows.Forms.Button DirectoryBT;
        private System.Windows.Forms.TextBox KeyTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label indicatorLabel;
        private System.Windows.Forms.Timer timer;
    }
}

