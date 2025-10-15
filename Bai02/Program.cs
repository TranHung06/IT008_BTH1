using System;

namespace BTTH1_BT2
{
    class Program
    {
        static void Main()
        {
            int n;
            int ch = -1;
            do
            {
                do
                {
                    Console.WriteLine("Nhap so nguyen duong > 0: ");
                    if (!int.TryParse(Console.ReadLine(), out n))
                        Console.WriteLine("Khong hop le");
                } while (n <= 0);
                Console.WriteLine("--Menu--");
                Console.WriteLine("1. Tinh tong so nguyen to.");
                Console.WriteLine("2. Thoat.");
                Console.WriteLine("Nhap lua chon: ");
                if (!int.TryParse(Console.ReadLine(), out ch)) 
                Console.WriteLine("Lua chon khong hop le");
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Tong so nguyen to: " + sumprime(n));
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Chon lai.");
                        break;
                }
            } while (ch != 2);

        }

        static bool isprime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        //Tinh tổng SNT < n
        static int sumprime(int n)
        {
            int prime = 0;
            for (int i = 2; i < n; i++)
            {
                if (isprime(i)) prime += i;
            }
            return prime;
        }

    }
}






