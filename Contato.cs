namespace whatsConsole
{
    public class Contato
    {
        //atributos
        public string Nome{get; set;}
        public string Telefone{get; set;}

        //coonstrutor
        public Contato(){

        }//fim construtor
        public Contato(string c_nome, string c_telefone){
            this.Nome = c_nome;
            this.Telefone = c_telefone;
        }//fim construtor







    }//fim class contato
}//fim namespace