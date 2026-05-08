using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text hpText;
    public TMP_Text scoreText;
    public GameObject gameOverText;
    void Awake()
    {
        instance = this;
    }
    public void UpdateHP(int hp)
    {
        hpText.text = "HP : " + hp;
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }
    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
    }
}
