using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    public GameObject blackPistol;
    public bool isFiring = false;
    public GameObject MuzzleFlash;
    public AudioSource PistolShot;
    public float ToTarget;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
        }


    }

    IEnumerator FireThePistol()
    {
        isFiring = true;
        ToTarget = PlayerCasting.DistanceFromTarget;
        blackPistol.GetComponent<Animator>().Play("Fire_pistol");
        PistolShot.Play();
        MuzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        MuzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.22f);
        blackPistol.GetComponent<Animator>().Play("New State");
        isFiring = false;

    }
}
