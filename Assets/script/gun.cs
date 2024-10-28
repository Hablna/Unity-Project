using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform muzzle;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;
    public projectile projectile;
    float nextShotTime;

    public void shoot(){
        if (Time.time > nextShotTime){
            nextShotTime = Time.time + msBetweenShots/1000;
            projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as projectile;
            newProjectile.SetSpeed(muzzleVelocity);
        }
    } 
}
