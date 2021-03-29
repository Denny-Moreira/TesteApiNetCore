using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTE_API_ASPNETCORE.Services;
using TESTE_API_ASPNETCORE.Model;

namespace TESTE_API_ASPNETCORE.Services
{
    public class UsuarioServiceImplementation : IUsuarioService
    {

        private SqlContext _context;

        public UsuarioServiceImplementation(SqlContext context)
        {
            _context = context;
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuario.ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuario.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Usuario Create(Usuario usuario)
        {
            try
            {
                _context.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }

        public Usuario Update(Usuario usuario)
        {
            if (!Exits(usuario.Id)) return new Usuario();

            var result = _context.Usuario.SingleOrDefault(p => p.Id.Equals(usuario.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(usuario);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return usuario;
        }

        public void Delete(int id)
        {
            var result = _context.Usuario.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Usuario.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool Exits(long id)
        {
            return _context.Usuario.Any(p => p.Id.Equals(id));
        }
    }
}
