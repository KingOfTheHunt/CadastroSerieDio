using System.Collections.Generic;

namespace CadastroSerie.Interfaces
{
    // Defindo os métodos do crud
    interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T t);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
