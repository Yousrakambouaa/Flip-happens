using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
    }
}
