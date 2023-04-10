namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IAutenticacao
    {
        Task<bool> UsuarioEstaAutenticadoAsync(string email, string senha);
        Task<bool> RegistrarUsuarioAsync(string email, string senha);
        Task<bool>RemoverUsuarioAsync (string email);   
        Task LogoutAsync();

    }
}
