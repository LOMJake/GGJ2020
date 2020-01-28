using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public new Camera camera;

    [Header("Bullet")]
    public Bullet bulletPrefab;
    public string bulletLayer = "PlayerBullet";
    public Transform bulletSpawnPoint;

    [Header("Graphic")]
    public Transform graphic;
    public float graphicTurnDelta = 5f;

    [Header("Cooldown")]
    private bool semiAuto = true;
    public float fireCooldownMax = 0.2f;
    private float fireCooldown;
    public float boosterTimerMax = 2f;
    private float boosterTimer;

    void Update()
    {
        Vector2 aimDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aimDirection.Normalize();

        graphic.LerpToFaceDirection(aimDirection, graphicTurnDelta * Time.deltaTime);

        boosterTimer -= Time.deltaTime;
        semiAuto = boosterTimer <= 0;

        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }

        bool fire;
        if (semiAuto)
        {
            fire = Input.GetButtonDown("Fire1");
        }
        else
        {
            fire = fireCooldown <= 0f && Input.GetButton("Fire1");
        }

        if (fire)
        {
            Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            newBullet.Fire(aimDirection);
            newBullet.gameObject.layer = LayerMask.NameToLayer(bulletLayer);

            fireCooldown = fireCooldownMax;
        }
    }

    public void ApplyBooster()
    {
        boosterTimer = boosterTimerMax;
    }
}
