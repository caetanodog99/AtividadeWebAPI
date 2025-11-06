using UnityEngine;
using UnityEngine.SceneManagement;

public class recarregar : MonoBehaviour
{
    [SerializeField] private TesteAPI teste;

    public void Reiniciar()
    {
        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
        teste.Coletou();
    }
}