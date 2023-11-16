namespace WhoWhatWhere.Data
{
    public class Game
    {
        public required Guid Id { get; set; }
        public required string GameCode { get; set; }
        public required List<Player> Players { get; set; }
        public bool DealComplete { get; set; } = false;

        public async Task AddPlayer(string name)
        {
            Players.Add(new Player()
            {
                Id = Guid.NewGuid(),
                Name = name
            });

            await Task.CompletedTask;
        }

        public static string GenerateGameCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            char[] randomArray = new char[5];

            for (int i = 0; i < 5; i++)
            {
                randomArray[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomArray);
        }
    }
}
