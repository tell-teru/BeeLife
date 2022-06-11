using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    [SerializeField]
    public static int minute;
    [SerializeField]
    public static float seconds;

    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト
    public Text timerText;

    public bool StopTime;


    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;

        StopTime = true;

        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StopTime == true)
        {
            seconds += Time.deltaTime;
            if (seconds >= 60f)
            {
                minute++;
                seconds = seconds - 60;
            }
            //　値が変わった時だけテキストUIを更新
            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");

                if (SceneManager.GetActiveScene().name == "Finish")
                {
                    //StopTime = false;

                }
            }
            oldSeconds = seconds;

        }

    }


}
