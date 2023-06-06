using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerUI : MonoBehaviour
{
    public static GameControllerUI Instance;
    [SerializeField] private TextMeshProUGUI TextScore;
    [SerializeField] private int Score;
    [SerializeField] public bool isOver;
    [SerializeField] private GameObject ReplayPanel;
    [SerializeField]
    private TextMeshProUGUI CurrentScore;
    [SerializeField]
    private Text TextTime;
    [SerializeField] private float TimePlay;

    public int score { get => Score; set => Score = value; }
    public float TimeMinuate1 { get => TimeMinuate; set => TimeMinuate = value; }

    [SerializeField] private float TimeMinuate;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Score = 0;
        TimeMinuate1 = 0;
         isOver =false;
        ReplayPanel.SetActive(false);
    }

    
    void Update()
    {
        if (isOver == false)
        {
            TimePlay += (1 * Time.deltaTime);
        }
       
        UpdateUi();
        if (PlayerHealth.instance.health == 0)
        {
            GameOver();
        }
    }
    private void UpdateUi()
    {
        TextScore.text = "Score:" + Score.ToString();
        if (TimePlay < 60)
        {
            if(TimeMinuate1<10)
            TextTime.text = "00:" +"0"+ TimeMinuate1.ToString("0") + ":" + TimePlay .ToString("0");
            else
                TextTime.text = "00:" + TimeMinuate1.ToString("0") + ":" + TimePlay .ToString("0");
        }
        else if(TimePlay>=60){
           TimeMinuate1 += 1;
            TimePlay = 0;
            TextTime.text = "00:" + TimeMinuate1.ToString("0") +":"+ TimePlay.ToString("0");
            
        }
    }
    public void GameOver()
    {
        
            isOver = true;
            CurrentScore.text = "Score:" + score;
            ReplayPanel.SetActive(true);
        
    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Replay()
    {
        Score = 0;
        isOver = false;
        PlayerHealth.instance.health += PlayerHealth.instance.maxHealth;
        EnemyLogic.Instance.Maxhp = 3;
        TimePlay = 0;
        TimeMinuate1 = 0;
       
    }
}
