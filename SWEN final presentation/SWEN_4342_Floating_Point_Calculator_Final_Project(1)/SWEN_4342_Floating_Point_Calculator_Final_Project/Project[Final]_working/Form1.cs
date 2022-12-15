using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _SWEN_4342__Floating_Point_Calculator__Final_Project_
{
     public partial class WindowTitle : Form
     {
          //strings contain the input the user entered after the type of calculation button is pressed (mul, add, sub, sign-exponent-mantissa)
          private string input1;
          private string input2;
          private string input3;
          private string input4;
          private string input5;
          private string input6;
          private string input7;
          private string input8;
          private string input9;
          private string input10;



          //window title is initialized and updated several times a second
          public WindowTitle()
          {
               InitializeComponent();
               //this line allows the program to check if a key is pressed (F10)
               this.KeyPreview = true;

            //PlayStartupSound();

            //message box will appear once the user opens the executable
            const string intro = "\nThis calculator will help you subtract, add, and multiply two numbers from any of the following numbers systems: " +
                   "decimal, hexadecimal, binary, and sign-exponent-mantissa. We recommend that you go over the documentation before jumping in. " +
                   "\n\n                           Thank you!";
               const string message = "Welcome to Team Euclids \"IEEE 754 Floating Point Calculator\" \n  " + intro;
               const string caption = "Euclid - IEEE 754 Floating Point Calculator";
               MessageBox.Show(message, caption);

               //changes text color and size at any point while running the application
              


             




              



               //Additional methods will help with additional requirements in the domains of accessability, visual design, etc.
               //supplementary methods below enable or show the images/loading bar the instant that the results are shown or there is an error







          }


          //These 2 methods update the text contents of the input text boxes 
          private void textBox1_TextChanged(object sender, EventArgs e)
          {
               input1 = textBox1.Text;
          }
          private void textBox2_TextChanged(object sender, EventArgs e)
          {
               input2 = textBox2.Text;
          }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            input3 = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            input4 = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            input5 = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            input6 = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            input7 = textBox7.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            input8 = textBox8.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            input9 = textBox9.Text;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            input10 = textBox10.Text;   
        }

        public void PlayStartupSound()
        {
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"SWEN_4342_Floating_Point_Calculator_Final_Project(1)\SWEN_4342_Floating_Point_Calculator_Final_Project\Project[Final]_working\sounds\8-bit.wav");
            //player.Play();
        }

        //https://stackoverflow.com/questions/20650954/how-to-convert-decimal-fractions-to-hexadecimal-fractions
        public static String DecimalToHexStr(String decimalStr) //returns a decimal string in HEX form 
          {

               Double value =  Math.Round(Convert.ToDouble(decimalStr), 7);
               String answerStr = "";

               string s = value.ToString();
               string[] parts = s.Split('.');
               int intValue = int.Parse(parts[0]);

                // Added an if statement, throwing error if value has no decimal places --CODY
                int fractionalValue = 0;
                if (value % 1 != 0)
                {
                    fractionalValue = int.Parse(parts[1]);
                }

               answerStr += intValue.ToString("X"); //integer part of the number is appended to the string that will be returned
               answerStr = answerStr + ".";


               // We have integer value in fact (e.g. 5.0)
               if (value == 0)
                    return "0.0";


               String doubleFractValue = "0." + fractionalValue.ToString();
               double fractionalValueDouble = Convert.ToDouble(doubleFractValue);
               // Double is 8 byte and so has at most 16 hexadecimal values
               for (int i = 0; i < 8; ++i)
               {
                    fractionalValueDouble = fractionalValueDouble * 16;
                    int digit = (int)fractionalValueDouble;
                    answerStr += digit.ToString("X");
                    fractionalValueDouble = fractionalValueDouble - digit;
                    if (value == 0)
                         break;
               }

              
               return answerStr.ToString();
          }


          //Methods/behaviours under this line will be responsible for converting between number systems interchangeably and conducting
          //the arithmetic operations (*, +, -) and display the sign exponent mantissa representation of the operations
          //*****************************************************************************************************************************************

          //Arithmetic operations are to be performed before converting to other number systems, i.e., before converting to binary and then to any
          //other number system after that


          //##########################################################################################################################################
          //##########################################################################################################################################
          //##########################################################################################################################################
          //methods below are responsible for the addition/multiplication/subtraction of the calculator***

          //Display the results in the appropiate label when the calculate button is pressed


          public void  sumDecimal(String one, String two)
          {
               //convert string to decimal values here 
               double result = Convert.ToDouble(one) + Convert.ToDouble(two);
               result = Math.Round(result, 7);
               String strResult = Convert.ToString(result);

            //display all the values in their correct fields


         




               DecimalAnswer.Text = strResult;

            if (result > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(strResult);
            }
            else
            {

                String posVal = Math.Abs(result).ToString();

                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }

            //str result is a decimal string 
            double textBoxFloat = double.Parse(strResult);
               textBoxFloat = Math.Round(textBoxFloat, 7);
         
               String decimalString = textBoxFloat.ToString(); //decimal of the form 'd*.ddddddd'


               //intValue, fractionalValue
               //input strings must contain '.' and 
               string s = decimalString;
               string[] parts = s.Split('.');
               int intValue = int.Parse(parts[0]);
                
                // Added an if statement, throwing error if value has no decimal places --CODY
                int fractionalValue = 0;
                if (textBoxFloat % 1 != 0)
                {
                    fractionalValue = int.Parse(parts[1]);
                }


            String wholeNumBinStr = "";
            if (intValue > 0)//positive
            {
                signBitSymbol.Text = "0";
                wholeNumBinStr = Convert.ToString(intValue, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                intValue = intValue * -1;
                wholeNumBinStr = Convert.ToString(intValue, 2);
                intValue = intValue * -1;
            }



             
               String fractionalValueStr = "0." + fractionalValue.ToString();
               double fractionalValueDouble = Convert.ToDouble(fractionalValueStr);


               String fractionalValueBinaryStr = ""; //append 0 or 1

               //Length is 7 bits
               for (int i = 0; i < fractionalValueStr.Length; i++)
               {
                    if (i == 0)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.5))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.5);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 1)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.25))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.25);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 2)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 3)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 4)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.03125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.03125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 5)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.015625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.015625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 6)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0078125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0078125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }

               }


               BinaryAnswer.Text = wholeNumBinStr + "." + fractionalValueBinaryStr;




          }

          public void  mulDecimal(String one, String two)
          {
               //convert string to decimal values here 
               double result = Convert.ToDouble(one) * Convert.ToDouble(two);
               String strResult = Convert.ToString(result);


               DecimalAnswer.Text = strResult;

            if (result > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(strResult);
            }
            else
            {

                String posVal = Math.Abs(result).ToString();

                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }

            //str result is a decimal string 
            double textBoxFloat = double.Parse(strResult);
               textBoxFloat = Math.Round(textBoxFloat, 7);

               String decimalString = textBoxFloat.ToString(); //decimal of the form 'd*.ddddddd'

               //intValue, fractionalValue
               //input strings must contain '.' and 
               string s = decimalString;
               string[] parts = s.Split('.');
               int intValue = int.Parse(parts[0]);

                // Added an if statement, throwing error if value has no decimal places --CODY
                int fractionalValue = 0;
                if (textBoxFloat % 1 != 0)
                {
                    fractionalValue = int.Parse(parts[1]);
                }

            String wholeNumBinStr = "";
            if (intValue > 0)//positive
            {
                signBitSymbol.Text = "0";
                wholeNumBinStr = Convert.ToString(intValue, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                intValue = intValue * -1;
                wholeNumBinStr = Convert.ToString(intValue, 2);
                intValue = intValue * -1;
            }



            String fractionalValueStr = "0." + fractionalValue.ToString();
               double fractionalValueDouble = Convert.ToDouble(fractionalValueStr);


               String fractionalValueBinaryStr = ""; //append 0 or 1

               //Length is 7 bits
               for (int i = 0; i < fractionalValueStr.Length; i++)
               {
                    if (i == 0)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.5))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.5);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 1)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.25))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.25);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 2)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 3)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 4)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.03125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.03125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 5)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.015625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.015625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 6)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0078125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0078125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }

               }


               BinaryAnswer.Text = wholeNumBinStr + "." + fractionalValueBinaryStr;




          }
          public void subDecimal(String one, String two)
          {
               //convert string to decimal values here 
               double result = Convert.ToDouble(one) - Convert.ToDouble(two);
               String strResult = Convert.ToString(Math.Round(result, 7));

              


               DecimalAnswer.Text = strResult;

               if (result > 0)
               {
                    HexadecimalAnswer.Text = DecimalToHexStr(strResult);
               }
               else
               {

                    String posVal = Math.Abs(result).ToString();

                    HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
               }


               
          
               //str result is a decimal string 
               double textBoxFloat = double.Parse(strResult);
               textBoxFloat = Math.Round(textBoxFloat, 7);

               String decimalString = textBoxFloat.ToString(); //decimal of the form 'd*.ddddddd'


               //intValue, fractionalValue
               //input strings must contain '.' and 
               string s = decimalString;
               string[] parts = s.Split('.');
               int intValue = int.Parse(parts[0]);
                
                // Added an if statement, throwing error if value has no decimal places --CODY
                int fractionalValue = 0;
                if (textBoxFloat % 1 != 0)
                {
                    fractionalValue = int.Parse(parts[1]);
                }


            String wholeNumBinStr = "";
            if (intValue > 0)//positive
            {
                signBitSymbol.Text = "0";
                wholeNumBinStr = Convert.ToString(intValue, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                intValue = intValue * -1;
                wholeNumBinStr = Convert.ToString(intValue, 2);
                intValue = intValue * -1;
            }

            String fractionalValueStr = "0." + fractionalValue.ToString();
               double fractionalValueDouble = Convert.ToDouble(fractionalValueStr);


               String fractionalValueBinaryStr = ""; //append 0 or 1

               //Length is 7 bits
               for (int i = 0; i < fractionalValueStr.Length; i++)
               {
                    if (i == 0)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.5))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.5);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 1)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.25))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.25);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 2)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 3)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 4)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.03125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.03125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 5)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.015625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.015625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 6)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0078125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0078125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }

               }


               BinaryAnswer.Text = wholeNumBinStr + "." + fractionalValueBinaryStr;

          }

          //##########################################################################################################################################
          //calculation methods for hexadecimal inputs

          private void sumHexadecimal()
          {


               int result = hexInDecimal1 + hexInDecimal2;

               DecimalAnswer.Text = result.ToString();//answer in decimal notation
             


            
            if (result > 0)//positive
            {
                signBitSymbol.Text = "0";
                BinaryAnswer.Text = Convert.ToString(result, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                result = result * -1;
                BinaryAnswer.Text = Convert.ToString(result, 2);
                result = result * -1;
            }






            if (result > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(Convert.ToString(result, 16));
            }
            else
            {

                String posVal = Math.Abs(result).ToString();

                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }



            //HexadecimalAnswer.Text = Convert.ToString(result, 16);//answer in hexadecimal

          }

          private void mulHexadecimal()
          {
                int result = hexInDecimal1 * hexInDecimal2;

                DecimalAnswer.Text = result.ToString();//answer in decimal notation

            if (result > 0)//positive
            {
                signBitSymbol.Text = "0";
                BinaryAnswer.Text = Convert.ToString(result, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                result = result * -1;
                BinaryAnswer.Text = Convert.ToString(result, 2);
                result = result * -1;
            }

            if (result > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(Convert.ToString(result, 16));
            }
            else
            {

                String posVal = Math.Abs(result).ToString();

                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }


            //HexadecimalAnswer.Text = Convert.ToString(result, 16);//answer in hexadecimal
        }

          private void subHexadecimal()
          {
            int result = hexInDecimal1 - hexInDecimal2;

            DecimalAnswer.Text = result.ToString();//answer in decimal notation

            if (result > 0)//positive
            {
                signBitSymbol.Text = "0";
                BinaryAnswer.Text = Convert.ToString(result, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                result = result * -1;
                BinaryAnswer.Text = Convert.ToString(result, 2);
                result = result * -1;
            }

            if (result > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(Convert.ToString(result, 16));
            }
            else
            {

                String posVal = Math.Abs(result).ToString();
                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }
            //HexadecimalAnswer.Text = Convert.ToString(result, 16);//answer in hexadecimal
        }

          //##########################################################################################################################################
          //calculation methods for binary inputs

          public void sumBinary(String one, String two)
          {
            

            int input1 = Convert.ToInt32(one, 2);
            int input2 = Convert.ToInt32(two, 2);

            int sumResult = input1 + input2;
            DecimalAnswer.Text = sumResult.ToString();

            //These values are whole numbers in binary form, convert binary to integer:

            if (sumResult > 0)//positive
            {
                signBitSymbol.Text = "0";
                BinaryAnswer.Text = Convert.ToString(sumResult, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                sumResult = sumResult * -1;
                BinaryAnswer.Text = Convert.ToString(sumResult, 2);
                sumResult = sumResult * -1;
            }



            if (sumResult > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(Convert.ToString(sumResult));
            }
            else
            {

                String posVal = Math.Abs(sumResult).ToString();

                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }






            //HexadecimalAnswer.Text = sumResult.ToString("X");
            //BinaryAnswer.Text = Convert.ToString(sumResult, 2);
               
               /*DecimalAnswer.Text = intAns;
               HexadecimalAnswer.Text = (Convert.ToInt32(intAns)).ToString("X");*/

            
        
               /*int from = 10;
               int to = 2;
               BinaryAnswer.Text = Convert.ToString(Convert.ToInt32(intAns, from), to);*/
          }//for some reason this doesnt work 

          public void mulBinary(String one, String two)
          {
            
       


            int input1 = Convert.ToInt32(one, 2);
            int input2 = Convert.ToInt32(two, 2);

            int sumResult = input1 * input2;

            DecimalAnswer.Text = Convert.ToString(sumResult);

            if (sumResult > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(Convert.ToString(sumResult, 16));
            }
            else
            {

                String posVal = Math.Abs(sumResult).ToString();

                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }


            //HexadecimalAnswer.Text = sumResult.ToString("X");
            //BinaryAnswer.Text = Convert.ToString(sumResult, 2);
            if (sumResult > 0)//positive
            {
                signBitSymbol.Text = "0";
                BinaryAnswer.Text = Convert.ToString(sumResult, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                sumResult = sumResult * -1;
                BinaryAnswer.Text = Convert.ToString(sumResult, 2);
                sumResult = sumResult * -1;
            }

        }

          public void subBinary(String one, String two)
          {
            int input1 = Convert.ToInt32(one, 2);
            int input2 = Convert.ToInt32(two, 2);

            int sumResult = input1 - input2;

            DecimalAnswer.Text = Convert.ToString(sumResult);
            //HexadecimalAnswer.Text = sumResult.ToString("X");
            if (sumResult > 0)
            {
                HexadecimalAnswer.Text = DecimalToHexStr(Convert.ToString(sumResult, 16));
            }
            else
            {

                String posVal = Math.Abs(sumResult).ToString();

                HexadecimalAnswer.Text = "-" + DecimalToHexStr(posVal).ToString();
            }




            //BinaryAnswer.Text = Convert.ToString(sumResult, 2);
            if (sumResult > 0)//positive
            {
                signBitSymbol.Text = "0";
                BinaryAnswer.Text = Convert.ToString(sumResult, 2);
            }
            else
            {
                signBitSymbol.Text = "1";//negative
                sumResult = sumResult * -1;
                BinaryAnswer.Text = Convert.ToString(sumResult, 2);
                sumResult = sumResult * -1;
            }
        }

        public void sumSEM()
        {
            double result1 = binSEMToDecSEM(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            double result2 = binSEMToDecSEM(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text);

            double wholeResult = result1 + result2;

            decSEMToBinSEM(wholeResult);

            DecimalAnswer.Text = Convert.ToString(wholeResult);
            /*HexadecimalAnswer.Text = wholeResult.ToString("X");*/
            
        }

        public void mulSEM()
        {
            double result1 = binSEMToDecSEM(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            double result2 = binSEMToDecSEM(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text);

            double wholeResult = result1 * result2;

            decSEMToBinSEM(wholeResult);

            DecimalAnswer.Text = Convert.ToString(wholeResult);
            /*HexadecimalAnswer.Text = wholeResult.ToString("X");*/
        }

        public void subSEM()
        {
            //save binary inputs 



            double result1 = binSEMToDecSEM(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            double result2 = binSEMToDecSEM(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text);

            double wholeResult = result1 - result2;

            decSEMToBinSEM(wholeResult);

            DecimalAnswer.Text = Convert.ToString(wholeResult);
            /*HexadecimalAnswer.Text = wholeResult.ToString("X");*/





















        }

        public double binSEMToDecSEM(string signStr, string expStr, string manIntStr, string manFractStr)
        {
            if (textBox3.Text.Length != 1)
            {//sign
                const string message = "Please make sure that the amount of bits labeled at the bottom of the input fields (sign) is the same as your inputs";
                const string caption = "Error Code 04";
                MessageBox.Show(message, caption);
            }

            if (textBox4.Text.Length != 4)
            {//exponent
                const string message = "Please make sure that the amount of bits labeled at the bottom of the input fields (exponent) is the same as your inputs";
                const string caption = "Error Code 05";
                MessageBox.Show(message, caption);
            }

            if (textBox5.Text.Length != 8)
            {//matissa (int)
                const string message = "Please make sure that the amount of bits labeled at the bottom of the input fields (mantissa int) is the same as your inputs";
                const string caption = "Error Code 06";
                MessageBox.Show(message, caption);
            }

            if (textBox6.Text.Length != 7)
            {//mantissa (fractional)
                const string message = "Please make sure that the amount of bits labeled at the bottom of the input fields (mantissa fractional component) is the same as your inputs";
                const string caption = "Error Code 07";
                MessageBox.Show(message, caption);
            }

            int exp = Convert.ToInt32(expStr, 2);

            double manInt = Convert.ToInt32(manIntStr, 2);

            double fracDec = 0;

            double twos = 2;

            int sign = Convert.ToInt32(signStr);

            for (int i = 0; i < manFractStr.Length; i++)
            {
                fracDec += (manFractStr[i] - '0') / twos;
                twos *= 2.0;
            }

            double result = manInt + fracDec;

            for (int i = 0; i < Math.Abs(exp); i++)
            {
                if (exp > 0)
                {
                    result = (result * 10);
                }
                else if (exp < 0)
                {
                    result = (result / 10);
                }
            }

            if (sign == 0)
            {
                result = result * 1;

            }
            else if (sign == 1)
            {
                result = result * -1;
            }

            return result;
        }

        public void decSEMToBinSEM(double num)
        {
            int k_prec = 7;

            String binary = "";

            // Fetch the integral part of decimal number
            int Integral = (int)num;

            // Fetch the fractional part decimal number
            double fractional = num - Integral;

            // Conversion of integral part to
            // binary equivalent
            while (Integral > 0)
            {
                int rem = Integral % 2;

                // Append 0 in binary
                binary += ((char)(rem + '0'));

                Integral /= 2;
            }

            // Reverse string to get original binary
            // equivalent
            binary = reverse(binary);

            // Append point before conversion of
            // fractional part
            binary += ('.');

            // Conversion of fractional part to
            // binary equivalent
            while (k_prec-- > 0)
            {
                // Find next bit in fraction
                fractional *= 2;
                int fract_bit = (int)fractional;

                if (fract_bit == 1)
                {
                    fractional -= fract_bit;
                    binary += (char)(1 + '0');
                }
                else
                {
                    binary += (char)(0 + '0');
                }
            }


        }

        public String reverse(String input)
        {
            char[] temparray = input.ToCharArray();
            int left, right = 0;
            right = temparray.Length - 1;

            for (left = 0; left < right; left++, right--)
            {
                // Swap values of left and right
                char temp = temparray[left];
                temparray[left] = temparray[right];
                temparray[right] = temp;
            }
            return String.Join("", temparray);
        }






        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################

        //These methods will define what actions will be performed once each button it pressed, basically doin the math***


        //method invoked if "add" is chosen:

        //method invoked if "subtract" is chosen:

        //method invoked if "multiplication" is chosen:

        //method invoked if "sign exponent mantissa" is chosen: [text box string contents are converted to floating point values]








        //##########################################################################################################################################
        //##########################################################################################################################################
        //##########################################################################################################################################
        //The methods below will convert from all other number systems other than binary into binary. We need these methods so that we can have a 
        //universal number system from which we can convert to any other***



        public static int hexInDecimal1;
          public static int hexInDecimal2;

          public int HexToDecimal(String input)
          {
               //Hexadecimal  0    1    2    3    4    5    6    7    8    9    A    B    C    D    E    F
               //Decimal 	0 	1 	2 	3 	4 	5 	6 	7 	8 	9 	10 	11 	12 	13 	14 	15

               int hexInBinStr = Convert.ToInt32(input, 16);

               return hexInBinStr;

               // resultAnswerLabel.Text = hexInBinStrOne;

          }



          //reference to algorithm that converts decimal to binary: https://www.log2base2.com/number-system/float-to-binary-conversion.html
          //A float has 7 decimal digits of precision and occupies 32 bits
          private void DecimalToBinary(String input)
          {
               double textBoxFloat = double.Parse(input);
               textBoxFloat = Math.Round(textBoxFloat, 7);
               //3456782.1234534636 -> 3456782.1234534
               //34.12 -> 34.12
               //033 -> 33



               HexadecimalAnswer.Text = textBoxFloat.ToString(); //used to check what this prints

              
               String decimalString = (System.Math.Round(float.Parse(input1), 7)).ToString();


               Decimal inputDecimal1 = Convert.ToDecimal(input1);

               //string binary = Convert.ToString(inputDecimal1, 2);

               //intValue, fractionalValue
               //input strings must contain '.' and 
               string s = textBoxFloat.ToString();
               string[] parts = s.Split('.');
               int intValue = int.Parse(parts[0]);
               int fractionalValue = int.Parse(parts[1]);

               DecimalAnswer.Text = Convert.ToString(intValue, 2);




               String fractionalValueStr = "0." + fractionalValue.ToString();
               double fractionalValueDouble = Convert.ToDouble(fractionalValueStr);


               String fractionalValueBinaryStr = "";

               //Length is 7 bits
               for (int i = 0; i < fractionalValueStr.Length; i++)
               {
                    if (i == 0)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.5))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.5);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 1)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.25))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.25);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 2)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 3)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 4)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.03125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.03125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 5)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.015625))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.015625);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }
                    else if (i == 6)
                    {
                         //7 bits: 1/2, 1/4, 1/8, 1/16, 1/32, 1/64, 1/128
                         if (fractionalValueDouble >= (0.0078125))
                         {
                              fractionalValueBinaryStr += "1";
                              fractionalValueDouble = fractionalValueDouble - (0.0078125);
                         }
                         else
                         {
                              fractionalValueBinaryStr += "0";
                         }

                    }

                    BinaryAnswer.Text = fractionalValueBinaryStr;


               }

          }


       









          //##########################################################################################################################################
          //##########################################################################################################################################
          //##########################################################################################################################################

          //Once the user chooses an operation to conduct on the two numbers inputed, all number systems will be displayed on the left 
          //part of the user interface, the code after this line will display the results in all number systems***

          //$ = sign, exponent, mantissa
          //generate methods that will convert from any number system (binary, decimal, hex, & $) to a universal number system (binary) from which we can convert to a target
          //number system (binary, decimal, hex).

          private void BinaryToBinary(String input)
          {

          }

          private void BinaryToDecimal(String input)
          {

          }
          private void BinaryToHex(String input)
          {

          }

          /* This comment explains how we chose to use the bits that represent the sign-exponent-mantissa represenation of the operation result
          We need 7 digits from the fractional component of the mantissa to attain precision of up to '.99' 
          sign  exponent 		mantisaa(8 + 7)

          1 		1111 		 (11111111) '.' (1111111) (7 digits)
                                                   (1/2),(1/4),(1/8),(1/16),(1/32),(1/64),(1/128) (Fractional values add up to 0.99)

                    4 bits range(0-15) The exponent needs 4 bits to define where the decimal can be placed throughout the 15 total bits that make up the mantissa  
           */

          private static void BinaryTosignExponentMantissa(String input)
          {

          }

          //##########################################################################################################################################
          //##########################################################################################################################################
          //##########################################################################################################################################


          //example code, code playground, remove when useless:










          //##########################################################################################################################################
          //##########################################################################################################################################
          //##########################################################################################################################################



          public void LargeTextLabel_CheckedChanged(object sender, EventArgs e)
          {
               Font f = new Font("Arial", 10, FontStyle.Bold);
               Font t = new Font("Segoe UI", 9, FontStyle.Regular);
               if (LargeTextLabel.Checked)
               {
                   

                    DecimalAnswer.Font = f;
                    resultsLabel.Font = f;
                    resultAnswerLabel.Font = f;
                    DecimalAnswerLabel.Font = f;
                    DecimalAnswer.Font = f;
                    HexadecimalAnswerLabel.Font = f;
                    HexadecimalAnswer.Font = f;
                    BinaryAnswerLabel.Font = f;
                    BinaryAnswer.Font = f;
                    signLabel.Font = f;
                    exponentLabel.Font = f;
                    mantissaLabel.Font = f;
                    signAnswer.Font = f;
                    exponentAnswer.Font = f;
                    mantissaAnswer.Font = f;
                    CompanyLabel.Font = f;
                    title.Font = f;
                    documentationLabel.Font = f;

                    AccesabilityOptionsLabel.Font = f;
                    LargeTextLabel.Font = f;
                    HighContrastLabel.Font = f;
                    linkLabel1.Font = f;
                    InputOneLabel.Font = f;
                    InputTwoLabel.Font = f;
                    calcButton.Font = f;
                    groupBox1.Font = f;
                    groupBox2.Font = f;
                    label9.Font = f;
                    label12.Font = f;
                    label13.Font = f;
                    label14.Font = f; 
                    label10.Font = f;
                    label11.Font = f;
                    label15.Font = f;
                    label5.Font = f;
                    label2.Font = f;
                    label3.Font = f;
                    label4.Font = f;

                    label7.Font = f;
                    label6.Font = f;

                    textBox1.Font = f;
                    textBox2.Font = f;
                    textBox3.Font = f;
                    textBox4.Font = f;
                    textBox5.Font = f;
                    textBox9.Font = f;
                    textBox8.Font = f;
                    textBox7.Font = f;
                    textBox6.Font = f;
                    textBox10.Font = f;

                    signBitLabel.Font = f;
                    signBitSymbol.Font = f;

                semBinRb.Font = f;
                semHexRb.Font = f;
                groupBox3.Font = f;



               }
               else
               {
                    DecimalAnswer.Font = t;
                    resultsLabel.Font = t;
                    resultAnswerLabel.Font = t;
                    DecimalAnswerLabel.Font = t;
                    DecimalAnswer.Font = t;
                    HexadecimalAnswerLabel.Font = t;
                    HexadecimalAnswer.Font = t;
                    BinaryAnswerLabel.Font = t;
                    BinaryAnswer.Font = t;
                    signLabel.Font = t;
                    exponentLabel.Font = t;
                    mantissaLabel.Font = t;
                    signAnswer.Font = t;
                    exponentAnswer.Font = t;
                    mantissaAnswer.Font = t;
                    CompanyLabel.Font = t;
                    title.Font = t;
                    documentationLabel.Font = t;

                    AccesabilityOptionsLabel.Font = t;
                    LargeTextLabel.Font = t;
                    HighContrastLabel.Font = t;
                    linkLabel1.Font = t;
                    InputOneLabel.Font = t;
                    InputTwoLabel.Font = t;
                    calcButton.Font = t;
                    groupBox1.Font = t;
                    groupBox2.Font = t;
                    label9.Font = t;
                    label12.Font = t;
                    label13.Font = t;
                    label14.Font = t;
                    label10.Font = t;
                    label11.Font = t;
                    label15.Font = t;
                    label5.Font = t;
                    label2.Font = t;
                    label3.Font = t;
                    label4.Font = t;

                    label7.Font = t;
                    label6.Font = t;

                    textBox1.Font = t;
                    textBox2.Font = t;
                    textBox3.Font = t;
                    textBox4.Font = t;
                    textBox5.Font = t;
                    textBox9.Font = t;
                    textBox8.Font = t;
                    textBox7.Font = t;
                    textBox6.Font = t;
                    textBox10.Font = t;

                    signBitLabel.Font = t;
                    signBitSymbol.Font = t;

                semBinRb.Font = t;
                semHexRb.Font = t;
                groupBox3.Font = t;
            }
          }

          public void HighContrastLabel_CheckedChanged(object sender, EventArgs e)
          {
               //https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.colors?view=windowsdesktop-7.0
               Color u = Color.DeepPink; //font color
               Color i = Color.MidnightBlue; //background color high contrast

               Color b = Color.Black; //default font color 
               Color t = Color.DodgerBlue;



               if (HighContrastLabel.Checked)
               {
                    this.BackColor = i;

                    DecimalAnswer.ForeColor = u;
                    resultsLabel.ForeColor = u;
                    resultAnswerLabel.ForeColor = u;
                    DecimalAnswerLabel.ForeColor = u;
                    DecimalAnswer.ForeColor = u;
                    HexadecimalAnswerLabel.ForeColor = u;
                    HexadecimalAnswer.ForeColor = u;
                    BinaryAnswerLabel.ForeColor = u;
                    BinaryAnswer.ForeColor = u;
                    signLabel.ForeColor = u;
                    exponentLabel.ForeColor = u;
                    mantissaLabel.ForeColor = u;
                    signAnswer.ForeColor = u;
                    exponentAnswer.ForeColor = u;
                    mantissaAnswer.ForeColor = u;
                    CompanyLabel.ForeColor = u;
                    title.ForeColor = u;
                    documentationLabel.ForeColor = u;

                    AccesabilityOptionsLabel.ForeColor = u;
                    LargeTextLabel.ForeColor = u;
                    HighContrastLabel.ForeColor = u;
                    linkLabel1.ForeColor = u;
                    InputOneLabel.ForeColor = u;
                    InputTwoLabel.ForeColor = u;
                    calcButton.ForeColor = u;
                    groupBox1.ForeColor = u;
                    groupBox2.ForeColor = u;
                    label9.ForeColor = u;
                    label12.ForeColor = u;
                    label13.ForeColor = u;
                    label14.ForeColor = u;
                    label10.ForeColor = u;
                    label11.ForeColor = u;
                    label15.ForeColor = u;
                    label5.ForeColor = u;
                    label2.ForeColor = u;
                    label3.ForeColor = u;
                    label4.ForeColor = u;

                    label7.ForeColor = u;
                    label6.ForeColor = u;

                    textBox1.ForeColor = u;
                    textBox2.ForeColor = u;
                    textBox3.ForeColor = u;
                    textBox4.ForeColor = u;
                    textBox5.ForeColor = u;
                    textBox9.ForeColor = u;
                    textBox8.ForeColor = u;
                    textBox7.ForeColor = u;
                    textBox6.ForeColor = u;
                    textBox10.ForeColor = u;

                    signBitLabel.ForeColor = u;
                    signBitSymbol.ForeColor = u;

                semBinRb.ForeColor = u;
                semHexRb.ForeColor = u;
                groupBox3.ForeColor = u;
            }
               else
               {
                    this.BackColor = t;

                    DecimalAnswer.ForeColor = b;
                    resultsLabel.ForeColor = b;
                    resultAnswerLabel.ForeColor = b;
                    DecimalAnswerLabel.ForeColor = b;
                    DecimalAnswer.ForeColor = b;
                    HexadecimalAnswerLabel.ForeColor = b;
                    HexadecimalAnswer.ForeColor = b;
                    BinaryAnswerLabel.ForeColor = b;
                    BinaryAnswer.ForeColor = b;
                    signLabel.ForeColor = b;
                    exponentLabel.ForeColor = b;
                    mantissaLabel.ForeColor = b;
                    signAnswer.ForeColor = b;
                    exponentAnswer.ForeColor = b;
                    mantissaAnswer.ForeColor = b;
                    CompanyLabel.ForeColor = b;
                    title.ForeColor = b;
                    documentationLabel.ForeColor = b;

                    AccesabilityOptionsLabel.ForeColor = b;
                    LargeTextLabel.ForeColor = b;
                    HighContrastLabel.ForeColor = b;
                    linkLabel1.ForeColor = b;
                    InputOneLabel.ForeColor = b;
                    InputTwoLabel.ForeColor = b;
                    calcButton.ForeColor = b;
                    groupBox1.ForeColor = b;
                    groupBox2.ForeColor = b;
                    label9.ForeColor = b;
                    label12.ForeColor = b;
                    label13.ForeColor = b;
                    label14.ForeColor = b;
                    label10.ForeColor = b;
                    label11.ForeColor = b;
                    label15.ForeColor = b;
                    label5.ForeColor = b;
                    label2.ForeColor = b;
                    label3.ForeColor = b;
                    label4.ForeColor = b;

                    label7.ForeColor = b;
                    label6.ForeColor = b;

                    textBox1.ForeColor = b;
                    textBox2.ForeColor = b;
                    textBox3.ForeColor = b;
                    textBox4.ForeColor = b;
                    textBox5.ForeColor = b;
                    textBox9.ForeColor = b;
                    textBox8.ForeColor = b;
                    textBox7.ForeColor = b;
                    textBox6.ForeColor = b;
                    textBox10.ForeColor = b;

                    signBitLabel.ForeColor = b;
                    signBitSymbol.ForeColor = b;

                semBinRb.ForeColor = b;
                semHexRb.ForeColor = b;
                groupBox3.ForeColor = b;

            }






















          }


          //if at any point the user presses 'F10', then the documentation will appear. *This code doesn't work, not sure why
          private void WindowTitle_KeyDown(object sender, KeyEventArgs e)
          {
               KeyPreview = true;
               if (e.KeyCode == Keys.F10 || e.KeyValue == (char)Keys.F10)
               {
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"SWEN_4342_Floating_Point_Calculator_Final_Project(1)\SWEN_4342_Floating_Point_Calculator_Final_Project\Project[Final]_working\sounds\Tada-sound.wav");
                //player.Play();
                const string pgOnePartOne = "This is a tutorial for the calculator, the following pages will go over features, controls, and proper data entry syntax." +
                        " Press F1-F5 after pressing \"OK\" to bring up the different pages. Press the link at the top right of the window to get more information on " +
                        "the IEEE 754 technical standard!";
                const string options = "\n\n Documentation Pages: F1(Basic Use), F2(Syntax), F3(Sign Exponent Mantissa Calculations), F4(Accessability Settings), F5(Errors)";
                    const string message = pgOnePartOne + options;
                    const string caption = "Welcome to the Documentation!";
                    DialogResult doc = MessageBox.Show(message, caption);

                
            }

               if (e.KeyCode == Keys.F1)
               {
                    const string pgOnePartOne = "\nEnter 2 valid values in text box 1 & 2, the values must be provided in the same number system. " +
                        "Choose an input number system, and calculation type. Finally, press \"Calculate!\" to convert the answer to all aformentioned number systems. " +
                        "All the number systems except sign-exponent-mantissa will be displayed instanteneously on the left.";
                    const string pgOnePartTwo = "\n If the sign-exponent-mantissa radio button is selected, only the sign-exponent-mantissa answer fields will appear. Input your values in sign-exponent-mantissa form in the bottom left corner." +
                        "";
                    const string message = pgOnePartOne + "\n" + pgOnePartTwo;
                    const string caption = "Basic Use (1/5)";
                    DialogResult doc = MessageBox.Show(message, caption);
               }

               if (e.KeyCode == Keys.F2)
               {
                    const string pgOnePartOne = "The only input number system that allows fractional values is decimal. You can get fractional hex and binary values in return " +
                    "if your answers contain a fractional component. \n\nYou may sometimes get negative numbers in your calculations but you may not use the \"-\" symbol when " +
                    "inputing values. If you want to convert a single number in any number system to the others, enter \"0\" in the same input number system as the first input and \"+\" or \"-\" it.";
                    const string message = pgOnePartOne;
                    const string caption = "Syntax (2/5)";
                    DialogResult doc = MessageBox.Show(message, caption);
               }

               if (e.KeyCode == Keys.F3)
            {
                const string pgOnePartOne = "You must enter the inputs in binary form. The number of digits for each set of values must be the same as what is labeled as below" +
                    "the corresponding text boxes. The results can be represented in binary or hexadecimal form via it's appropiate checkbox.";
                const string message = pgOnePartOne;
                const string caption = "Sign Exponent Mantissa (3/5)";
                DialogResult doc = MessageBox.Show(message, caption);
            }

            if (e.KeyCode == Keys.F4)
            {
                const string pgOnePartOne = "Select the \"Large Text\" checkbox to make the user interface text larger and attain a bold style. Select the \"High Contrast\" checkbox to make the user interface text " +
                    "change to bright pink color and change the background color to a dark blue color.";
                const string message = pgOnePartOne;
                const string caption = "Accessability Settings (4/5)";
                DialogResult doc = MessageBox.Show(message, caption);
            }

            if (e.KeyCode == Keys.F5)
            {
                const string pgOnePartOne = "You may receive an error if you dont enter the values in the appropiate number system. Try again and make sure the correct " +
                    "radio buttons are selected. ";
                const string message = pgOnePartOne;
                const string caption = "Errors (5/5)";
                DialogResult doc = MessageBox.Show(message, caption);
            }

            if (e.KeyCode == Keys.F7)
            {
                const string pgOnePartOne = "Congratulations, I guess...";
                const string message = pgOnePartOne;
                const string caption = "You found an easter egg, hehe";
                DialogResult doc = MessageBox.Show(message, caption);
            }




        }



          //this method will start the calculations, here I will implement event handling as well
          private void calcButton_Click(object sender, EventArgs e){
               //This logic checks to see if the input text boxes are empty, throws error if so
               if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
               {
                    const string message = "\"One or more of your input fields are null, please enter appropiate value(s) and try again!\"";
                    const string caption = "Error Code 01";
                    MessageBox.Show(message, caption);
               }



            if (signExpManRb.Checked)
            {
                signLabel.Visible = true;
                exponentLabel.Visible = true;
                mantissaLabel.Visible = true;

                signAnswer.Visible = true;
                exponentAnswer.Visible = true;
                mantissaAnswer.Visible = true;

                DecimalAnswerLabel.Visible = false;
                DecimalAnswer.Visible = false;
                HexadecimalAnswerLabel.Visible = false;
                HexadecimalAnswer.Visible = false;
                BinaryAnswerLabel.Visible = false;
                signBitLabel.Visible = false;
                signBitSymbol.Visible=false;
                BinaryAnswer.Visible = false;



            }
            else
            {
                signLabel.Visible = false;
                exponentLabel.Visible = false;
                mantissaLabel.Visible = false;

                signAnswer.Visible = false;
                exponentAnswer.Visible = false;
                mantissaAnswer.Visible = false;

                DecimalAnswerLabel.Visible = true;
                DecimalAnswer.Visible = true;
                HexadecimalAnswerLabel.Visible = true;
                HexadecimalAnswer.Visible = true;
                BinaryAnswerLabel.Visible = true;
                signBitLabel.Visible = true;
                signBitSymbol.Visible = true;
                BinaryAnswer.Visible = true;


            }





               //Atleast one of these radio buttons must be selected for the program to run. This tells us which number system the user is inputing the values in

               //At this point, make sure the inputs from box text boxes are converted to binary/decimal from which the math operations will be easier to do in. These values will be
               //assigned to 2 distinct 'global' variables (Strings) from which we can call the math methods. Ex: if DecimalRadioButton is checked, convert input1 & input2 to binary and
               //save in decimalAsBinaryStr1 & decimalAsBinaryStr2 to be used later in mulRb.Checked, addRb.Checked, etc.




               //Atleast one of these radio buttons must be selected for the program to run. 

               if (mulRb.Checked)
               {

                    if (DecimalRadioButton.Checked)
                    {
                         mulDecimal(input1, input2);
                    }
                    else if (HexadecimalRadioButton.Checked)
                    {
                         hexInDecimal1 = HexToDecimal(input1);
                         hexInDecimal2 = HexToDecimal(input2);
                         mulHexadecimal();
                    }
                    else if (BinaryRadioButton.Checked)
                    {
                        mulBinary(input1, input2);
                    }
                    else if (signExpManRb.Checked)
                    {
                        mulSEM();
                    }
                    else if (!DecimalRadioButton.Checked && !HexadecimalRadioButton.Checked && !BinaryRadioButton.Checked && !signExpManRb.Checked)
                    {
                         const string message = "\"Please select the decimal, hexadecimal, binary, or sign-exponent-mantissa radio button.\"";
                         const string caption = "Error Code 02";
                         MessageBox.Show(message, caption);
                    }

               }
               
               
               
               
               if (addRb.Checked)
               {
                    if (DecimalRadioButton.Checked) //done!
                    {
                         sumDecimal(input1, input2);
                    }
                    else if (HexadecimalRadioButton.Checked)//done!
                    {
                         hexInDecimal1 = HexToDecimal(input1);
                         hexInDecimal2 = HexToDecimal(input2);
                         sumHexadecimal();
                    }
                    else if (BinaryRadioButton.Checked)
                    {
                         sumBinary(input1, input2);
                    }
                    else if (signExpManRb.Checked)
                    {
                        sumSEM();
                    }
                    else if (!DecimalRadioButton.Checked && !HexadecimalRadioButton.Checked && !BinaryRadioButton.Checked && !signExpManRb.Checked)
                    {
                         const string message = "\"Please select the decimal, hexadecimal, binary, or sign-exponent-mantissa radio button.\"";
                         const string caption = "Error Code 02";
                         MessageBox.Show(message, caption);
                    }

               }
               
               
               
               if (subRb.Checked)
               {
                    if (DecimalRadioButton.Checked)
                    {
                         subDecimal(input1, input2);
                    }
                    else if (HexadecimalRadioButton.Checked)
                    {
                        hexInDecimal1 = HexToDecimal(input1);
                        hexInDecimal2 = HexToDecimal(input2);
                        subHexadecimal();
                    }
                    else if (BinaryRadioButton.Checked)
                    {
                        subBinary(input1, input2);
                    }
                    else if (signExpManRb.Checked)
                    {
                        subSEM();
                    }
                    else if (!DecimalRadioButton.Checked && !HexadecimalRadioButton.Checked && !BinaryRadioButton.Checked && !signExpManRb.Checked)
                    {
                         const string message = "\"Please select the decimal, hexadecimal, binary, or sign-exponent-mantissa radio button.\"";
                         const string caption = "Error Code 02";
                         MessageBox.Show(message, caption);
                    }
               }

               
               
               
               if (!mulRb.Checked && !addRb.Checked && !subRb.Checked)
               {
                    const string message = "\"Please select arithmetic operation (*, +, -) before pressing \"Calculate!\"\"";
                    const string caption = "Error Code 03";
                    MessageBox.Show(message, caption);
               }

          }



          //removes the values in the answers label so that they may be replaced by new answers one the calculate button has been pressed agan.
          public void removeAnswers(object sender, LinkLabelLinkClickedEventArgs e)
          {

          }


          //Allows for the link in the window to be clickable
          private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               Process.Start(new ProcessStartInfo { FileName = @"https://www.wikiwand.com/en/IEEE_754", UseShellExecute = true });
               //Process.Start(new ProcessStartInfo { FileName = @"C:\", UseShellExecute = true });
          }

        
        }

     }


