using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Unitarios
{
    public class SugestaoTest
    {
        [Fact]
        public void CriarSugestaoValida()
        {
            var departamento = new Departamento("Departamento");
            var sugestao = new Sugestao("Gabriel", departamento, "justificativa", "descriçao");
            Assert.True(departamento.IsValid && sugestao.IsValid);
        }
        [Fact]
        public void CriarSugestaoInvalida()
        {
            var departamento = new Departamento("Departamento");
            var sugestao = new Sugestao("Gabriel", departamento, "", "");
            Assert.True(departamento.IsValid && !sugestao.IsValid);
        }
        [Fact]
        public void CriarSugestaoValidaDepartamentoInvalido()
        {
            var departamento = new Departamento("");
            var sugestao = new Sugestao("Gabriel", departamento, "justificativa", "descriçao");
            Assert.True(!departamento.IsValid && !sugestao.IsValid);
        }
    }
}
