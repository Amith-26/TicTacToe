using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadPlayAgain()
    {
        StartCoroutine(DelayLauncher());
    }
    IEnumerator DelayLauncher()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
