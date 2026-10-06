using ControleEstoque;
using ControleEstoque.Models;
using ControleEstoque.Services;

EstoqueService estoqueService =
    new EstoqueService(DadosEstoque.Produtos);

Console.WriteLine("=== CONTROLE DE ESTOQUE ===");

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\nProdutos disponíveis:");

    foreach (Produto produto in DadosEstoque.Produtos)
    {
        Console.WriteLine(
            $"{produto.CodigoProduto} - " +
            $"{produto.DescricaoProduto} - " +
            $"Estoque: {produto.Estoque}");
    }

    Console.Write("\nDigite o código do produto: ");
    int codigoProduto = int.Parse(Console.ReadLine()!);

    Console.Write("Digite o tipo da movimentação (Entrada/Saída): ");
    string tipo = Console.ReadLine()!;

    Console.Write("Digite a quantidade: ");
    int quantidade = int.Parse(Console.ReadLine()!);

    Console.Write("Digite a descrição da movimentação: ");
    string descricao = Console.ReadLine()!;

    try
    {
        MovimentacaoEstoque movimentacao =
            estoqueService.RealizarMovimentacao(
                codigoProduto,
                tipo,
                quantidade,
                descricao);

        Produto produto = DadosEstoque.Produtos
            .First(p => p.CodigoProduto == codigoProduto);

        Console.WriteLine("\n=== MOVIMENTAÇÃO REALIZADA ===");

        Console.WriteLine($"ID: {movimentacao.Id}");
        Console.WriteLine($"Produto: {produto.DescricaoProduto}");
        Console.WriteLine($"Tipo: {movimentacao.Tipo}");
        Console.WriteLine($"Descrição: {movimentacao.Descricao}");
        Console.WriteLine(
            $"Quantidade movimentada: {movimentacao.Quantidade}");
        Console.WriteLine($"Estoque final: {produto.Estoque}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
    }

    Console.Write("\nDeseja realizar outra movimentação? (S/N): ");
    string resposta = Console.ReadLine()!;

    if (resposta.Equals("N", StringComparison.OrdinalIgnoreCase))
    {
        continuar = false;
    }
}

Console.WriteLine("\nPrograma encerrado.");