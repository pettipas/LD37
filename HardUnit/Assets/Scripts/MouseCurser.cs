using UnityEngine;
using System.Collections;

public class MouseCurser : MonoBehaviour {

    public Transform curser;

    void Update() {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Hero.Instance != null) {
            curser.position = new Vector3(hit.point.x, Hero.Instance.transform.position.y, hit.point.z);
        }
    }
}
