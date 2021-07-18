using System;
using System.Collections.Generic;
using System.Linq;

namespace INSS
{
    public class CalculadorInss : ICalculadorInss
    {
        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            var tabela = ObterTabelasContribuicao().FirstOrDefault(c => c.Ano == data.Year);
            var faixa = tabela.FaixasContribuicao.FirstOrDefault(f => f.MinimoSalario <= salario && f.MaximoSalario >= salario);

            if (faixa == null)
            {
                return tabela.Teto;
            }

            var resultado = faixa.Aliquota * salario;

            return resultado;
        }

        private List<TabelaContribuicao> ObterTabelasContribuicao()
        {
            return new List<TabelaContribuicao>
            {
                new TabelaContribuicao
                {
                    Ano = 2011,
                    Teto = 405.86m,
                    FaixasContribuicao = new List<FaixaContribuicao>
                    {
                        new FaixaContribuicao { MaximoSalario = 1106.9m, Aliquota = 0.08m },
                        new FaixaContribuicao { MinimoSalario = 1106.91m, MaximoSalario = 1844.83m, Aliquota = 0.09m },
                        new FaixaContribuicao { MinimoSalario = 1844.84m, MaximoSalario = 3689.66m, Aliquota = 0.11m }
                    }
                },
                new TabelaContribuicao
                {
                    Ano = 2012,
                    Teto = 500m,
                    FaixasContribuicao = new List<FaixaContribuicao>
                    {
                        new FaixaContribuicao { MaximoSalario = 1000m, Aliquota = 0.07m },
                        new FaixaContribuicao { MinimoSalario = 1000.01m, MaximoSalario = 1500m, Aliquota = 0.08m },
                        new FaixaContribuicao { MinimoSalario = 1500.01m, MaximoSalario = 3000m, Aliquota = 0.09m },
                        new FaixaContribuicao { MinimoSalario = 3000.01m, MaximoSalario = 4000m, Aliquota = 0.11m }
                    }
                }
            };
        }
    }
}
