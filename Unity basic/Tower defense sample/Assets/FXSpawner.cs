using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : MonoBehaviour
{
    public static FXSpawner Instance { get; private set; }

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

    [SerializeField] private ParticleSystem explosionFXPrefab;

    public void SpawnExplosionEffect(Vector3 position)
    {
        ParticleSystem effect = Instantiate(explosionFXPrefab, position, Quaternion.identity);
        //effect.Play();
        StartCoroutine(DespawnEffect(effect.gameObject, 2f));
    }

    IEnumerator DespawnEffect(GameObject effect, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(effect);
    }
}
