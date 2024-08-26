using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTimeBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    private bool isTimerWorking = true;

    SuperPower superPower;

    [SerializeField]
    float
        timerValue = 0f,
        currentValue = 0f,
        maxValue = 10;

    private void Start()
    {
        superPower = gameObject.GetComponent<SuperPower>();
    }

    private void FixedUpdate()
    {
        //bu ciktiyi kontrol etmek isteyen kiþi isSuperpowerAvailable in degerini cekecek ve kullanacak,
        //gucu kullanýnca da isSuperpowerAvailable u false yapacak

        if (superPower.GetisSuperpowerAvailable() == false)
        {
            TimerWork();
        }
                  
        if (superPower.isPlayerInvisibleNow)           
        {
            isTimerWorking = true;
        }

        if (superPower.isPlayerTeleported) 
        {
            isTimerWorking = true;
            superPower.SetisTeleportedFalse();

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

                superPower.SetisSuperpowerAvailableTrue();
            }
        }
    }

    private void UpdateTimeBar()
    {
        currentValue = timerValue;
        slider.value = currentValue / maxValue;
    }


}
