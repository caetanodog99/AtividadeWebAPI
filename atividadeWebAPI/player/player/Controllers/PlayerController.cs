using Microsoft.AspNetCore.Mvc;

namespace player.Models
{
    public class PlayerController : ControllerBase
    {

        public static List<Player> jogadores = new()
        {
        //new Player  {id = "77", Vida=100, QuantidadeItens=100, PosicaoX="1", PosicaoY="1", PosicaoZ="1"}
        };
        [HttpGet]
        [Route("api/players")]

        public IActionResult GetPlayers()
        {
            return Ok(jogadores);
        }

        [HttpGet]
        [Route("api/players/{id}")]
        public IActionResult GetPlayerID(string id)
        {
            var jogador = jogadores.FirstOrDefault(p => p.id == id);
            if (jogador == null)
            {
                return NotFound();
            }
            return Ok(jogadores);
        }

        [HttpPost]
        [Route("api/players")]
        public IActionResult AddPlayer([FromBody] Player novoPlayer)
        {
            jogadores.Add(novoPlayer);
            return Ok(novoPlayer);
        }

        [HttpDelete]
        [Route("api/players/{id}")]
        public IActionResult DeletePlayer(string id)
        {
            var jogador = jogadores.FirstOrDefault(p => p.id == id);
            if (jogador == null)
            {
                return NotFound();
            }
            jogadores.Remove(jogador);
            return Ok(jogador);
        }


        [HttpPut]
        [Route("api/players/{id}")]
        public IActionResult UpdatePlayer(string id, [FromBody] Player playerAtualizado)
        {
            var jogador = jogadores.FirstOrDefault(p => p.id == id);
            if (jogador == null)
            {
                return NotFound();
            }
            jogador.Vida = playerAtualizado.Vida;
            jogador.QuantidadeItens = playerAtualizado.QuantidadeItens;
            jogador.PosicaoX = playerAtualizado.PosicaoX;
            jogador.PosicaoY = playerAtualizado.PosicaoY;
            jogador.PosicaoZ = playerAtualizado.PosicaoZ;
            return Ok(jogador);
        }
    }
}
