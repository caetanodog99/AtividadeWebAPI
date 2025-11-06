using UnityEngine;
using TMPro;

public class textManager : MonoBehaviour
{
    [SerializeField] private player jogador; 
    [SerializeField] private TextMeshProUGUI vidaTXT;
    [SerializeField] private TextMeshProUGUI itensTXT;
    [SerializeField] private TextMeshProUGUI posicaoXTXT;
    [SerializeField] private TextMeshProUGUI posicaoYTXT;
    [SerializeField] private TextMeshProUGUI posicaoZTXT;

    void Update()
    {
        if (jogador == null) return;
        if (vidaTXT != null) vidaTXT.text = "Vida: " + jogador.GetVida().ToString();
        if (itensTXT != null) itensTXT.text = "Itens coletados: " + jogador.GetItens().ToString();
        if (posicaoXTXT != null) posicaoXTXT.text = "Posição X: " + jogador.transform.position.x.ToString("F2");
        if (posicaoYTXT != null) posicaoYTXT.text = "Posição Y: " + jogador.transform.position.y.ToString("F2");
        if (posicaoZTXT != null) posicaoZTXT.text = "Posição Z: " + jogador.transform.position.z.ToString("F2");
    }


}
