namespace UnitTestSample.Aula_02_Mock
{
    public class Somatoria
    {
        IMathOps _mathOps;
        public Somatoria(IMathOps mathOps)
        {
            _mathOps = mathOps;
        }

        /// <summary>
        /// Calcula fatoriais e soma os resultados.
        /// </summary>
        /// <param name="numeros">Array de números</param>
        /// <returns>A somatoria do fatorial de cada inteiro no array numeros</returns>
        public int SomaDeFatoriais(int[] numeros)
        {
            var soma = 0;
            foreach (var num in numeros)
                soma += _mathOps.Fatorial(num);

            return soma;
        }
    }
}
