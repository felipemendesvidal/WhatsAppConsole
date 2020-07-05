namespace whatsConsole
{
    public class Contato
    {
        //atributos
        public string Nome{get; set;}
        public int Telefone{get; set;}

        //coonstrutor
        public Contato(){

        }//fim construtor
        public Contato(string c_nome, int c_telefone){
            this.Nome = c_nome;
            this.Telefone = c_telefone;
        }//fim construtor







    }//fim class contato
}//fim namespace