using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : IUsuarioRepository
{

    private readonly ApplicationDbContext _usuarioContex;
    private readonly IAutenticacao _autenticacao;
    public UsuarioRepository(ApplicationDbContext usuarioContex, IAutenticacao autenticacao)
    {
        _usuarioContex = usuarioContex;
        _autenticacao = autenticacao;
    }

    public async Task AdicionarUsuario(Usuario usuario)
    {
        var usuarioResult = await _autenticacao.RegistrarUsuario(usuario.Login, usuario.Senha);

        if (usuarioResult)
            await _usuarioContex.Usuarios.AddAsync(usuario);

        if (await _usuarioContex.SaveChangesAsync() == 0)
            await _autenticacao.RemoverUsuario(usuario.Login);

    }

    public async Task<IEnumerable<Usuario>> ObterUsuarios()
    => await _usuarioContex.Usuarios
                           .Where(u => u.Ativo == true)
                           .ToListAsync();

    public async Task RemoverUsuario(Guid id)
    {
        var usuario = await Obterusuario(id);

        if (usuario == null) return;

        usuario.Ativo = false;
        AtualizaUsuario(usuario);

    }

    private void AtualizaUsuario(Usuario usuario)
        => _usuarioContex.Set<Usuario>().Update(usuario);

    private async Task<Usuario> Obterusuario(Guid id)
        => await _usuarioContex.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
}


