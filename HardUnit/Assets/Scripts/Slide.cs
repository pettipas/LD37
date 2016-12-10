using UnityEngine;
using System.Collections;

public class Slide : HeroController {

    public Vector3 cachedDirection;
    public float speed;
    public float distance;
    float distanceConsumed;
    public float radius;

    public void OnEnable(){
        cachedDirection = Hero.direction.normalized;
        distanceConsumed = 0;
        Hero.AnimateSliding();
    }

    public void Update() {

        distanceConsumed += Time.smoothDeltaTime * speed;

        if(distanceConsumed>=distance){
            Hero.SetMode(Mode.Walk);
        }

        Hero.Ctrl.Move(cachedDirection * speed * Time.smoothDeltaTime);
    }
}
