using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float time = 5f;
    int round = 1;
    int score_needed = 10;
    
    public Text timeUI; 
    public Text roundUI; 
    
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
            timeUI.text = "Time : " + Mathf.CeilToInt(time).ToString();
        }

        roundUI.text = "Round : " + round.ToString();
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
            launchDucks.SetActive(false);
            if(Input.GetKeyDown(KeyCode.Q))
            {
                launchDucks.SetActive(true);
                round++;
                time = 10;
                score_needed += 1; 
                launchDucks.interval *= 0.9f;
                DuckController.baseMaxHealth += 5;
                InvokeRepeating("SCCountdownTimer", 1.0f, 1.0f); // Redémarrer le timer
                Debug.Log("Round " + round + " started!");
            }
            
        }
    }
}