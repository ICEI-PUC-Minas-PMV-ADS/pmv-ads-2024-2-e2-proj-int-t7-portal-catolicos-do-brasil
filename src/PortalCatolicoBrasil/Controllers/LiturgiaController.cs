using Microsoft.AspNetCore.Mvc;
using PortalCatolicoBrasil.Interfaces;
using PortalCatolicoBrasil.Utils;


namespace PortalCatolicoBrasil.Controllers
{
    public class LiturgiaController : Controller
    {
        private readonly ILiturgiaService _liturgiaService;

        public LiturgiaController(ILiturgiaService liturgiaService)
        {
            _liturgiaService = liturgiaService;
        }

        // Método para obter a liturgia baseada na data atual
        [HttpGet("liturgia")]
        public async Task<IActionResult> ObterLiturgia()
        {
            var currentDate = DateUtils.GetCurrentDate();
            var liturgia = await _liturgiaService.ObterLiturgiaDiariaAsync(currentDate);
            return Content(liturgia, "text/html");
        }
    }
}
