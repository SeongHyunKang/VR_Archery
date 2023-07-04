using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI scoreDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplay.text = "Score : " + score;
    }
}
