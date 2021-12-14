using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameManager gameManager;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);


        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameManager.IncreaseScore(collision.gameObject.GetComponent<Invader>().scoreValue);
            Destroy(collision.gameObject);
            //gameManager.IncreaseScore(collision.gameObject.GetComponent<EnemyScript>().scoreValue);


        }
        Destroy(gameObject);
    }
   
}
