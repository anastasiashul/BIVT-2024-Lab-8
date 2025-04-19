using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        public string Output { get; private set; }
        
        private string elements = new string(new char[] { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/'   });
        
        
        public override void Review()
        {
            if (Input == null) return;
            string[] words = Input.Split();  
            for(int i = 0; i<words.Length; i++)
            {
                words[i] = Rev(words[i]);
            }
            Output = String.Join(" ",  words);
        }
        private string Rev(string inp)
        {
            if (inp == "") return "";
            string copy = "";
            string ans = "";
            for (int i = 0; i < inp.Length; i++)
            {
                if (Char.IsDigit(inp[i]))  return inp;
                if (!(elements.Contains(inp[i])) )
                {
                    copy += inp[i];
                }
                else
                {
                    for (int j = copy.Length - 1; j >= 0; j--)
                    {
                        ans += copy[j];
                    }
                    ans += inp[i];
                    copy = "";
                }

            }
            if(!(elements.Contains(inp[inp.Length-1])))
            {
                for (int j = copy.Length - 1; j >= 0; j--)
                {
                    ans +=  copy[j];
                }
            }
            return ans;
        }
        public Purple_1(string s) : base(s)
        {
            Output = null;    
        }
        public override string ToString()   
        {

            return Output;
        }

    }
}
