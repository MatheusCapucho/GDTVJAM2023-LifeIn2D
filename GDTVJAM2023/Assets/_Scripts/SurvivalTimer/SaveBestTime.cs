using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBestTime : MonoBehaviour
{

    private static float _bestTimeInSeconds;
    private static float _currentTimeInSeconds;
    public static Action<float> SaveTimer;

    private void OnEnable()
    {
        SaveTimer += Save;
    }

    private void OnDisable()
    {
        SaveTimer -= Save;
    }

    private void Save(float sec)
    {

        _currentTimeInSeconds = sec;

        if(_currentTimeInSeconds > GetBestTime())
        {
            _bestTimeInSeconds = _currentTimeInSeconds;
            PlayerPrefs.SetFloat("BestTime", _bestTimeInSeconds);
        }

    }

    public static float GetBestTime()
    {
        _bestTimeInSeconds = PlayerPrefs.HasKey("BestTime") ? PlayerPrefs.GetFloat("BestTime") : 0f;
        return _bestTimeInSeconds;
    }

    public static float GetCurrentTime()
    {
        return _currentTimeInSeconds;
    }

}
