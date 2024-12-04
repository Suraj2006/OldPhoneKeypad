using System;
using System.Numerics;

public class Program
{
    //EntryPoint
    public static void Main()
    {
        #region TESTCASES 
        string output1 = OldPhonePad("33#");   //Expected output:E
        Console.WriteLine("OldPhonePad(“33#”) => output: " + output1);

        string output2 = OldPhonePad("227*#"); // Expected output:B
        Console.WriteLine("OldPhonePad(227*#)=>output: " + output2);

        string output3 = OldPhonePad("4433555 555666#"); // Expected output:HELLO
        Console.WriteLine("OldPhonePad(4433555 555666#)=>output: " + output3);

        string output4 = OldPhonePad("8 88777444666*664#"); //Expected output:TURING
        Console.WriteLine("OldPhonePad(8 88777444666*664#)=>output: " + output4);

        #endregion
    }

    public static string[] keypad = new string[] { "", "", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };


    public static string OldPhonePad(string numberInput)
    {
        if (numberInput.EndsWith("#"))
        {
            numberInput = numberInput.Substring(0, numberInput.Length - 1);
        }

        string outputWord = "";
        int n = 0;

        while (n < numberInput.Length)
        {
            char currentChar = numberInput[n];

            if (currentChar == '*')
            {
                // Remove the last character from the outputWord 
                if (outputWord.Length > 0)
                {
                    outputWord = outputWord.Substring(0, outputWord.Length - 1);
                }
                n++;
                continue;
            }

            int key = currentChar - '0'; // Convert character to number

            // Check how many times the key is pressed consecutively
            int pressCount = 1;
            while (n + 1 < numberInput.Length && numberInput[n + 1] == currentChar)
            {
                pressCount++;
                n++;
            }

            // Find the corresponding character for the key and press count
            if (key >= 2 && key <= 9)
            {
                string chars = keypad[key];
                outputWord += chars[(pressCount - 1) % chars.Length];
            }

            n++;
        }

        return outputWord;
    }
}
