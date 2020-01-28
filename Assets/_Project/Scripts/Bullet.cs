using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveDelta = 5;
    public Vector3 direction;

    private bool isOffscreen;

    public void Fire(Vector2 direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        transform.position += direction * moveDelta * Time.deltaTime;

        if (!isOffscreen && Camera.main.IsWorldPointOnScreen(transform.position))
        {
            Destroy(gameObject, 0.5f);
            isOffscreen = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // GetComponent returns null if the component isn't found
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        // So this condition will only be true if the component WAS found
        if (enemy)
        {
            Destroy(enemy.gameObject);
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(1);
        }
    }
}
