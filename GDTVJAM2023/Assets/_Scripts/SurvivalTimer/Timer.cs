using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startingTime;
    private TextMeshProUGUI _timerText;
    private float _currentTimePassed;
    private String _currentTimePassedText;
    public String CurrentTimePassedText;
    private bool _isRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
        _currentTimePassed = _startingTime;
        _currentTimePassedText = _startingTime.ToString();
        _timerText.text = _currentTimePassedText;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunning)
            UpdateTimer();
    }

    public void UpdateTimer()
    {
        _currentTimePassed += Time.deltaTime;
        float timeSpanConversionHours = TimeSpan.FromSeconds(_currentTimePassed).Hours;
        float timeSpanConversionMinutes = TimeSpan.FromSeconds(_currentTimePassed).Minutes;
        float timeSpanConversionSeconds = TimeSpan.FromSeconds(_currentTimePassed).Seconds;

        string textfieldHours = timeSpanConversionHours.ToString("00");
        string textfieldMinutes = timeSpanConversionMinutes.ToString("00");
        string textfieldSeconds = timeSpanConversionSeconds.ToString("00");

        _currentTimePassedText = _startingTime.ToString(string.Format("{0:00}:{1:00}:{2:00}", textfieldHours, textfieldMinutes, textfieldSeconds));

        _timerText.text = _currentTimePassedText;
    }

    public void StopTimer()
    {
        _isRunning = false;
        print(_currentTimePassed);
        SaveBestTime.SaveTimer(_currentTimePassed);
        _currentTimePassed = _startingTime;
    }

}
