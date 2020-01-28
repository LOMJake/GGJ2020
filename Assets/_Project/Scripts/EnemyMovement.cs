using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : ChaseMovement
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // GetComponent returns null if the component isn't found
        Player player = collision.gameObject.GetComponent<Player>();
        // So this condition will only be true if the component WAS found
        if (player)
        {
            player.status.AddHitpoints(-1);
            Destroy(gameObject);
        }
    }
}
