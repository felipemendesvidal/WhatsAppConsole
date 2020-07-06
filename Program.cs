using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text;
namespace whatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ao criar esse objeto, por causa do construtor ele já vai criar o ditetorio e o arquivo desejado
            Agenda contato = new Agenda();
            Contato vedentinaldina= new Contato("vedentinaldina","(00)1 2345-6789");
            Contato fredolovaldo = new Contato("fredolovaldo","(00)1 2345-6789");
            Contato felipe = new Contato("felipe","(00)1 2345-6789");


            contato.Inserir(vedentinaldina);
            contato.Inserir(fredolovaldo);
            contato.Excluir(felipe);

            foreach(Contato item in contato.Ler()){
                Console.WriteLine($"Nome: {item.Nome} - Tel: {item.Telefone}");
            }
            


            
        }
    }
}
