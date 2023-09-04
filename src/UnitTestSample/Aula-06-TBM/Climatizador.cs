using Microsoft.CSharp.RuntimeBinder;

namespace UnitTestSample.Aula_06_TBM
{
    public class Climatizador
    {
        private bool _ligado = false, _umid = false;
        private int _velAtual = 0;
        public int velocidade() { return _velAtual; }

        public bool umidificando() { return _umid; }
        public void umidificar() { _umid = !_umid; }

        public void ligar()
        {
            if (_ligado) throw new RuntimeBinderException();

            _ligado = _umid = true;
            _velAtual = 1;
        }
        public void desligar()
        {
            if (!_ligado) throw new RuntimeBinderException();

            _ligado = _umid = false;
            _velAtual = 0;
        }

        public bool aumentarV()
        {
            if (_velAtual == 2) return false;

            _velAtual++;
            return true;
        }

        public bool diminuirV()
        {
            if (_velAtual <= 1) return false;

            _velAtual--;
            return true;
        }
    }
}
