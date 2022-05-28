using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{

    [SerializeField]
    private string nextSceneName;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextSceneName);
    }
}
