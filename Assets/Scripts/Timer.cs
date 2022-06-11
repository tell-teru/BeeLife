using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;

        timerText = GetComponentInChildren<Text>();

        var ScoreMin = PlayerPrefs.GetInt("Time min", minute);
        var ScoreSec = PlayerPrefs.GetInt("Time sec", ((int)seconds));

        //ScoreText.text = "はちみつ" + "\n" + "Time :  " + ScoreMin.ToString("00") + ":" + ScoreSec.ToString("00");
    }

    // Update is called once per frame
    void Update()
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
        }
        oldSeconds = seconds;

        PlayerPrefs.SetInt("Time min", minute);
        PlayerPrefs.SetInt("Time sec", ((int)seconds));
    }





    //// 登録されたBestTimeを取り出す
    //void Load()
    //{
    //    // もしベストスコアが保存されていたら
    //    if (PlayerPrefs.HasKey(BESTTIME_KEY))
    //    {
    //        bestTime = PlayerPrefs.GetFloat(BESTTIME_KEY);
    //    }
    //    else
    //    {
    //        // ベストスコアを0として取り出す
    //        bestTime = f;
    //        PlayerPrefs.SetFloat(BESTTIME_KEY, 0.0f);
    //    }

    //}



}
