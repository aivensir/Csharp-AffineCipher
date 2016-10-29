using System;
using System.IO;

namespace Functions
{
    public static class Affine
    {
        private static string filename;
        private static byte a = 0, b = 0;
        private static int m = 256;        
        public static void Encryption()
        {
            do
            {
                Console.Write("Enter the file name to encrypt (with extension): ");
                filename = Console.ReadLine();
                if (!File.Exists(filename)) Console.WriteLine("File not found. Try again!");
            } while (!File.Exists(filename));

            Byte[] M = File.ReadAllBytes(filename);
            a = 21; b = 57;//variant 9            
            for (int i = 0; i < M.Length; i++) { M[i] = (byte)((a * M[i] + b) % m); }
            File.WriteAllBytes(filename, M);
        }
        public static void Decryption()
        {
            do
            {
                Console.Write("Enter the file name to decrypt (with extension): ");
                filename = Console.ReadLine();
                if (!File.Exists(filename)) Console.WriteLine("File not found. Try again!");
            } while (!File.Exists(filename));

            Byte[] C = File.ReadAllBytes(filename);
            a = 21; b = 57;//variant 9
            int obr_a  = 0;
            int x, y;
            EuclidAdvanced(a, m, out x, out y);
            if (x > -1) obr_a = x;
            else if (y > -1) obr_a = y;
            for (int i = 0; i < C.Length; i++) { C[i] = (byte)(((C[i] - b)*obr_a) % m); }
            File.WriteAllBytes(filename, C);
        }

        public static int EuclidAdvanced(byte a, int m, out int x, out int y)
        {            
            if (a == 0)
            {
                x = 0; y = 1;
                return b;
            }
            int x1, y1;
            byte tmp = (byte)(m % a);
            int d = EuclidAdvanced(tmp, a, out x1, out y1);
            x = y1 - (m / a) * x1;
            y = x1;
            return d;
        }
    }
}
