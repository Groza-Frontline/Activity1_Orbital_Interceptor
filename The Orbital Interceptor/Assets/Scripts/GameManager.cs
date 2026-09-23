using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score = 0;
    
    //We use awake instead of start,Awake runs before anyu starts method in game.
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log($"Score added: +{points}. Current Score = {score}");
    }

    public void DeductScore(int points) {
        
        score -= points;
        Debug.Log($"Score deducted: -{points}. Current Score = {score}");
    
    }
}
