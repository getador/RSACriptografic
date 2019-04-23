using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace RSACriptografic.Classes
{
    class CriptoWorker
    {
        uint p;
        uint q;
        uint n;
        uint m;
        uint d;
        uint e;

        public CriptoWorker(int maxValue,Random random)
        {
            if (maxValue<2)
            {
                maxValue = 3;
            }
            p = 0;
            q = 0;
            while (!SimpleNumberWorker.IsPrime(p))
            {
                p = (uint)random.Next(2,maxValue);
            }
            while (!SimpleNumberWorker.IsPrime(q))
            {
                q = (uint)random.Next(2, maxValue);
            }
            n = p * q;
            m = (p - 1) * (q - 1);
            d = m;
            while (!SimpleNumberWorker.IsMutuallyPrimary(d,m))
            {
                d = (uint)random.Next((int)m-1);
            }
            e = FindEelement(random);
        }

        public CriptoWorker(uint p, uint q, uint n, uint m, uint d, uint e)
        {
            this.p = p;
            this.q = q;
            this.n = n;
            this.m = m;
            this.d = d;
            this.e = e;
        }

        /// <summary>
        /// Шифрование RSA
        /// </summary>
        /// <param name="message">Сообщение для зашифровки</param>
        /// <param name="e">Первый элемент открытого ключа</param>
        /// <param name="n">Второй элемент открытого ключа</param>
        /// <returns>Зашифрованое сообщение</returns>
        public string Encript(string message)
        {
            message = message.ToLower();
            string encriptMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                int index = 0;
                for (int j = 0; j < Alphabet.alphabet.Length; j++)
                {
                    if (message[i]==Alphabet.alphabet[j])
                    {
                        index = j;
                        break;
                    }
                }
                if (index<n)
                {
                    encriptMessage += Convert.ToString((int)(Math.Pow(index, e) % n)) + "|";
                }
                else
                {
                    encriptMessage += " ";
                }
            }
            using (StreamWriter stream = new StreamWriter("1.txt", false))
            {
                stream.WriteLine(encriptMessage);
                stream.WriteLine(ToString());
            }
            return encriptMessage;
        }
        public string ToUnEncript(string message)
        {
            string unEncriptMessage = "";
            string[] arrayElement = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrayElement.Length; i++)
            {
                //try
                //{
                //unEncriptMessage += Convert.ToString((int)(Math.Pow(int.Parse(arrayElement[i]), d) % n)) + "|";
                unEncriptMessage += Convert.ToString(Alphabet.alphabet[(int)(Math.Pow(int.Parse(arrayElement[i]), d) % n)]);
                //}
                //catch (Exception)
                //{
                //}                
            }
            using (StreamWriter stream = new StreamWriter("2.txt",false))
            {
                stream.WriteLine(unEncriptMessage);
                stream.WriteLine(ToString());
            }
            return unEncriptMessage;
        }
        public uint FindEelement(Random random)
        {
            uint element = 0;
            while (!(element*d%m==1))
            {
                element = (uint)random.Next((int)m - 1);
            }
            //for (int i = 0; i < m; i++)
            //{
            //    if ((i*d)%m==1)
            //    {
            //        element = (uint)i;
            //        break;
            //    }
            //}
            return element;
        }
        public override string ToString()
        {
            return $"P={p} Q={Q} M={M} D={D} E={E} N={N}";
        }
        public uint P { get => p; set => p = value; }
        public uint Q { get => q; set => q = value; }
        public uint M { get => m; set => m = value; }
        public uint D { get => d; set => d = value; }
        public uint E { get => e; set => e = value; }
        public uint N { get => n; set => n = value; }
    }
}
