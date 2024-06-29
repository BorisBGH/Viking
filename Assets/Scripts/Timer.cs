using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _timerText;
    private float _timerValue;




    private void Update()
    {
        if (_timerValue > 0)
        {
            _timerValue -= Time.deltaTime;
            UpdateTimerText();
            if (_timerValue <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void UpdateTimerText()
    {
        _timerText.text = Mathf.RoundToInt(_timerValue).ToString();
    }

    public void SetValue(float value)
    {
        if (_timerValue == 0)
        {
            _timerValue = value;
        }
    }

}
