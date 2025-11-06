using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TesteAPI : MonoBehaviour
{
    private GameApiService apiService;
    [SerializeField] private player jogador;

    private Jogador criadoJogador1;

    async void Start()
    {
        apiService = new GameApiService();

        Debug.Log("=== TESTE DA API ===");

        Jogador novoJogador1 = new Jogador();
        novoJogador1.Vida = jogador.GetVida();
        novoJogador1.QuantidadeItens = jogador.GetItens();
        novoJogador1.PosicaoX = jogador.transform.position.x.ToString("F2");
        novoJogador1.PosicaoY = jogador.transform.position.y.ToString("F2");
        novoJogador1.PosicaoZ = jogador.transform.position.z.ToString("F2");

        criadoJogador1 = await apiService.CriarJogador(novoJogador1); 
        Debug.Log($"Jogadores criados: (ID: 1");

        await MostrarTodosJogadores();

        Debug.Log("=== FIM DOS TESTES ===");
    }

    async public void Coletou()
    {
        if (criadoJogador1 == null) return;

        criadoJogador1.Vida = jogador.GetVida();
        criadoJogador1.QuantidadeItens = jogador.GetItens();
        criadoJogador1.PosicaoX = jogador.transform.position.x.ToString("F2");
        criadoJogador1.PosicaoY = jogador.transform.position.y.ToString("F2");
        criadoJogador1.PosicaoZ = jogador.transform.position.z.ToString("F2");

        criadoJogador1 = await apiService.AtualizarJogador(criadoJogador1);
        Debug.Log($"Jogador atualizado: (ID: {1})");
    }

    async Task MostrarTodosJogadores()
    {
        Jogador[] jogadores = await apiService.GetTodosJogadores();
        Debug.Log($"Total de jogadores: {jogadores.Length}");
        foreach (var jogador in jogadores)
        {
            Debug.Log($"Jogador:  (ID: {1}, Vida: {jogador.Vida})");
        }
    }
}
