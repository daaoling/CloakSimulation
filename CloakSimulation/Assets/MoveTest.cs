using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MoveTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    

    bool isPress = false;
    float joyOffsetX;
    float joyOffsetY;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)
        || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            isPress = true;
            joyOffsetX = Input.GetAxis("Horizontal");
            joyOffsetY = Input.GetAxis("Vertical");
            //MessageBridge.FireFromLuaCallCharp("JoyStickChange", isPress, x, y * -1);
        }
        else
        {
            if (isPress)
            {
                isPress = false;
                //MessageBridge.FireFromLuaCallCharp("JoyStickChange", isPress, 0, 0);
            }
        }

        if(isPress)
        {
            var x = joyOffsetX;
            var z = joyOffsetY;
            Vector3 deltaOffset = new Vector3(x, 0, z).normalized;
            transform.forward = deltaOffset;
            transform.position += deltaOffset * Time.deltaTime * 3.0f;
        }
	}
}
