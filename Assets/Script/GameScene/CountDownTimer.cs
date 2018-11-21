using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour {

    public Text timerText;

    public float totalTime;//秒で入力
    private float initialTotalTime;
    int seconds;

    bool countDownFlag = false;

    public StageSetting stageSetting;//stagesetting側
    GameObject refObj;

    // Use this for initialization
    void Start()
    {
        refObj = GameObject.Find("StageManager");
        stageSetting = refObj.GetComponent<StageSetting>();

        timerText.text = "TimeLimit:" + (seconds / 60).ToString() + (seconds % 60).ToString();
        initialTotalTime = totalTime;
    }


    public void TimerInit()
    {
        totalTime = initialTotalTime;
        countDownFlag = false;
    }
    // Update is called once per frame
    public void CountDown()
    {
        countDownFlag = true;
        StartCoroutine(CountTimer());
    }
   IEnumerator CountTimer()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.T))
            {
                totalTime = 3;//テスト用　残り3秒
            }
            if (countDownFlag)
            {

                totalTime -= Time.deltaTime;
                seconds = (int)totalTime;
                timerText.text = "TimeLimit:" + (seconds / 60).ToString() + ":" + (seconds % 60).ToString();
                if (seconds % 2 == 0)
                {
                  //  stageSetting.RandomSpawn(Random.Range(0, 7), Random.Range(0, 7));

                }
            }
            if (totalTime <= 0)
            {
                TimerInit();
                FindObjectOfType<Score>().Save();
                FindObjectOfType<ChangeResult>().StartChange();

            }
            yield return null;
        }
       
    }
}
