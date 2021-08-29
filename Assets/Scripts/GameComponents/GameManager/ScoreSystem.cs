using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private double score;
    public Text playerScore;
    public float scoreMultiply;

    void Awake()
    {
        scoreMultiply = 1.5f;
    }

    public void UpdateMultiply(float multi)
    {
        if (multi > 2.5f)
        {
            multi = 2.5f;
            this.scoreMultiply = multi;
        }

    }
    
    public void UpdateScore(int points)
    {
        
        score = (points * scoreMultiply);
        playerScore.text = this.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        this.score = Damage.playerScore;
    }
}
