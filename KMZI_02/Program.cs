using System;
using System.IO;
using Functions;

namespace KMZI_02 
{
    class Program
    {
        static void Main(string[] args)
        {
            char point;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("[---AFFINE CIPHER---]");
                Console.WriteLine("MENU");
                Console.Write("1 - file encryption\n2 - file decryption\n3 - exit\nSelect the option (press the proper number): ");
                point = Console.ReadKey().KeyChar;
                Console.Clear();
                if (point == '1' || point == '2' || point == '3')
                {
                    switch (point)
                    {
                        case '1':
                            Affine.Encryption();
                            Console.Clear();
                            break;
                        case '2':
                            Affine.Decryption();
                            Console.Clear();
                            break;
                        case '3':                            
                            flag = false;
                            break;
                    }
                }
                else Console.WriteLine("Input data is incorrect! You entered \'{0}\'", point);
            }
        }
    }
}
