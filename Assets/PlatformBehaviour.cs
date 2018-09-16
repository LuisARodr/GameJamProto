using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el movimiento de las plataformas
/// </summary>
public class PlatformBehaviour : MonoBehaviour {

    /// <summary>
    /// Si true, la plataforma se mueve en el eje movingHorizontaly y con un rango de movementRange
    /// </summary>
    public bool isMoving = false;
    /// <summary>
    /// Rango por el que la plataforma se movera, solo se usa si isMoving es true
    /// </summary>
    public float movementRange = 5;
    /// <summary>
    /// representa como se mueve la plataforma, si true, la plataforma se mueve en el eje x, si false se mueve en el eje y
    /// </summary>
    public bool movingHorizontaly = true;
    /// <summary>
    /// cantidad de unidades por deltaTime que la plataforma se va a mover.
    /// </summary>
    public float speed = 0.04f;
    /// <summary>
    /// Representa la cantidad de unidades que se ha movido la plataforma, se usa para conocer que tanto se ha movido la
    /// plataforma para compar con movementRange.
    /// </summary>
    private float movedUnits;
    /// <summary>
    /// Si true el valor de movedUnits incrementa, si false el valor de movedUnits decrementa.
    /// </summary>
    private bool increasing;

    /// <summary>
    /// Transform de la plataforma a mover
    /// </summary>
    private Transform platformTransform;
    /// <summary>
    /// Posicion Inicial de la plataforma
    /// </summary>
    private Vector3 originalPosition;


	// Use this for initialization
	void Start () {
        platformTransform = GetComponent<Transform>();
        originalPosition = platformTransform.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isMoving)
        {
            movedUnits += movedUnits + speed > movementRange && increasing ? movementRange - movedUnits : 
                movedUnits + speed <= movementRange && increasing ? speed :
                movedUnits - speed > 0 && !increasing ? -speed : -movedUnits;

            platformTransform.position = movingHorizontaly?  originalPosition + new Vector3(movedUnits, 0, 0) : 
                originalPosition + new Vector3(0, movedUnits, 0);


            if(movedUnits == movementRange || movedUnits == 0)
            {
                increasing = !increasing;
            }   
        }
	}


}
