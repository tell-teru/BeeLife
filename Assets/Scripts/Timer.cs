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
    ////　Score表示用テキスト
    //public Text ScoreText;

    public float bestTime;

    // BestTimeのPlayerPrefs
    const string BESTTIME_KEY = "BESTTIME";

    //public static ScoreMin;

    public bool StopTime;


    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;

        StopTime = true;

        timerText = GetComponentInChildren<Text>();

        //var ScoreMin = PlayerPrefs.GetInt("Time min", minute);
        //var ScoreSec = PlayerPrefs.GetInt("Time sec", ((int)seconds));

        //ScoreText.text = "はちみつ" + "\n" + "Time :  " + ScoreMin.ToString("00") + ":" + ScoreSec.ToString("00");
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

                //PlayerPrefs.SetInt("Time min", minute);
                //PlayerPrefs.SetInt("Time sec", ((int)seconds));


                if (SceneManager.GetActiveScene().name == "Finish")
                {
                    PlayerPrefs.SetInt("Time min", minute);
                    PlayerPrefs.SetInt("Time sec", ((int)seconds));


                    StopTime = false;

                    var ScoreMin = PlayerPrefs.GetInt("Time min", minute);
                    var ScoreSec = PlayerPrefs.GetInt("Time sec", ((int)seconds));

                    Debug.Log("StopTime");

                    Debug.Log("min : " + ScoreMin);
                    Debug.Log("sec : " + ScoreSec);

                    //Debug.Log("Time : " + Time.time);
                }
            }
            oldSeconds = seconds;

        }

    }


}
