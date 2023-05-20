using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    public void SpawnBullet()
    {
        Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}
