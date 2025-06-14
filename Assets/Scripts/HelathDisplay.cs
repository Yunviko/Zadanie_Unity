using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelathDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHearts;
    public Image[] hearths;
    

    void Start() 
    { }
    

    void Update()
    {
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
            if(i<maxHealth)
            {
                hearths[i].enabled=true;             
            }
            else
            {
                hearths[i].enabled=false;
            }
        }
    }
    




    
}
