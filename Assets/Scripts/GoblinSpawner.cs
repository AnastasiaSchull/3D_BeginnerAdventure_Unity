using System.Collections;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goblinPrefab; 
    [SerializeField] private Transform target; // цель 
    [SerializeField] private float spawnInterval = 5f; 
    [SerializeField] private int maxGoblinCount = 60; 
    private int currentGoblinCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnGoblin());
    }

    private IEnumerator SpawnGoblin()
    {
        while (currentGoblinCount < maxGoblinCount)
        {
            Spawn();
            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    private void Spawn()
    {
        if (goblinPrefab != null)
        {
            GameObject goblin = Instantiate(goblinPrefab, transform.position, Quaternion.identity);
            Goblin goblinScript = goblin.GetComponent<Goblin>();

            if (goblinScript != null && target != null)
            {
                goblinScript.SetTarget(target); // цель для гоблина
            }

            currentGoblinCount++;
        }
    }
}
