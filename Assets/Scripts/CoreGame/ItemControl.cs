using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame
{
    namespace Items
    {
        public static class ItemControl
        {
            /// <summary>
            /// Representa que objetos se an comprado para enseñarse en la casa del jugador.
            /// 0 = comida
            /// 1 = cerveza
            /// 2 = meds en general
            /// </summary>
            public static bool[] items = { false, true, false };

        }
    }
}