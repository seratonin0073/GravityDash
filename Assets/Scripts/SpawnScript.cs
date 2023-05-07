using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float SpawnTime;
    public int FoodChance;
    public Color FoodColor;
    [Space(10)]
    public GameObject Enemy;


    private GameObject[] SpawnPosition;
    private GameObject enemyObj;
    void Start()
    {
        enemyObj = GameObject.Find("EnemObj");
        SpawnPosition = GameObject.FindGameObjectsWithTag("SpawnPosition");
        if (FoodColor.a < 0.5f) FoodColor.a = 1;
        if (FoodChance == 0) FoodChance = 10;
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        GameObject obj = Instantiate(Enemy,
            SpawnPosition[Random.Range(0, SpawnPosition.Length)].transform.position,
            Quaternion.identity);

        obj.transform.SetParent(enemyObj.transform);
        if (Random.Range(0,100) < FoodChance)
        {
            obj.gameObject.tag = "Food";
            obj.GetComponent<SpriteRenderer>().color = FoodColor;
            obj.GetComponent<BoxCollider2D>().size = new Vector2(1.3f,1.3f);
        }
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(Spawn());
  }
}
