using System;


namespace BTTH1_BT5
{
    class Program
    {
        int ng, th, n;
        static void Main()
        {
            int ch;
            do
            {
                Console.WriteLine("--Menu--");
                Console.WriteLine("0. Thoat CT");
                Console.WriteLine("1. Nhap ngay thang nam");
                Console.WriteLine("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out ch))
                    Console.WriteLine("Lua chon khong hop le");
                switch (ch)
                {
                    case 0:
                        break;
                    case 1:
                        Program i = new Program();
                        i.input();
                        //Cho rang nam < 0 la nam TCN
                        if (i.test())
                        {
                            //Ngay 1/1/0001 la thu 2
                            int temp = i.timthu();
                            switch (temp)
                            {
                                case 0:
                                    Console.WriteLine("Thu hai");
                                    break;
                                case 1:
                                    Console.WriteLine("Thu ba");
                                    break;
                                case 2:
                                    Console.WriteLine("Thu tu");
                                    break;
                                case 3:
                                    Console.WriteLine("Thu nam");
                                    break;
                                case 4:
                                    Console.WriteLine("Thu sau");
                                    break;
                                case 5:
                                    Console.WriteLine("Thu bay");
                                    break;
                                default:
                                    Console.WriteLine("Chu nhat");
                                    break;
                            }
                        }
                        else Console.WriteLine("Ngay thang nam khong hop le");
                        break;
                }
            } while (ch != 0);
        }
        bool input()
        {
            Console.WriteLine("Nhap ngay: ");
            if (!int.TryParse(Console.ReadLine(), out ng)) return false;
            Console.WriteLine("Nhap thang: ");
            if (!int.TryParse(Console.ReadLine(), out th)) return false;
            Console.WriteLine("Nhap nam: ");
            if (!int.TryParse(Console.ReadLine(), out n)) return false;
            return true;
        }

        //Kiểm tra hợp lệ
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

        //Tính tổng số ngày đã qua trong tháng
        static int tongngay(int th,int n)
        {
            int sum = 0;
            int start = 1;
            while (start < th)
            {
                switch (start)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        sum += 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        sum += 30;
                        break;
                    case 2:
                        if (n % 400 == 0 || (n % 4 == 0 && n % 100 != 0))
                        {
                            sum += 29;
                        }
                        else sum += 28;
                        break;
                    default:
                        return sum;
                }
                start++;
            }
            return sum;
        }
        //Tính tổng ngày kể từ 1/1/0001 xong mod cho 7
        int timthu()
        {
            int sum = 0;
            for (int i = 1; i < Math.Abs(n); i++)
            {
                if (i % 400 == 0 || (i % 4 == 0 && i % 100 != 0))
                {
                    sum += 366;
                }
                else
                {
                    sum += 365;
                }
                sum %= 7;
            }
            sum += tongngay(th, n);
            sum += ng - 1;
            return sum % 7;
            
        }

    }
}




