using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setul_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int prob, ok = 1;
            do
            {
                Console.Clear();
                Console.Write("Alegeti o problema: ");
                prob = int.Parse(Console.ReadLine());
                if (prob < 1 || prob > 17) Console.Write("Nu ati introdus un numar corect!");
                else
                {
                    switch (prob)
                    {
                        case 1: P1(); break;
                        case 2: P2(); break;
                        case 3: P3(); break;
                        case 4: P4(); break;
                        case 5: P5(); break;
                        case 6: P6(); break;
                        case 7: P7(); break;
                        case 8: P8(); break;
                        case 9: P9(); break;
                        case 10: P10(); break;
                        case 11: P11(); break;
                        case 12: P12(); break;
                        case 13: P13(); break;
                        case 14: P14(); break;
                        case 15: P15(); break;
                        case 16: P16(); break;
                        case 17: P17(); break;
                    }

                }
                Console.Write("\nDoriti sa alegeti alta problema?: 0 - Nu, 1 - Da ");
                
                ok = int.Parse(Console.ReadLine());
            } while (ok != 0);

        }

       


        /// <summary>
        /// Se da o secventa de 0 si 1, unde 0 inseamna paranteza deschisa si 1 inseamna paranteza inchisa. Determinati daca secventa reprezinta o secventa de paranteze corecta si,  daca este, determinati nivelul maxim de incuibare a parantezelor. De exemplu 0 1 0 0 1 0 1 1 este corecta si are nivelul maxim de incuibare 2 pe cand 0 0 1 1 1 0 este incorecta. 
        /// </summary>
        private static void P17()
        {
            bool brackets = true;
            string n;
            int nr1 = 0, nr0 = 0, maxcuib=0, consec0 = 0;
            Console.WriteLine(" Determinati daca secventa reprezinta o secventa de paranteze corecta.\nIntroduceti o secventa de 0 si 1, nu folositi separatoare. (0 inseamna paranteza deschisa si 1 inseamna paranteza inchisa):");
            n = Console.ReadLine();
            /*if ((n[0] - '0') == 1) brackets = false;
            for (int i = 0; i < n.Length; i++)
            {
              
                if ((n[i]-'0') == 0) nr0++;
                else nr1++;
                if (nr0 < nr1) brackets = false;
            }
            if((n[n.Length-1] - '0') == 0) brackets = false;
            if (nr0 != nr1) brackets = false;
            if (brackets)
                Console.WriteLine("Este o secventa de paranteze corecta");
            else
                Console.WriteLine("NU Este o secventa de paranteze corecta");
            */

            if ((n[0] - '0') == 1) brackets = false;
            if(brackets)
            for (int i = 0; i < n.Length; i++)
            {
                    if ((n[i] - '0') == 0) { nr0++; consec0++; }
                    else { nr0--; if (consec0 > maxcuib) maxcuib = consec0; consec0 = 0;  }
                if (nr0 < 0) { brackets = false; break; }
            }
            if ((n[n.Length - 1] - '0') == 0) brackets = false;
            if (nr0 != 0) brackets = false;
            if (brackets)
                Console.WriteLine($"Este o secventa de paranteze corecta, nivelul de incuibare maxima este {maxcuib}");
            else
                Console.WriteLine("NU Este o secventa de paranteze corecta");
        }

        /// <summary>
        /// O secventa bitonica rotita este o secventa bitonica sau una ca poate fi transformata intr-o secventa bitonica prin rotiri succesive (rotire = primul element devine ultimul). Se da o secventa de n numere. Se cere sa se determine daca este o secventa bitonica rotita. 
        /// </summary>
        private static void P16()
        {
            int x, n, ante, stop = 0, i, ult, prim;
            bool cresc = false, decresc = false;

            Console.Write("Se da o secventa de n numere. Se cere sa se determine daca este o secventa bitonica rotita. \nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 1)
            {
                Console.Write($"Elementul 1: ");
                ante = int.Parse(Console.ReadLine());
                prim = ante;
                Console.Write($"Elementul 2: ");
                x = int.Parse(Console.ReadLine());

                if (x < ante) // daca incepem cu sir desc
                {
                    for (i = 2; i < n; i++) // incepem cu un sir descresc
                    {
                        Console.Write($"Elementul {i + 1}: ");
                        x = int.Parse(Console.ReadLine());
                        if (x > ante) { stop++; ante = x; break; }
                        ante = x;
                        cresc = true;
                    }
                    if (i < n)
                    {
                        stop = 0;
                        for (i = i + 1; i < n; i++) // continuam sir crescator
                        {
                            Console.Write($"Elementul {i + 1}: ");
                            x = int.Parse(Console.ReadLine());
                            if (x < ante) { stop++; ante = x; break; }
                            ante = x;
                            decresc = true;
                        }
                        if (i < n)
                        {
                            stop = 0;
                            for (i = i + 1; i < n; i++) // terminam sir descresc
                            {
                                Console.Write($"Elementul {i + 1}: ");
                                x = int.Parse(Console.ReadLine());
                                if (x > ante) stop++;
                                ante = x;
                            }
                        }
                    }
                    ult = ante;
                    if (stop == 0 && prim < ult && decresc && cresc) Console.WriteLine("Sirul este o secventa bitonica rotita");
                    else Console.Write("Sirul nu este o secventa bitonica rotita");
                }
                else
                {
                    for (i = 2; i < n; i++)
                    {
                        Console.Write($"Elementul {i + 1}: ");
                        x = int.Parse(Console.ReadLine());
                        if (x < ante) 
                        {
                            if (i == n - 1) decresc = true;
                            else { stop++; ante = x; break; } 
                        }
                        ante = x;
                        cresc = true;
                    }

                    if (i < n)
                    {
                        stop = 0;
                        for (i = i + 1; i < n; i++)
                        {
                            Console.Write($"Elementul {i + 1}: ");
                            x = int.Parse(Console.ReadLine());
                            if (x > ante) stop++;
                            ante = x;
                            decresc = true;
                        }
                    }
                  
                    
                    if (stop == 0 && cresc && decresc) Console.WriteLine("Sirul este o secventa bitonica rotita");
                    else Console.Write("Sirul nu este o secventa bitonica rotita");
                }
            }
            else
                Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// O secventa bitonica este o secventa de numere care incepe monoton crescator si continua monoton descrecator. De ex. 1,2,2,3,5,4,4,3 este o secventa bitonica. Se da o secventa de n numere. Sa se determine daca este bitonica. 
        /// </summary>
        private static void P15()
        {
            int x, n, ante, stop = 0,i;
            
            Console.Write("Se da o secventa de n numere. Sa se determine daca este bitonica.  \nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                Console.Write($"Elementul 1: ");
                ante = int.Parse(Console.ReadLine());

                for (i = 1; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x < ante) { stop++; ante = x; break; }
                    ante = x;
                }
                stop = 0;
                for (i = i + 1; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x > ante) stop++;
                    ante = x;
                }
                if (stop == 0) Console.WriteLine("Sirul este o secventa bitonica");
                else Console.Write("Sirul nu este bitonica");
            }
            else Console.WriteLine("n este prea mic!");
        }
        /// <summary>
        /// O secventa monotona rotita este o secventa de numere monotona sau poate fi transformata intr-o secventa montona prin rotiri succesive. Determinati daca o secventa de n numere este o secventa monotona rotita. 
        /// </summary>
        private static void P14()
        {
            int x, n, ante, stop = 0;
            bool repetat = false;

            Console.Write(" Determinati daca o secventa de n numere este o secventa monotona rotita. \nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 1)
            {
                Console.Write($"Elementul 1: ");
                ante = int.Parse(Console.ReadLine());
                Console.Write($"Elementul 2: ");
                x = int.Parse(Console.ReadLine());
                if (x > ante)
                {
                    ante = x;
                    for (int i = 2; i < n; i++)
                    {
                        Console.Write($"Elementul {i + 1}: ");
                        x = int.Parse(Console.ReadLine());
                        if (x < ante) stop++;
                        if (x == ante) repetat = true;
                        ante = x;
                    }
                    if (stop == 0 && !repetat) Console.WriteLine("Sirul este o secventa monotona (crescatoare) rotita.(Sirul era deja crescatoare)");
                    else if (stop == 1) Console.WriteLine("Sirul este o secventa monotona (crescatoare) rotita");
                    else if (stop == n - 2) Console.WriteLine("Sirul este o secventa monotona (descrescatoare) rotita");
                    else Console.Write("Sirul nu este monotona rotita");
                }
                else
                {
                    ante = x;
                    for (int i = 2; i < n; i++)
                    {
                        Console.Write($"Elementul {i + 1}: ");
                        x = int.Parse(Console.ReadLine());
                        if (x > ante) stop++;
                        if (x == ante) repetat = true;
                        ante = x;
                    }
                    if (stop == 0 && !repetat) Console.WriteLine("Sirul este o secventa monotona (descrescatoare) rotita.(Sirul era deja descrescatoare)");
                    else if (stop == 1) Console.WriteLine("Sirul este o secventa monotona (descrescatoare) rotita");
                    else if (stop == n - 2) Console.WriteLine("Sirul este o secventa monotona (crescatoare) rotita");
                    else Console.Write("Sirul nu este monotona rotita");
                }
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// O secventa crescatoare rotita este o secventa de numere care este in ordine crescatoare sau poate fi transformata intr-o secventa in ordine crescatoare prin rotiri succesive (rotire cu o pozitie spre stanga = toate elementele se muta cu o pozitie spre stanga si primul element devine ultimul). Determinati daca o secventa de n numere este o secventa crescatoare rotita. 
        /// O secventa monotona rotita este o secventa de numere monotona sau poate fi transformata intr-o secventa montona prin
        /// </summary>
        private static void P13()
        {
            int x, n, ante, stop=0;
            bool repetat = false;
            
            Console.Write(" Determinati daca o secventa de n numere este o secventa crescatoare rotita. \nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)

            {
                Console.Write($"Elementul 1: ");
                ante = int.Parse(Console.ReadLine());
                for (int i = 1; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x < ante) stop++;
                    if (x == ante) repetat = true;
                    ante = x;
                }
                if (stop == 0 && !repetat) Console.WriteLine($"Sirul este o secventa crescatoare rotita.(Sirul era deja crescatoare)");
                else if (stop == 1) Console.WriteLine($"Sirul este o secventa crescatoare rotita");
                else Console.Write("Sirul nu poate fi o secventa crescatoare rotita");
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere. Considerati fiecare astfel de grup ca fiind un cuvant, zero fiind delimitator de cuvinte. De ex. pentru secventa 1, 2, 0, 3, 4, 5, 0, 0, 6, 7, 0, 0 raspunsul este 3. 
        /// </summary>
        private static void P12()
        {
            int x, n, nrcuv = 0, l = 0;
            Console.Write("Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x != 0) l++;
                    else
                        if (l != 0)
                    {
                        nrcuv++;
                        l = 0;
                    }

                }
                if (l != 0)
                {
                    nrcuv++;
                    l = 0;
                }

                Console.WriteLine($"Sunt {nrcuv} grupuri de numere diferite de zero.");
            }
            else Console.WriteLine("n este prea mic!");
        }

        static int inversa(int n)
        {
            int nr = 0;
            
            while(n!=0)
            {
                nr = nr * 10 + n % 10;
                n = n / 10;
            }
            
            return nr;
        }
        /// <summary>
        /// Se da o secventa de n numere. Se cere sa se caculeze suma inverselor acestor numere. 
        /// </summary>
        private static void P11()
        {
            int x, n, suma = 0,inv;
            Console.Write("Se da o secventa de n numere. Se cere sa se calculeze suma inverselor acestor numere. \nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    inv = inversa(x);
                    suma += inv;
                }

                Console.WriteLine($"Suma inverselor este {suma}");
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// Se da o secventa de n numere. Care este numarul maxim de numere consecutive egale din secventa. 
        /// </summary>
        private static void P10()
        {
            int x, n, max, nr,maxmax=0;
            Console.Write("Se da o secventa de n numere. Care este numarul maxim de numere consecutive egale din secventa.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                Console.Write($"Elementul 1: ");
                nr = int.Parse(Console.ReadLine());
                max = 1;
                for (int i = 1; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (nr == x) max++;
                    else
                    {
                        if (max > maxmax) maxmax = max;
                        nr = x;
                        max = 1;
                    }
                }
                if (max > maxmax) maxmax = max;

                Console.WriteLine($"Numarul maxim de numere consecutive egale este {maxmax}.");
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// Sa se determine daca o secventa de n numere este monotona. Secventa monotona = secventa monoton crescatoare sau monoton descrescatoare. 
        /// </summary>
        private static void P9()
        {
            int x, n,ante,ok=0;
            Console.Write("Sa se determine daca o secventa de n numere este monotona.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 1)
            {
                Console.Write($"Elementul 1: ");
                ante = int.Parse(Console.ReadLine());
                Console.Write($"Elementul 2: ");
                x = int.Parse(Console.ReadLine());
                if (ante < x)
                {
                    ante = x;
                    for (int i = 2; i < n; i++)
                    {
                        Console.Write($"Elementul {i + 1}: ");
                        x = int.Parse(Console.ReadLine());
                        if (x <= ante) ok = 1;
                        ante = x;

                    }
                    if (ok == 0)
                        Console.WriteLine("Sirul este monoton crescator");
                }
                else
                    if (ante > x)
                {
                    ante = x;
                    for (int i = 2; i < n; i++)
                    {
                        Console.Write($"Elementul {i + 1}: ");
                        x = int.Parse(Console.ReadLine());
                        if (x >= ante) ok = 1;
                        ante = x;
                    }
                    if (ok == 0)
                        Console.WriteLine("Sirul este monoton descrescator");
                }
                else
                {
                    ok = 1;
                    for (int i = 2; i < n; i++)
                    {
                        Console.Write($"Elementul {i + 1}: ");
                        x = int.Parse(Console.ReadLine());

                    }
                }
                if (ok != 0)
                    Console.WriteLine("Sirul NU este monoton.");
            }
            else Console.WriteLine("n este prea mic!");

        }
        static int fibonacci(int n)
        {
            if (n == 1 || n == 0) return 0;
            else
                if (n == 2) return 1;
            else return fibonacci(n-2)+fibonacci(n - 1);

        }
        /// <summary>
        /// Determianti al n-lea numar din sirul lui Fibonacci. Sirul lui Fibonacci se construieste astfel: f1 = 0, f2 = 1, f_n = f_(n-1) + f(n-2). Exemplu: 0, 1, 1, 2, 3, 5, 8 ...
        /// </summary>
        private static void P8()
        {
            int n,fn=0; //f1=0,f2=1;
            Console.Write("Determianti al n-lea numar din sirul lui Fibonacci.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            /*if (n == 1) Console.Write($"Al {n} numar este {f1}");
            if (n == 2) Console.Write($"Al {n}-lea numar este {f2}");
            Console.Write($"0 1 ");
            for (int i = 3; i <= n; i++)
            {
                fn = f1 + f2;
                f1 = f2;
                f2 = fn;
            }*/
            fn = fibonacci(n);
            Console.WriteLine($"Al {n} numar este {fn}");
        }

        /// <summary>
        /// Se da o secventa de n numere. Sa se determine cea mai mare si cea mai mica valoare din secventa. 
        /// </summary>
        private static void P7()
        {
            int x, n, max ,min;
            Console.Write("Se da o secventa de n numere. Sa se determine cea mai mare si cea mai mica valoare din secventa.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                Console.Write($"Elementul 1: ");
                min = int.Parse(Console.ReadLine());
                max = min;
                for (int i = 1; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x > max) max = x;
                    if (x < min) min = x;

                }
                Console.WriteLine($"Numarul minim este {min}, numarul maxim este {max}");
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// Se da o secventa de n numere. Sa se determine daca numerele din secventa sunt in ordine crescatoare. 
        /// </summary>
        private static void P6()
        {
            int x, n, ok=0, ante;
            Console.Write("Se da o secventa de n numere. Sa se determine daca numerele din secventa sunt in ordine crescatoare. \nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                Console.Write($"Elementul 1: ");
                ante = int.Parse(Console.ReadLine());
                for (int i = 1; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x <= ante) ok = 1;
                    ante = x;

                }
                if (ok == 0) Console.WriteLine("Numerele sunt in ordine crescatoare");
                else Console.WriteLine("Numerele NU sunt in ordine crescatoare");
            }
            else Console.WriteLine("n este prea mic!");
        }


        /// <summary>
        /// Cate elemente dintr-o secventa de n numere sunt egale cu pozitia pe care apar in secventa. Se considera ca primul element din secventa este pe pozitia 0. 
        /// </summary>
        private static void P5()
        {
            int x, n, poz = -1, egal=0;
            Console.Write("Cate elemente dintr-o secventa de n numere sunt egale cu pozitia pe care apar in secventa.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                Console.WriteLine($"Introduceti {n} valori: ");
                for (int i = 0; i < n; i++)
                {
                    x = int.Parse(Console.ReadLine());
                    poz++;
                    if (x == poz) egal++;

                }
                // daca a apare de mai multe ori se salveaza ultima aparitie
                if (egal == 0) Console.WriteLine("Nu exista elemente egale cu pozitia lor");
                else
                if (egal == 1) Console.WriteLine("Exista un element egal cu pozitia sa");
                else
                    Console.WriteLine($"{egal} elemente sunt egale cu pozitia lor");
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// Se da o secventa de n numere. Determinati pe ce pozitie se afla in secventa un numara a. Se considera ca primul element din secventa este pe pozitia zero. Daca numarul nu se afla in secventa raspunsul va fi -1. 
        /// </summary>
        private static void P4()
        {
            int x, n, a,poz=-1, pozf=-1;
            Console.Write("Se da o secventa de n numere. Determinati pe ce pozitie se afla in secventa un numar a.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                Console.Write("Introduceti valoarea pentru a: ");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine($"Introduceti {n} valori: ");
                for (int i = 0; i < n; i++)
                {
                    x = int.Parse(Console.ReadLine());
                    poz++;
                    if (x == a) pozf = poz;

                }
                // daca a apare de mai multe ori se salveaza ultima aparitie
                if (pozf != -1)
                    Console.WriteLine($"Numarul {a} e pe pozitia {pozf}");
                else
                    Console.WriteLine($"Numarul {a} e pe pozitia {pozf}, adica nu se afla in sir");
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// Calculati suma si produsul numerelor de la 1 la n. 
        /// </summary>
        private static void P3()
        {
            long n, suma, produs = 1;
            Console.Write("Calculati suma si produsul numerelor de la 1 la n. \nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n < 1) { Console.Write("n este prea mic!"); return; }
           
            for (int i = 1; i <= n; i++)
            {
                //suma += i;
                produs = produs * i;

            }
            suma = n * (n + 1) / 2;
            
            Console.WriteLine($"Suma de la 1 la {n} este {suma}, iar produsul este {produs}");
        }

        /// <summary>
        /// Se da o secventa de n numere. Sa se determina cate sunt negative, cate sunt zero si cate sunt pozitive. 
        /// </summary>
        private static void P2()
        {
            int x, n, par = 0, impar = 0, zero = 0 ;
            Console.Write("Se da o secventa de n numere. Sa se determina cate sunt negative, cate sunt zero si cate sunt pozitive.\nIntroduceti o valoare pentru n:");
            n = int.Parse(Console.ReadLine());
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x % 2 == 0 && x != 0) par++;
                    else
                        impar++;
                    if (x == 0) zero++;


                }
                Console.WriteLine($"Numarul elementelor: pare = {par}, impare = {impar}, si zero = {zero}");
            }
            else Console.WriteLine("n este prea mic!");
        }

        /// <summary>
        /// Se da o secventa de n numere. Sa se determine cate din ele sunt pare.
        /// </summary>
        private static void P1()
        {
            int x, n, par=0;
            Console.Write("Se da o secventa de n numere. Sa se determine cate din ele sunt pare.\nIntroduceti o valoare pentru n:");
            n= int.Parse(Console.ReadLine());
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Elementul {i + 1}: ");
                    x = int.Parse(Console.ReadLine());
                    if (x % 2 == 0) par++;

                }
                Console.WriteLine($"Numarul elementelor pare este {par}");
            }
            else Console.WriteLine("n este prea mic!");
        }
    }
}
