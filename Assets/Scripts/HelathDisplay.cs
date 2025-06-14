using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelathDisplay : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHearts;
    public Image[] hearths;
    public PlayerStats playerStats;

    void Start()
    { }

    void Update()
    {
        health = playerStats.health;
        maxHealth = playerStats.maxHealth;

        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < health)
            {
                hearths[i].sprite = fullHearts;
            }
            else
            {
                hearths[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearths[i].enabled = true;
            }
            else
            {
                hearths[i].enabled = false;
            }
        }
    }
}
