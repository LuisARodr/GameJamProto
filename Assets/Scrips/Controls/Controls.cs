using UnityEngine;

namespace CoreGame {
    public static class Controls {
        static bool LeftJoystickMoved;
        static bool RightJoystickMoved;
        static bool PadMoved;
        static bool LeftTriggerMoved;
        static bool RightTriggerMoved;

        public static bool button_A {
            get { return Input.GetButton("A_Button"); }
        }
        public static bool button_B {
            get { return Input.GetButton("B_Button"); }
        }
        public static bool button_X {
            get { return Input.GetButton("X_Button"); }
        }
        public static bool button_Y {
            get { return Input.GetButton("Y_Button"); }
        }
        public static bool button_Left {
            get { return Input.GetButton("Left_Button"); }
        }
        public static bool button_Right {
            get { return Input.GetButton("Right_Button"); }
        }
        public static bool button_Back {
            get { return Input.GetButton("Back_Button"); }
        }
        public static bool button_Start {
            get { return Input.GetButton("Start_Button"); }
        }
        
        // -- Left Axis
        public static float LeftHorizontal() {
            float r = 0.0f;
            r += Input.GetAxis("J_Left_Horizontal");
            r += Input.GetAxis("K_Left_Horizontal");
            return Mathf.Clamp(r, -1.0f, 1.0f);
        }
        public static float LeftVertical() {
            float r = 0.0f;
            r += Input.GetAxis("J_Left_Vertical");
            r += Input.GetAxis("K_Left_Vertical");
            return Mathf.Clamp(r, -1.0f, 1.0f);
        }
        public static Vector2 LeftJoystick() {
            if (LeftHorizontal() != 0 || LeftVertical() != 0) {
                LeftJoystickMoved = true;
            }
            return new Vector2(LeftHorizontal(), LeftVertical());
        }
        public static bool LeftJoystickReturnedCenter() {
            if (LeftJoystickMoved) {
                if (LeftHorizontal() == 0 && LeftVertical() == 0) {
                    LeftJoystickMoved = false;
                    return true;
                }
            }
            return false;
        }

        // -- Right Axis
        public static float RightHorizontal() {
            float r = 0.0f;
            r += Input.GetAxis("J_Right_Horizontal");
            //r += Input.GetAxis("K_Right_Horizontal");
            return Mathf.Clamp(r, -1.0f, 1.0f);
        }
        public static float RightVertical() {
            float r = 0.0f;
            r += Input.GetAxis("J_Right_Vertical");
            //r += Input.GetAxis("K_Right_Vertical");
            return Mathf.Clamp(r, -1.0f, 1.0f);
        }
        public static Vector2 RightJoystick() {
            if (RightHorizontal() != 0 || RightVertical() != 0) {
                RightJoystickMoved = true;
            }
            return new Vector2(RightHorizontal(), RightVertical());
        }
        public static bool RightJoystickReturnedCenter() {
            if (RightJoystickMoved) {
                if (RightHorizontal() == 0 && RightVertical() == 0) {
                    RightJoystickMoved = false;
                    return true;
                }
            }
            return false;
        }

        // -- Pad Axis
        public static float PadHorizontal() {
            float r = 0.0f;
            r += Input.GetAxis("Pad_Horizontal");
            //r += Input.GetAxis("K_Pad_Horizontal");
            return Mathf.Clamp(r, -1.0f, 1.0f);
        }
        public static float PadVertical() {
            float r = 0.0f;
            r += Input.GetAxis("Pad_Vertical");
            //r += Input.GetAxis("K_Pad_Vertical");
            return Mathf.Clamp(r, -1.0f, 1.0f);
        }
        public static Vector2 Pad() {
            if (PadHorizontal() != 0 || PadVertical() != 0) {
                PadMoved = true;
            }
            return new Vector2(PadHorizontal(), PadVertical());
        }
        public static bool PadReturnedCenter() {
            if (PadMoved) {
                if (PadHorizontal() == 0 && PadVertical() == 0) {
                    PadMoved = false;
                    return true;
                }
            }
            return false;
        }

        // -- Left Trigger Axis
        public static float LeftTrigger() {
            float r = 0.0f;
            r += Input.GetAxis("Left_Trigger");
            //r += Input.GetAxis("K_Left_Trigger");
            r = Mathf.Clamp(r, -1.0f, 1.0f);
            if (r != 0) {
                LeftTriggerMoved = true;
            }
            return r;
        }
        public static bool LeftTriggerUp() {
            if (LeftTriggerMoved) {
                if (LeftTrigger() == 0) {
                    LeftTriggerMoved = false;
                    return true;
                }
            }
            return false;
        }

        // -- Right Trigger Axis
        public static float RightTrigger() {
            float r = 0.0f;
            r += Input.GetAxis("Right_Trigger");
            //r += Input.GetAxis("K_Right_Trigger");
            r = Mathf.Clamp(r, -1.0f, 1.0f);
            if (r != 0) {
                RightTriggerMoved = true;
            }
            return r;
        }
        public static bool RightTriggerUp() {
            if (RightTriggerMoved) {
                if (RightTrigger() == 0) {
                    RightTriggerMoved = false;
                    return true;
                }
            }
            return false;
        }
    }
}