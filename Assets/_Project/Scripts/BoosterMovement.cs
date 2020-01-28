using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMovement : ChaseMovement
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.weapon.ApplyBooster();
            Destroy(gameObject);
        }
    }
}
