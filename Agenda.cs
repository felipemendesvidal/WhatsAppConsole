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

        private const string PAHT_DIRETORIO = "C:\\Users\\Phellipe\\Desktop\\senai\\c#\\whatsConsole\\Database"; //caminho do diretorio
        //local onde o aquivo vai ser criado
        private const string PAHT_ARQUIVO ="Database/Agenda.csv";//caminho arquivo
        //lista de contatos
        List<Contato> contatos = new List<Contato>();

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

//prepara linha csv
    /// <summary>
    /// cria os arquivos separados e editados no arquivo
    /// </summary>
    /// <param name="p_csv"></param>
    /// <returns></returns>
    private string PrepararLinhaNoCsv(Contato p_csv){
        return $"Nome: {p_csv.Nome};Telefone: {p_csv.Telefone}";
    }//fim metodo preparar linha

//Metodo(cadastrar) inserir Linha
    /// <summary>
    /// Insere os dados nas linhas do csv (cadastrar)
    /// </summary>
    /// <param name="c_contato">dado posicionador</param>
     public void Inserir(Contato c_contato){
         var linha_arquivo = new string [] {PrepararLinhaNoCsv(c_contato) };
         File.AppendAllLines(PAHT_ARQUIVO, linha_arquivo);
     }//fim metodo inserir

//Ler arquivo csv
    /// <summary>
    /// Le os arquivos cvg e coloca ele na lista de contatos
    /// </summary>
    /// <returns> retorna a lista de contatos</returns>
    public List<Contato> Ler() {
        //Anotações para reuso aula 28
        //trasformar as linhas encontradas em um array de strings
        string[] linhas_csv = File.ReadAllLines(PAHT_ARQUIVO); //ler todas as linhas do arquivo
        //analise do arquivo
        foreach(var varrer_linhas in linhas_csv){
            //quebramos ou separamos as linhas com o ;
            string[] dadosEncontrados = varrer_linhas.Split(";");
            //tratando os dados encontrados e adicionando eles na lista criada
            contatos.Add(new Contato(dadosEncontrados[0], dadosEncontrados[1]) );
        }//fim foreach
        return contatos;//retornando a lista tratada pelo foreach
    }//fim do metodo ler arquivos

//metodos remover
    public void Excluir(Contato e_contato) {
        List<string> linhasArquivo = new List<string>();
        using(StreamReader arquivoAnalisado = new StreamReader(PAHT_ARQUIVO) ){
            string linhasLida;
            while( ( linhasLida = arquivoAnalisado.ReadLine() ) != null ){
                linhasArquivo.Add(linhasLida);
            }//fim while
        }//fim using
        linhasArquivo.RemoveAll( x => x.Contains(e_contato.Nome) );
        //criar metodo: Reescrevercsv(linhasArquivo);
    }//fim do metodo remover linhas  

//metodo que vai ser usado para separar dados encontrados
    /// <summary>
    /// Metodo usado para separar dados com -
    /// </summary>
    /// <param name="dadoSeparado">separador -</param>
    /// <returns>retorna os dados separados -</returns>
    public string SepararDados(string dadoSeparado){
        return dadoSeparado.Split("-")[1];
    }//fim separar dados








        
    }//fim da public agenda
}//fim namespace