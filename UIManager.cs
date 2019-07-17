using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject TargetGenerator;
    GameObject timerText;
    GameObject scoreText;
    GameObject endText;
    GameObject startButton;
    GameObject restartButton;
   
    int score = 0;
    int startCount = 3;
    float time = 30.0f;

    public void StartCountDown(){
        this.startButton.SetActive(false);
        for (int i = 0; i < 3; i++){
            this.startCount -= 1;
        }
    }

    public void RestartGame() {
        startCount = 3;
        time = 30.0f;
        score = 0;
        this.timerText.SetActive(false);
        this.scoreText.SetActive(false);
        this.endText.SetActive(false);
        this.restartButton.SetActive(false);
        StartCountDown();
    }

    public void GetScore(){
        this.score += 100;
    }

    public void GetMiss(){
        this.score -= 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Timer");
        this.scoreText = GameObject.Find("Score");
        this.endText = GameObject.Find("End");
        this.startButton = GameObject.Find("StartButton");
        this.restartButton = GameObject.Find("RestartButton");
        this.timerText.SetActive(false);
        this.scoreText.SetActive(false);
        this.endText.SetActive(false);
        this.restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.startCount > 0){//内部カウントダウン中

        }else if(this.startCount <= 0 && this.time > 0){//カウントダウン終了＆ゲーム時間中
            StartGame();
            this.time -= Time.deltaTime;
            this.timerText.GetComponent<Text>().text =
                "Time:" + this.time.ToString("F1");
            this.scoreText.GetComponent<Text>().text = 
                "Score:" + this.score.ToString();
        }else{//ゲーム時間終了
            EndGame();
            this.TargetGenerator.SetActive(false);
        }
    }

    void StartGame(){//タイマーと点数の表示
        this.timerText.SetActive(true);
        this.scoreText.SetActive(true);
    }

    void EndGame(){//終了時のUI表示
        this.timerText.SetActive(false);
        this.scoreText.SetActive(false);
        this.restartButton.SetActive(true);
        this.endText.SetActive(true);
        this.endText.GetComponent<Text>().text = 
        "今回獲得したスコアは"　+ this.score.ToString() + "です";
    }
}
