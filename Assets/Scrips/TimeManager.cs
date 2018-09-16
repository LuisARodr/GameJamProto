using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameTime
{
    /// <summary>
    /// Clase que controla el tiempo, el tiempo avanza en decrementos.
    /// </summary>
    public class TimeManager
    {
        /// <summary>
        /// tiempo restante
        /// </summary>
        float timer;

        /// <summary>
        /// Inicializa TimeManager con la cantidad de tiempo del contador
        /// </summary>
        /// <param name="startingTime">Tiempo inicial en segundos </param>
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
        /// <summary>
        /// Disminuye el timepo restante en deltaTime
        /// </summary>
        public void AdvanceTime()
        {
            timer -= Time.deltaTime;
        }

        /// <summary>
        /// Actualiza el objeto Text llamado Timer con la cantidad de tiempo restante.
        /// </summary>
        public void UpdateTimer()
        {
            GameObject go = GameObject.Find("Timer");
            go.GetComponent<Text>().text = "    0:" + timer.ToString("00");
        }

        /// <summary>
        /// Disminuye el tiempo restante en deltaTime si el timepo no se ha acabado, 
        /// actualiza el timer de la UI,y regresa un bool que representa
        /// si el tiempo restante se ha acabado.
        /// </summary>
        /// <returns>True = el tiempo restante llego a 0
        ///         False =  en timepo restante es mayor a 0</returns>
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

        /// <summary>
        /// Disminuye el tiempo restante en deltaTime si el timepo no se ha acabado, 
        /// y regresa un bool que representa si el tiempo restante se ha acabado.
        /// </summary>
        /// <returns>True = el tiempo restante llego a 0
        ///         False =  en timepo restante es mayor a 0</returns>
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
