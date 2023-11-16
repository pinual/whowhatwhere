namespace WhoWhatWhere.Data
{
    public class GameService
    {
        protected List<Game> _games = new List<Game>();

        public async Task<bool> ValidateGameCode(string gameCode)
        {
            return await Task.FromResult(_games.Exists(x => x.GameCode == gameCode));
        }

        public async Task<string> ValidateJoinGame(string gameCode, string playerName)
        {
            var game = await Task.FromResult(_games.Find(x => x.GameCode == gameCode));
            if(game == null)
            {
                return "Invalid Game Code";
            }
            if(game.Players.Exists(x => x.Name == playerName))
            {
                return "A player with that name already joined.";
            }
            return "";
        }

        public async Task<Game?> GetGameAsync(string gameCode)
        {
            return await Task.FromResult(_games.Find(x => x.GameCode == gameCode));
        }

        public async Task<string> CreateGame()
        {
            var game = new Game()
            {
                Id = Guid.NewGuid(),
                GameCode = Game.GenerateGameCode(),
                Players = new List<Player>()
            };
            
            _games.Add(game);

            return await Task.FromResult(game.GameCode);
        }

        public async Task DeleteGame(Guid id)
        {
            _games.RemoveAll(x => x.Id == id);
        }
    }
}
