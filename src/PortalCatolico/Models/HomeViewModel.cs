using PortalCatolico.Controllers;

namespace PortalCatolico.Models
{
    public class HomeViewModel
    {
        public SantoDia SantoDoDia { get; set; }
        public LiturgiaController.Root Liturgia { get; set; }
    }
}