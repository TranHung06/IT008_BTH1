using System;

namespace BTTH1_BT1
{
    class Program
    {
        int[] v = new int[0];
        int n, minv = 0, maxv = 0;
        static void Main()
        {
            Program p = new Program();
            bool cd = false;
            do
            {
                if (p.input())
                cd = true;
            } while (!cd);
            p.v = createarr(p.n, p.minv, p.maxv);
            p.repeat();
        }
        void repeat()
        {
            int ch;
            do
            {
                Console.WriteLine("--Menu--");
                Console.WriteLine("0. In mang.");
                Console.WriteLine("1. Tinh tong so le.");
                Console.WriteLine("2. Tim so luong so nguyen to.");
                Console.WriteLine("3. Tim so chinh phuong nho nhat.");
                Console.WriteLine("4. Thoat.");
                Console.WriteLine("Nhap lua chon: ");
                if (!int.TryParse(Console.ReadLine(), out ch))
                    Console.WriteLine("Lua chon khong hop le");
                switch (ch)
                {
                    case 0:
                        printarr(v);
                        break;
                    case 1:
                        Console.WriteLine("Tong so le: " + sumodd(v));
                        break;
                    case 2:
                        Console.WriteLine("So luong so nguyen to: " + countprime(v));
                        break;
                    case 3:
                        int t = minscp(v);
                        if (t != -1)
                            Console.WriteLine("So chinh phuong nho nhat: " + t);
                        else Console.WriteLine("Khong co so chinh phuong.");
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Chon lai.");
                        break;
                }
            } while (ch != 4);
            
        }

        bool input()
        {
            Console.WriteLine("Nhap so phan tu mang > 0: ");
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Khong hop le");
                return false;
            }
            Console.WriteLine("Nhap gia tri be nhat cua phan tu: ");
            if (!int.TryParse(Console.ReadLine(), out minv))
            {
                Console.WriteLine("Khong hop le");
                return false;
            }
            Console.WriteLine("Nhap gia tri lon nhat cua phan tu: ");
            if (!int.TryParse(Console.ReadLine(), out maxv) || minv > maxv)
            {
                Console.WriteLine("Khong hop le");
                return false;
            }
            return true;
        }

        //In mảng
        static void printarr(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }

        //Tạo mảng
        static int[] createarr(int n, int min, int max)
        {
            int[] v = new int[n];
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                v[i] = rd.Next(min, max + 1);
            }
            return v;
        }

        //Kiểm tra SNT
        static bool isprime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        //Kiểm tra số chính phương
        static bool isscp(int n)
        {
            if (n < 0) return false;
            if (((double)Math.Sqrt(n)) == ((int)Math.Sqrt(n)))
            {
                return true;
            }
            return false;
        }

        //(a) Tổng các số lẻ
        static int sumodd(int[] v)
        {
            int sum = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] % 2 != 0)
                    sum += v[i];
            }
            return sum;
        }

        //(b) Đếm SNT
        static int countprime(int[] v)
        {
            int prime = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (isprime(v[i])) prime++;
            }
            return prime;
        }

        //(c) SCP nhỏ nhất
        static int minscp(int[] v)
        {
            int scp = -1;
            for (int i = 0; i < v.Length; i++)
            {
                if (isscp(v[i]) && (v[i] < scp || scp == -1))
                {
                    scp = v[i];
                }
            }
            return scp;
        }
    }
}