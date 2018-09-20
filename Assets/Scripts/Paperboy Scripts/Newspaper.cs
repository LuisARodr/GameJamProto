using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

	[SerializeField]
	GameObject newspaper;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("X_Button")) {
			GameObject news = Instantiate (newspaper, transform.position, transform.rotation);
			news.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 50f);
			news.name = "newspaper";
		}
	}
}
