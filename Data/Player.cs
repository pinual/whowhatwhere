namespace WhoWhatWhere.Data
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? MyWho { get; set; }
        public string? MyWhat { get; set; }
        public string? MyWhere { get; set; }
        public string? RecWho { get; set; }
        public string? RecWhat { get; set; }
        public string? RecWhere { get; set; }
    }
}
