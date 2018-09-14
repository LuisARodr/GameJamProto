using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameTime
{
    public class TimeManager
    {
        float timer;

        public TimeManager(float startingTime)
        {
            timer = startingTime;
        }

        /// <summary>
        /// Inicializa el tiempo inicial del contador de tiempo
        /// </summary>
        /// <param name="startingTime">Tiempo inicial en segundos</param>
        public void StartTime(float startingTime)
        {
            timer = startingTime;
        }

        public void AdvanceTime()
        {
            timer -= Time.deltaTime;
        }

        public void UpdateTimer()
        {
            GameObject go = GameObject.Find("Timer");
            go.GetComponent<Text>().text = "    0:" + timer.ToString("00");
        }

        public bool IsTimeOverUpdate()
        {
            if (timer - Time.deltaTime > 0)
            {
                AdvanceTime();
            }
            else
            {
                timer = 0;
                UpdateTimer();
                return true;
            }
            UpdateTimer();
            return false;
        }

        public bool IsTimeOver()
        {
            if (timer - Time.deltaTime > 0)
            {
                AdvanceTime();
            }
            else
            {
                timer = 0;
                return true;
            }
            return false;
        }



    }

}
