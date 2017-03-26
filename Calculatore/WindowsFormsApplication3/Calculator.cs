using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class Calculator
    {
        public enum Operation {
            NONE, 
            NUMBER, 
            PLUS, 
            MINUS, 
            EQUAL,
            SAVE,
            TIMES,
            DIVIDED,
            MMINUS,
            MPLUS,
            MREAD
        };
        public Operation operation;
        public double firstNumber, secondNumber;

        public Calculator()
        {
            operation = Operation.NONE;

            firstNumber = 0;
            secondNumber = 0;
        }

        public void saveFirstNumber(string s)
        {
            firstNumber = double.Parse(s);
        }
        public string DeleteLastCharacter(string word) {
            string word1 = "";
            for (int i = 0; i < word.Length - 1; i++)
                      word1 += word[i];
            return word1;
        
        }
        public void saveSecondNumber(string s)
        {
            secondNumber = double.Parse(s);
        }

        public double getResultPlus()
        {
           
            return firstNumber + secondNumber;
        }
        public double getResultMinus()
        {
            return firstNumber - secondNumber;
        }
        public double getResultDivided()
        {
            return firstNumber / secondNumber;
        }
        public double getResultTimes()
        {
            return firstNumber * secondNumber;
        }
       

    }
}
