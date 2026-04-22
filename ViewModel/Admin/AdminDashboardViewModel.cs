using Sala.Model;

namespace Sala.ViewModel
{
    public class AdminDashboardViewModel
    {
        public int TotalUsuarios { get; set; }
        public int TotalUsuariosAtivos { get; set; }

        public int TotalChamados { get; set; }
        public int ChamadosAbertos { get; set; }
        public int ChamadosFechados { get; set; }

        public int TotalOrdensServico { get; set; }
        public int OsPendentes { get; set; }
        public int OsConcluidas { get; set; }

        public int TotalFaturas { get; set; }
        public int FaturasPendentes { get; set; }
        public int FaturasPagas { get; set; }

        public decimal FaturamentoTotal { get; set; }

        public List<Chamado> UltimosChamados { get; set; } = new();
        public List<Fatura> UltimasFaturas { get; set; } = new();
    }
}