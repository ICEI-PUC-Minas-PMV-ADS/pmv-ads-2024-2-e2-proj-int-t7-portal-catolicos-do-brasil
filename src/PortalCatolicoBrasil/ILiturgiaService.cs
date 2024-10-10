namespace PortalCatolicoBrasil.Interfaces
{
    public interface ILiturgiaService
    {
        Task<string> ObterLiturgiaDiariaAsync(DateTime date);
    }
}
