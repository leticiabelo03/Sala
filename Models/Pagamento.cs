using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Sala.Model
{
    public class Pagamento
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("faturaId")]
        public int FaturaId { get; set; }

        [Column("dataPagamento")]
        public DateTime DataPagamento { get; set; }

        [Column("valorPago")]
        public decimal ValorPago { get; set; }

        [Column("metodo")]
        public MetodoPagamentoEnum Metodo { get; set; }

        public Fatura? Fatura { get; set; }
    }

    public enum MetodoPagamentoEnum
    {
        [Description("Pix")]
        Pix,

        [Description("Cartao")]
        Cartao,

        [Description("Boleto")]
        Boleto,

        [Description("Dinheiro")]
        Dinheiro
    }
}