using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void RemoveHeart()
    {
        anim.SetBool("loseHP", true);
        anim.SetBool("isRespawn", false);
    }

    public void SpawnHeart()
    {
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(255);
        anim.SetBool("isRespawn", true);
        anim.SetBool("loseHP", false);
    }

    public void HideHeart()
    {
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(0);
    }

}
