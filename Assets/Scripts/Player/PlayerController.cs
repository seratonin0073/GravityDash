using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int rnd = Random.Range(0, 2);
        if(rnd == 0)
        {
            transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
        }
    }

    
}
