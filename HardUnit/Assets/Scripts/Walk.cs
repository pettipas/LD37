using UnityEngine;
using System.Collections;
using InControl;

public class Walk : HeroController {

    public float speed;

    public void OnEnable(){
        Hero.Animator.Play("hero_walk",0,0);
        Hero.gunsOut.SafeEnable();
    }

    public void Update(){
        
        NormalWalk();

        Hero.FaceDirectionOfMotion();


        if (!Hero.GunsOut) {
            if (Hero.direction == Vector3.zero) {
                Hero.AnimateResting();
            }
            else {
                Hero.AnimateWalking();
            }
        }
        else {
            if (Hero.direction == Vector3.zero) {
                Hero.AnimateGunsOutRest();
            }
            else {
                Hero.AnimateGunsOut();
            }
        }

        var input = InputManager.ActiveDevice;
        if(!Hero.StandingStill && (Input.GetKeyDown(KeyCode.Space) || input.Action1.IsPressed) && !Hero.Slideing){
            input.Action1.ClearInputState();
            Hero.SetMode(Mode.Slide);
            Hero.gunsOut.Pause();
        }

    }

    void NormalWalk(){
        Hero.Ctrl.Move(Hero.direction * (speed + Hero.Instance.fast) * Time.smoothDeltaTime);
    }
}
