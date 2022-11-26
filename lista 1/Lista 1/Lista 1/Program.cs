using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp
{
    internal class Program
    {
        static void showMenu()
        {
            Console.WriteLine("-------Meniu-------");
            Console.WriteLine("1.Rezolvati ecuatia de gradul 1 cu o necunoscuta: ax + b = 0, unde a si b sunt date de intrare.");
            Console.WriteLine("2.Rezolvati ecuatia de gradul 2 cu o necunoscuta: ax ^ 2 + bx + c = 0, unde a, b si c sunt date de intrare. Tratati toate cazurile posibile.");
            Console.WriteLine("3.Determinati daca n se divide cu k, unde n si k sunt date de intrare.");
            Console.WriteLine("4.Detreminati daca un an y este an bisect.");
            Console.WriteLine("5.Extrageti si afisati a k - a cifra de la sfarsitul unui numar. Cifrele se numara de la dreapta la stanga.");
            Console.WriteLine("6.Detreminati daca trei numere pozitive a, b si c pot fi lungimile laturilor unui triunghi. ");
            Console.WriteLine("7.(Swap) Se dau doua variabile numerice a si b ale carori valori sunt date de intrare. Se cere sa se inverseze valorile lor. ");
            Console.WriteLine("8.(Swap restrictionat) Se dau doua variabile numerice a si b ale carori valori sunt date de intrare. Se cere sa se inverseze valorile lor fara a folosi alte variabile suplimentare.  ");
            Console.WriteLine("9.Afisati toti divizorii numarului n. ");
            Console.WriteLine("10.Test de primalitate: determinati daca un numar n este prim.");
            Console.WriteLine("11.Afisati in ordine inversa cifrele unui numar n. ");
            Console.WriteLine("12.Determinati cate numere integi divizibile cu n se afla in intervalul [a, b]. ");
            Console.WriteLine("13.Determianti cati ani bisecti sunt intre anii y1 si y2.");
            Console.WriteLine("14.Determianti daca un numar n este palindrom. (un numar este palindrom daca citit invers obtinem un numar egal cu el, de ex. 121 sau 12321. ");
            Console.WriteLine("15.Se dau 3 numere. Sa se afiseze in ordine crescatoare. \n");
            Console.WriteLine("16.Se dau 5 numere. Sa se afiseze in ordine crescatoare. (nu folositi tablouri)");
            Console.WriteLine("17.Determianti cel mai mare divizor comun si cel mai mic multiplu comun a doua numere. Folositi algoritmul lui Euclid. \n");
            Console.WriteLine("18.Afisati descompunerea in factori primi ai unui numar n.  De ex. pentru n = 1176 afisati 2^3 x 3^1 x 7^2. \n");
            Console.WriteLine("19.Determinati daca un numar e format doar cu 2 cifre care se pot repeta. De ex. 23222 sau 9009000 sunt astfel de numere, pe cand 593 si 4022 nu sunt. ");
            Console.WriteLine("20.Afisati fractia m/n in format zecimal, cu perioada intre paranteze (daca e cazul). Exemplu: 13/30 = 0.4(3).");
            Console.WriteLine("Ghiciti un numar intre 1 si 1024 prin intrebari de forma \"numarul este mai mare sau egal decat x?\".");
            Console.WriteLine("0. Inchideti meniul");
        }

        static void problema1()
        {
            int a, b;
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            if (a != 0)
                Console.WriteLine("Rezultatul ecuatiei ax + b = 0 este: " + (-b / a));
            else
            {
                Console.WriteLine("Rezultatul este infinit! ");
            }
        }

        static void problema2()
        {
            double a, b, c, d = -1, x1, x2;
            Console.WriteLine("Dati a: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Dati c: ");
            c = double.Parse(Console.ReadLine());
            if (a != 0 && b != 0)
            {
                d = b * b - 4 * a * c;
            }
            if (d >= 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Raspunsul este: " + x1 + " " + x2);
                return;
            }
            else if (d < 0)
            {
                Console.WriteLine("Ecuatia nu are solutii! ");
                return;
            }
            if (a == 0 && b == 0 && c == 0)
            {
                Console.WriteLine("Ecuatia are o infinitate de solutii");
                return;
            }
            else if (a == 0 && b == 0)
            {
                Console.WriteLine("Ecuatia nu are solutii! ");
                return;
            }
            else if (a == 0)
            {
                if (c != 0)
                {
                    x1 = -b / c;
                    Console.WriteLine("Raspunsul este: " + x1);
                    return;
                }
                else
                {
                    Console.WriteLine("Ecuatia nu are solutii ");
                    return;
                }
            }
            else if (b == 0)
            {
                if ((-c / a) >= 0 && c != 0)
                {
                    x1 = Math.Sqrt(-c / a);
                    Console.WriteLine("Raspunsul este: " + x1);
                    return;
                }
                else if (c == 0)
                {
                    Console.WriteLine("RAspunsul este: 0");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Ecuatia nu are solutii");
                return;
            }
        }

        static void problema3()
        {
            int n, k;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati k: ");
            k = int.Parse(Console.ReadLine());
            if (n % k == 0)
            {
                Console.WriteLine("N se divide cu k");
            }
            else
            {
                Console.WriteLine("n nu se divide cu k");
            }
        }

        static void problema4()
        {
            int an;
            Console.WriteLine("Dati anul: ");
            an = int.Parse(Console.ReadLine());
            if ((an % 4 == 0 && an % 100 != 0) || an % 400 == 0)
            {
                Console.WriteLine("Anul este bisect");
            }
            else
            {
                Console.WriteLine("Anul nu este bisect");
            }
        }

        static void problema5()
        {
            int n, k, nrCifra = 0;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati k: ");
            k = int.Parse(Console.ReadLine());
            while (n != 0)
            {
                nrCifra++;
                int cif = n % 10;
                n /= 10;
                if (nrCifra == k)
                {
                    Console.WriteLine("A k a cifra a numarului n este: " + cif);
                    return;
                }
            }
            Console.WriteLine("Numarul nu are atat de multe cire");
        }

        static void problema6()
        {
            int a, b, c;
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati c: ");
            c = int.Parse(Console.ReadLine());
            if (a < b + c && b < a + c && c < a + b)
            {
                Console.WriteLine("Cele 3 valori pot forma laturile unui triunghi");
            }
            else
            {
                Console.WriteLine("Cele 3 valori nu pot forma laturile unui triunghi");
            }
        }

        static void problema7()
        {


            int a, b;
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            int aux = a;
            a = b;
            b = aux;
            Console.WriteLine("Valorile lor inversate sunt: a = " + a + " b = " + b);
        }

        static void problema8()
        {
            int a, b;
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("Valorile lor inversate sunt: a = " + a + " b = " + b);
        }

        static void problema9()
        {
            int n;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Divizorii lui n sunt: ");
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }

        static void problema10()
        {
            int n;
            bool prim = true;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            if (n < 2)
            {
                prim = false;
            }
            else if (n == 2)
            {
                prim = true;
            }
            else if (n % 2 == 0)
                prim = false;
            else
            {
                for (int d = 3; d * d < n; d += 2)
                {
                    if (n % d == 0)
                    {
                        prim = false;
                        break;
                    }
                }
            }
            if (prim)
            {
                Console.WriteLine("Numarul este prim");
            }
            else
            {
                Console.WriteLine("Numarul nu este prim");
            }
        }

        static void problema11()
        {
            int n;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Cifrele lui n sunt: ");
            while (n != 0)
            {
                int cif = n % 10;
                Console.Write(cif + " ");
                n /= 10;
            }
            Console.WriteLine();
        }

        static void problema12()
        {
            int n, a, b, nr = 0;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            for (int i = a; i < b; i++)
            {
                if (i > 0 && n % i == 0)
                    nr++;
            }
            Console.WriteLine("In intervalul [" + a + "," + b + "] numarul numerelor intregi divizible cu " + n + " este: " + nr);
        }

        static void problema13()
        {
            int y1, y2, nr = 0;
            Console.WriteLine("Dati a: ");
            y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            y2 = int.Parse(Console.ReadLine());
            for (int i = y1; i <= y2; i++)
            {
                if ((i % 4 == 0 && i % 100 != 0) || i % 400 == 0)
                    nr++;
            }
            Console.WriteLine("Intre anii " + y1 + "," + y2 + " sunt " + nr + " ani bisecti");
        }

        static void problema14()
        {
            int n, invers = 0;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            int copie = n;
            while (copie > 0)
            {
                invers = invers * 10 + copie % 10;
                copie /= 10;
            }
            if (n == invers)
            {
                Console.WriteLine("Numarul este palindrom");
            }
            else
            {
                Console.WriteLine("Numarul nu este palindrom");
            }
        }

        static void SwapNum(ref int x, ref int y)
        {

            int tempswap = x;
            x = y;
            y = tempswap;
        }

        static void problema15()
        {
            int a, b, c;
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati c: ");
            c = int.Parse(Console.ReadLine());
            if (a > c)
            {
                SwapNum(ref a, ref c);
            }
            if (a > b)
            {
                SwapNum(ref a, ref b);
            }
            if (b > c)
            {
                SwapNum(ref b, ref c);
            }
            Console.WriteLine("Cele 3 numere in ordine crescatoare sunt: " + a + " " + b + " " + c);
        }

        static void problema16()
        {
            int a, b, c, d, e;
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati c: ");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati d: ");
            d = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati e: ");
            e = int.Parse(Console.ReadLine());

            if (a > e)
            {
                SwapNum(ref a, ref e);
            }
            if (a > d)
            {
                SwapNum(ref a, ref b);
            }
            if (a > c)
            {
                SwapNum(ref a, ref c);
            }
            if (a > b)
            {
                SwapNum(ref a, ref b);
            }
            if (b > e)
            {
                SwapNum(ref b, ref e);
            }
            if (b > d)
            {
                SwapNum(ref b, ref d);
            }
            if (b > c)
            {
                SwapNum(ref b, ref c);
            }
            if (c > e)
            {
                SwapNum(ref c, ref e);
            }
            if (c > d)
            {
                SwapNum(ref c, ref d);
            }
            if (d > e)
            {
                SwapNum(ref d, ref e);
            }
            Console.WriteLine("Cele 5 numere in ordine crescatoare sunt: " + a + " " + b + " " + c + " " + d + " " + e);

        }

        static int cmmdc(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }

        static void problema17()
        {
            int a, b;
            Console.WriteLine("Dati a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati b: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Cmmdc al celor 2 numere este: " + cmmdc(a, b));
            Console.WriteLine("Cmmmc al celor 2 numere este: " + (a + b) / cmmdc(a, b));
        }

        static void problema18()
        {
            int n;
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            int p, d = 2;
            Console.WriteLine("Descompunerea in factori primi a numarului " + n + " este: ");
            while (n > 1)
            {
                if (n % d == 0)
                {
                    p = 0;
                    while (n % d == 0)
                    {
                        p++;
                        n /= d;
                    }
                    Console.WriteLine(d + " la puterea " + p);
                }
                d++;
            }
        }

        static void problema19()
        {
            int n, nr = 0;
            int[] fr = new int[10];
            for(int i = 0; i < 10; i++)
            {
                fr[i] = 0;
            }
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());
            while(n != 0)
            {
                int cif = n % 10;
                fr[cif]++;
                n /= 10;
            }
            for(int i = 0; i < 10; i++)
            {
                if (fr[i] > 0)
                {
                    nr++;
                }
            }
            if(nr != 2)
            {
                Console.WriteLine("Numarul nu este format doar cu 2 cifre care se pot repeta! ");
            }
            else
            {
                Console.WriteLine("Numarul este format doar din 2 cifre care se repeta! ");
            }
        }

        static void problema20()
        {
            int m, n;
            Console.WriteLine("Dati m: ");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati n: ");
            n = int.Parse(Console.ReadLine());

            int parteInt = m / n;
            int parteFract = m % n;
            Console.Write($"{parteInt},");
            int c, r;
            List<int> rests = new List<int>();
            List<int> cifre = new List<int>();
            rests.Add(parteFract);
            bool periodic = false;
            do
            {
                c = parteFract * 10 / n;
                cifre.Add(c);
                r = parteFract * 10 % n;
                if (!rests.Contains(r))
                    rests.Add(r);
                else
                {
                    periodic = true;
                    break;
                }
                parteFract = r;

            } while (r != 0);

            if (!periodic)
            {
                for(int i = 0; i < cifre.Count; i++)
                {
                    Console.Write(cifre[i]);
                }
            }
            else
            {
                for(int i = 0; i < rests.Count; i++)
                {
                    if (rests[i] == r)
                    {
                        Console.Write("(");
                    }
                    Console.Write(cifre[i]);
                }
                Console.WriteLine(")");
            }
        }

        static void problema21()
        {
            int st = 1, dr = 1024;
            int mid = 0;
            string ans = "";
            while(st <= dr)
            {
                mid = (st + dr) / 2;
                Console.WriteLine("Numarul este mai mare sau egal decat " + mid + "?");
                ans = Console.ReadLine();
                if (ans == "da")
                {
                    st = mid + 1;
                }
                else
                {
                    dr = mid - 1;
                }
            }
            if(ans == "da")
                Console.WriteLine("Numarul este: " + mid);
            else
                Console.WriteLine("Numarul este: " + (mid-1));
  
        }

        static void menu()
        {
            int option = 1;
            while (option != 0)
            {
                Console.WriteLine("Dati optiunea: ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            problema1();
                            break;
                        }
                    case 2:
                        {
                            problema2();
                            break;
                        }
                    case 3:
                        {
                            problema3();
                            break;
                        }
                    case 4:
                        {
                            problema4();
                            break;
                        }
                    case 5:
                        {
                            problema5();
                            break;
                        }
                    case 6:
                        {
                            problema6();
                            break;
                        }
                    case 7:
                        {
                            problema7();
                            break;
                        }
                    case 8:
                        {
                            problema8();
                            break;
                        }
                    case 9:
                        {
                            problema9();
                            break;
                        }
                    case 10:
                        {
                            problema10();
                            break;
                        }
                    case 11:
                        {
                            problema11();
                            break;
                        }
                    case 12:
                        {
                            problema12();
                            break;
                        }
                    case 13:
                        {
                            problema13();
                            break;
                        }
                    case 14:
                        {
                            problema14();
                            break;
                        }
                    case 15:
                        {
                            problema15();
                            break;
                        }
                    case 16:
                        {
                            problema16();
                            break;
                        }
                    case 17:
                        {
                            problema17();
                            break;
                        }
                    case 18:
                        {
                            problema18();
                            break;
                        }
                    case 19:
                        {
                            problema19();
                            break;
                        }
                    case 20:
                        {
                            problema20();
                            break;
                        }
                    case 21:
                        {
                            problema21();
                            break;
                        }
                    case 0:
                        {
                            option = 0;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Optiune inexistenta! Reincercati!");
                            break;
                        }





                }
            }
        }

        static void Main(string[] args)
        {
            showMenu();
            menu();

        }
    }
}

