using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA240130
{
    internal class Allomas
    {
        public List<int> Csapadekok { get; set; }
        public int OsszEso { get; set; }

        public Allomas(string sor)
        {
            var atmeneti = sor.Split(';');
            this.Csapadekok = new();

            for (int i = 0; i < atmeneti.Length; i++)
            {
                this.Csapadekok.Add(Convert.ToInt32(atmeneti[i]));
            }
            this.OsszEso = Csapadekok.Sum();
        }

        public override string ToString()
        {
            return string.Join($", ",this.Csapadekok);
        }
    }
}
