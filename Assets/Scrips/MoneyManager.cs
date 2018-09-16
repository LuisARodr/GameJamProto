using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    /// <summary>
    /// Clase estatica que controla el dinero del juego y las actividades.
    /// </summary>
    public static class MoneyManager
    {
        /// <summary>
        /// dinero total del juego
        /// </summary>
        public static float TotalMoney = 0;
        /// <summary>
        /// dinero total de la actividad
        /// </summary>
        public static float ActivityMoney = 0;
        

        /// <summary>
        /// Añade a la cantidad de dinero de la actividad actual, tambien refresca el contador de dinero de la pantalla.
        /// Para disminuir la cantidad de dinero usar un money negativo.
        /// </summary>
        /// <param name="money">Cantidad de dinero a sumar </param>
        public static void AddActivityMoney(float money)
        {
            ActivityMoney += money;
            RefeshCounter();
        }
        /// <summary>
        /// Finaliza la actividad actual agregando el dinero de la actividad al dinero total.
        /// Regresa el dinero de la actividad a 0
        /// </summary>
        public static void EndActivity()
        {
            TotalMoney += ActivityMoney;
            ActivityMoney = 0;
        }
        /// <summary>
        /// Hace que el contador de la pantalla se actualize con el valor del dinero de la actividad actual.
        /// Usa un formato de $ 000.00
        /// </summary>
        private static void RefeshCounter()
        {
            GameObject go = GameObject.Find("MoneyCount");
            //Debug.Log("hello");
            go.GetComponent<Text>().text = "$ " + ActivityMoney.ToString("000.00");
        }

    }
}

