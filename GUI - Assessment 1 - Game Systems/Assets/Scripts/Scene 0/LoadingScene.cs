using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // scean zero will have this as the text
    public Text loadingText;
   
    // will need a t4ext that tells people contiue
    public Text continueText;
    // spinny boi
    public Image LionHead;
    public static bool callIsTure;
    public static bool callIsFalse;
    public static bool Dota2IsHardTryAGAIN;
    public static bool callIsOut;
    public static bool startHasBeen;




    // Start is called before the first frame update
    
    void Start()
    {
        LoadingText();
        LionHead.gameObject.SetActive(false);
        callIsFalse = false;
        callIsOut = false;
        callIsTure = false;
        Dota2IsHardTryAGAIN = false;
        startHasBeen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (callIsTure == true)
        {
            //are you reading this james I dids for you well if not you probs just clicked with mouse and that is BORING!!!!!!!!
            Dota2IsHardTryAGAIN = false;
        }

        if (callIsOut == true)
        {
            if (Input.anyKeyDown)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Dota2IsHardTryAGAIN = true;
                    ContinueButton();
                } 
                else
                {
                    callIsFalse = true;
                    ContinueButton();
                }
            }
        }
        if (startHasBeen == true)
        {
            ContinueButton();
        }

        return;
        
    }
    void LoadingText()
    {
        loadingText.text = "Loading Please Wait";
        //Spinning head
        Invoke("SpinnyHead", 2f);

        //will give the next button after 50 seconds because suffer Muhahahahahaha
        
        Invoke("ContinueButton", 18f);

    }
    void SpinnyHead()
    {
        //make the head visable 
        LionHead.gameObject.SetActive(true);       
    }
    void ContinueButton()
    {
        startHasBeen = true;
        if (callIsOut == false)
        {
            callIsOut = true;
            loadingText.text = "Please";
            continueText.text = "Press Any Key";
            callIsTure = false;
        }
        if (callIsFalse == true)
        {

            SceneManager.LoadScene(1);

        }

        if (Dota2IsHardTryAGAIN == true)
        {
            
            continueText.text = "Dont push that Key.....Try again but not with that KEY..... any KEY but that KEY.....";
            
            
            Invoke("False", 5f);


        }
        
    }
    void False()
    {
        callIsTure = true;
        callIsOut = false;
    }
   
}
