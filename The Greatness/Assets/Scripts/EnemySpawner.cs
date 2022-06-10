using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _container;

    public void SpawnEnemies(int count)
    {
        StartCoroutine(Spawn(count));
    }

    private IEnumerator Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            foreach (GameObject enemy in _prefabs)
            {
                Instantiate(enemy, _container.transform);
                yield return new WaitForSeconds(Random.Range(.5f, 1));
            }
        }
    }
}
