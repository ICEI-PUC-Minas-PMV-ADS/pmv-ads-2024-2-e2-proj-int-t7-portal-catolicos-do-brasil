using PortalCatolicoBrasil.Interfaces;

namespace PortalCatolicoBrasil.Service
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
            var formattedDate = date.ToString("dd-MM");
            var response = await _httpClient.GetAsync($"https://liturgiadiaria.site/{formattedDate}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}