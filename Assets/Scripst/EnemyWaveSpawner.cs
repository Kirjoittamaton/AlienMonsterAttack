using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyWaveSpawner : MonoBehaviour
{


    public GameManager gameManager;
    public GameObject wave1;
    public GameObject enemyArea;
    public GameObject enemyArea2;
    public GameObject player;
    //static Transform playerMove;
    //public NavMeshAgent myAgent;
    public bool repeating = true;
  
    

    // Start is called before the first frame update
    void Start()
    {
        // gameManager = GetComponent<GameManager>();  
        //Instantiate(Wave[1], transform.position, transform.rotation)
        enemyArea.SetActive(true);
       // myAgent = wave1.GetComponentInChildren<NavMeshAgent>();
        //playerMove = Transform.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && repeating)
        {
            //GetComponent<EnemyScript>().target = player.transform.Find();
            //GetComponent<EnemyScript>().myAgent = myAgent;
            wave1 = Instantiate(wave1, transform.position, transform.rotation);
            
                

                repeating = false;


            print("alueella");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
          
            enemyArea.SetActive(false);
            enemyArea2.SetActive(true);
            player.GetComponent<PlayerMover>().Gun[0].SetActive(false);
            player.GetComponent<PlayerMover>().Gun[1].SetActive(true);

        }
    }


}       










