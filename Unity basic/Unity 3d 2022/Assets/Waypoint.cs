using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private bool hasLoadNewScene = false;

    //a
    private void OnTriggerEnter(Collider other)
    {
        if (!hasLoadNewScene)
        {
            hasLoadNewScene = true;
            //SceneManager.LoadScene(sceneName);
            StartCoroutine(LoadSceneDelay());
        }
    }

    private IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneName);
    }
}
