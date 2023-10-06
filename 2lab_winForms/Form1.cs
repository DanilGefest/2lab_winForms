using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MinimizationApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

       


        private double CalculateFunction(double x)
        {

            return (27 - 18 * x + 2 * Math.Pow(x, 2)) * Math.Pow(Math.E, -(x / 3));
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

            double a, b, epsilon;

            if (!double.TryParse(aTextBox.Text, out a) || !double.TryParse(bTextBox.Text, out b) || !double.TryParse(epsilonTextBox.Text, out epsilon))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для a, b и точности (epsilon).", "Ошибка");
                return;
            }

            double minimum = CalculateMinimum(a, b, epsilon);
            solutionTextBox.Text = $"Минимум функции: {minimum:F6}";
        }

        private double CalculateMinimum(double a, double b, double epsilon)
        {
            double x1 = a;
            double x2 = b;

            do
            {
                double x3 = (x1 + x2) / 2;
                double f1 = CalculateFunction(x1);
                double f2 = CalculateFunction(x2);
                double f3 = CalculateFunction(x3);

                if (f1 * f3 < 0)
                {
                    x2 = x3;
                }
                else
                {
                    x1 = x3;
                }
            } while (Math.Abs(x2 - x1) > epsilon);

            return (x1 + x2) / 2;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            aTextBox.Clear();
            bTextBox.Clear();
            epsilonTextBox.Clear();
            solutionTextBox.Clear();
        }

        private void InitializeComponent()
        {
            this.aLabel = new System.Windows.Forms.Label();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.epsilonTextBox = new System.Windows.Forms.TextBox();
            this.bLabel = new System.Windows.Forms.Label();
            this.epsilonLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.solutionTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(8, 38);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(31, 20);
            this.aLabel.TabIndex = 0;
            this.aLabel.Text = "а =";
            this.aLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(45, 38);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(100, 26);
            this.aTextBox.TabIndex = 1;
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(45, 85);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(100, 26);
            this.bTextBox.TabIndex = 2;
            // 
            // epsilonTextBox
            // 
            this.epsilonTextBox.Location = new System.Drawing.Point(190, 58);
            this.epsilonTextBox.Name = "epsilonTextBox";
            this.epsilonTextBox.Size = new System.Drawing.Size(278, 26);
            this.epsilonTextBox.TabIndex = 3;
            this.epsilonTextBox.TextChanged += new System.EventHandler(this.epsilonTextBox_TextChanged);
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.Location = new System.Drawing.Point(8, 88);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(31, 20);
            this.bLabel.TabIndex = 4;
            this.bLabel.Text = "b =";
            // 
            // epsilonLabel
            // 
            this.epsilonLabel.AutoSize = true;
            this.epsilonLabel.Location = new System.Drawing.Point(240, 35);
            this.epsilonLabel.Name = "epsilonLabel";
            this.epsilonLabel.Size = new System.Drawing.Size(180, 20);
            this.epsilonLabel.TabIndex = 5;
            this.epsilonLabel.Text = "Точность (прим. 0,001)";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(31, 135);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(115, 35);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Расчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click_1);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(386, 210);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(115, 35);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click_1);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(27, 191);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(253, 20);
            this.resultLabel.TabIndex = 8;
            this.resultLabel.Text = "Локальный минимум функции = ";
            this.resultLabel.Click += new System.EventHandler(this.resultLabel_Click);
            // 
            // solutionTextBox
            // 
            this.solutionTextBox.Location = new System.Drawing.Point(31, 214);
            this.solutionTextBox.Name = "solutionTextBox";
            this.solutionTextBox.Size = new System.Drawing.Size(210, 26);
            this.solutionTextBox.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(513, 275);
            this.Controls.Add(this.solutionTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.epsilonLabel);
            this.Controls.Add(this.bLabel);
            this.Controls.Add(this.epsilonTextBox);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label aLabel;

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.TextBox epsilonTextBox;
        private Label bLabel;
        private Label epsilonLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button clearButton;
        private Label resultLabel;
        private System.Windows.Forms.TextBox solutionTextBox;

        private void calculateButton_Click_1(object sender, EventArgs e)
        {
            calculateButton.Click += new EventHandler(CalculateButton_Click);

        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            clearButton.Click += new EventHandler(ClearButton_Click);
        }

        private void epsilonTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void functionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void resultLabel_Click(object sender, EventArgs e)
        {

        }

        private MenuStrip menuStrip1;

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
