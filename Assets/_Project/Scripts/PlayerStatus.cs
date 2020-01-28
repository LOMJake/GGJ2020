using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Text hitpointsLabel;
    public int hitpointsMax = 5;
    private int hitpoints;

    public MeshRenderer[] meshRenderers;
    public float hitTimerMax = 0.5f;
    private float hitTimer;
    private bool showRenderers;

    private void Start()
    {
        hitpoints = hitpointsMax;
        AddHitpoints(0);
    }

    private void Update()
    {
        UpdateRenderers();
    }

    void UpdateRenderers()
    {
        if (hitTimer > 0f)
        {
            hitTimer -= Time.deltaTime;
            showRenderers = !showRenderers;
        }
        else
        {
            showRenderers = true;
        }

        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = showRenderers;
        }
    }

    public void AddHitpoints(int amount)
    {
        hitpoints += amount;
        hitpointsLabel.text = "HP: " + hitpoints.ToString();

        // if taken damage
        if(amount < 0)
        {
            hitTimer = hitTimerMax;
        }

        // if no hp left
        if (hitpoints <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
