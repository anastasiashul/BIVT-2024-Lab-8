using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2: Purple 
    {
        public string[] Output { get; private set; }
        public Purple_2(string s):base(s) {
            Output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            string[] words = Input.Split(' ');
            string[] res = new string[0];
            StringBuilder temp = new StringBuilder(words[0]);
            for(int i = 1; i < words.Length; i++)
            {
                if(temp.Length +1+words[i].Length <=50)
                {
                    temp.Append($" {words[i]}");
                }
                else
                {
                    /*int razn = 50 - temp.Length;
                    int spaces = (temp.ToString().Split().Length - 1);
                    temp.Replace(" ", new string(' ', 1 + razn/spaces));
                    int ost = razn % spaces;
                    bool post = false;
                    for(int b = 0; b<50; b++)
                    {
                        if (temp.Length == 50) break;
                        if (temp[b] != ' ') post = false;
                        else if(!post)

                        {
                            temp.Append(" ", b, 1);
                            post = true;
                        }
                    }*/
                    CorrectString(ref temp);
                    Array.Resize(ref res, res.Length + 1);
                    res[res.Length - 1] = temp.ToString();
                    temp.Clear();
                    temp.Append(words[i]);

                }

            }
            CorrectString(ref temp);
            Array.Resize(ref res, res.Length + 1);
            res[res.Length - 1] = temp.ToString();
            Output = new string[res.Length];
            Array.Copy(res, Output, res.Length);


        }
        private void CorrectString(ref StringBuilder str)
        {
            int razn = 50 - str.Length;
            int spaces = (str.ToString().Split().Length - 1);
            if (spaces == 0) return;
            str.Replace(" ", new string(' ', 1 + razn / spaces));
            int ost = razn % spaces;
            bool post = false;
            for (int b = 0; b < 50; b++)
            {
                if (str.Length == 50) break;
                if (str[b] != ' ') post = false;
                else if (!post)

                {
                    str.Insert(b, " ");
                    post = true;
                }
            }
        }
        public override string ToString()
        {
            if (Output == null)  return null;
            string answ = "";
            for(int i = 0; i<Output.Length-1; i++)
            {
                answ += Output[i]+"\r\n";
            }
            answ += Output[Output.Length-1];
            return answ;
        }
    }
}
