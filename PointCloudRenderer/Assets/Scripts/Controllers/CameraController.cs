﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers {
    /*
     * CameraController for flying-controls
     */
    public class CameraController : MonoBehaviour {

        //Current yaw
        private float yaw = 0.0f;
        //Current pitch
        private float pitch = 0.0f;

        private float lowSpeed = 10;
        private float highSpeed = 100;

        void Start() {
            //Hide the cursor
            Cursor.visible = false;
        }


        void FixedUpdate() {
            //React to controls. (WASD, EQ and Mouse)
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            float moveUp = Input.GetKey(KeyCode.E) ? 1 : Input.GetKey(KeyCode.Q) ? -1 : 0;

            float speed = lowSpeed;
            if (Input.GetKey(KeyCode.LeftShift)) {
                speed = highSpeed;
            }
            transform.Translate(new Vector3(moveHorizontal * speed * Time.deltaTime, moveUp * speed * Time.deltaTime, moveVertical * speed * Time.deltaTime));

            yaw += 2 * Input.GetAxis("Mouse X");
            pitch -= 2 * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }

}
