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
            Console.WriteLine($"Enviar msg parar {c_contato.Nome}?");
            Texto_msg = Console.ReadLine();

            System.Console.WriteLine($"Mensagem: {Texto_msg} enviada: {c_contato.Nome}."); 
        }
    }
}