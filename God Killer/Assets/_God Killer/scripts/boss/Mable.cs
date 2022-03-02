using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mable : MonoBehaviour
{
    public dialogueControl DC;

    public dialogue Dialogue1;
    public dialogue Dialogue2;
    public dialogue Dialogue3;

    public AudioSource music;

    public int life = 3;

    public Animator anim;

    public GameObject powerOrbShooter;
    public GameObject powerOrbShooterDown;
    public GameObject powerOrbShooterUp;

    public int randomShooter;
    public float deley;

    public bool canShoot;

    public Transform spanwShooter1;
    public Transform spanwShooter2;
    public Transform spanwShooter3;
    public Transform spanwShooter4;
    public Transform spanwShooter5;
    public Transform spanwShooter6;
    public Transform spanwShooter7;
    public Transform spanwShooter8;
    public Transform spanwShooter9;
    public Transform spanwShooter10;

    public Transform spawnPowerOrbDown;
    public Transform spawnPowerOrbUp;

    public BoxCollider2D bc;
    public BoxCollider2D bcDamage;
    public SpriteRenderer sprite;

    void Start()
    {
        canShoot = true;
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        if(DC.StartBossFight && canShoot)
        {
            bc.enabled = true;
        }

        if(life <= 0)
        {
            anim.SetBool("dead", true);
            Destroy(this, 1);
            music.Pause();
        }
    }

    void SpanwShooter()
    {
        randomShooter = Random.Range(0, 10);

        if(randomShooter <= 1)
        {
            Instantiate(powerOrbShooter, spanwShooter1.position, spanwShooter1.rotation);
        }

        if(randomShooter == 2)
        {
            Instantiate(powerOrbShooter, spanwShooter2.position, spanwShooter2.rotation);
        }

        if(randomShooter == 3)
        {
            Instantiate(powerOrbShooter, spanwShooter3.position, spanwShooter3.rotation);
        }

        if(randomShooter == 4)
        {
            Instantiate(powerOrbShooter, spanwShooter4.position, spanwShooter4.rotation);
        }

        if(randomShooter == 5)
        {
            Instantiate(powerOrbShooter, spanwShooter5.position, spanwShooter5.rotation);
        }

        if(randomShooter == 6)
        {
            Instantiate(powerOrbShooter, spanwShooter6.position, spanwShooter6.rotation);
        }

        if(randomShooter == 7)
        {
            Instantiate(powerOrbShooter, spanwShooter7.position, spanwShooter7.rotation);
        }

        if(randomShooter == 8)
        {
            Instantiate(powerOrbShooter, spanwShooter8.position, spanwShooter8.rotation);
        }

        if(randomShooter == 9)
        {
            Instantiate(powerOrbShooter, spanwShooter9.position, spanwShooter9.rotation);
        }

        if(randomShooter == 10)
        {
            Instantiate(powerOrbShooter, spanwShooter10.position, spanwShooter10.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InvokeRepeating("SpanwShooter", 0, 1);
            canShoot = false;
            bc.enabled = false;
        }

        if(collision.gameObject.tag == "damage1")
        {
            StartCoroutine(TakeDamage());
            life--;
            InvokeRepeating("SpawnPowerOrbDown", 0, 3);
            InvokeRepeating("SpawnPowerOrbUP", 0, 5);
            if(life == 2)
            {
                Dialogue1.Activate();
            }
            if(life == 1)
            {
                Dialogue2.Activate();
            }
            if(life == 0)
            {
                Dialogue3.Activate();
            }
        }
    }

    public void SpawnPowerOrbDown()
    {
        if(life <= 2)
        {
            Instantiate(powerOrbShooterDown, spawnPowerOrbUp.position, spawnPowerOrbUp.rotation);
        }
    }

    public void SpawnPowerOrbUP()
    {
        if(life <= 1)
        {
            StartCoroutine(secondAttacks());
        }
    }

    IEnumerator TakeDamage()
    {
        bcDamage.enabled = false;
        sprite.color = new Color(1f, 0, 0, 1f); 
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1f, 1f, 1f, 1f);
        
        for(int i = 0; i < 7; i++)
        {
            sprite.enabled  = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled  = true;
            yield return new WaitForSeconds(0.15f);
        }

        bcDamage.enabled = true;
    }

    IEnumerator secondAttacks()
    {
        anim.SetBool("secondAttack", true);
        yield return new WaitForSeconds(0.5f);
        Instantiate(powerOrbShooterUp, spawnPowerOrbDown.position, spawnPowerOrbDown.rotation);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("secondAttack", false);
    }
}
