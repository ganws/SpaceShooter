using UnityEngine;

public class HealthBarController : MonoBehaviour
{

    public GameObject[] hearts = new GameObject[4];
    public int currentHP;
    public int maxHP = 4;

    public void Start()
    {
        currentHP = maxHP;
    }

    public void ReduceHP()
    {
        currentHP--;
        hearts[currentHP].GetComponent<HealthController>().RemoveHeart();

        if (currentHP <= 0)
        {
            Debug.Log("Game over!!");
            FindObjectOfType<GameManager>().endGame();
        }

    }

    public void IncreaseHP()
    {
        if (currentHP < maxHP)
        {
            currentHP++;
            hearts[currentHP-1].GetComponent<HealthController>().SpawnHeart();
        }

    }
}
