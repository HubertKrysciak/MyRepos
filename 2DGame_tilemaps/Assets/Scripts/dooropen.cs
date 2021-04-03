using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{

    public SpriteRenderer door;
    public Sprite DO;
    public Sprite mysprite;

    private SpriteRenderer toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "plr")
        {
            toggle.sprite = mysprite;
            door.sprite = DO;
        }
    }
}
