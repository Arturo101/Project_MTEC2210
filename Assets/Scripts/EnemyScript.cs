using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Invader[] prefabs;

    public int rows = 5;

    public int columns = 11;

    private Vector3 _direction = Vector2.right;

    public float speed = 1.0f;

    public GameObject bulletPrefab;

    private float timeTillFire;

    public float fireDelay = 3;

    
    //public int scoreValue;
    void Start()
    {
        timeTillFire = fireDelay;
        

    }


    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 1.0f * (this.rows - 1);
            Vector2 centering = new Vector2 (-width / 2, - height / 2 );
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for(int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.position = position;
            }

        }
        
    
    }
    private void Update()
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject. activeInHierarchy){
                continue;
            }
            if (_direction == Vector3.right && invader.position.x > (rightEdge.x - 1.0f)){
                AdvanceRow();
                } else if (_direction == Vector3.left && invader.position.x < (leftEdge.x + 1.0f)){
                    AdvanceRow();
                }
        }
        
        if (timeTillFire > 0)
        {
            timeTillFire -= Time.deltaTime;
        }
        else
        {
            EnemyShoot();
            timeTillFire = fireDelay;

        }

    }
    public void EnemyShoot()
    {
        int numberofEnemies = GetComponentsInChildren<Invader>().Length;
        int index = Random.Range(0, numberofEnemies);
        var enemyArray = GetComponentsInChildren<Invader>();
        Vector3 bullPos = enemyArray[index].transform.position;
        Instantiate(bulletPrefab, bullPos, Quaternion.identity);
    }
    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;

    }
}
