using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public new Camera camera;
    public Player player;

    [Header("Enemy Spawning")]
    public Enemy enemyPrefab;
    public Booster boosterPrefab;
    public float spawnCooldownMax = 1f;
    private float spawnCooldown;
    private Line spawnLine;

    private void Awake()
    {
        // The spawn line will be along the edges of the screen
        Vector2[] points = new Vector2[5];
        points[0] = camera.ViewportToWorldPoint(new Vector2(0, 0));
        points[1] = camera.ViewportToWorldPoint(new Vector2(0, 1));
        points[2] = camera.ViewportToWorldPoint(new Vector2(1, 1));
        points[3] = camera.ViewportToWorldPoint(new Vector2(1, 0));
        points[4] = camera.ViewportToWorldPoint(new Vector2(0, 0));
        spawnLine = new Line(points);
    }

    private void Update()
    {
        if(spawnCooldown > 0f)
        {
            spawnCooldown -= Time.deltaTime;
        }
        else
        {
            if (Random.value < 0.8f)
            {
                Enemy newEnemy = Instantiate(enemyPrefab, spawnLine.GetNormalisedPoint(Random.value), Quaternion.identity);
                newEnemy.movement.Initialise(player.transform);
            }
            else
            {
                Booster newBooster = Instantiate(boosterPrefab, spawnLine.GetNormalisedPoint(Random.value), Quaternion.identity);
                newBooster.movement.Initialise(player.transform);
            }
            spawnCooldown = spawnCooldownMax;
        }
    }
}
