using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Start_Button"))
        {
            GameManager.scene = 1;
            GameManager.goToScene(1);//1 es la escena de la pantalla de titulo actualmente.
        }
	}
}
