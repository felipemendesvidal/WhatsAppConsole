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
using System.Text;
namespace whatsConsole
{
    public class Agenda : IAgenda
    {

        //atributo
        public string Nome{get; set;}
        public string Telefone {get; set;}
        //atributo com uma lista como valor, assim posso chamar essa lista depois
        public List<Contato> Contatos {get; set;}
        //caminho do diretorio
        private const string PAHT_DIRETORIO = "C:\\Users\\Phellipe\\Desktop\\senai\\c#\\whatsConsole\\Database"; //teste
        //local onde o aquivo vai ser criado
        private const string PAHT_ARQUIVO ="Database/Agenda.csv";

//construtor
        /// <summary>
        /// Cria arquivos e o dietorio
        /// </summary>
        public Agenda(){
            //separar o caminho entre pasta e o arquivo que será criado
            //string barra = PAHT_ARQUIVO.Split('/')[0];

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
        public Agenda(string c_nome, string c_telefone){
            this.Nome = c_nome;
            this.Telefone = c_telefone;
        }//fim construtor

//Metodo inserir Linha
    /// <summary>
    /// Insere os dados nas linhas do csv
    /// </summary>
    /// <param name="c_contato">dado posicionador</param>
     public void Inserir(Agenda c_contato){
         var linha_arquivo = new string [] {c_contato.PrepararLinhaNoCsv(c_contato) };
         File.AppendAllLines(PAHT_ARQUIVO, linha_arquivo);
     }//fim metodo inserir

//prepara linha csv
    
    private string PrepararLinhaNoCsv(Agenda p_csv){
        return $"Nome: {p_csv.Nome};Telefone: {p_csv.Telefone}";
    }//fim metodo preparar linha
   

//excluir 
      












        
    }//fim da public agenda
}//fim namespace