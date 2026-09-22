using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public int playerScore = 0;
    private int playerHealth;
    //We use awake instead of start,Awake runs before anyu starts method in game.
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore(int points)
    {
        playerScore += points;
    }


}
