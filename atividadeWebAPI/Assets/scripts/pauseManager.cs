using UnityEngine;


public class pauseManager : MonoBehaviour
{

    [SerializeField] private GameObject pause;

    void Update()
    {
        if (!pause.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                pause.SetActive(false);
     
            }
        }
    }
}
