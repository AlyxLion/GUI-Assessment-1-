using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Component section under the option Soy Sauce/Player Scripts/Mouse Look
[AddComponentMenu("Soy Sauce/Player Scripts/First Person Mouse Look")]
public class MouseLook : MonoBehaviour
{
    #region RotationalAxis
    //What are Enums???
    /*enums are what we call state value variables 
      they are comma separated lists of identifiers
      we can use them to create types or categories */
    //Create a public enum called RotationalAxis
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    #endregion
    #region Variables
    [Header("Rotation")]
    //create a public reference to the rotational axis called axis and set a defualt axis
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Header("Sensitivity")]
    //public floats for our x and y sensitivity  
    public Vector2 sensitivity = new Vector2(30, 30);
    [Header("Y Rotation Clamp")]
    //public floats max and min Y rotation
    public Vector2 rotationRangeY = new Vector2(-60, 60);
    //float for rotation Y//we will have to invert our mouse position later to calculate our mouse look correctly
    float _rotY;

    #endregion
    public static int invert = -1;
    void Start()
    {
        //Lock Cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
        //Hide Cursor from view
        Cursor.visible = false;
        //if our game object has a rigidbody attached to it
        if (GetComponent<Rigidbody>())
        {
            //set the rigidbodys freezeRotation to true
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        //if our game object has a Camera attached to it
        if (GetComponent<Camera>())
        {
            //Set our rotation for a MouseY axis
            axis = RotationalAxis.MouseY;
        }
    }
    void Update()
    {
        #region Mouse X
        //if we are rotating on the X
        if (axis == RotationalAxis.MouseX)
        {
            //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity.x * Time.deltaTime, 0);
        }
        #endregion
        #region Mouse Y
        //else we are only rotating on the Y
        else
        {
            //our rotation Y is plus equals  our mouse input for Mouse Y times Y sensitivity
            _rotY += Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime;
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
            _rotY = Mathf.Clamp(_rotY, rotationRangeY.x, rotationRangeY.y);
            //transform our local euler angle to the next vector3 rotation -rotY on the x axis
            transform.localEulerAngles = new Vector3(invert * _rotY, 0, 0);
        }
        #endregion
    }
}

