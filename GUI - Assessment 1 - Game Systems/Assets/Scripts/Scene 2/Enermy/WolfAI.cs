using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : AngryKevinWayPoints
{
    public void BiteAttack()
    {
        //0-20
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        if (critChance>=17)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        player.GetComponent<PlayerHandler>().DamagePlayer(baseDamage * difficulty + critDamage);
    }
}
