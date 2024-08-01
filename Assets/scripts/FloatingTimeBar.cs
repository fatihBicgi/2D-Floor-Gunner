using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTimeBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    private bool isTimerWorking = true;
    private bool isSuperpowerAvailable = false;

    [SerializeField]
    float
        timerValue = 0f,
        currentValue = 0f,
        maxValue = 10;

    private void Update()
    {

        //bu ciktiyi kontrol etmek isteyen kiþi isSuperpowerAvailable in degerini cekecek ve kullanacak,
        //gucu kullanýnca da isSuperpowerAvailable u false yapacak

        if (isSuperpowerAvailable == false)
        {
            TimerWork();
        }
        
    }

    private void TimerWork()
    {
        if (isTimerWorking)
        {
            if (timerValue <= maxValue)
            {
                timerValue += Time.deltaTime;
                UpdateTimeBar();
            }

            else
            {
                //if timer is full you can use superpower
                timerValue = 0;
                isTimerWorking = false;

                isSuperpowerAvailable = true;
            }
        }
    }

    private void UpdateTimeBar()
    {
        currentValue = timerValue;
        slider.value = currentValue / maxValue;
    }

    // getter setter
    public bool GetisSuperpowerAvailable()
    {
        return isSuperpowerAvailable;
    }
    public void SetisSuperpowerAvailableFalse()
    {
        isSuperpowerAvailable = false;
    }



}
