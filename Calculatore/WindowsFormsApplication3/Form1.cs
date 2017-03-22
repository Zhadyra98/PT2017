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
        public  void DisableButtons()
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
        {if (saved != 0)
            {
                B1.Enabled = true;
                B2.Enabled = true;
            }
          else if (saved == 0)
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

    public static bool percpressed = false;
        public static bool numisnum = true;
        public static int memplus = 0;
        public static int memminus = 0;
        public static double percent = 0;
        public static bool equalpressed = false;
        public static double saved = 0;
        public static double AnPlusCount = 0; // when we press plus two or more times textbox should show us the result of operation
        public static int newlinecnt = 0;
        public static int pluscnt = 0;
        public static int NumberStored = 0;
        public static double Number;
        public static double Number1 = 0;
        public static int sctn = 0; // if there is number saved in memory MR button will show nothing
        public static int ctn=0; //counter for operations
        public static int cnt=0; // counter created to add/substract/divide/multiplicate second number to the result
        public static int ccnt = 0;//comma counter
        public static Calculator calculator;
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
            if (calculator.operation == Calculator.Operation.PLUS && AnPlusCount >= 2)
            {
                Number = 0;
                Number1 = 0;
                AnPlusCount = 0;
                display.Text = btn.Text;
                newlinecnt = 0;
                pluscnt = 0;
            }
            if (calculator.operation == Calculator.Operation.NONE ||
                calculator.operation == Calculator.Operation.NUMBER)
            {
               
                if (display.Text == "0" && btn.Text == ",")
                    display.Text += btn.Text;
                else if (display.Text != "0" && equalpressed || display.Text == "Cannot divide by zero")
                {
                    EnableButtons();
                    display.Text = btn.Text;
                    equalpressed = false;
                }
                else if (display.Text != "0" && newlinecnt == 1)
                {
                    newlinecnt = 0;
                    display.Text = btn.Text;
                }
               
             
                else if (display.Text != "0")
                    display.Text += btn.Text;
                else if (display.Text == "0")
                    display.Text = btn.Text;
                
            }
            else if (calculator.operation == Calculator.Operation.PLUS && AnPlusCount==1 )
            {
               calculator.saveFirstNumber(display.Text);
               numisnum = true;
               display.Text = btn.Text;
               ctn = 1;
               ccnt = 0;
               cnt = 0;
               pluscnt=2;
               
              
               
            }
          
            else if (calculator.operation == Calculator.Operation.SAVE)
            {
               
                display.Text = btn.Text;
                sctn = 1;
            }
            else if (calculator.operation == Calculator.Operation.MINUS)
            {
                calculator.saveFirstNumber(display.Text);
                display.Text = btn.Text;
                ctn = 2;
                ccnt = 0;
                cnt = 0;
            }
            else if (calculator.operation == Calculator.Operation.DIVIDED)
            {
                calculator.saveFirstNumber(display.Text);
                display.Text = btn.Text;
                ctn = 3;
                ccnt = 0;
                cnt = 0;
            }
            else if (calculator.operation == Calculator.Operation.TIMES)
            {
                calculator.saveFirstNumber(display.Text);
                display.Text = btn.Text;
                ctn = 4;
                ccnt = 0;
                cnt = 0;
            }

            calculator.operation = Calculator.Operation.NUMBER;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (calculator.operation == Calculator.Operation.PLUS && AnPlusCount>=2 )
            {
                Number += Number1;
                display.Text = (Number).ToString();
            }
          
            else
            { if (display.Text == "Cannot divide by zero")
            {
                display.Text = "0";
                EnableButtons();
            }
            if (numisnum) { 
                if (cnt == 0)
                    calculator.saveSecondNumber(display.Text);
                else
                    calculator.saveFirstNumber(display.Text);

               

                    switch (ctn)
                    {
                        case 1:
                            display.Text = calculator.getResultPlus().ToString();
                            cnt++;
                            equalpressed = true;
                            break;
                        case 2:
                            display.Text = calculator.getResultMinus().ToString();
                            cnt++;
                            equalpressed = true;
                            break;
                        case 3:
                            if (calculator.secondNumber == 0)
                            {
                                display.Text = "Cannot divide by zero";
                                DisableButtons();
                            }
                            else
                            {
                                display.Text = calculator.getResultDivided().ToString();
                                cnt++;
                                equalpressed = true;
                            }
                            break;
                        case 4:
                            display.Text = calculator.getResultTimes().ToString();
                            cnt++;
                            equalpressed = true;
                            break;


                    }
                 

                }
            }
            newlinecnt = 1;
            pluscnt = 0;

        }
       

        private void button11_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.PLUS;
            if (pluscnt  == 2)
            {
                display.Text = (double.Parse(display.Text) + calculator.firstNumber).ToString();
            }
            pluscnt = 1;
            if (AnPlusCount==1)
            {
                Number1 = (double.Parse(display.Text));
                Number =  (double.Parse(display.Text));
            }
            
           if (AnPlusCount==0)
             AnPlusCount=1;
           else if (calculator.operation == Calculator.Operation.PLUS && AnPlusCount == 1)
             AnPlusCount = 2;
           }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.MINUS;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (display.Text == "Cannot divide by zero")
            {
                display.Text = "0";
                EnableButtons();
            }
            if (calculator.firstNumber != 0)
            {
                display.Text = "0";
                calculator.secondNumber = 0;
                ccnt = 0;
            }
            else
            {
                display.Text = "0";
                calculator.firstNumber = 0;
                ccnt = 0;
            }

           
        }

        private void display_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button30_Click(object sender, EventArgs e)
        {

            /*  if (sctn == 0)
              {

                      }

              else
              {*/
        
              
                display.Text = (saved).ToString();
     
            // }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            display.Text = Math.Sqrt(double.Parse(display.Text)).ToString();
            equalpressed = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.TIMES;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.DIVIDED;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ccnt == 0)
            {
                display.Text += ",";
                ccnt=1;
            }
            else { }
           
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            display.Text = Math.Pow(double.Parse(display.Text),2).ToString();
            equalpressed = true;
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
            if (display.Text == "Cannot divide by zero")
            {
                display.Text = "0";
                EnableButtons();
            }
            display.Text = "0";
            ccnt = 0;
            calculator.firstNumber = 0;
            calculator.secondNumber = 0;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (equalpressed!=true)
            {
                percent = double.Parse(display.Text) / 100;
                calculator.saveSecondNumber((double.Parse(display.Text) / 100).ToString());
             
                percpressed = true;
            }
            else
            {
                switch (ctn)
                {
                    case 1:
                        display.Text = (double.Parse(display.Text) * (1 + percent)).ToString();
                        break;
                    case 2:
                        display.Text = (double.Parse(display.Text) * (1 - percent)).ToString();
                        break;
                    case 3:
                        display.Text = (double.Parse(display.Text) * (1 / percent)).ToString();
                        break;
                    case 4:
                        display.Text = (double.Parse(display.Text) * (1 * percent)).ToString();
                        break;
                }
            }
        }







        private void button14_Click(object sender, EventArgs e)
        {
            if (display.Text == "Cannot divide by zero")
            {
                display.Text = "0";
                EnableButtons();
            }
            if (display.Text.Length == 1||display.Text == "" ||display.Text=="0") 
            {
                display.Text = "0";
                  ccnt = 0;
                 } 
            
            else if (display.Text.Length > 1)
            { 
            display.Text = display.Text.Substring(0, display.Text.Length - 1);
                if (display.Text.Contains(",") != true)
                {
                    ccnt = 0; 
                }
            }
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            saved = 0;
             EnableButtons();
        }

        public void button27_Click(object sender, EventArgs e)
        {
            calculator.operation = Calculator.Operation.SAVE;
            saved = double.Parse(display.Text);
            EnableButtons();
        }

        private void button28_Click(object sender, EventArgs e)
        {
           
        saved -= double.Parse(display.Text);
        }

        private void button29_Click(object sender, EventArgs e)
        {
         
        saved += double.Parse(display.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            display.Text =( double.Parse(display.Text) *(-1)).ToString();
        }
 }
}
