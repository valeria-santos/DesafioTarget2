using ControleEstoque.Models;

namespace ControleEstoque.Services;

public class EstoqueService
{
    private readonly List<Produto> produtos;

    private int proximoId = 1;

    public EstoqueService(List<Produto> produtos)
    {
        this.produtos = produtos;
    }

    public MovimentacaoEstoque RealizarMovimentacao(
        int codigoProduto,
        string tipo,
        int quantidade,
        string descricao)
    {
        Produto? produto = produtos
            .FirstOrDefault(p => p.CodigoProduto == codigoProduto);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        if (quantidade <= 0)
        {
            throw new Exception("A quantidade deve ser maior que zero.");
        }

        if (tipo.Equals("Saída", StringComparison.OrdinalIgnoreCase))
        {
            if (produto.Estoque < quantidade)
            {
                throw new Exception("Estoque insuficiente.");
            }

            produto.Estoque -= quantidade;
        }
        else if (tipo.Equals("Entrada", StringComparison.OrdinalIgnoreCase))
        {
            produto.Estoque += quantidade;
        }
        else
        {
            throw new Exception("Tipo de movimentação inválido.");
        }

        MovimentacaoEstoque movimentacao = new MovimentacaoEstoque
        {
            Id = proximoId++,
            CodigoProduto = codigoProduto,
            Descricao = descricao,
            Tipo = tipo,
            Quantidade = quantidade
        };

        return movimentacao;
    }
}