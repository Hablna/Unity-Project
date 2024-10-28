using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public Transform weaponHold;
    gun equipedGun;
    public gun startingGun;

    void Start (){
        if (startingGun !=null){}
        gunEquip(startingGun);
    }


   public void gunEquip(gun gunToEquip){
    if ( equipedGun != null){
        Destroy(equipedGun.gameObject);
    }
    equipedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as gun;
    equipedGun.transform.parent = weaponHold;
   }

   public void shoot(){
       if (equipedGun != null){
           equipedGun.shoot();
       }
   }
}
