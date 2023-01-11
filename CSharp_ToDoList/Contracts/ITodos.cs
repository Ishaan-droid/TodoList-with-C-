namespace todos
{
    public interface ITodos
    {
        string Todo { set; get; }
        Guid UniqueId { set; get; }
        bool check { set; get; }
    }
}