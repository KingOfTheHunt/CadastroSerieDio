using System;
using System.Collections.Generic;
using System.Linq;
using CadastroSerie.Entidades;
using CadastroSerie.Interfaces;

namespace CadastroSerie.Repositorios
{
    // Implementando os métodos do crud que foi definido na interface.
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> _series = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            _series[id] = entidade;
        }

        public void Exclui(int id)
        {
            if (Existe(id) == false)
            {
                throw new Exception("Não foi possível realizar a exclusão, pois " +
                    "não há uma série com este id.");
            }
          
            _series.Where(s => s.GetId == id).FirstOrDefault().Ativo = false;
        }

        public void Insere(Serie serie)
        {
            if (serie == null)
            {
                throw new ArgumentNullException("A série não pode ser nula.");
            }
            _series.Add(serie);
        }

        public List<Serie> Lista()
        {
            if (_series.Count == 0)
            {
                throw new Exception("Não há nenhuma série na sua lista.");
            }

            return _series.Where(s => s.Ativo == true).ToList();
        }

        public int ProximoId()
        {
            return _series.Count + 1;
        }

        public Serie RetornaPorId(int id)
        {
            if (Existe(id) == false)
            {
                throw new Exception("Não existe nenhuma série com este id.");
            }

            return _series.Where(s => s.GetId == id && s.Ativo == true).FirstOrDefault();
        }

        public bool Existe(int id)
        {
            if (_series.Any(s => s.GetId == id) == false)
            {
                return false;
            }

            return true;
        }
    }
}
