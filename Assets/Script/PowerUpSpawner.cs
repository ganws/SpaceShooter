using System.Collections;
using UnityEngine;
 
public class PowerUpSpawner : MonoBehaviour
{
    public GameObject hpDrop;
    public GameObject weaponDrop;

    public float hpSpawnTime = 5f;
    public float weaponSpawnTime = 5f;
    public float timeUncertainty = 1f; //plus minus spawntime

    public float speed = 4f;
    public float speedUncertainty = 1f;

    public float spawnOffsetY = 2f;
    public float spawnOffsetX = 1f;
    public Vector2 spawnXRange;

    private Vector2 screenBound;

    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spawnXRange.x = -screenBound.x + spawnOffsetX;
        spawnXRange.y = screenBound.x - spawnOffsetX;

        StartCoroutine("hpWave");
        StartCoroutine("weaponWave");
    }

    private void spawnHP()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), screenBound.y + spawnOffsetY, transform.position.z);
        GameObject a = Instantiate(hpDrop, spawnPos, this.transform.rotation);
        a.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-speed+Random.Range(-speedUncertainty, + speedUncertainty));
        Debug.Log("spawnHP");
    }

    private void spawnWeapon()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), screenBound.y + spawnOffsetY, transform.position.z);
        GameObject a = Instantiate(weaponDrop, spawnPos, this.transform.rotation);
        a.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed + Random.Range(-speedUncertainty, +speedUncertainty));
        Debug.Log("spawnWeapon");
    }

    IEnumerator hpWave()
    {
        while(true)
        {
            float spwnTime = hpSpawnTime + Random.Range(-timeUncertainty, timeUncertainty);
            yield return new WaitForSeconds(spwnTime);
            spawnHP();
        }
    }

    IEnumerator weaponWave()
    {
        while (true)
        {
            float spwnTime = weaponSpawnTime + Random.Range(-timeUncertainty, timeUncertainty);
            yield return new WaitForSeconds(spwnTime);
            spawnWeapon();
        }
    }
}
