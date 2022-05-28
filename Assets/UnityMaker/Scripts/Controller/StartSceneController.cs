using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{

    // 次のシーン名を指定する変数
    [SerializeField]
    string nextSceneName;

    // ゲーム開始するためのキーコード
    [SerializeField]
    KeyCode startKey = KeyCode.X;

    [SerializeField]
    Text hightScoreValue;



    private void Start()
    {
        int point = PlayerPrefs.GetInt("point");
        int highScore = PlayerPrefs.GetInt("highscore");

        if (point > highScore)
        {
            highScore = point;
            PlayerPrefs.SetInt("highscore", highScore);
        }

        PlayerPrefs.DeleteKey("coin");
        PlayerPrefs.DeleteKey("point");
        hightScoreValue.text = highScore.ToString("0000000");
    }


    void Update()
    {

        // ゲーム開始のキーを押した場合
        if (Input.GetKeyDown(startKey))
        {
            // 次のシーンをロードする処理を開始
            StartCoroutine(StartGame());
        }
    }


    private IEnumerator StartGame()
    {
        foreach (AudioSource audioS in FindObjectsOfType<AudioSource>())
        {
            audioS.volume = 0.2f;
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 0.5f);

        // 次のシーン名を文字列で指定してロード
        SceneManager.LoadScene(nextSceneName);
    }
}