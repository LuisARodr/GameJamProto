using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class Houses : MonoBehaviour {

	[SerializeField]
	GameObject YellowHouse, RedHouse, Walkway, Bush1, Bush2, Trashcan, Mailbox;
	[SerializeField]
	int Dificultad;
	bool casaRoja = false;

	int calculateHouseColor(){
		return (int)Mathf.Round (Random.Range (0, 2));
	}

	int calculateBushes(){
		if (Dificultad == 0) {
			return 0;
		} else if (Dificultad == 1) {
			return (int)Mathf.Round (Random.Range (0, 10));
		} else if (Dificultad == 2) {
			return (int)Mathf.Round (Random.Range (0, 5));
		} else if (Dificultad == 3) {
			return (int)Mathf.Round (Random.Range (0, 3));
		} else {
			return 0;
		}
	}

	int calculateTrashcan(){
		if (Dificultad == 0) {
			return 0;
		} else if (Dificultad == 1) {
			return (int)Mathf.Round (Random.Range (0, 10));
		} else if (Dificultad == 2) {
			return (int)Mathf.Round (Random.Range (0, 5));
		} else if (Dificultad == 3) {
			return (int)Mathf.Round (Random.Range (0, 3));
		} else {
			return 0;
		}
	}

	int calculateMailbox(){
		if (Dificultad == 0) {
			return (int)Mathf.Round (Random.Range (0, 3));
		} else if (Dificultad == 1) {
			return (int)Mathf.Round (Random.Range (0, 5));
		} else if (Dificultad == 2) {
			return (int)Mathf.Round (Random.Range (0, 7));
		} else if (Dificultad == 3) {
			return (int)Mathf.Round (Random.Range (0, 10));
		} else {
			return 0;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name.Equals("ColliderCreate")) {
			if (calculateHouseColor() == 0) {
				GameObject casamarilla = Instantiate(YellowHouse, transform.position, transform.rotation);
				casamarilla.name = "yellow house";
				casaRoja = false;
			} else {
				GameObject casaroja = Instantiate(RedHouse, transform.position, transform.rotation);
				casaroja.name = "red house";
				casaRoja = true;
			}
			if (calculateBushes () == 1) {
				GameObject arbusto1 = Instantiate (Bush1, new Vector3(transform.position.x-2.8f,-1f,0f), transform.rotation);
				GameObject arbusto2 = Instantiate (Bush2, new Vector3(transform.position.x-2.5f,-2.5f,0f), transform.rotation);
				GameObject arbusto3 = Instantiate (Bush1, new Vector3(transform.position.x+2.8f,-1f,0f), transform.rotation);
				GameObject arbusto4 = Instantiate (Bush2, new Vector3(transform.position.x+2.3f,-2.5f,0f), transform.rotation);
				arbusto1.name = arbusto2.name = arbusto3.name = arbusto4.name = "bushes";
			}
			if (calculateTrashcan () == 1) {
				GameObject basura = Instantiate (Trashcan, new Vector3(transform.position.x-1f,-1.8f,0f), transform.rotation);
				basura.name = "trashcan";
			}
			if (calculateMailbox () == 1) {
				GameObject buzon = Instantiate (Mailbox, new Vector3(transform.position.x+1f,-1.6f,0f), transform.rotation);
				if (casaRoja) {
					buzon.name = "red mailbox";
				} else {
					buzon.name = "mailbox";
				}
			}
			Instantiate (Walkway, new Vector3(transform.position.x,-1.4f,0f), transform.rotation);
			transform.position += new Vector3 (6f, 0f, 0f);
		}
	}
}
