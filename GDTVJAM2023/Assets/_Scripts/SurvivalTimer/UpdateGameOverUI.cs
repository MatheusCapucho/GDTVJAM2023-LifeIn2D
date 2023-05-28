using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateGameOverUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmpBestTime;
    [SerializeField]
    private TextMeshProUGUI tmpCurrentTime;
    void Start()
    {
        UpdateBestTime();
        UpdateCurrentTime();

    }

    private void UpdateCurrentTime()
    {
        float current = SaveBestTime.GetCurrentTime();
        var hours = TimeSpan.FromSeconds(current).Hours;
        var minutes = TimeSpan.FromSeconds(current).Minutes;
        var seconds = TimeSpan.FromSeconds(current).Seconds;
        string textfieldHours = hours.ToString("00");
        string textfieldMinutes = minutes.ToString("00");
        string textfieldSeconds = seconds.ToString("00");

        tmpCurrentTime.text = current.ToString(string.Format("{00}:{00}:{00}", textfieldHours, textfieldMinutes, textfieldSeconds));
    }

    private void UpdateBestTime()
    {
        float best = SaveBestTime.GetBestTime();
        var hours = TimeSpan.FromSeconds(best).Hours;
        var minutes = TimeSpan.FromSeconds(best).Minutes;
        var seconds = TimeSpan.FromSeconds(best).Seconds;
        string textfieldHours = hours.ToString("00");
        string textfieldMinutes = minutes.ToString("00");
        string textfieldSeconds = seconds.ToString("00");

        tmpBestTime.text = best.ToString(string.Format("{00}:{00}:{00}", textfieldHours, textfieldMinutes, textfieldSeconds));
    }
}
