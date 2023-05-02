using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun1Script : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] public static GameObject blullet1;
    [SerializeField] public static GameObject GunHole1;
    [SerializeField] public static GameObject GunHole2;
    [SerializeField] public static GameObject GunHole3;
    [SerializeField] public static GameObject GunHole4;
    [SerializeField] public static GameObject Gun1;
    [SerializeField] public static float fireRate = 0.5f;
    [SerializeField] public static bool canFire = true;
    public GameObject hitEffect;
    public static  Animator gun1Animator;
   


    // Start is called before the first frame update
    void Start()
    {
        blullet1 = GameObject.Find("blullet1");
        Gun1 = GameObject.Find("Gun1");
        GunHole1 = GameObject.Find("GunHole1");
        GunHole2 = GameObject.Find("GunHole2");
        GunHole3 = GameObject.Find("GunHole3");
        GunHole4 = GameObject.Find("GunHole4");
        gun1Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetButtonDown("Jump"))
        {

            StartCoroutine("shootBullets");
        }*/
    }

    public static IEnumerator ShootBullets()
    {
        

            gun1Animator.SetBool("Shooting", true);

        GunHole1 = Instantiate(blullet1, GunHole1.transform.position, GunHole1.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true; 
        
        GunHole2 = Instantiate(blullet1, GunHole2.transform.position, GunHole2.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
        
        GunHole3 = Instantiate(blullet1, GunHole3.transform.position, GunHole3.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;

        GunHole4 = Instantiate(blullet1, GunHole4.transform.position, GunHole4.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;

        

    }

    public static IEnumerator ShootIdle()
    {
        
        gun1Animator.SetBool("Idle", true);
        gun1Animator.SetBool("Shooting", false);
        yield return new WaitForSeconds(2);
    }
}
