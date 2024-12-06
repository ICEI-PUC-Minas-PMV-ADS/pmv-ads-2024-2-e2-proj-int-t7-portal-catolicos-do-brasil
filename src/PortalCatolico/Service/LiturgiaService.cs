using PortalCatolico.Interfaces;

namespace PortalCatolico.Service
{
    public class LiturgiaService : ILiturgiaService
    {
        private readonly HttpClient _httpClient;

        public LiturgiaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObterLiturgiaDiariaAsync(DateTime date)
        {
            //var formattedDate = date.ToString("dd-MM");
            var response = await _httpClient.GetAsync("https://liturgia.up.railway.app/05-11");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}