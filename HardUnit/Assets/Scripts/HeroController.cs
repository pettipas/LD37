using UnityEngine;
using System.Collections;

public abstract class HeroController : MonoBehaviour {
    Hero hero;
    public Hero Hero{
        get{
            if(hero == null){
                hero = GetComponent<Hero>();
            }
            return hero;
        }
    }
}

public enum ControlMode{
    Walk,
    Rest
}