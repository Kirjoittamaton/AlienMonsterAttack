using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipDamage1 : MonoBehaviour
{
    public GameObject Wing1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            Destroy (Wing1);

        }
    }
}
