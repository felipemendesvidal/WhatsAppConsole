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