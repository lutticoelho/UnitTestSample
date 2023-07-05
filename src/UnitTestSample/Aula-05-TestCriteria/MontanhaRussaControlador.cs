namespace UnitTestSample.Aula_05_TestCriteria
{
    public class MontanhaRussaControlador
    {
        IClienteDao clienteDao;

        public MontanhaRussaControlador(IClienteDao pClienteDao)
        {
            clienteDao = pClienteDao;
        }

        public String Autorizar(String nome, int idade)
        {
            if (!ValidarNome(nome)) 
            {
                throw new ArgumentException("Argumento inválido", nameof(nome));
            }

            if (!ValidarIdade(idade))
            {
                throw new ArgumentException("Argumento inválido", nameof(idade));
            }

            if (!clienteDao.ehCliente(nome))
            {
                throw new ArgumentOutOfRangeException(nameof(nome), "Não é um cliente");
            }

            var result = "acompanhado do responsavel legal";

            if (idade is >= 18 and <= 90)
            {
                result = "autorizado";
            }
            else if (idade < 18)
            {
                result = "acompanhado dos pais";
            }

            return result;
        }

        private bool ValidarNome(string nome)
        {
            var nomes = nome.Split(' ');

            var possuiMinimoDoisNomes = nomes.Length > 1;
            var todosCaracteresSaoLetrasOuEspaco = nomes.All(_ => _.All(char.IsLetter));

            return possuiMinimoDoisNomes && todosCaracteresSaoLetrasOuEspaco;
        }

        private bool ValidarIdade(int idade) 
        {
            return idade is >= 1 and <= 120;
        }
    }
}
