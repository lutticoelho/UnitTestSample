namespace UnitTestSample.Aula_03_BranchCoverage
{
    public class Resolvedor
    {
        private IClienteRepo repo;
        public Resolvedor(IClienteRepo repo) { this.repo = repo; }
        public List<Cliente> DefinirPromocao(int[] cods)
        {
            
            if (cods == null || cods.Count() == 0) // #1 - #2
                throw new ArgumentException("sem codigo algum"); //#3

            var clientes = new List<Cliente>(); // #4
            foreach (int cod in cods) // #5 - #6
            {
                Cliente c = repo.GetCliente(cod); // #7
                if (c == null)  // #8
                    throw new Exception("Codigo do cliente nao valido");  // #9
                clientes.Add(c);  // #10
            }
            var resposta = new List<Cliente>();  // #11
            if (clientes.Count() >= 3)  // #12
            {
                // todos ganham 25% de desconto
                foreach (Cliente c in clientes)  //#13 - #14
                {
                    c.setDesconto(25); // #15
                    resposta.Add(c);
                }
            }
            else
            {
                // o 1º cliente ganha 15%
                clientes[0].setDesconto(15); // #16
                resposta.Add(clientes[0]);
                //e, se existir, o 2º ganha 10%
                if (clientes.Count() > 1) // #17
                {
                    clientes[1].setDesconto(10); // #18
                    resposta.Add(clientes[1]);
                }
            }
            return resposta; // #19
        }
    }
}
