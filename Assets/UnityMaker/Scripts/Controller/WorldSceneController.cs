using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class WorldSceneController : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    public Transform UnityChan;
    public Transform stopPosition;


    void LateUpdate()
    {
        var right = Camera.main.ViewportToWorldPoint(Vector2.right);
        var center = Camera.main.ViewportToWorldPoint(Vector2.one * 0.5f);

        if (center.x < UnityChan.position.x)
        {
            var pos = Camera.main.transform.position;

            if (Math.Abs(pos.x - UnityChan.position.x) >= 0.0000001f)
            {
                Camera.main.transform.position = new Vector3(UnityChan.position.x, pos.y, pos.z);
            }
        }

        if (stopPosition.position.x - right.x < 0)
        {
            WorldClear();
            enabled = false;
        }
    }


    public void WorldClear()
    {
        StartCoroutine(LoadNextScene());
    }


    public void GameOver()
    {
        StartCoroutine(LoadStartScene());
    }


    public void GameClear()
    {
        StartCoroutine(LoadStartScene());
    }


    private IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(1.65f);
        SceneManager.LoadScene("Start");
    }


    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextSceneName);
    }
}

