using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    void Awake()
    {
        instance = this;
    }
    public void AddScore(int value)
    {
        score += value;
        UIManager.instance.UpdateScore(score);
    }
    public void GameOver()
    {
        UIManager.instance.ShowGameOver();
        Time.timeScale = 0f;
    }
}
