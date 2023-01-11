namespace todos
{
    public class Todos : ITodos
    {
        public string Todo { set; get; }
        public Guid UniqueId { set; get; }
        public bool check { set; get; } = false;
    }
}