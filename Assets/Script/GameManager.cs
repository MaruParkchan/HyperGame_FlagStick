using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        textScore.SetText(score.ToString());
    }

    public void DecreaseScore()
    {   
        score--;
        textScore.SetText(score.ToString());
    }
}
