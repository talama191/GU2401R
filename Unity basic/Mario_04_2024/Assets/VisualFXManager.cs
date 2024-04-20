using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFXManager : MonoBehaviour
{
    public static VisualFXManager Instance;

    [SerializeField] private GameObject disappearFXPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnDisappearEffect(Vector3 pos)
    {
        GameObject effect = Instantiate(disappearFXPrefab, pos, Quaternion.identity);
        StartCoroutine(DestroyEffect(effect));
    }

    IEnumerator DestroyEffect(GameObject effect)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(effect);
    }
}
