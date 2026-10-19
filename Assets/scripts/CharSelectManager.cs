using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject froggySprite;
    [SerializeField] GameObject squiwiSprite;
    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseFroggy()
    {
        froggySprite.SetActive(true);
        BeginGame();
    }

    public void ChooseSquiwi()
    {
        squiwiSprite.SetActive(true);
        BeginGame();
    }
}
