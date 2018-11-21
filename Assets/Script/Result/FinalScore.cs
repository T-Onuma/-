using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinalScore : MonoBehaviour {

    // スコアを表示する
    public Text finalScoreText;
    public Text NextText;
    int viewScore;

    float red, green, blue;    //RGBを操作するための変数
    float a_color;

    float randomRollTime=5f;

    private void Start()
    {
        red = NextText.GetComponent<Text>().color.r;
        green = NextText.GetComponent<Text>().color.g;
        blue = NextText.GetComponent<Text>().color.b;

        Initialize();
        viewScore = Score.GetFScore();
    }

    void Update()
    {
        randomRollTime -= Time.deltaTime;

        if (randomRollTime <= 0)
        {
            finalScoreText.text = viewScore.ToString();
            NextText.text = "PushSpaceKey";
            a_color += Time.deltaTime;
            NextText.GetComponent<Text>().color = new Color(red, green, blue, a_color);
        }
        else
        {
            // スコア・ハイスコアを表示する
            finalScoreText.text = Random.Range(0, 9999999).ToString();
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScene");
        }
    }

    private void Initialize()
    {
        viewScore = 0;
    }

}
