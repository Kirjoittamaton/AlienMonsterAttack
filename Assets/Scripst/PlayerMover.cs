using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMover : MonoBehaviour
{
    public CharacterController CharacterController;



    [Header("Player Movement")]
    [SerializeField] GameObject player;
    [SerializeField] float inputX;
    [SerializeField] float inputZ;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    //[SerializeField] bool heightUp;
    //[SerializeField] bool heightDown;


    [Header("Health")]
    public float health = 100f;
    public float damage = 20f;
    public Text healthText;
    public GameObject enemy;


    [Header("Shooting")]
    //public GameObject bullet;
    // public GameObject gun;
    // public float fireRate = 0.5f;
    //  public bool canFire = true;
    //public GameObject hitEffect;
    //public GameObject gun1;

    [Header("Shooting")]
    [SerializeField] public GameObject Bullet1;
    [SerializeField] public GameObject Bullet2;
    //[SerializeField] public  GameObject GunHole1;
    //[SerializeField] public GameObject GunHole2;
    //[SerializeField] public  GameObject GunHole3;
    //[SerializeField] public  GameObject GunHole4;
    [SerializeField] public GameObject[] Gun;
    [SerializeField] public GameObject[] enemeyArea;


    [Header("Gun1")]
    [SerializeField] public GameObject[] GunHole;
    [SerializeField] public float fireRate = 0.5f;
    [SerializeField] public bool canFire = true;
    public GameObject hitEffect;

    public Animator gun1Animator;

    [Header("Gun2")]
    [SerializeField] public GameObject[] GunHole2_1;
    [SerializeField] public float fireRate2 = 0.5f;
    [SerializeField] public bool canFire2 = true;
    public GameObject hitEffect2;

    public void Hit(float damage)
    {
        //TextMeshPro healthText;
        health -= damage;

        healthText.text = "+" + health.ToString();


        if (health <= 0)
        {
            print("tuhouduit");
        }

    }




    // Start is called before the first frame update
    void Start()
    {
        //gun1 = .GetComponent<Gun1Script>();
        GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        // GetComponent<Gun1Script>();
        gun1Animator = GetComponentInChildren<Animator>();
        Gun[1].SetActive(false);
    }


    void Update()
    {

        Movement();
        if (Input.GetButtonDown("Jump"))
        {
            moveSpeed = 20f;
        }
        else if (Input.GetButtonUp("Turbo"))
        {
            moveSpeed = 5f;
        }


        {
           // transform.Rotate(0, Input.GetAxis("Rotate") * 60 * Time.deltaTime, 0);
            CharacterController characterController = GetComponent<CharacterController>();
        }

        if (Input.GetButton("HeightUp"))
        {
            transform.position = transform.position + Vector3.up * moveSpeed * Time.deltaTime;
            print("up");
        }

        if (Input.GetButton("HeightDown"))
        {
            transform.position = transform.position + -Vector3.up * moveSpeed * Time.deltaTime;
            print("down");
        }

        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);

        if (Input.GetButton("Fire1"))
        {
            StartCoroutine("shoot");


        }
        else
        {
            StartCoroutine("idle");
        }
    }
    private void Movement()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.forward * inputZ + transform.right * inputX;
        CharacterController.Move(moveDir * moveSpeed * Time.deltaTime);

        

        if (inputX > 1)
        {

        }

        if (inputX < -1)
        {

        }


    }



    public IEnumerator shoot()
    {
        if (Gun[0].activeSelf)
        {
            gun1Animator.SetBool("Shooting", true);

            yield return new WaitForSeconds(fireRate);

            Instantiate(Bullet1, GunHole[0].transform.position, GunHole[0].transform.rotation);
            canFire = false;
            yield return new WaitForSeconds(fireRate);
            canFire = true;

            Instantiate(Bullet1, GunHole[1].transform.position, GunHole[1].transform.rotation);
            canFire = false;
            yield return new WaitForSeconds(fireRate);
            canFire = true;

            Instantiate(Bullet1, GunHole[2].transform.position, GunHole[2].transform.rotation);
            canFire = false;
            yield return new WaitForSeconds(fireRate);
            canFire = true;

            Instantiate(Bullet1, GunHole[3].transform.position, GunHole[3].transform.rotation);
            canFire = false;
            yield return new WaitForSeconds(fireRate);
            canFire = true;

            yield return new WaitForSeconds(fireRate);
        }
        else if (Gun[1].activeSelf)
        {
            Instantiate(Bullet2, GunHole2_1[0].transform.position, GunHole2_1[0].transform.rotation);
            canFire2 = false;
            yield return new WaitForSeconds(fireRate2);
            canFire2 = true;


        }



    }


    public IEnumerator idle()
    {
        gun1Animator.SetBool("Idle", true);
        gun1Animator.SetBool("Shooting", false);
        yield return new WaitForSeconds(2);


    }



    //transform.Translate(new Vector3(hor * moveSpeed * Time.deltaTime, ver * moveSpeed * Time.deltaTime, 0));
    /*
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime * -ver);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * hor);

            if (Input.GetButton("Fire1"))
            {



        /// <returns>The 3d mouse position</returns>





        */

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<EnemyScript>().Hit(damage);
        }


        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hit(damage);
        }

    }
}