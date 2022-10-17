using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{

    public static Dinosaur sharedInstance;

    [SerializeField] private Transform playerChoose;
    private Vector3 playerPosition = Vector3.zero;
    private Rigidbody2D rb; 
    void Awake()
    {
        sharedInstance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //rb.MovePosition(playerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //playerPosition = playerChoose.position;

        if (canGoAgainToKill && Input.GetKey(KeyCode.K))
        {
            FindEnemy();
        }

        if (isBackToPlayer)
        {
            BackToPlayer();
        }
    }

    void FindEnemy()
    {
        
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(playerPosition.x + 50f, transform.position.y), 5f * Time.deltaTime);
        isGoToKillEnemy = true;
        isBackToPlayer = false;
    }


    public void BackToPlayer()
    {
        if (transform.position.x > playerChoose.position.x) 
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(playerChoose.position.x, transform.position.y), 5f * Time.deltaTime);
        } 

        if(transform.position.x <= playerChoose.position.x)
        {
            canGoAgainToKill = true;
            //isBackToPlayer = false;
            isGoToKillEnemy = false;
            canGoAgainToKill = true;
        }
    }

    public void DestroyEnemy()
    {
        isGoToKillEnemy = false;
        isBackToPlayer = true;
        canGoAgainToKill = false;
    }

    private bool isBackToPlayer = false;
    private bool canGoAgainToKill = true;
    private bool isGoToKillEnemy = false;
}
