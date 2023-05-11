using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        UIScript.OnPause.AddListener(Pause);
        UIScript.OnResume.AddListener(Resume);
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
        if(Input.GetMouseButtonDown(0) && !isPaused)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
        }
    }


    Vector2 velocity;
    private void Pause()
    {
        isPaused = true;
        velocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void Resume()
    {
        isPaused = false;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }


}
