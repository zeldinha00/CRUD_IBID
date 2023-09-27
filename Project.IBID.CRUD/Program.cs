using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ID { get; set; }
    public string Nome { get; set; }
}

public class ProductManager
{
    private List<Product> products = new List<Product>();
    private int nextId = 1;

    public void AddProduct(Product product)
    {
        product.ID = nextId++;
        products.Add(product);
    }

    public void RemoveProduct(int productId)
    {
        Product productToRemove = products.FirstOrDefault(p => p.ID == productId);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
        }
    }

    public void UpdateProduct(int productId, string newName)
    {
        Product productToUpdate = products.FirstOrDefault(p => p.ID == productId);
        if (productToUpdate != null)
        {
            productToUpdate.Nome = newName;
        }
    }

    public List<Product> GetProducts()
    {
        return products;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Seja bem-vindo ao CRUD IBID\n");

        ProductManager productManager = new ProductManager();

        while (true)
        {
            Console.WriteLine("Opções:");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Remover Produto");
            Console.WriteLine("3 - Editar Nome do Produto");
            Console.WriteLine("4 - Visualizar Todos os Produtos");
            Console.WriteLine("5 - Sair");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Nome do Produto: ");
                    string nome = Console.ReadLine();
                    Product newProduct = new Product { Nome = nome };
                    productManager.AddProduct(newProduct);
                    Console.WriteLine("Produto adicionado com sucesso.");
                    break;

                case 2:
                    Console.Write("ID do Produto a ser removido: ");
                    int productIdToRemove = int.Parse(Console.ReadLine());
                    productManager.RemoveProduct(productIdToRemove);
                    Console.WriteLine("Produto removido com sucesso.");
                    break;

                case 3:
                    Console.Write("ID do Produto a ser editado: ");
                    int productIdToEdit = int.Parse(Console.ReadLine());
                    Console.Write("Novo Nome: ");
                    string newName = Console.ReadLine();
                    productManager.UpdateProduct(productIdToEdit, newName);
                    Console.WriteLine("Nome do produto atualizado com sucesso.");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Lista de Produtos:");
                    Console.WriteLine("ID\tNome");

                    foreach (Product product in productManager.GetProducts())
                    {
                        Console.WriteLine($"{product.ID}\t{product.Nome}");
                    }

                    Console.WriteLine();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
