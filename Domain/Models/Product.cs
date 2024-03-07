using System;

namespace Domain.Entities
{
    public class Product
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; } // considerei um código numérico por não ter sido definido na descrição
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
