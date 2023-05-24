using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelBoundaries : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void GameOver()
    {
        print("ff");
    }
}
