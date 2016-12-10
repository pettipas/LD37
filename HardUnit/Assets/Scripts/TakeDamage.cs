using UnityEngine;
using System.Collections;

public class TakeDamage : HeroController {

    Vector3 cachedDirection;
    public float speed;
    public float distance;
    float distanceConsumed;

    public bool Ready {
        get {
            return distanceConsumed > distance / 4.0f;
        }
    }

    public Vector3 CachedDir {
        get {
            return cachedDirection;
        }set {
            cachedDirection = new Vector3(value.x,0,value.z);
        }
    }

    public void Renew(Vector3 newDir) {
        if(Ready) {
            CachedDir = newDir;
        }
        Hero.AnimateTakeDamage();
    }

    public void OnEnable(){
        distanceConsumed = 0;
        cachedDirection = Hero.PushDir;
        Hero.AnimateTakeDamage();

    }

    public void Update() {

        distanceConsumed += Time.smoothDeltaTime * speed;

        if(distanceConsumed >= distance){
            Hero.SetMode(Mode.Walk);
            Hero.SetMode(Mode.Invulnerable);
            Hero.gunsOut.Resume();
            Game.Instance.damage -= 1;
        }
        Hero.Ctrl.Move(cachedDirection * speed * Time.deltaTime);
    }
}
