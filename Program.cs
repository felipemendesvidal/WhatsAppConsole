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
            Contato teste = new Contato();
            contato.Nome = "teste";
            contato.Telefone = "123456";
            teste.Nome = "mais um teste";
            teste.Telefone = "12322222";


            contato.Inserir(contato);
            contato.Inserir(teste);

            
        }
    }
}
