using System.Collections.Generic;

namespace INSS
{
    public class TabelaContribuicao
    {
        public int Ano { get; set; }
        public decimal Teto { get; set; }
        public List<FaixaContribuicao> FaixasContribuicao { get; set; }
    }
}
