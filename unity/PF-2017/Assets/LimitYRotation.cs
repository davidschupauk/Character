using UnityEngine;
using System.Collections;

public class LimitYRotation : MonoBehaviour {
    Transform cameraTransform;
    float angV;
        
    // Use this for initialization
    void Start() {
       Camera.main.transform.localEulerAngles = new Vector3(Mathf.Clamp(Camera.main.transform.localEulerAngles.x, -60, 60), 0, 0);
    
    }
	// Update is called once per frame
	void Update () {
        Vector3 newRotationV = new Vector3(angV, 0, 0);
        transform.localEulerAngles = transform.localEulerAngles + newRotationV;

        float x = transform.localEulerAngles.x;

        if (x > 45 && x < 315)
        {
            if (x > 45 && x < 50)
            {
                transform.localEulerAngles = new Vector3(45, transform.localEulerAngles.y, 0);
            }
            else if (x > 310 && x < 315)
            {
                transform.localEulerAngles = new Vector3(315, transform.localEulerAngles.y, 0);
            }
        }
    }
}
