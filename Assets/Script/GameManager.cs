using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int score;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] Color clearColor;
    [SerializeField] Color failColor;
    [SerializeField] GameObject buttonRestart;
    public bool isGameOver = false;

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
        if(score <= 0)
        {
            SetGameOver(true);
        }
    }

    public void SetGameOver(bool isClear)
    {
        if(isGameOver == false)
            isGameOver = true;

            Camera.main.backgroundColor = isClear ? clearColor : failColor;
            buttonRestart.SetActive(true); // 버튼 활성화
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
