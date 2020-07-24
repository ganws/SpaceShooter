using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{


    public float steerSpeed = 500;
    public float forwardSpeed = 500;
    public HealthBarController hpbar;

    public Rigidbody2D rb;
    public Transform player;

    // Laser Settings
    public GameObject laserPrefabs;
    public float laserSpeed = 25.0f;
    public float fireRate = 0.2f;

    private Vector3 fireOffset = new Vector3(0, 0.65f, 0);
    private float fireTimer;
    private int laserNum = 1;
    private int laserMaxNum = 6;
    private float laserSpacing = 0.2f;

    void Start()
    {
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("FireLaser");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalDir = Input.GetAxis("Horizontal");
        float verticalDir = Input.GetAxis("Vertical");

        //player.Translate(new Vector3(horizontalDir * Time.deltaTime * steerSpeed, verticalDir * Time.deltaTime * forwardSpeed, player.position.z));

        rb.velocity = new Vector2(horizontalDir * Time.deltaTime * steerSpeed, verticalDir * Time.deltaTime * forwardSpeed);
        if (Input.GetButton("Fire1"))
            FireLaser();

        fireTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
            hpbar.IncreaseHP();

    }

    private void FireLaser()
    {
        if (fireTimer <= 0)
        {
            AudioSource audio = FindObjectOfType<SoundController>().laser_fire;
            audio.PlayOneShot(audio.clip, 1f);

            Vector3 offset = fireOffset;
            for (int i = 0; i < laserNum; i++)
            {
                GameObject a = Instantiate(laserPrefabs) as GameObject;

                offset.x = -(laserNum-1)*laserSpacing * 0.5f + i*laserSpacing;
                a.transform.position = this.transform.position + offset;
                a.GetComponent<laser>().speed = laserSpeed;
            }
            fireTimer = fireRate;

        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("hit");
                hpbar.ReduceHP();
                laserNum -= 2;
                if (laserNum <= 0)
                    laserNum = 1;
                break;

            case "HPDrop":
                hpbar.IncreaseHP();
                Destroy(collision.gameObject);
                break;

            case "WeaponDrop":
                laserNum++;
                if (laserNum >= laserMaxNum)
                    laserNum = laserMaxNum;

                Destroy(collision.gameObject);
                break;

            default:
                break;
        }
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("hit");
        //    hpbar.ReduceHP();
        //}

        //if 
    }

    private void RestartPosition()
    {

    }


}
