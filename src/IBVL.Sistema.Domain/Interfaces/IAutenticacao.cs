namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IAutenticacao
    {
        Task<bool> UsuarioEstaAutenticado(string email, string senha);
        Task<bool> RegistrarUsuario(string email, string senha);
        Task Logout();

    }
}
