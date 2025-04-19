using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        public string Output {  get; private set; }
        public (string, char)[] Codes { get; private set; }

        private char[] code;
        public Purple_3(string s) : base(s) {
            Output = null;
            Codes = new (string, char)[5];
            code = new char[5];
        }

        public override void Review()
        {
            if (String.IsNullOrEmpty(Input)) return;
            Output = String.Copy(Input);
            string copy = String.Copy(Input);
            
            string[] pairs = new string[5];
            int[] counts = new int[5];
            
            int count = 0;
            for(int i = 32; i<126; i++)
            {
                if (count >= 5) break;
                if (!copy.Contains((Char)i))
                {
                    code[count++] = (char)i;
                }
            }
            //
            for(int i = 0; i<Input.Length-1; i++)
            {

                string temp = copy.Substring(i, 2);
                if (!Char.IsLetter(temp[0]) || !Char.IsLetter(temp[1])) continue;
                if (pairs.Any(x => x == temp)) continue;
                copy=copy.Replace(temp, code[0].ToString());
                int now =copy.Count(x => x == code[0]);
                if (now > counts[4])
                {
                    counts[4] = now;
                    pairs[4] = temp;
                    int place = 4;
                    while(place>0 && counts[place] > counts[place - 1])
                    {
                        (counts[place], counts[place - 1]) = (counts[place-1], counts[place]);
                        (pairs[place], pairs[place - 1])= (pairs[place-1], pairs[place]);
                        place--;
                    }
                }
                copy=copy.Replace(code[0].ToString(), temp);
                
            }
            for(int i = 0; i<pairs.Length;i++)
            {
                Codes[i] = (pairs[i], code[i]);
                Output = Output.Replace(pairs[i], code[i].ToString());
            }
            

        }


        public override string ToString()
        {
            return Output;
        }
    }
}
