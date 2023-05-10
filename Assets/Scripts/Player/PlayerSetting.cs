using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    public int speed;
    public Color PlayerColor;
    [Space(10)]
    [HideInInspector] public GameObject EatFX;
    [HideInInspector] public GameObject BoomFX;
    [HideInInspector] public GameObject HitFX;

    private Rigidbody2D rb2d;
    private ScoreScript scoreScript;
    private PlayerSoundManager soundManager;
    void Start()
    {

        scoreScript = GameObject.Find("UIManager").GetComponent<ScoreScript>();
        rb2d = GetComponent<Rigidbody2D>();
        soundManager = GetComponent<PlayerSoundManager>();

        rb2d.AddForce(new Vector2(speed, 5), ForceMode2D.Impulse);

        if (PlayerColor.a < 0.5f) PlayerColor.a = 1;
        GetComponent<SpriteRenderer>().color = PlayerColor;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (soundManager != null) soundManager.PlaySound("Hit");
            //rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * -1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Destroy(collision.gameObject);
            
            Instantiate(EatFX, transform.position, Quaternion.identity);
            scoreScript.UpdateScore(1);

            if(soundManager != null) soundManager.PlaySound("Food");

        }
        if(collision.tag == "Enemy")
        {
            if (soundManager != null) soundManager.PlaySound("Dead");
            Instantiate(BoomFX, transform.position, Quaternion.identity);
            
            if(GameObject.FindObjectOfType<UIScript>())
            {
                GameObject.FindObjectOfType<UIScript>().Dead();
                rb2d.velocity = new Vector2(0f, 0f);
                transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                transform.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!!!");
        if (soundManager != null) soundManager.PlaySound("Hit");
        Instantiate(HitFX, transform.position, Quaternion.identity);
    }
}
