using System.Data;
using System.Linq.Expressions;

namespace PSIW_lab9
{
    public partial class Form1 : Form
    {
        private List<string> history;
        private bool isScientificMode = false;

        float a, b;
        int count;
        bool znak = true;
        public Form1()
        {
            InitializeComponent();
            isScientificMode = false;
            ShowSimpleMode();
            history = new List<string>();
        }
        private void InitializeCalculator()
        {
            ShowSimpleMode();
            button14.Click += OperationButton_Click;
            button15.Click += OperationButton_Click;
            button16.Click += OperationButton_Click;
            button17.Click += OperationButton_Click;
            button18.Click += buttonEquals_Click;

            button19.Click += SpecialFunctionButton_Click;
            button20.Click += SpecialFunctionButton_Click;
            button21.Click += SpecialFunctionButton_Click;
           
            listView1.View = View.Details;
            listView1.Columns.Add("Operacja", 200);
            listView1.Columns.Add("Wynik", 100);
        }
        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            label1.Text = button.Text;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = label1.Text + " " + textBox1.Text;
                double result = EvaluateExpression(expression);

                label1.Text = result.ToString();
                AddToHistory(expression, result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void SpecialFunctionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string functionName = button.Tag.ToString();
            string expression = functionName + "(" + textBox1.Text + ")";
            double result = EvaluateExpression(expression);

            label1.Text = result.ToString();
            AddToHistory(expression, result.ToString());
        }

        private double EvaluateExpression(string expression)
        {
            DataTable table = new DataTable();
            var result = table.Compute(expression, "");
            return Convert.ToDouble(result);
        }

        private void AddToHistory(string operation, string result)
        {
            ListViewItem item = new ListViewItem(operation);
            item.SubItems.Add(result);
            listView1.Items.Add(item);
        }

        private void ShowSimpleMode()
        {
            // Wyœwietlanie przycisków dla trybu prostego
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            // Ustawienie rozmiaru okna kalkulatora
            Width = 1000;
        }
        private void ShowScientificMode()
        {
            // Wyœwietlanie przycisków dla trybu naukowego
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button21.Visible = true;
            button22.Visible = true;
            button23.Visible = true;
            button24.Visible = true;
            // Ustawienie rozmiaru okna kalkulatora
            Width = 400;
        }
        private void SwitchModeButton_Click(object sender, EventArgs e)
        {
            isScientificMode = !isScientificMode;

            if (isScientificMode)
                ShowScientificMode();
            else
                ShowSimpleMode();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string entry in history)
            {
                listView1.Items.Add(entry);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                double expression = double.Parse(label1.Text);
                double result = Math.Log10(expression);
                label1.Text = result.ToString();

                // Dodawanie do historii operacji
                listView1.Items.Add("log(" + expression + ") = " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = label1.Text;
                DataTable table = new DataTable();
                var result = table.Compute(expression, "");
                double resultValue = Convert.ToDouble(result);
                label1.Text = resultValue.ToString();

                // Dodawanie do historii operacji
                listView1.Items.Add(expression + " = " + resultValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBox1.Text);
                textBox1.Clear();
                count = 1;
                label1.Text = a.ToString() + "+";
                znak = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label1.Text = a.ToString() + "-";
            znak = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out float parsedValue))
            {
                a = parsedValue;
                textBox1.Clear();
                count = 3;
                label1.Text = a.ToString() + "*";
                znak = true;
            }
            else
            {
                MessageBox.Show("Wprowadzona wartoœæ nie jest liczb¹ poprawnego formatu.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out float parsedValue))
            {
                a = parsedValue;
                textBox1.Clear();
                count = 4;
                label1.Text = a.ToString() + "/";
                znak = true;
            }
            else
            {
                MessageBox.Show("Wprowadzona wartoœæ nie jest liczb¹ poprawnego formatu.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (isScientificMode)
            {
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                isScientificMode = false;
            }
            else
            {

                button18.Visible = true;
                button19.Visible = true;
                button20.Visible = true;
                button21.Visible = true;
                button22.Visible = true;
                button23.Visible = true;
                button24.Visible = true;

                isScientificMode = true;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Empty value", "Empty error", MessageBoxButtons.OK);
                button24.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
            ShowSimpleMode();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                double expression = double.Parse(label1.Text);
                double result = Math.Sin(expression);
                label1.Text = result.ToString();

                // Dodawanie do historii operacji
                listView1.Items.Add("sin(" + expression + ") = " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                double expression = double.Parse(label1.Text);
                double result = Math.Cos(expression);
                label1.Text = result.ToString();

                // Dodawanie do historii operacji
                listView1.Items.Add("cos(" + expression + ") = " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                double expression = double.Parse(label1.Text);
                double result = Math.Tan(expression);
                label1.Text = result.ToString();

                // Dodawanie do historii operacji
                listView1.Items.Add("tan(" + expression + ") = " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                double expression = double.Parse(label1.Text);
                double result = Math.Sqrt(expression);
                label1.Text = result.ToString();

                // Dodawanie do historii operacji
                listView1.Items.Add("sqrt(" + expression + ") = " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                double expression = double.Parse(label1.Text);
                double result = Math.Pow(expression, 2); // Potêga 2 dla przyk³adu
                label1.Text = result.ToString();

                // Dodawanie do historii operacji
                listView1.Items.Add(expression + "^2 = " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }
    }
}