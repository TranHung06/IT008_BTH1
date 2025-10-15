using System;
using System.Reflection.Metadata.Ecma335;

namespace BTTH1_BT6
{
    class Program
    {
        int n, m, minv, maxv;
        int[,] v = new int[0,0];
        static void Main()
        {
            Program p = new Program();
            p.repeat();
        }
        void repeat()
        {
            bool cd;
            Program i = new Program();
            do
            {
                cd = i.input();
            } while (!cd);
            i.createarr();
            int ch;
            do
            {
                Console.WriteLine("--Menu--");
                Console.WriteLine("0. In mang.");
                Console.WriteLine("1. Tim phan tu lon nhat va nho nhat.");
                Console.WriteLine("2. Tim dong co tong lon nhat.");
                Console.WriteLine("3. Tinh tong cac so khong phai la so nguyen to.");
                Console.WriteLine("4. Xoa dong thu k trong ma tran.");
                Console.WriteLine("5. Xoa cot chua phan tu lon nhat trong ma tran.");
                Console.WriteLine("6. Thoat");
                Console.WriteLine("Nhap lua chon: ");
                if (!int.TryParse(Console.ReadLine(), out ch))
                    Console.WriteLine("Lua chon khong hop le");
                switch (ch)
                {
                    case 0:
                        i.printarr();
                        break;
                    case 1:
                        int[,] max = i.findmax();
                        int min = i.findmin();
                        Console.WriteLine("Phan tu lon nhat: " + max[0, 1]);
                        Console.WriteLine("Phan tu be nhat: " + min);
                        break;
                    case 2:
                        int[,] mr = i.maxrow();
                        Console.WriteLine($"Dong co tong lon nhat: {mr[0, 0] + 1} Co gia tri la {mr[0, 1]}");
                        break;
                    case 3:
                        int t = i.sumnotprime();
                        Console.WriteLine(t);
                        break;
                    case 4:
                        bool cond = false;
                        int k;
                        do
                        {
                            Console.WriteLine($"Nhap vao dong k muon xoa >=1 va <= {i.v.GetLength(0)} :");

                            if (!int.TryParse(Console.ReadLine(), out k) || (k < 1 && k > i.v.GetLength(0)))
                            {
                                Console.WriteLine("Du lieu khong hop le");
                                continue;
                            }
                            cond = true;
                        } while (!cond);
                        i.delrowk(k);
                        
                        break;
                    case 5:
                        int[,] delc = i.findmax();
                        i.delcolk(delc[0, 0]);
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Chon lai.");
                        break;
                }
            } while (ch != 6);
        }
        //Nhập thông tin
        bool input()
        {
            Console.WriteLine("Nhap so dong > 0: ");
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Khong hop le");
                return false;
            }            
            Console.WriteLine("Nhap so cot > 0: ");
            if (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
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
        void printarr()
        {
            if (v.GetLength(0)==0 && v.GetLength(1) == 0)
            {
                Console.WriteLine("Mang rong.");
                return;
            }
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                    Console.Write(v[i,j] + " ");
                Console.Write('\n');
            }
                
        }
        //Tạo mảng
        int[,] createarr()
        {
            v = new int[n,m];
            Random rd = new Random();
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    v[i, j] = rd.Next(minv,maxv+1);
                }
            }
            return v;
        }
        //Tìm số nhỏ nhất
        int findmin()
        {
            int min = v[0, 0];
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if (min > v[i, j]) min = v[i, j];
                }
            }
            return min;
        }
        //Tìm số lớn nhất trong mảng đồng thời giữ lại chỉ số cột để tí xóa
        int[,] findmax()
        {
            if (v.GetLength(0) ==0 || v.GetLength(1) == 0)
            {
                return new int[1, 3];
            }
            int[,] max = new int[1, 2];
            max[0, 1] = v[0, 0];
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if (max[0, 1] < v[i, j])
                    {
                        max[0,1] = v[i, j];
                        max[0, 0] = j;
                    }
                    
                }
            }
            return max;
        }
        //Tìm dòng có tổng lớn nhất
        int[,] maxrow()
        {
            int[,] max = new int[1, 2];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    max[0, 1] += v[i, j];
                }
            }
            for (int i = 1; i < v.GetLength(0); i++)
            {
                int temp = 0;
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    temp += v[i, j];
                }
                if (temp > max[0, 1])
                {
                    max[0, 1] = temp;
                    max[0, 0] = i;
                }
            }
            return max;
        }
        //Tổng số không phải là SNT
        int sumnotprime()
        {
            int sum = 0;
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if (!isprime(v[i,j])) 
                    {
                        sum += v[i, j];
                    }
                }
            }
            return sum;
        }
        static bool isprime(int v)
        {
            if (v < 2) return false;
            for (int i = 2; i * i <= v; i++)
            {
                if (v % i == 0) return false;
            }
            return true;
        }
        //xóa dòng
        void delrowk(int k)
        {
            if (v.GetLength(0) == 0)
            {
                Console.WriteLine("Khong con gi de xoa.");
                return;
            }
            if (v.GetLength(0) <= 1)
            {
                v = new int[0, 0];
                Console.WriteLine("Da xoa thanh cong");
                return;
            }
            int[,] res = new int[v.GetLength(0) - 1, v.GetLength(1)];
            int r = 0, c = 0;
            for (int i = 0; i < v.GetLength(0); i++)
            {
                if (i == k - 1)
                    continue;
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    res[r, c++] = v[i, j];
                }
                r++;
                c = 0;
            }
            v = new int[res.GetLength(0), res.GetLength(1)];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    v[i,j] = res[i,j];
                }
            }
            Console.WriteLine("Da xoa thanh cong");
        }
        //xóa cột
        void delcolk(int k)
        {
            if (v.GetLength(1) == 0 ||v.GetLength(0) == 0)
            {
                Console.WriteLine("Khong con gi de xoa.");
                return;
            }
            if (v.GetLength(1) <= 1)
            {
                v = new int[0, 0];
                Console.WriteLine("Da xoa thanh cong");
                return;
            }
            int[,] res = new int[v.GetLength(0) , v.GetLength(1) - 1];
            int r = 0, c = 0;
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if (j == k )
                    {
                        continue;
                    }
                    res[r, c++] = v[i, j];
                }
                r++;
                c = 0;
            }

            v = new int[res.GetLength(0), res.GetLength(1)];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    v[i, j] = res[i, j];
                }
            }
            Console.WriteLine("Da xoa thanh cong");
        }
    }
}