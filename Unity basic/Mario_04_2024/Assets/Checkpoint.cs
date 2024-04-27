using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private Animator animator;

    private bool hasTrigger = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTrigger)
        {
            StartCoroutine(LoadScene());
            animator.enabled = true;
            hasTrigger = true;
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
