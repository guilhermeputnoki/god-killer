using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool right;
    [SerializeField]
    private bool left;
    [SerializeField]
    private bool up;
    [SerializeField]
    private bool down;

    public GameObject bullet;
    public GameObject player;

    public Transform playerp;
    public Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerp = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerp.transform.position.x, playerp.transform.position.y);
        LookAt();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }

        //if(right)
        //{
            //transform.Translate(Vector3.right * Time.deltaTime * speed);
        //}
        
        //if(left)
        //{
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
        //}

        //if(up)
        //{
            //transform.Translate(Vector3.up * Time.deltaTime * speed);
        //}

        //if(down)
        //{
            //transform.Translate(Vector3.down * Time.deltaTime * speed);
        //}
        
    }

    public void LookAt()
    {
        Vector3 playerPosition = player.transform.position;

        Vector2 direction = new Vector2(playerPosition.x - bullet.transform.position.x, playerPosition.y - bullet.transform.position.y);
        if(up || down)
        {
            bullet.transform.up = direction;
        }

        if(right || left)
        {
            bullet.transform.right = direction;
        }
    }
}
