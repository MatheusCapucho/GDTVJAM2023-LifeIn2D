using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseGameObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.IsPaused)
        {
            GameManager.IsPaused = true;
            _pauseGameObject.SetActive(true);
            Time.timeScale = 0f;
        } 
        else
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.IsPaused)
        {
            GameManager.IsPaused = false;
            _pauseGameObject.SetActive(false);
            Time.timeScale = 1f;
        }

    }

}
