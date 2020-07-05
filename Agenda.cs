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
        //public List<Contato> Contatos {get; set;} //atribuido embaixo
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

//Metodo(cadastrar) inserir Linha
    /// <summary>
    /// Insere os dados nas linhas do csv (cadastrar)
    /// </summary>
    /// <param name="c_contato">dado posicionador</param>
     public void Inserir(Agenda c_contato){
         var linha_arquivo = new string [] {c_contato.PrepararLinhaNoCsv(c_contato) };
         File.AppendAllLines(PAHT_ARQUIVO, linha_arquivo);
     }//fim metodo inserir

//prepara linha csv
    /// <summary>
    /// cria os arquivos separados e editados no arquivo
    /// </summary>
    /// <param name="p_csv"></param>
    /// <returns></returns>
    private string PrepararLinhaNoCsv(Agenda p_csv){
        return $"Nome: {p_csv.Nome};Telefone: {p_csv.Telefone}";
    }//fim metodo preparar linha
   

//Ler arquivo csv
    /// <summary>
    /// Le e remove as linhas do arquivo csv
    /// </summary>
    /// <param name="listaLinhas">lista com as linhas do arquivo</param>
    /// <param name="filtro">filtro para apagar as linhas</param>
    public void Ler_e_Remover_ArqeuivosCsv(List<string> listaLinhas, string filtro){
        //Anotações para reuso
        //trasformar as linhas encontradas em um array de strings
        //strings[] linhas_csv =File.ReadAllLines(PAHT_ARQUIVO); //ler todas as linhas do arquivo
        //analise do arquivo
        //foreach(var varrer_linhas in linhas_csv){
            //quebramos ou separamos as linhas com o ;
            //string[] dadosEncontrados = varrer_linhas.Split(";");
            //tratando os dados encontrados e adicionando eles em um novo objeto
            // Agenda dadosTratados = new Agenda();
        // Implementar caso precise, nos testes ainda não é necessario por ser poucos dados
            using(StreamReader arquivocsv = new StreamReader(PAHT_ARQUIVO)){
                string linha_lida;
                while((linha_lida = arquivocsv.ReadLine() ) != null){
                    listaLinhas.Add(linha_lida);
                }//fim while
                //remove
                listaLinhas.RemoveAll( z => z.Contains(filtro));
            }//fim using
    }//fim do metodo ler arquivos

//metodos remover
    public void ApagarLinhacsv(List<string> ListaLerLinhas) {
        //pesquisar melhor
        using(StreamReader remover = new StreamReader(PAHT_ARQUIVO) ){
            //leitura das linhas
            foreach(string varrer_linha in ListaLerLinhas){
                remover.Write(varrer_linhas + "\n");
            }//fim foreach
        }//fim using
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

//listar contatos igual o exemplo professor
    /// <summary>
    /// lista os contatos e organiza eles em uma lista tratada
    /// </summary>
    /// <returns>objeto novo com a lista tratada</returns>
    public List<Contato> ListarContatos (){
        //lista de contatos
        List<Contato> contatos = new List <Contato>();

        //aula 28 ver anotações professor
        //tranformando cada linha em um array de strings
        string[] linhas_encontradas = File.ReadAllLines(PAHT_ARQUIVO);//Vai ler todas as linhas do arquivo
        //analisando os arquivos
        foreach(var varrer_linhas in linhas_encontradas){

            //separando as linhas com ;
            strings[] dados_encontrados = varrer_linhas.Split(";");

            //criando um objeto para tratar dados
            Contato tratar_dados = new Cotato();
            tratar_dados.Nome = SepararDados(dados_encontrados[1]);
            tratar_dados.Telefone = SepararDados(dados_encontrados[1]);

            //adicionando objto na lista
            contatos.Add(tratar_dados);
        }//fim foreach
        contatos =contatos.OrderBy(y => y.Nome).ToList();//pesquisar lambida
        return contatos;
    }//fim metodo listar contatos
      












        
    }//fim da public agenda
}//fim namespace