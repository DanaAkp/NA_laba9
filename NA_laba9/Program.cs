using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_laba9
{
    class Program
    {
        static void Main(string[] args)
        {
            double t0 = 0.1;
            double T = 1.1;
            double u0 = 0.3314113;
            double tau1 = 0.1;
            double tau2 = 0.05;
            double tau3 = 0.025;

            Console.WriteLine("При тау=0.1");
            Console.WriteLine("Метод Рунг-Кутта 3 порядка");
            Console.WriteLine(RK_3(t0,u0,tau1,T));

            Console.WriteLine("Метод Рунг-Кутта 4 порядка");
            Console.WriteLine(RK_3(t0,u0,tau1,T));

            Console.WriteLine("При тау=0.05");
            Console.WriteLine("Метод Рунг-Кутта 3 порядка");
            Console.WriteLine(RK_3(t0,u0, tau2, T));

            Console.WriteLine("Метод Рунг-Кутта 4 порядка");
            Console.WriteLine(RK_3(t0,u0, tau2, T));

            Console.WriteLine("При тау=0.025");
            Console.WriteLine("Метод Рунг-Кутта 3 порядка");
            Console.WriteLine(RK_3(t0, u0, tau3, T));

            Console.WriteLine("Метод Рунг-Кутта 4 порядка");
            Console.WriteLine(RK_3(t0, u0, tau3, T));

            Console.ReadLine();
        }

        public static string RK_3(double t0,double u0,double tau, double T)
        {
            string s = "n\tk1\tk2\tk3\tti\tui\n";
            double t = t0;
            double u = u0;
            int c = 0;
            int n = (int)((T - t0) / tau);

            for(int i=0;i<=n;i++)
            {
                double k1 = func(t, u);
                double k2 = func(t + tau / 2.0, u + tau * k1 / 2.0);
                double k3 = func(t + tau, u - tau * k1 + 2 * tau * k2);
                s += c + "\t" +Math.Round( k1,4) + "\t" + Math.Round(k2, 4) + "\t" + Math.Round(k3, 4) + "\t" + Math.Round(t, 2) + "\t" + Math.Round(u, 4) + "\n";
                u = u + (tau / 6.0) * (k1 + 4 * k2 + k3);
                t += tau;c++;
            }
            return s;
        }
        public static double func(double t, double u)
        {
            return (Math.Cos(t) + 2 * t) / 2 * u;
        }

        public static string RK_4(double t0, double u0, double tau, double T)
        {
            string s = "n\tk1\tk2\tk3\tk4\tti\tui\n";
            double t = t0;
            double u = u0;
            int c = 0;

            int n = (int)((T - t0) / tau);

            for (int i = 0; i <= n; i++)
            {
                double k1 = func(t, u);
                double k2 = func(t + tau / 2.0, u + tau * k1 / 2.0);
                double k3 = func(t + tau/2.0, u + tau/2.0 * k2);
                double k4 = func(t + tau, u + tau * k3);
                s += c + "\t" + Math.Round(k1, 4) + "\t" + Math.Round(k2, 4) + "\t" + Math.Round(k3, 4) + "\t" + Math.Round(k4, 4) + "\t" + Math.Round(t, 2) + "\t" + Math.Round(u, 4) + "\n";
                u = u + (tau / 6.0) * (k1 + 2 * k2 + 2*k3+k4);
                t += tau; c++;
            }
            return s;
        }
    }
}
