using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Transform _fruitsTransform;


    public void StartSpawningFood()
    {
        StartCoroutine(SpawnFood());
    }
    private IEnumerator SpawnFood()
    {
        while (true)
        {
            int foodIndex = Random.Range(0, _templates.Length);
            GameObject template = Instantiate(_templates[foodIndex], transform.position, _templates[foodIndex].transform.rotation, _fruitsTransform);
            yield return new WaitForSeconds(_spawnDelay);
        }

    }
}
