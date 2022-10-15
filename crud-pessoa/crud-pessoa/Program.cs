﻿using crud_pessoa.entidades;
using crud_pessoa.util;
using MySqlConnector;
using System;
using System.Data;

public class Program
{
    static void Main(string[] args)
    {
        

        MenuPrincipal();

    }

    private static void MenuPrincipal()
    {
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*         BEM-VINDO          *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");

        bool sair = false;
        Console.WriteLine("1 - Cadastra novo usuario.");
        Console.WriteLine("2 - Atualizar dados do usuario.");
        Console.WriteLine("3 - deletar usuario.");
        Console.WriteLine("4 - visualizar usuario.");
        
        do { 
            Console.Write("Digite sua opção:");
            var resposta = Console.ReadLine();
            sair = false;
            switch (resposta)
            {
                case "1":
                    AdicionarDados();
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;
                case "4":
                    VisualizarDados();
                    break;
                default:
                    sair = true;
                    Console.WriteLine("Opção invalida, Digite novamente...");
                    break;

            }
        } while (sair);


    }

    private static void VisualizarDados()
    {
        ListaDados();
        bool sair = false;

        
        Console.WriteLine("1 - Voltar ao menu principal.");
        do
        {
            Console.Write("Digite sua opção:");
            var resposta = Console.ReadLine();
            sair = false;
            switch (resposta)
            {
                case "1":
                    Console.Clear();
                    MenuPrincipal();
                    break;

                default:
                    sair = true;
                    Console.WriteLine("Opção invalida, Digite novamente...");
                    break;

            }
        } while (sair);
    }

    private static void ListaDados()
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Lista de usuarios       *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();

        MySqlCommand Query = new MySqlCommand();
        Query.Connection = Conexao._connection;
        Conexao._connection.Open();//Abre conexão

        Query.CommandText = @"SELECT id, nome, cpf, dataNascimento,email FROM tb_usuario";
        MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

        Console.WriteLine("*********************************************");
        Console.WriteLine("ID - NOME - CPF - DATA DE NASCIMENTO - EMAIL");
        Console.WriteLine();
        while (dtreader.Read())//Enquanto existir dados no select
        {

            var id = dtreader["id"].ToString();//Preencha objeto do tipo pessoa (id) com dados vindo do banco de dados
            var nome = dtreader["nome"].ToString();
            var cpf = dtreader["cpf"].ToString();
            var dataNascimento = dtreader["dataNascimento"].ToString();
            var email = dtreader["email"].ToString();

            Console.WriteLine(id +" - " + nome + " - " + cpf+ " - " + dataNascimento+ " - " + email);
           
        }
        Console.WriteLine();
        Console.WriteLine("*********************************************");
        Console.WriteLine();
        Conexao._connection.Close();//Fecha Conexao

    }

    private static void AdicionarDados() // insert
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Adicionar usuarios      *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();
        Console.Write("Digite o nome: ");
        var nome = Console.ReadLine();
        Console.Write("Digite o cpf: ");
        var cpf = Console.ReadLine();
        Console.Write("Digite sua data de nascimento: ");
        var data = Console.ReadLine();
        Console.Write("Digite o seu email: ");
        var email = Console.ReadLine();

        Conexao._connection.Open();//Abre conexão
        MySqlCommand comm = Conexao._connection.CreateCommand();

        comm.CommandText = "INSERT INTO tb_usuario (nome, cpf, dataNascimento,email) VALUES(@nome, @cpf, @dataNascimento, @email)";// inserindo os dados as variaveis
        comm.Parameters.AddWithValue("@nome", nome);
        comm.Parameters.AddWithValue("@cpf", cpf);
        comm.Parameters.AddWithValue("@dataNascimento", data);
        comm.Parameters.AddWithValue("@email", email);
        comm.ExecuteNonQuery();
        Console.Clear();

        Conexao._connection.Close();//Fecha Conexao
        MenuPrincipal();
    }
    private static void DeletaDados()//Deleta dados
    {
        Console.Clear();
        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        Console.WriteLine("*    Deletar usuarios        *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();
        ListaDados();

        Console.WriteLine("Digite o id do usuario para deletar");

    }
}
