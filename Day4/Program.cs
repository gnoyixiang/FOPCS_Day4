using System;

namespace Bank
{
    class Quiz
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Bank of ISS");
            string pin = "123456";
            int count = 0;
            bool correct = true;
            do
            {
                if (count >= 3)
                {
                    correct = false;
                    break;
                }
                if (count > 0) Console.WriteLine("Incorrect PIN. Please try again");
                Console.Write("Enter your PIN: ");
                count++;
            } while (Console.ReadLine() != pin);
            if (correct) Console.WriteLine("PIN accepted. You can access your account now.");
            else Console.WriteLine("Too many wrong entries. Your account is now locked.");
        }
        
        
    }
}