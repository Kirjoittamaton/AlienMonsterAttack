using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner3 : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject wave3;
    public GameObject enemyArea3;
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
            enemyArea3.SetActive(true);
            Instantiate(wave3, transform.position, transform.rotation);
            repeating = false;
            print("alueella3");




        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyArea3.SetActive(false);
        }
    }

}