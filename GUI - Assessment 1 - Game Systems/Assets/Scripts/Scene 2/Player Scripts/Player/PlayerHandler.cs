using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : Stats
{
    [Header("Damage Flash and Death")]
    public Image damageImage;
    public Image deathImage;
    public Text deathText;
    public AudioClip deathClip;
    public AudioSource playersAudio;
    public Transform currentCheckPoint;
    //                                      R G B A
    public Color flashColour = new Color(1, 0, 0, 0.2f);
    public float flashSpeed = 5f;
    public static bool isDead;
    public bool isDamaged;
    public bool canHeal;
    public float healDelayTimer;

    // Start is called before the first frame update
    void DeathText()
    {
        deathText.text = "You've Fallen in Battle...";
    }

    // Update is called once per frame
    void RespawnText()
    {
        deathText.text = "...But the Gods have devided it is not your time...";
    }
    void Respawn()
    {
        //RESET EVERYTHING
        deathText.text = "";
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].currentValue = attributes[i].maxValue;
        }
        isDead = false;
        //load psition
        this.transform.position = currentCheckPoint.position;
        this.transform.rotation = currentCheckPoint.rotation;
        //Resoawn
        deathImage.GetComponent<Animator>().SetTrigger("Respawn");
    }
    void Death()
    {
        //Set the death flag to dead
        isDead = true;
        //clear exsiting text just in case!
        deathText.text = "";
        //Set and Play audio clip
        playersAudio.clip = deathClip;
        playersAudio.Play();
        //Trigger death screen
        deathImage.GetComponent<Animator>().SetTrigger("isDead");
        //in 2 seconds set our text when we die
        Invoke("DeathText", 2f);
        //in 6 second set out text when we respawn
        Invoke("RespawnText", 6f);
        //in 9 second respawn us
        Invoke("Respawn", 9f);
    }
    public void RegenOverTime(int valueIndex)
    {
        attributes[valueIndex].currentValue += Time.deltaTime * (attributes[valueIndex].regenValue/*plus multiplier of stat eg consitution or dex*/);
    }
    public void DamagePlayer(float damage)
    {
        //Turn on red flicker
        isDamaged = true;
        //take damage
        attributes[0].currentValue -= damage;
        //delay regen healing
        canHeal = false;
        healDelayTimer = 0;
        if (attributes[0].currentValue <= 0 && !isDead)
        {
            Death();
        }
    }
    private void Update()
    {
        //debug
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.X))
        {
            DamagePlayer(10);
        }
#endif
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].displayImage.fillAmount = Mathf.Clamp01(attributes[i].currentValue / attributes[i].maxValue);
        }
        #region DamageFlash
        if (isDamaged && !isDead)
        {
            damageImage.color = flashColour;
            isDamaged = false;
        }
        else if (damageImage.color.a>0)
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        #endregion
        #region
        if (!canHeal)
        {
            healDelayTimer += Time.deltaTime;
            if (healDelayTimer >=5)
            {
                canHeal = true;
            }
        }
        if (canHeal && attributes[0].currentValue < attributes[0].maxValue && attributes[0].currentValue > 0)
        {
            RegenOverTime(0);
        }
        #endregion
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckPoint = other.transform;
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i].regenValue += 7;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i].regenValue -= 7;
            }
        }
    }
}