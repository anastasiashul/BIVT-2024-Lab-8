using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4:Purple
    {
        public string Output {  get; private set; }
        private (string, char)[] _cods;
        public Purple_4(string s, (string, char)[] codes):base(s)
        {
            Output = null;
            _cods = codes;
        }

        public override void Review()
        {
            if (Input==null) return;
            Output = "";
            string copy =  String.Copy(Input);
            for (int i = 0; i < _cods.Length; i++)
            {

                copy = copy.Replace(_cods[i].Item2.ToString(), _cods[i].Item1);
            }
            Output = string.Copy(copy.ToString());
            
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
