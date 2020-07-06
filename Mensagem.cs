using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text;
namespace whatsConsole
{
    public class Mensagem
    {   
        //atributos
        public string Texto_msg { get; set; }
        public Contato Destinatario;

//enviar msg
        /// <summary>
        /// Envia mensagem 
        /// </summary>
        /// <param name="c_contato">contato</param>
        public void Enviar(Contato c_contato){
            Console.WriteLine($"Mensagem: {Texto_msg} enviada: {Destinatario.Nome}."); 
        }
    }
}