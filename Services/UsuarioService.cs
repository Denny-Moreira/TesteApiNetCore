using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTE_API_ASPNETCORE.Model;

namespace TESTE_API_ASPNETCORE.Services
{
    public interface IUsuarioService
    {
        Usuario Create(Usuario usuario);
        Usuario FindById(int id);
        List<Usuario> FindAll();

        Usuario Update(Usuario usuario);
        void Delete(int id);
    }
    
}
