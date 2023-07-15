using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
            touchposition.z=0;
            transform.position = touchposition;
        }
        
    }
}
