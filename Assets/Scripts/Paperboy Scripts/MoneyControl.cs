using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Money;

public class MoneyControl : MonoBehaviour {
    
	bool LaCasaRecibioDinero = false;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name.Equals ("newspaper")) {
			switch (this.name) {
			case "yellow house":
                if(!LaCasaRecibioDinero) {
                    MoneyManager.AddActivityMoney(10f);
                    LaCasaRecibioDinero = true;
                    Debug.Log("LE DISTE A LA CASA AMARILLA");
                }
				break;
			case "red house":
                MoneyManager.AddActivityMoney(-50f);
                Debug.Log ("LE DISTE A LA CASA ROJA");
				break;
			case "mailbox":
                if (!LaCasaRecibioDinero) {
                    MoneyManager.AddActivityMoney(30f);
                    LaCasaRecibioDinero = true;
                    Debug.Log("LE DISTE AL BUZON");
                }
				break;
			case "red mailbox":
                MoneyManager.AddActivityMoney(-75f);
                Debug.Log ("LE DISTE AL BUZON DE LA CASA ROJA NO MA");
				break;
			case "bushes":
                MoneyManager.AddActivityMoney(-10f);
                Debug.Log ("LE DISTE A LOS ARBUSTOS");
				break;
			}
            Destroy(collider.gameObject);

        } else if (collider.name.Equals ("ColliderDelete") && this.name.Equals("yellow house")) { 
			//SI AL MOMENTO DE DESTRUIR UNA CASA AMARILLA ESTÁ FALSE LA VARIABLE
			//ES PORQUE NO LE DISTE A LA CASA NI AL BUZON, ASI QUE SE TE FUE
			if (!LaCasaRecibioDinero) {
                MoneyManager.AddActivityMoney(-10f);
                Debug.Log ("SE TE FUE UNA CASA :(");
			} else {
				LaCasaRecibioDinero = false;
			}
		}
	}

}
