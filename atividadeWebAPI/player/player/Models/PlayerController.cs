using Microsoft.AspNetCore.Mvc;

namespace player.Models
{
    public class PlayerController : ControllerBase
    {
        public List<Player> PlayerList { get; set; }
    }
}
