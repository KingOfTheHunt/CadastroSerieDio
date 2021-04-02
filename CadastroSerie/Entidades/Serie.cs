using System;
using System.Text;
using CadastroSerie.Enums;

namespace CadastroSerie.Entidades
{
    public class Serie : EntidadeBase
    {
        private float _nota;

        private Genero _genero;
        private string _titulo;
        private string _descricao;
        private DateTime _ano;
        private bool _ativo;
        

        public Serie(int id, Genero genero, string titulo, string descricao, DateTime ano, float nota)
        {
            Id = id;
            _genero = genero;
            _titulo = titulo;
            _descricao = descricao;
            _ano = ano;
            Nota = nota;
            _ativo = true;
        }

        private float Nota 
        {
            get { return _nota; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("O valor da nota não pode ser menor do que " +
                        "0 ou maior do que 10.");
                }

                _nota = value;
            }
        }
        
        public int GetId
        {
            get { return Id; }
        }

        public string GetTitulo
        {
            get { return _titulo; }
        }

        public bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Gênero: {_genero}");
            sb.AppendLine($"Título: {_titulo}");
            sb.AppendLine($"Descrição: {_descricao}");
            sb.AppendLine($"Ano de início: {_ano.Year}");
            sb.AppendLine($"Nota: {Nota}");

            return sb.ToString();
        }
    }
}
