using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public void SpawnBullet(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}
