using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent myAgent;
    public Transform target;
    public GameObject player;
    //public GameObject[] enemy;
    //public GameObject[] wave;
    //public GameObject Bullet1;

    public float damage = 20f;
    public float health = 100f;
    public Text healthText;
   public float x = 10f;
    public float y = 10f;

    public float fireRate = 0.5f;
    public bool canFire = true;
    public GameObject bullet;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;



    public void Hit(float damage)
    {
        health -= damage;
        healthText.text = "+" + health.ToString();
       // healthText.transform.position = enemy[0].transform.position + new Vector3(y, x);
        //healthText.transform.position = enemy[1].transform.position + new Vector3(y, x);
        //healthText.transform.position = enemy[2].transform.position + new Vector3(y, x);

        if (health <= 0) 
        {

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        target = transform.root.Find("/Player/");
        //healthText = GameObject.Find("/Canvas/HealthTextEnemy").GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        StartCoroutine("shoot");
        /*
                wave[0] = GameObject.FindWithTag("Wave1");
                wave[1] = GameObject.FindWithTag("Wave2");
                wave[2] = GameObject.FindWithTag("Wave3");



                if ( player == wave[0])
                {
                    enemy[0] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant1_1");
                    enemy[1] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant1_2");
                    enemy[2] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant1_3");
                }
                if (player == wave[1])
                {
                    enemy[0] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant2_1");
                    enemy[1] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant2_2");
                    enemy[2] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant2_3");
                }
                if (player == wave[2])
                {
                    enemy[0] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant3_1");
                    enemy[1] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant3_2");
                    enemy[2] = GameObject.Find("/enemyArea/EnemyArea/EnemyVariant3_3");
                }

               // enemy = GameObject[].Find("/enemyArea/EnemyArea");
                //Bullet1 = GameObject.Find("/Bullet1");
        */

        // myAgent = NavMeshAgent.

        //healthText = Text.Find("/Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        myAgent.destination = target.position;
      /*  if(myAgent)
        {
            
        }*/
            
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
           
            player.GetComponent<PlayerMover>().Hit(damage);
        }
 

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hit(damage);
        }

    
    }

    public IEnumerator shoot()
    {
        Instantiate(bullet, gun1.transform.position, gun1.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;

        Instantiate(bullet, gun2.transform.position, gun2.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;

        Instantiate(bullet, gun3.transform.position, gun3.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    /*public IEnumerator shoot()
    {
        Instantiate(Bullet1, transform.position, transform.rotation);
        
        yield return new WaitForSeconds(2);
        
    }
    */

}