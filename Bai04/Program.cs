using System;

namespace BTTH1_BT4
{
    class Program
    {
        int th, n;
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
                Console.WriteLine("1. Nhap thang nam");
                if (!int.TryParse(Console.ReadLine(), out ch))
                    Console.WriteLine("Lua chon khong hop le");
                switch (ch)
                {
                    case 0:
                        break;
                    case 1:
                        Program i = new Program();
                        //Cho rang nam < 0 la nam TCN
                        if (!i.input())
                        {
                            Console.WriteLine("Ngay hoac thang khong hop le.");
                            continue;
                        }
                        int ng = i.timngay();
                        if (ng == -1)
                            Console.WriteLine("Thang,nam khong hop le");
                        else Console.WriteLine("So ngay cua thang la: " + ng);
                        break;
                }
            } while (ch != 0);
        }
        bool input()
        {
            Console.WriteLine("Nhap thang: ");
            if (!int.TryParse(Console.ReadLine(), out th) && (th <=0 || th >12 )) return false;
            Console.WriteLine("Nhap nam: ");
            string? str = Console.ReadLine();
            bool cd = true;
            if (str != null)
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsNumber(str[i]))
                    {
                        if (i == 0 && str[i] == '-')
                            continue;
                        cd = false;
                        break;
                    }

                }
            if (str == null || !(cd) || !int.TryParse(str, out n)) return false;
            return true;
        }
        int timngay()
        {
            switch (th)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (n % 400 == 0 || (n % 4 == 0 && n % 100 != 0))
                    {
                        return 29;
                    }
                    else return 28;
                default:
                    return -1;
            }
        }

    }
}




