using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

	[SerializeField]
	GameObject sprite;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name.Equals("ColliderCreate")) {
			Instantiate(sprite, transform.position, transform.rotation);
			transform.position += new Vector3 (10f, 0f, 0f);
		}
	}

}
