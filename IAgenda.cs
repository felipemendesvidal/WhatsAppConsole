using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text;
namespace whatsConsole
{
    public interface IAgenda
    {
        //  void Cadastrar (Contato c_contato);
        void Inserir(Contato c_contato);
        void Excluir (Contato e_contato);
        List<Contato> Ler();
    }
}