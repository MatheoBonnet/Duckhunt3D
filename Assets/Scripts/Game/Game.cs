using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private float time = 5f;
    int round = 60;
    int score_needed = 120;
    bool phase_jeu = true;
    
    public Text timeUI; 
    
    void Start()
    {
        // Démarrer le timer une seule fois
        InvokeRepeating("SCCountdownTimer", 1.0f, 1.0f);
    }

    void Update()
    {
        if (time <= 0)
        {
            CheckRoundEnd();
        }
        if (timeUI != null)
        {
            timeUI.text = "Time: " + Mathf.CeilToInt(time).ToString();
        }
    }
    
    void SCCountdownTimer()
    {
        if (time > 0)
        {
            time--;
        }
    }
    
    void CheckRoundEnd()
    {
        CancelInvoke("SCCountdownTimer"); // Arrêter le timer
        
        if (Player.score < score_needed)
        {
            Debug.Log("Game Over");
            GameOver.GameOverScreen();
        }
        else
        {
            round++;
            time = 60;
            score_needed += 200; 
            InvokeRepeating("SCCountdownTimer", 1.0f, 1.0f); // Redémarrer le timer
            Debug.Log("Round " + round + " started!");
        }
    }
}