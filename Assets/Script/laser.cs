using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    private Vector2 screenBound;
    private float offset = 2.0f;

    public float speed;
    public ParticleSystem explosion;

    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, transform.position.z));

        if (transform.position.y > screenBound.y + offset)
            Destroy(gameObject);
    }

    public void onHit()
    {

        AudioSource audio = FindObjectOfType<SoundController>().laser_ht;
        audio.Play();

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);

    }
}
