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
            var serie = _series.Where(s => s.GetId == id).FirstOrDefault();

            if (serie != null)
            {
                serie = entidade;
                _series[id] = entidade;
            }
        }

        public void Exclui(int id)
        {
            bool existe = _series.Where(s => s.GetId == id).Any();

            if (!existe)
            {
                throw new Exception("Não existe nenhuma série com este id.");
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
            return _series.Where(s => s.Ativo == true).ToList();
        }

        public int ProximoId()
        {
            return _series.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return _series.Where(s => s.GetId == id).FirstOrDefault();
        }
    }
}
