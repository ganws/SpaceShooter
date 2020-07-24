using UnityEngine;

public class asteroid : MonoBehaviour
{

    public float speed = 10.0f;
    private float screenOffset = 3.0f;
    public ParticleSystem explosion;

    private Vector2 screenBound;
    private Rigidbody2D rb;
    private int HP = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //meteor = GetComponent<Transform>();
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        // meteor.Translate(new Vector3(0, -speed * Time.deltaTime, meteor.position.z));

        if (transform.position.y < -(screenBound.y + screenOffset))
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Laser")
        {
            HP -= 1;
            collision.collider.gameObject.GetComponent<laser>().onHit();
            FindObjectOfType<GameManager>().addScore(1);

            if (HP <= 0)
            {
                Explode();
                Destroy(gameObject);

            }
        }

        if (collision.collider.gameObject.tag == "Player")
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
       Instantiate(explosion, this.transform.position, this.transform.rotation);

        AudioSource audio = FindObjectOfType<SoundController>().asteroid_explode;
        audio.Play();
    }

    public void setHP(int hp)
    {
        HP = hp;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

}
