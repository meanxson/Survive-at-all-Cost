namespace Client.Scripts.Player
{
    public class PlayerModel
    {
        public string Nickname { get; private set; }
        public int UserId { get; private set; }

        public PlayerModel(string nickname, int userId)
        {
            Nickname = nickname;
            UserId = userId;
        }
        
        public override string ToString() => $"[ID: {UserId}; Nick: {Nickname}]";
    }
}