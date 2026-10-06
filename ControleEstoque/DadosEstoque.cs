using ControleEstoque.Models;

namespace ControleEstoque;

public static class DadosEstoque
{
    public static List<Produto> Produtos = new()
    {
        new Produto
        {
            CodigoProduto = 101,
            DescricaoProduto = "Caneta Azul",
            Estoque = 150
        },

        new Produto
        {
            CodigoProduto = 102,
            DescricaoProduto = "Caderno Universitário",
            Estoque = 75
        },

        new Produto
        {
            CodigoProduto = 103,
            DescricaoProduto = "Borracha Branca",
            Estoque = 200
        },

        new Produto
        {
            CodigoProduto = 104,
            DescricaoProduto = "Lápis Preto HB",
            Estoque = 320
        },

        new Produto
        {
            CodigoProduto = 105,
            DescricaoProduto = "Marcador de Texto Amarelo",
            Estoque = 90
        }
    };
}