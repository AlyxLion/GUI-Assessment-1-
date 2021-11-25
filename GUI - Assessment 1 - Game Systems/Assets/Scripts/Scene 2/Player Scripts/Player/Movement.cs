using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the compinets menu sectin under the options soy sauce/player scripts.first person Movement
[AddComponentMenu("Soy Sauce/PlayerPrefs Scripts/First Person Movement")]
//This scrpt requires the component Character controller to be attahed to the Game Object
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    #region Extra Study
    //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
    //Input(https://docs.unity3d.com/ScriptReference/Input.html)
    //CharacterController allows you to move the character kinda like Rigidbody (https://docs.unity3d.com/ScriptReference/CharacterController.html
    #endregion
    #region Variables
    [Header("Character")]
    //Vector3 called moveDir, we wil use this to apply movement in worldspace
    public Vector3 moveDir;
    //Character controller called _charC
    [SerializeField]
    public CharacterController _charC;
    [Header("Character Speeds")]
    /* 
     public float varibles speed, walk = 5, run = 10, crouch = 2.5, jumpSpeed = 8, gravity = 20
    */
    public float speed;
    public float walk = 5, run = 10, crouch = -2.5f, jumpSpeed = 8, gravity = 20;
    [Header("Input")]
    public Vector2 input;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //_charc is set to the Character controller on this GameObject
        
        _charC = GetComponent<CharacterController>();

    }
    
    // Update is called once per frame
    void Update()
    {
        //MainMenu.keys
        /* input.y = 0;
        Input.GetKey(MainMenu.keys["Forward"]) = 1
        Input.GetKey(MainMenu.keys["Backward"]) = -1
        */
        if (Input.GetKey(KeyBindManager.inputKeys["Forward"]))
        {
            input.y = 1;
        }
        else if (Input.GetKey(KeyBindManager.inputKeys["Backward"]))
        {
            input.y = -1;
        }
        else
        {
            input.y = 0;
        }
        /*
        input.x = 0;
        Input.GetKey(MainMenu.keys["Left"]) = -1
        Input.GetKey(MainMenu.keys["Right"]) = 1
        */
        if (Input.GetKey(KeyBindManager.inputKeys["Left"]))
        {
            input.x = -1;
        }
        else if (Input.GetKey(KeyBindManager.inputKeys["Right"]))
        {
            input.x = 1;
        }
        else
        {
            input.x = 0;
        }
        /*
        speed = walk;
        Input.GetKey(MainMenu.keys["Sprint"] = run
        Input.GetKey(MainMenu.keys["Crouch"]) = crouch
        */
        if (Input.GetKey(KeyBindManager.inputKeys["Sprint"]))
        {
           speed= run;
        }
        else if (Input.GetKey(KeyBindManager.inputKeys["Crouch"]))
        {
            speed = crouch;
        }
        else
        {
            speed = walk;
        }
        //if out character is grounded
        if (_charC.isGrounded)
        {
            //set moveDri to the unputs direction 
            moveDir = new Vector3(input.x, 0, input.y);
            //moveDir's forward is changed from global z (forwards) to the Game Object local z (forward) - allows us to move where player is faceing
            moveDir = transform.TransformDirection(moveDir);
            // moveDir is muultiplied by speed so we move at a decent pace
            moveDir *= speed;
            //if the input button for jump is pressed then 
            if (Input.GetKey(KeyBindManager.inputKeys["Jump"]))
            {
                // out moveDur.y is equal to out jump speed
                moveDir.y = jumpSpeed;
            }
        }
        //regardless of if we are grounded or not the players moveDir.y is always affected by Gravity timesed mby time.deltaTime to normalize it
        moveDir.y -= gravity * Time.deltaTime;
        // we then tell the character Controller that it is moving in a direction ,ultiplied tome.deltaTime
        _charC.Move(moveDir * Time.deltaTime);

    }
}
