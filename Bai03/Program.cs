using System;

namespace BTTH1_BT3
{
    class Program
    {
        int ng, th, n;
        static void Main()
        {
            Program p = new Program();
            p.repeat();
        }
        void repeat()
        {
            int ch;
            do
            {
                Console.WriteLine("--Menu--");
                Console.WriteLine("0. Thoat CT");
                Console.WriteLine("1. Nhap ngay thang nam");
                if (!int.TryParse(Console.ReadLine(), out ch))
                    Console.WriteLine("Lua chon khong hop le");
                switch (ch)
                {
                    case 0:
                        break;
                    case 1:
                        bool cd;
                        Program i = new Program();
                        do
                        {
                            cd = i.input();
                        } while (!cd);
                        //Cho rang nam < 0 la nam TCN
                        if (i.test())
                            Console.WriteLine("Ngay thang nam hop le");
                        else Console.WriteLine("Khong hop le");
                        break;
                }
            } while (ch != 0);
        }
        bool input()
        {
            Console.WriteLine("Nhap ngay: ");
            if (!int.TryParse(Console.ReadLine(),out ng)) return false;
            Console.WriteLine("Nhap thang: ");
            if (!int.TryParse(Console.ReadLine(), out th)) return false;
            Console.WriteLine("Nhap nam: ");
            if (!int.TryParse(Console.ReadLine(), out n)) return false;
            return true;
        }
        bool test()
        {
            if (ng <= 0) return false;
            switch (th)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (ng > 31)
                        return false;
                    break;
                case 4:
                case 6:
                case 9: 
                case 11:
                    if (ng > 30) return false;
                    break;
                case 2:
                    if (n % 400 == 0 || (n % 4 == 0 && n % 100 != 0))
                    {
                        if (ng > 29) return false;
                    }
                    else if (ng > 28) return false;
                    break;
                default:
                    return false;
            }
            return true;
        }
       
    }
}




