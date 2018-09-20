using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Money;

public class Character2D : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb2d;
	float contador;
	float tiempo;

	[SerializeField]
	float Velocity;

    [SerializeField]
    Text tiempoText;

	void Awake () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		tiempo = 60;
	}

	Vector2 Axis{
		get
		{
			return new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		}
	}

	// Use this for initialization
	void Start () {
        MoneyManager.IniciateMoney();

    }

	// Update is called once per frame
	void Update () {
		anim.SetFloat("Move",Mathf.Abs(rb2d.velocity.x));
		if (Input.GetButtonUp("A_Button")) {
			rb2d.velocity += new Vector2 (3f, 0f);
		}
		contador -= Time.deltaTime;
		if (contador < 0) {
			if (rb2d.velocity.x > 0) {
				rb2d.velocity -= new Vector2 (2f, 0f);
			}
			contador = 0.5f;
		}

        tiempo -= Time.deltaTime;
        tiempoText.text = tiempo.ToString("00");
        if (tiempo < 0) {
            MoneyManager.EndActivity();
            GameManager.goToScene(20);//20es el numero de la escena de transicion.
        }
	}
}