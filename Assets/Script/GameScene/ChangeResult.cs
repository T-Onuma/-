using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeResult : MonoBehaviour {
    bool a_flag;
    float a_color;
    float red, green, blue;    //RGBを操作するための変数
    public float speed;  //透明化の速さ
    bool once = true;

    // Use this for initialization
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        a_flag = false;
        a_color = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //a_flagがtrueの間実行する
        if (a_flag)
        {
            GetComponent<Image>().color = new Color(red, green, blue, a_color);
            a_color += speed;

            //透明度が255になったら終了する。
            if (a_color >= 1)
            {
                a_color = 0;
                a_flag = false;
                SceneManager.LoadScene("ResultScene");
            }
        }
    }

    public void StartChange()
    {
        a_flag = true;
        a_color = 0;
        once = false;
    }
}
