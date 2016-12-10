using UnityEngine;
using System.Collections;

public static class Extensions {

    public static void SafeEnable<T>(this T mono) where T : MonoBehaviour{
        if(mono != null && !mono.enabled){
            mono.enabled = true;
        }
    }

    public static void SafeDisable<T>(this T mono) where T : MonoBehaviour{
        if(mono != null && mono.enabled){
            mono.enabled = false;
        }
    }

    public static T AddIfNull<T>(this GameObject g) where T : Component{
        if (g.GetComponent<T>() == null) {
            return g.AddComponent<T>();
        }return null;
    }

    public static bool IsNamedStateActive(this Animator animator, string thisName){
        return animator.GetCurrentAnimatorStateInfo(0).IsName(thisName);
    }
}
