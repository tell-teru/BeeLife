using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{

    public int time = 300;

    public string resetSceneName;
    public Text timer;


    void Update()
    {
        int remainingTime = time - Mathf.FloorToInt(Time.timeSinceLevelLoad * 1.0f);

        if (0 <= remainingTime)
        {
            timer.text = remainingTime.ToString("000");
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                StartCoroutine(LoadNextScene());
                enabled = false;
            }
        }
    }


    private IEnumerator LoadNextScene()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            player.SendMessage("TimeOver", SendMessageOptions.DontRequireReceiver);
        }

        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(resetSceneName);
    }
}

