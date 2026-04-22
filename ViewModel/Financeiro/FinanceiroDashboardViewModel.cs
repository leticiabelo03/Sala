namespace Sala.ViewModel
{
    public class FinanceiroDashboardViewModel
    {
        public int TotalPendentes { get; set; }
        public decimal ValorPendente { get; set; }

        public int TotalFaturas { get; set; }
        public decimal ValorFaturado { get; set; }

        public List<Sala.Model.OrdemServico> Pendentes { get; set; } = new();
    }
}