namespace JogoGourmetEdson.Entidades
{
    public class Noh
    {
        public string Nome { get; set; }
        public Noh Sim { get; set; }
        public Noh Nao { get; set; }

        public bool EhPrato => Sim == null && Nao == null;

        public Noh(string nome)
        {
            Nome = nome;
        }
    }
}
