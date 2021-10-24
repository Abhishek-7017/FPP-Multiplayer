using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] LayerMask targetMask;
    [SerializeField] ParticleSystem flash;
    [SerializeField] GameObject impactEffect;
    [SerializeField] Camera Ccamera;
    [SerializeField] float fireRate = 15f;
    [SerializeField] float timeToFire = 0f;

    void FixedUpdate(){
        if(Input.GetButton("Fire1")&&Time.time >= timeToFire){
            timeToFire = Time.deltaTime + 1/fireRate;
            ShootBullet();
        }
    }
    //This function is called everytime player hits left mouse button and sends a ray 
    //to check weather any object is in range
    private void ShootBullet(){
        RaycastHit hit;
        flash.Play();
        if(Physics.Raycast(Ccamera.transform.position,Ccamera.transform.forward,out hit,100f)){
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if(target!=null){
                target.Hitted();
            }

            GameObject impact = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(impact,1f);
        }
    }
}
