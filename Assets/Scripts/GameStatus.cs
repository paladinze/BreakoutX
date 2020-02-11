using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [Range(1.0f, 10.0f)][SerializeField] float gameSpeed = 1.0f;
    [SerializeField] int scorePerBlockDestroyed = 10;

    [SerializeField] int totalScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool autoPlayModeEnabled = false;

    private void Awake()
    {
        if(FindObjectsOfType<GameStatus>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void IncreaseTotalScore()
    {
        totalScore += scorePerBlockDestroyed;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"SCORE: {totalScore.ToString()}";
    }

    public void ResetScore()
    {
        Destroy(gameObject);
        totalScore = 0;
    }

    public bool GetIsAutoPlaymodeEnabled()
    {
        return autoPlayModeEnabled;
    }
}
