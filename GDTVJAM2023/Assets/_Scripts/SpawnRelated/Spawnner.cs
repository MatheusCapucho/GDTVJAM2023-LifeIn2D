using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public void SpawnBullet(GameObject prefab)
    {
        Vector3 _spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-3.0f, 3.0f), transform.position.z);
        Instantiate(prefab, _spawnPosition, transform.rotation, transform);
    }
}
