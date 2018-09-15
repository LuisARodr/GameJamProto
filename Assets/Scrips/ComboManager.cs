using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoreGame
{
    namespace Combos
    {
        public class ComboManager
        {
            static public int comboCounter = 0;

            public static void addCombo()
            {
                comboCounter += 1;
            }

            public static void resetCombo()
            {
                comboCounter = 0;
            }
        }
    }
}
