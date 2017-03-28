using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form

    {
        public void DisableButtons()
        {
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            B4.Enabled = false;
            B5.Enabled = false;
            B6.Enabled = false;
            B7.Enabled = false;
            B8.Enabled = false;
            B9.Enabled = false;
            B13.Enabled = false;
            B17.Enabled = false;
            B21.Enabled = false;
            B25.Enabled = false;
            B26.Enabled = false;
            B28.Enabled = false;

        }

        public void EnableButtons()
        { if (SavedNumber != 0)
            {
                B1.Enabled = true;
                B2.Enabled = true;
            }
            else if (SavedNumber == 0)
            {
                B1.Enabled = false;
                B2.Enabled = false;
            }
            B3.Enabled = true;
            B4.Enabled = true;
            B5.Enabled = true;
            B6.Enabled = true;
            B7.Enabled = true;
            B8.Enabled = true;
            B9.Enabled = true;
            B13.Enabled = true;
            B17.Enabled = true;
            B21.Enabled = true;
            B25.Enabled = true;
            B26.Enabled = true;
            B28.Enabled = true;



        }
        public void CannotDivideByZero() {
            if (display.Text == "Cannot divide by zero")
            {
                display.Text = "0";
                EnableButtons();
            }
        }

        // public static bool FirstNumberIsNotEmpty=false;
        public static Calculator calculator;
        public static bool FirstNumberIsNotEmpty = false;
        public static double PercentNumber = 0;
        public static double SavedNumber = 0;
        public static int CounterForOperation = 0;
        public static int SecondCounterForOperation = 0;
        public static int OperationPressedAmount = 0;
        public static bool NoOperationSign = false;
        public static bool NumberPressed = false;
        public static int CounterForEqualsAndNumbersAmount = 0;
        public Form1()
        {

            InitializeComponent();
            calculator = new Calculator();
            display.Text = "0";
            EnableButtons();
        }

        public void number_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (display.Text == "Cannot divide by zero")
            {
                EnableButtons();
            }
            if (calculator.operation == Calculator.Operation.EQUAL)
            {
                if (CounterForEqualsAndNumbersAmount == 0)
                {
                    NoOperationSign = true;
                    NumberPressed = true;
                    calculator.operation = Calculator.Operation.NUMBER;
                    calculator.firstNumber = calculator.secondNumber;
                    display.Text = "";
                    CounterForEqualsAndNumbersAmount = 1;
                }
                else {
                    NoOperationSign = true;
                    NumberPressed = false;
                    calculator.operation = Calculator.Operation.EQUAL;
                    display.Text = "";
                    display.Text += btn.Text;
                  }
                 }
             if (calculator.operation == Calculator.Operation.NONE ||
                calculator.operation == Calculator.Operation.NUMBER )
            { 
            if (display.Text.Length >= 23)
              { }
                else
                {
                    if (display.Text == "0")
                    {
                        display.Text = btn.Text;
                    }
                    else if (display.Text != "0")
                    {
                        display.Text += btn.Text;
                       
                    }
                    
                }
            }
                else if (calculator.operation == Calculator.Operation.PLUS ||
                     calculator.operation == Calculator.Operation.MINUS ||
                     calculator.operation == Calculator.Operation.TIMES ||
                     calculator.operation == Calculator.Operation.DIVIDED)
            {
              //  calculator.saveFirstNumber(display.Text);
                display.Text = btn.Text;
                switch (calculator.operation) {
                    case Calculator.Operation.PLUS:
                        CounterForOperation = 1;
                        break;
                    case Calculator.Operation.MINUS:
                        CounterForOperation = 2;
                        break;
                    case Calculator.Operation.TIMES:
                        CounterForOperation = 4;
                        break;
                    case Calculator.Operation.DIVIDED:
                        CounterForOperation = 3;
                        break;
                }
                OperationPressedAmount = 2;
              //  FirstNumberIsNotEmpty = true;
            }

            else if (calculator.operation == Calculator.Operation.SAVE)
            {
                display.Text = btn.Text;
            }

            calculator.operation = Calculator.Operation.NUMBER;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OperationPressedAmount = 0;
            if (display.Text == "Cannot divide by zero")
            {
                CannotDivideByZero();
                CounterForOperation = 0;// counter created to add/substract/divide/multiplicate second number to the result
              
                OperationPressedAmount = 0;
                NoOperationSign = false;
                NumberPressed = false;
                calculator.operation = Calculator.Operation.NONE;
            }
           
            else{
                if (FirstNumberIsNotEmpty) {
                    if (calculator.operation == Calculator.Operation.NUMBER || calculator.operation == Calculator.Operation.SAVE
                    || calculator.operation == Calculator.Operation.PLUS ||
                     calculator.operation == Calculator.Operation.MINUS ||
                     calculator.operation == Calculator.Operation.TIMES ||
                     calculator.operation == Calculator.Operation.DIVIDED)

                      {   
                         if (CounterForOperation == 2 && NumberPressed == false)
                            calculator.saveSecondNumber((double.Parse(display.Text)*(-1)).ToString());
                         else if (CounterForOperation == 2 && NumberPressed)
                          { 
                          calculator.saveSecondNumber(double.Parse(display.Text).ToString());
                           NumberPressed = false;
                          }
                          else if (CounterForOperation == 3 && NumberPressed == false)
                            {
                               if (display.Text == "0")
                            {
                                calculator.secondNumber = 0;
                                DisableButtons();
                            }
                                  else if (display.Text != "Cannot divide by zero" || display.Text != "0")
                                calculator.saveSecondNumber((1 / double.Parse(display.Text)).ToString());
                        }
                        else if (CounterForOperation == 3 && NumberPressed)
                        {
                            calculator.saveSecondNumber(double.Parse(display.Text).ToString());
                            NumberPressed = false;
                        }
                        else
                            calculator.saveSecondNumber(display.Text);}
                    else if (calculator.operation == Calculator.Operation.EQUAL)
                    { if (NoOperationSign == false)
                            calculator.saveFirstNumber(display.Text);
                        else 
                            calculator.saveSecondNumber(display.Text);
                    }
                    switch (CounterForOperation)
                    {
                        case 1:
                            display.Text = calculator.getResultPlus().ToString();
                            break;
                        case 2:
                            display.Text = calculator.getResultPlus().ToString();
                            break;
                        case 3:
                            if (calculator.secondNumber == 0)
                            {
                                display.Text = "Cannot divide by zero";
                                calculator.secondNumber = 1;
                            }
                            else
                                display.Text = calculator.getResultTimes().ToString();
                            break;
                        case 4:
                            display.Text = calculator.getResultTimes().ToString();
                            break;


                    }
                    calculator.operation = Calculator.Operation.EQUAL;
                }
            }

        }




        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (OperationPressedAmount == 0)
            {
                switch (btn.Text)
                {
                    case "+":
                        calculator.operation = Calculator.Operation.PLUS;
                        CounterForOperation = 1;
                        SecondCounterForOperation = 1;
                        break;
                    case "-":
                        calculator.operation = Calculator.Operation.MINUS;
                        CounterForOperation = 2;
                        SecondCounterForOperation = 2;
                        break;
                    case "÷":
                        calculator.operation = Calculator.Operation.DIVIDED;
                        CounterForOperation = 3;
                        SecondCounterForOperation = 3;
                        break;
                    case "*":
                        calculator.operation = Calculator.Operation.TIMES;
                        CounterForOperation = 4;
                        SecondCounterForOperation = 4;
                        break;
                }
            }
            else if (OperationPressedAmount == 2)
            {
                switch (btn.Text)
                {
                    case "+":
                        calculator.operation = Calculator.Operation.PLUS;
                    SecondCounterForOperation = 1;
                        break;
                    case "-":
                        calculator.operation = Calculator.Operation.MINUS;
                        SecondCounterForOperation = 2;
                        break;
                    case "÷":
                        calculator.operation = Calculator.Operation.DIVIDED;
                       SecondCounterForOperation = 3;
                        break;
                    case "*":
                        calculator.operation = Calculator.Operation.TIMES;
                       SecondCounterForOperation = 4;
                        break;
                }
            }
            if (OperationPressedAmount == 2)
                {
                    switch (CounterForOperation)
                    {
                        case 3:
                            display.Text = (calculator.firstNumber / double.Parse(display.Text)).ToString();
                            break;
                        case 2:
                            display.Text = ((-1)*double.Parse(display.Text) + calculator.firstNumber).ToString();
                            break;
                        case 4:
                            display.Text = (double.Parse(display.Text) * calculator.firstNumber).ToString();
                            break;
                        case 1:
                            display.Text = (double.Parse(display.Text) + calculator.firstNumber).ToString();
                            break;
                    }
                   OperationPressedAmount = 0;
                    calculator.saveFirstNumber(display.Text);
             }
            FirstNumberIsNotEmpty = true;
            NoOperationSign = false;
            NumberPressed = false;
            CounterForEqualsAndNumbersAmount = 0;
            calculator.saveFirstNumber(display.Text);
        }
         

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void button19_Click(object sender, EventArgs e)
        {
            CannotDivideByZero();
            if (FirstNumberIsNotEmpty)
            {
                display.Text = "0";
                calculator.secondNumber = 0;
            }
            else
            {
                display.Text = "0";
                calculator.firstNumber = 0;
            }
           }

        private void display_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button30_Click(object sender, EventArgs e)
        {
            calculator.saveFirstNumber(display.Text);
            display.Text = (SavedNumber).ToString();
            switch (calculator.operation)
            {
                case Calculator.Operation.PLUS:
                    CounterForOperation = 1;
                    break;
                case Calculator.Operation.MINUS:
                    CounterForOperation = 2;
                    break;
            }
                    calculator.operation = Calculator.Operation.SAVE;

            FirstNumberIsNotEmpty = true;

        }

        private void button23_Click(object sender, EventArgs e)
        {
            display.Text = Math.Sqrt(double.Parse(display.Text)).ToString();
           
        }

     

        private void button13_Click(object sender, EventArgs e)
        {
           if (!display.Text.Contains(','))
                display.Text += ",";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            display.Text = Math.Pow(double.Parse(display.Text),2).ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
           
            if (display.Text == "0")
            {
                display.Text = "Cannot divide by zero";
                DisableButtons();
            }
           else 
           display.Text = (1 / (Convert.ToDouble(display.Text))).ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CannotDivideByZero();
            display.Text = "0";
            FirstNumberIsNotEmpty = false;
            PercentNumber = 0;
            CounterForOperation = 0;
            OperationPressedAmount = 0;
            NoOperationSign = false;
            NumberPressed = false;
            CounterForEqualsAndNumbersAmount = 0;
            calculator.firstNumber = 0;
            calculator.secondNumber = 0;
            calculator.operation = Calculator.Operation.NONE;
           }

        private void button24_Click(object sender, EventArgs e)
        {
            if (calculator.operation == Calculator.Operation.NUMBER)
            {
                PercentNumber = double.Parse(display.Text) / 100;
                calculator.saveSecondNumber((PercentNumber).ToString());
                display.Text = (PercentNumber * calculator.firstNumber).ToString();
            }
            else 
            {
                switch (CounterForOperation)
                {
                    case 1:
                        display.Text = (double.Parse(display.Text) * (1 + PercentNumber)).ToString();
                        break;
                    case 2:
                        display.Text = (double.Parse(display.Text) * (1 - PercentNumber)).ToString();
                        break;
                    case 3:
                        display.Text = (double.Parse(display.Text) * (1 / PercentNumber)).ToString();
                        break;
                    case 4:
                        display.Text = (double.Parse(display.Text) * (1 * PercentNumber)).ToString();
                        break;
                }
            }
        }







        private void button14_Click(object sender, EventArgs e)
        {
            CannotDivideByZero();
            if (display.Text.Length == 1 )
            {
                display.Text = "0";
             }
            else if (display.Text.Length > 1)
            {
                display.Text = calculator.DeleteLastCharacter(display.Text);
            }
            else { }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            SavedNumber = 0;
            EnableButtons();
        }

        public void button27_Click(object sender, EventArgs e)
        {
         calculator.operation = Calculator.Operation.SAVE;
         SavedNumber = double.Parse(display.Text);
         EnableButtons();
        }

        private void button28_Click(object sender, EventArgs e)
        {
         SavedNumber -= double.Parse(display.Text);
        }

        private void button29_Click(object sender, EventArgs e)
        {
         SavedNumber += double.Parse(display.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            display.Text =( double.Parse(display.Text) *(-1)).ToString();
        }
 }
}
