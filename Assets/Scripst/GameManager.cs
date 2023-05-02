using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyArea;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<PlayerMover>(Gun[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            enemyArea[0].SetActive(true);
        }

    }
    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            enemyArea[0].SetActive(false);
            enemyArea[1].SetActive(true);

            /* GetComponent(PlayerMover.FindFirstObjectByType);
                 Gun[0].SetActive(false);
                 enemyArea[1].SetActive(true);
         */

        }

    }





}
    




