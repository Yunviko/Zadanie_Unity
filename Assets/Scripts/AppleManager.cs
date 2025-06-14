using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppleManager : MonoBehaviour
{
    public int appleCount;
    public Text appleText;

    [SerializeField] private List<GameObject> apples;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject apple in apples)
        {
            if (Vector2.Distance(player.position, apple.transform.position) <= 1f)
            {
                appleCount++;
                apples.Remove(apple);
                Destroy(apple);
                break;
            }           
        }
        appleText.text = appleCount.ToString();
    }
}
