using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Aula_04_MutationTests
{
    public class Pessoa
    {
        private String nome;
        private int idade;
        public Pessoa(String pNome, int pIdade)
        {
            nome = pNome;
            idade = pIdade;
        }

        public String getNome() { return nome; }

        public int getIdade() { return idade; }
    }

    public class Original
    {
        public String definirFaixaEtaria(Pessoa p)
        {
            if (p.getIdade() < 0 || p.getIdade() >= 110)
                throw new ArgumentException("idade invalida");

            int idade = p.getIdade();
            String tipo = "";
            if (idade <= 11)
                tipo = "crianca";
            else if (idade <= 18)
                tipo = "adolescente";
            else if (idade <= 59)
                tipo = "adulto";
            else
                tipo = "idoso";

            return p.getNome() + " eh " + tipo;
        }
    }

    public class Mutante1
    {
        public String definirFaixaEtaria(Pessoa p)
        {
            if (p.getIdade() < 0 && p.getIdade() >= 110) // '||' -> '&&'
                throw new ArgumentException("idade invalida");

            int idade = p.getIdade();
            String tipo = "";
            if (idade <= 11)
                tipo = "crianca";
            else if (idade <= 18)
                tipo = "adolescente";
            else if (idade <= 59)
                tipo = "adulto";
            else
                tipo = "idoso";

            return p.getNome() + " eh " + tipo;
        }
    }

    public class Mutante2
    {
        public String definirFaixaEtaria(Pessoa p)
        {
            if (p.getIdade() < 0 || p.getIdade() >= 110)
                throw new ArgumentException("idade invalida");

            int idade = p.getIdade();
            String tipo = "";
            if (idade <= 11)
                tipo = "crianca";
            else if (idade < 18) //'<=' -> '<'
                tipo = "adolescente";
            else if (idade <= 59)
                tipo = "adulto";
            else
                tipo = "idoso";

            return p.getNome() + " eh " + tipo;
        }
    }

    public class Mutante3
    {
        public String definirFaixaEtaria(Pessoa p)
        {
            if (p.getIdade() < 0 || p.getIdade() >= 110)
                throw new ArgumentException("idade invalida");

            int idade = p.getIdade();
            String tipo = "";
            if (idade <= 11)
                tipo = "crianca";
            else if (idade <= 18)
                tipo = "adolescente";
            else if (idade == 59) //'<=' -> '=='
                tipo = "adulto";
            else
                tipo = "idoso";

            return p.getNome() + " eh " + tipo;
        }
    }

}
