using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private float minAngular = 35, maxAngular = 80;
    void Start()
    {
        UIScript.OnPause.AddListener(Pause);
        UIScript.OnResume.AddListener(Resume);

        rb2d = GetComponent<Rigidbody2D>();

        if (speed > 0) speed *= -1;            
        rb2d.AddForce(new Vector2(Random.Range(-1.5f, 1.5f), speed), ForceMode2D.Impulse);
       
        if(Random.Range(0,2) == 0)
            rb2d.angularVelocity = Random.Range(minAngular, maxAngular);
        else
            rb2d.angularVelocity = Random.Range(-minAngular, -maxAngular);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    Vector2 velocity;
    private void Pause()
    {
        velocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void Resume()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
