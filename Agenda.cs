/*Capacidades: 
13. Utilizar o paradigma da programação orientada a objetos
10. Manipular os diferentes tipos de dados na elaboração de programas
12. Utilizar técnicas de versionamento através de softwares específicos
9. Aplicar técnicas de código limpo (clean code)
Nesta atividade crie um sistema com o contexto similar ao do WhatsApp, aplicando o diagrama em anexo.
Regras:
- Utilize um método construtor para a classe Contato
- Crie uma interface para a agenda antes de criar a classe Agenda
- Implemente a interface utilizando control ponto
- Lembre-se de utilizar o método construtor para criar o arquivo .csv caso ele não exista
- Crie um arquivo .csv para a agenda apenas, salve as mensagens somente sobrar tempo
- Faça os métodos restantes do CRUD somente se sobrar tempo
- No program: pode instanciar Contatos diretamente e salvá-los utilizando os métodos da agenda*/
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
namespace whatsConsole
{
    public class Agenda
    {
//atributos
        public string Nome{get; set;}
        public int Telefone{get; set;}
    
        //caminho do diretorio
        private const string PAHT_DIRETORIO = "C:\\Users\\Phellipe\\Desktop\\senai\\c#\\whatsConsole\\Database"; //teste
        //local onde o aquivo vai ser criado
        private const string PAHT_ARQUIVO ="Database/Agenda.csv";

//construtor
        public Agenda(){
            //verificação se o diretorio existe, caso não exista será criado
            if(!Directory.Exists(PAHT_DIRETORIO)){
                Directory.CreateDirectory(PAHT_DIRETORIO);
            }//fim if paht diretorio

            //fazendo o mesmo com o arquivo, verificando se ele existe, cado contrario, vai ser criado
            //.close apos criar o arquivo, ele fecha o arquivo criado
            if(!File.Exists(PAHT_ARQUIVO)){
                File.Create(PAHT_ARQUIVO).Close();
            }//fim do if paht_arquivo

        }//fim do construtor
        public Agenda(string c_nome, int c_telefone){
            this.Nome = c_nome;
            this.Telefone = c_telefone;
        }//fim construtor

//Metodo Criar Linha
        /// <summary>
            /// Cria as separações dos dados no arquivo csv, escolha: , ou ; para fazer a separação e registrar no arquivo certinho, esse metodo é interno.
         /// </summary>
         /// <returns>devolve a string já formatada, com todos os dados</returns>
         private string CriarLinha(Agenda separador){
             return $"{separador.Nome};{separador.Telefone}";
         }//fim do metodo criarLinha











        
    }//fim da public agenda
}//fim namespace