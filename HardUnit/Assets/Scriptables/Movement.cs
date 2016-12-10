using UnityEngine;
using System.Collections;
using InControl;
public class Movement : HeroController {

    public float timeX;
    public float timeZ;

    float signX;
    float signZ;

    public void Update(){
        var inputDevice = InputManager.ActiveDevice;
        var x = 0.0f;
        var z = 0.0f;
      
        x = inputDevice.LeftStick.X;
        z = inputDevice.LeftStick.Y;

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Hero.direction.x = x;
        Hero.direction.z = z;
    }
}
