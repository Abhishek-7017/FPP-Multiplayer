using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private float targetHitPoints = 50f;

    public void Hitted(){
        targetHitPoints-=10f;
        if(targetHitPoints<=0){
            Destroy(gameObject);
        }
    }
}
