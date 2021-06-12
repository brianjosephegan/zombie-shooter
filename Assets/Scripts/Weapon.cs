using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] GameObject[] hitEffects;
    [SerializeField] float muzzleFlashTime = 0.05f;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("PlayMuzzleFlash");
            ProcessRaycast();
        }
    }

    private void ProcessRaycast()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out raycastHit, range))
        {
            Debug.Log(raycastHit.transform.name);
            PlayHitEffect(raycastHit);
            EnemyHitDetector enemyHitDetector = raycastHit.transform.GetComponent<EnemyHitDetector>();
            if (enemyHitDetector != null)
            {
                enemyHitDetector.TakeHit(damage);
            }
        }
    }

    private void PlayHitEffect(RaycastHit raycastHit)
    {
        var hitEffect = hitEffects[Random.Range(0, hitEffects.Length)];
        var impact = Instantiate(hitEffect, raycastHit.point, Random.rotation);
        Destroy(impact, 0.1f);
    }

    private IEnumerator PlayMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(muzzleFlashTime);
        muzzleFlash.SetActive(false);
    }
}
