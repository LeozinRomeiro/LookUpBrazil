using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.ObjectValues
{
    public class CityFromJson
    {
        public class Municipio
        {
            public int Id { get; set; }
            public string Nome { get; set; } = null!;
            public Microrregiao Microrregiao { get; set; } = null!;
        }

        public class Microrregiao
        {
            public int Id { get; set; }
            public string Nome { get; set; } = null!;
            public Mesorregiao Mesorregiao { get; set; } = null!;
        }

        public class Mesorregiao
        {
            public int Id { get; set; }
            public string Nome { get; set; } = null!;
            public UF UF { get; set; } = null!;
        }

        public class UF
        {
            public int Id { get; set; }
            public string Nome { get; set; } = null!;
            public string Sigla { get; set; } = null!;
            public Regiao Regiao { get; set; } = null!;
        }

        public class Regiao
        {
            public int Id { get; set; }
            public string Nome { get; set; } = null!;
            public string Sigla { get; set; } = null!;
        }

    }
}
