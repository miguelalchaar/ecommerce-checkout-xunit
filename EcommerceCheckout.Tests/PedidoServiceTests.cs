using EcommerceCheckout.App;

namespace EcommerceCheckout.Tests;

public class PedidoServiceTests
{
    private readonly PedidoService _sut = new();

    [Fact]
    public void GerarCodigoRastreio_DeveRetornarMascaraExata()
    {
        string resultado = _sut.GerarCodigoRastreio("sudeste", 42);

        Assert.Equal("SUDESTE-0042", resultado);
    }

    [Fact]
    public void CalcularPontosFidelidade_DeveRetornarPontosCorretos()
    {
        int resultado = _sut.CalcularPontosFidelidade(150);

        Assert.Equal(30, resultado);
    }

    [Fact]
    public void TemDireitoAFreteGratis_ClienteVipAbaixoDe200_DeveRetornarTrue()
    {
        bool resultado = _sut.TemDireitoAFreteGratis(150, true);

        Assert.True(resultado);
    }

    [Fact]
    public void TemDireitoAFreteGratis_ClienteNaoVipAbaixoDe200_DeveRetornarFalse()
    {
        bool resultado = _sut.TemDireitoAFreteGratis(150, false);

        Assert.False(resultado);
    }
}
