using System;
using System.Collections;
using System.Numerics;
using UnityEngine;

using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class SpawnMeteor : MonoBehaviour
{

    public float spawnTime = 1.0f; //Spawn timer
    //float MeteorSpeed = 10.0f; //speed


    private Vector2 screenBound;
    private float spawnOffset = 3.0f;
    private Vector2 hpRange = new Vector2(1.0f, 5.0f);
    private Vector2 scaleRange = new Vector2(0.5f, 1.5f);
    private Vector2 angularVRange = new Vector2(-200f, 200f);
    private Vector2 speedRange = new Vector2(5.0f, 10.0f);

    public GameObject meteorPrefbs;

    //Level Progression Settings
    private float currentLvlModifier = 1.0f;
    private float baseLvlModifier = 1.0f;
    private float lvlModMaxIncrease = 1.0f;

    public float spawnRateModifier = 4.0f; //how spawn time scale with level

    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine("asteroidWave");
    }

    private void spawnMeteor()
    {
       
        GameObject a = Instantiate(meteorPrefbs) as GameObject;
        Rigidbody2D rb = a.GetComponent<Rigidbody2D>();

        //Randomize parameter
        float scale = Random.Range(scaleRange.x, scaleRange.y);
        float rotation = Random.Range(angularVRange.x, angularVRange.y);

        rb.angularVelocity = rotation;
        a.transform.position = new Vector3(Random.Range(-screenBound.x, screenBound.x),  screenBound.y + spawnOffset, a.transform.position.z);
        a.transform.localScale = new Vector3(scale, scale, 1) ; 

        // set HP
        int hp = Convert.ToInt16(scale.Remap(scaleRange.x, hpRange.x, scaleRange.y, hpRange.y));
        a.GetComponent<asteroid>().setHP(hp);

        // set speed, the larger the rock the slower the speed
        a.GetComponent<asteroid>().setSpeed(currentLvlModifier* scale.Remap(scaleRange.x, speedRange.y, scaleRange.y, speedRange.x));

    }


    IEnumerator asteroidWave()
    {
        while(true)
        {
            float newSpawnTime = 1/ (spawnRateModifier*currentLvlModifier) * spawnTime;
            yield return new WaitForSeconds(newSpawnTime);
            spawnMeteor();
        }
    }

    public void increaseLvlMod(int currentLevel, int lvlMax)
    {
        float val = (float)currentLevel;
        currentLvlModifier = baseLvlModifier +  val.Remap(1, 0, lvlMax, lvlModMaxIncrease);
    }
}
