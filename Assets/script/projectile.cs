using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    float speed = 10;

    public void SetSpeed(float newSpeed){
        speed = newSpeed;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        checkCollision(moveDistance);
        transform.Translate(Vector3.right * moveDistance);
    }

    void checkCollision(float moveDistance){
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)){
            OnHitObject();
        }
    }

    void OnHitObject(){
       GameObject.Destroy(gameObject);
        print("Hit");
    }
}
