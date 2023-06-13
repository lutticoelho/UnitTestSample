namespace UnitTestSample
{
    public class PessoaDAO
    {

        IRHService _rhservice;
        public PessoaDAO(IRHService rhservice)
        {
            _rhservice = rhservice;
        }

        public bool ExistePessoa(String nome)
        {
            List<Pessoa> pessoas = _rhservice.GetAllPessoas();
            foreach (Pessoa p in pessoas)
            {
                if (p.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }

}
