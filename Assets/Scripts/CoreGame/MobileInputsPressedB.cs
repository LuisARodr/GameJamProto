﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

namespace CoreGame {
    public class MobileInputsPressedB : MonoBehaviour {

        bool touchStart = false;
        bool touchButton = false;
        Vector2 pointA;
        Vector2 pointB;
        Vector2 direction;

        bool A_Button, B_Button_Down, B_Button_Up, B_Button_Began, X_Button, Y_Button;
        
        [SerializeField]
        Transform circle, outerCircle;

        [SerializeField]
        LayerMask layer;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (B_Button_Up) B_Button_Up = false;

            if ((Input.touchCount == 1)) {
                //Si va empezando el touch
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    //hacer un raycast
                    Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                    RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward, .1f, layer);
                    //Si hay un collider, comparar el nombre
                    if (hitInformation.collider != null) {
                        //Si es un boton
                        switch (hitInformation.collider.name) {
                            case "A_Button":
                                Debug.Log("A_Button");
                                A_Button = true;
                                touchButton = true;
                                pointA = pointB;
                                break;
                            case "X_Button":
                                Debug.Log("X_Button");
                                X_Button = true;
                                touchButton = true;
                                pointA = pointB;
                                break;
                            case "Y_Button":
                                Debug.Log("Y_Button");
                                Y_Button = true;
                                touchButton = true;
                                pointA = pointB;
                                break;
                        }
                    }
                    else {
                        //Es el joystick
                        Debug.Log("Joystick");
                        pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.transform.position.z));
                        circle.transform.position = pointA;
                        outerCircle.transform.position = pointA;
                    }
                }
                else if (!touchButton && (Input.GetTouch(0).phase == TouchPhase.Moved
                                       || Input.GetTouch(0).phase == TouchPhase.Stationary)) {
                    touchStart = true;
                    pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                }
                else {
                    touchStart = false;
                    touchButton = false;
                    A_Button = false;
                    X_Button = false;
                    Y_Button = false;
                }
            }
            
            //Para que sirva el B ocupas estar moviendo la palanca tambien
            if ((Input.touchCount == 2)) {
                Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward, .1f, layer);
                //Si hay un collider, comparar el nombre
                if (hitInformation.collider != null) {
                    if (hitInformation.collider.name == "B_Button") {
                        //B began
                        if (Input.GetTouch(1).phase == TouchPhase.Began) {
                            Debug.Log("B_Button");
                            B_Button_Began = true;
                        }
                        //B Down
                        else if (Input.GetTouch(1).phase == TouchPhase.Moved
                                || Input.GetTouch(1).phase == TouchPhase.Stationary) {
                            B_Button_Began = false;
                            B_Button_Down = true;
                        }
                        //B up
                        if (Input.GetTouch(1).phase == TouchPhase.Ended) {
                            B_Button_Down = false;
                            B_Button_Up = true;
                        }
                    }
                }
            }
        }

        private void FixedUpdate() {
            if (touchStart) {
                Vector2 offset = pointB - pointA;
                direction = Vector2.ClampMagnitude(offset, 1.0f);
                circle.transform.position = pointA + direction * 3;
            }
            else {
                direction = Vector2.zero;
                Vector2 aTomarPorCulo = new Vector2(-100f, 0f); ;
                circle.transform.position = aTomarPorCulo;
                outerCircle.transform.position = aTomarPorCulo;
            }
        }

        public Vector2 Direction {
            get {
                return direction;
            }
        }
        public bool AButton {
            get {
                return A_Button;
            }
        }
        public bool BButtonDown {
            get {
                return B_Button_Down;
            }
        }
        public bool XButton {
            get {
                return X_Button;
            }
        }
        public bool YButton {
            get {
                return Y_Button;
            }
        }
        public bool BButtonUp {
            get {
                return B_Button_Up;
            }
        }
        public bool BButtonBegan {
            get {
                return B_Button_Began;
            }
        }

    }
}