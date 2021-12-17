using ApiTeste.Data;
using ApiTeste.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Services
{
    public class UsuarioService : BaseService
    {
        private readonly Context _context;

        public UsuarioService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>?> GetUsuariosAsync()
        {            
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch
            {
                Errors.Add("Erro interno com o servidor.");
                return null;
            }                
        }

        public async Task<Usuario?> GetByIdAsync(int codigo) 
        {
            if (codigo <= 0) 
            {
                return null;
            }

            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(x => x.Codigo == codigo);
            }
            catch
            {
                Errors.Add("Erro interno com o servidor.");
                return null;
            }
        }

        public async Task<bool> AddUsuarioAsync(Usuario usuario) 
        {
            if (!usuario.Validate()) 
            {
                AddErrors(usuario.GetErrors());
                return false;
            }

            try
            {
                var sexo = _context.Sexos.FirstOrDefault(x => x.Id == usuario.SexoId);
                var tipoPessoa = _context.TipoPessoas.FirstOrDefault(x => x.Id == usuario.TipoPessoaId);
                var model = _context.Usuarios.FirstOrDefault(x => x.Codigo == usuario.Codigo);

                if (sexo == null)
                    AddError("Sexo inexistente");
                if (tipoPessoa == null)
                    AddError("Tipo de Pessoa inexistente");
                if (model != null)
                    AddError("Já existe um usuário cadastrado com este código");

                if (HasError)
                    return false;
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Errors.Add("Erro interno com o servidor." + " Exception: "+e.InnerException);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateUsuarioAsync(Usuario usuario, int codigoAtual)
        {
            if (!usuario.Validate())
            {
                AddErrors(usuario.GetErrors());
                return false;
            }

            try
            {
                var sexo = _context.Sexos.FirstOrDefault(x => x.Id == usuario.SexoId);
                var tipoPessoa = _context.TipoPessoas.FirstOrDefault(x => x.Id == usuario.TipoPessoaId);
                if (sexo == null)
                    AddError("Sexo inexistente");
                if (tipoPessoa == null)
                    AddError("Tipo de Pessoa inexistente");
                if(HasError)
                    return false;

                var model = _context.Usuarios.FirstOrDefault(x => x.Codigo == codigoAtual);
                if (model != null)
                {
                    if (usuario.Codigo != codigoAtual) 
                    {
                        var verifyModel = _context.Usuarios.FirstOrDefault(x => x.Codigo == usuario.Codigo);
                        if (verifyModel != null)
                        {
                            AddError("Já existe um usuário cadastrado com este novo código");
                            return false;
                        }
                        Usuario newModel = new Usuario(usuario.Codigo, usuario.Nome, usuario.SexoId, usuario.TipoPessoaId);
                        await _context.Usuarios.AddAsync(newModel);
                        await _context.SaveChangesAsync(); 
                        _context.Usuarios.Remove(model);
                        await _context.SaveChangesAsync();
                        return true;
                    }                    
                    model.Update(usuario.Codigo ,usuario.Nome, usuario.SexoId, usuario.TipoPessoaId);
                    await _context.SaveChangesAsync();
                    return true;
                }
                AddError("Nenhum usuário encontrado");
                return false;
            }
            catch (Exception e)
            {
                Errors.Add("Erro interno com o servidor." + " Exception: " + e.InnerException);
                return false;
            }
        }

        public async Task<bool> DeleteUsuarioAsync(int codigo) 
        {
            try
            {
                var model = _context.Usuarios.FirstOrDefault(x => x.Codigo == codigo);
                if (model != null)
                {
                    _context.Remove(model);
                    await _context.SaveChangesAsync();
                    return true;
                }
                AddError("Nenhum usuário encontrado");
                return false;
            }
            catch (Exception e)
            {
                Errors.Add("Erro interno com o servidor." + " Exception: " + e.InnerException);
                return false;
            }
        }
    }
}
