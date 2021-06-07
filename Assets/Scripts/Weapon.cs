using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] float muzzleFlashTime = 0.05f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Fire");
        }
    }

    private IEnumerator Fire()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(muzzleFlashTime);
        muzzleFlash.SetActive(false);
    }
}
