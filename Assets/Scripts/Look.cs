﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Joemomma.FPSTutorial
{

    public class Look : MonoBehaviour
    {

        #region Variables
        public static bool cursorLocked = true;

        public Transform player;
        public Transform cams;
        public Transform weapon;

        public float xSensitivity;
        public float ySensitivity;
        public float maxAngle;

        private Quaternion camCenter;

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            camCenter = cams.localRotation; //set rotation origin for camera to camCenter
        }

        // Update is called once per frame
        void Update()
        {
            SetY();
            SetX();

            UpdateCursorLock();
        }

        void SetY()
        {
            float t_input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
            // the adj means adjusment.
            Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
            Quaternion t_delta = cams.localRotation * t_adj;

            if (Quaternion.Angle(camCenter, t_delta) < maxAngle)
            {
                cams.localRotation = t_delta;
            }

            weapon.rotation = cams.rotation;
        }

        void SetX()
        {
            float t_input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
            // the adj means adjusment.
            Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
            Quaternion t_delta = player.localRotation * t_adj;
            player.localRotation = t_delta;
            
        }

        void UpdateCursorLock()
        {
            if(cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    cursorLocked = false;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    cursorLocked = true;
                }
            }
        }
    }
}