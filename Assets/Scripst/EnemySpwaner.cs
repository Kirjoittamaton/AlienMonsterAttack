using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{

    public GameObject Wave1;


    // Start is called before the first frame update
    void Start()
    {
        

        Instantiate(Wave1, transform.position, transform.rotation);
    

    }
  
}