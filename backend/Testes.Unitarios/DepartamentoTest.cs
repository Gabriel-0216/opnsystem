
using Xunit;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Testes.Unitarios
{
    public class DepartamentoTest
    {
        [Fact]
        public void CriarDepartamentoValido()
        {
            var departamento = new Departamento("Departamento teste");
            Assert.True(departamento.IsValid);
        }
        [Fact]
        public void CriarDepartamentoInvalido()
        {
            var departamento = new Departamento("");
            Assert.True(!departamento.IsValid);
        }
        [Fact]
        public void AdicionarSugestaoValida()
        {
            var departamento = new Departamento("Departamento teste");
            var sugestao = new Sugestao("Gabriel", departamento, "Justificativa", "Descrição");
            departamento.AdicionarSugestao(sugestao);
            Assert.True(departamento.IsValid && sugestao.IsValid && departamento.Sugestoes.Count > 0);
        }
        [Fact]
        public void AdicionarSugestaoInvalida()
        {
            var departamento = new Departamento("Departamento teste");
            var sugestao = new Sugestao("Gabriel", departamento, "", "");
            departamento.AdicionarSugestao(sugestao);
            Assert.True(departamento.IsValid && !sugestao.IsValid && departamento.Sugestoes.Count == 0);

        }
        [Fact]
        public void EditarDepartamentoValidoDeixarInvalido()
        {
            var departamento = new Departamento("Departamento teste");
            departamento.EditarNome("");
            Assert.True(!departamento.IsValid);
        }
    }
}
