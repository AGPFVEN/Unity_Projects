using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    float countdown;
    void Start()
    {
        countdown = 0;
        transform.position = new Vector3(Random.Range(-11.5f, 11.5f), Random.Range(-5f, 6f), 0);
    }
    void Update()
    {
        countdown += 1 * Time.deltaTime;

        if (countdown >= 5)
        {
            Instantiate(gameObject);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            GameObject.Find("Canvas").GetComponent<Interfaz>().score += 2.5f;
            Instantiate(gameObject);
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "player")
        {
            GameObject.Find("Canvas").GetComponent<Interfaz>().score += 5;
            Instantiate(gameObject);
            Destroy(gameObject);
        }
    }
}
