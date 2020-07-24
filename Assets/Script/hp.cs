using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    private Vector2 screenBound;
    private float offset = 1.0f;
    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -(screenBound.y + offset))
        {
            Destroy(gameObject);
        }
    }
}
