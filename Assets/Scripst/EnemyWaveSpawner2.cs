using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner2 : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject wave2;
    public GameObject enemyArea2;
    
    public GameObject player;
    public bool repeating = true;

    // Start is called before the first frame update
    void Start()
    {
        // gameManager = GetComponent<GameManager>();  
        //Instantiate(Wave[1], transform.position, transform.rotation)

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && repeating)
        {
            enemyArea2.SetActive(true);
            //GetComponent<EnemyScript>().target = player.transform.Find();
            //GetComponent<EnemyScript>().myAgent = myAgent;
            wave2 = Instantiate(wave2, transform.position, transform.rotation);



            repeating = false;


            print("alueella");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            enemyArea2.SetActive(false);
            //enemyArea3.SetActive(true);

        }
    }

}