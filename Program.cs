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
            contato.Nome = "teste";
            contato.Telefone = "123456";

            contato.Inserir(contato);
        }
    }
}
