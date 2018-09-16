using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoreGame
{
    namespace Combos
    {
        /// <summary>
        /// Clase estatica que contiene el combo counter
        /// </summary>
        public static class ComboManager
        {
            /// <summary>
            /// numero actual del combo
            /// </summary>
            static public int comboCounter = 0;

            /// <summary>
            /// suma 1 a el combo actual
            /// </summary>
            public static void addCombo()
            {
                comboCounter += 1;
            }

            /// <summary>
            /// regresa el combo a 0 
            /// </summary>
            public static void resetCombo()
            {
                comboCounter = 0;
            }
        }
    }
}
