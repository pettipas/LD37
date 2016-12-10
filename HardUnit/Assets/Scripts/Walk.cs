using UnityEngine;
using System.Collections;
using InControl;

public class Walk : HeroController {

    public float speed;

    public void OnEnable(){
        Hero.Animator.Play("hero_walk",0,0);
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
                Hero.AnimateResting();
            }
            else {
                Hero.AnimateGunsOut();
            }
        }

        var input = InputManager.ActiveDevice;
        if(!Hero.StandingStill && (Input.GetKeyDown(KeyCode.Space) || input.Action1.IsPressed) && !Hero.Slideing){
            input.Action1.ClearInputState();
            Hero.SetMode(Mode.Slide);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            if (Hero.gunsOut.enabled) {
                Hero.gunsOut.SafeDisable();
            }
            else {
                Hero.gunsOut.SafeEnable();
            }
           
        }
    }

    void NormalWalk(){
        Hero.Ctrl.Move(Hero.direction * speed * Time.smoothDeltaTime);
    }
}
