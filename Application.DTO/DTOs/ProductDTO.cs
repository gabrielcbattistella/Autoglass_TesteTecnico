using System;

namespace Application.DTOs
{
    public class ProductDTO
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
