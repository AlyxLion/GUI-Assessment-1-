using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Componets Menu section under the option Soy Sauce/player Scrpts/Player iteraction
[AddComponentMenu("soy Sauce/Player Scripts/Player")]

public class Interact : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyBindManager.inputKeys["Interact"]))
        {
            #region
            //RAY- A ray is an infinate line starting at origin and going in the same direction.
            //RAYCASTING- Casts a ray, from the point origin, in direction direction, of length maxDistance, against all colliders in the scene.
            //RAYCASTHIT- Structure used to get information back from raycast
            #endregion
            //creat ray
            Ray interactRay; // this is out line... Our Ray/Lione doesnt have an origin, or a direction//assigning origgin
            //this ray is shooting out from the main cameras screen point center of screen
            //assigning origin
            interactRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));// this ray is shooting out from the main camera screen point center of screen
            //create hit info
            RaycastHit hitInfo;
            //if this physics raycast hits somthing with 10 units
            if(Physics.Raycast(interactRay,out hitInfo,10))
            {
                #region
                //if the collider we hit is tagged NPC
                if (hitInfo.collider.tag=="NPC")
                {
                    //Debug that we hit a NPC
                    Debug.Log("NPC");
                    if (hitInfo.collider.gameObject.GetComponent<LinearDlg>())
                    {
                        hitInfo.collider.gameObject.GetComponent<LinearDlg>().showDlg = true;
                    }
                }
                #endregion
                #region Item
                //if the collider we hit is tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    //Debug that we Hit a Item
                    Debug.Log("Item");
                    ItemHander handler = hitInfo.transform.GetComponent<ItemHander>();
                    if (handler!=null)
                    {
                        handler.OnCollection();
                    }
                }
                #endregion
                #region Chest
                if (hitInfo.collider.CompareTag("Chest"))//and that hits info is tagged Item
                {
                    //Debug that we hit an Item  
                    Debug.Log("Our Interact ray hit a Chest");
                    LinearChest currentChest = hitInfo.transform.GetComponent<LinearChest>();
                    if (currentChest != null)
                    {
                        currentChest.showChest = !currentChest.showChest;
                    }
                }
                #endregion

            }
        }
    }
}
