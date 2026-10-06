using ControleEstoque.Models;
using ControleEstoque.Services;

namespace ControleEstoque.Tests;

public class EstoqueServiceTests
{
    [Fact]
    public void DeveRealizarEntradaDeEstoque()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act
        var movimentacao = service.RealizarMovimentacao(
            101,
            "Entrada",
            50,
            "Reposição de mercadoria"
        );

        // Assert
        Assert.Equal(200, produtos[0].Estoque);
        Assert.Equal(1, movimentacao.Id);
        Assert.Equal(101, movimentacao.CodigoProduto);
        Assert.Equal("Entrada", movimentacao.Tipo);
        Assert.Equal(50, movimentacao.Quantidade);
    }


    [Fact]
    public void DeveRealizarSaidaDeEstoque()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act
        var movimentacao = service.RealizarMovimentacao(
            101,
            "Saída",
            30,
            "Venda para cliente"
        );

        // Assert
        Assert.Equal(120, produtos[0].Estoque);
        Assert.Equal(1, movimentacao.Id);
        Assert.Equal("Saída", movimentacao.Tipo);
        Assert.Equal(30, movimentacao.Quantidade);
    }


    [Fact]
    public void DeveGerarIdsDiferentesParaMovimentacoes()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act
        var primeiraMovimentacao = service.RealizarMovimentacao(
            101,
            "Entrada",
            10,
            "Primeira entrada"
        );

        var segundaMovimentacao = service.RealizarMovimentacao(
            101,
            "Saída",
            5,
            "Primeira saída"
        );

        // Assert
        Assert.Equal(1, primeiraMovimentacao.Id);
        Assert.Equal(2, segundaMovimentacao.Id);
    }


    [Fact]
    public void DeveLancarErroQuandoProdutoNaoForEncontrado()
    {
        // Arrange
        var produtos = new List<Produto>();

        var service = new EstoqueService(produtos);

        // Act & Assert
        var excecao = Assert.Throws<Exception>(() =>
            service.RealizarMovimentacao(
                999,
                "Entrada",
                10,
                "Produto inexistente"
            )
        );

        Assert.Equal(
            "Produto não encontrado.",
            excecao.Message
        );
    }


    [Fact]
    public void DeveLancarErroQuandoQuantidadeForZero()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act & Assert
        var excecao = Assert.Throws<Exception>(() =>
            service.RealizarMovimentacao(
                101,
                "Entrada",
                0,
                "Quantidade inválida"
            )
        );

        Assert.Equal(
            "A quantidade deve ser maior que zero.",
            excecao.Message
        );
    }


    [Fact]
    public void DeveLancarErroQuandoQuantidadeForNegativa()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act & Assert
        var excecao = Assert.Throws<Exception>(() =>
            service.RealizarMovimentacao(
                101,
                "Entrada",
                -10,
                "Quantidade inválida"
            )
        );

        Assert.Equal(
            "A quantidade deve ser maior que zero.",
            excecao.Message
        );
    }


    [Fact]
    public void DeveLancarErroQuandoEstoqueForInsuficiente()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 10
            }
        };

        var service = new EstoqueService(produtos);

        // Act & Assert
        var excecao = Assert.Throws<Exception>(() =>
            service.RealizarMovimentacao(
                101,
                "Saída",
                20,
                "Venda"
            )
        );

        Assert.Equal(
            "Estoque insuficiente.",
            excecao.Message
        );

        // O estoque não deve ser alterado
        Assert.Equal(10, produtos[0].Estoque);
    }


    [Fact]
    public void DeveLancarErroQuandoTipoForInvalido()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act & Assert
        var excecao = Assert.Throws<Exception>(() =>
            service.RealizarMovimentacao(
                101,
                "Transferência",
                10,
                "Transferência entre depósitos"
            )
        );

        Assert.Equal(
            "Tipo de movimentação inválido.",
            excecao.Message
        );

        // O estoque não deve ser alterado
        Assert.Equal(150, produtos[0].Estoque);
    }


    [Fact]
    public void DeveAceitarEntradaComLetraMinuscula()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act
        service.RealizarMovimentacao(
            101,
            "entrada",
            20,
            "Reposição"
        );

        // Assert
        Assert.Equal(170, produtos[0].Estoque);
    }


    [Fact]
    public void DeveAceitarSaidaComLetraMinuscula()
    {
        // Arrange
        var produtos = new List<Produto>
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var service = new EstoqueService(produtos);

        // Act
        service.RealizarMovimentacao(
            101,
            "saída",
            20,
            "Venda"
        );

        // Assert
        Assert.Equal(130, produtos[0].Estoque);
    }
}