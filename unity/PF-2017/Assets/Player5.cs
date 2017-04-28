using UnityEngine;
using System.Collections;

public class Player5 : MonoBehaviour {
    public GameObject camara;
    private CAMARA otroscript;
    private float speed2;

	// Use this for initialization
	void Start () {
        otroscript = camara.GetComponent<CAMARA>();
        speed2 = otroscript.speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 v = camara.transform.rotation.eulerAngles;
            v.x = 0.0f;
            Quaternion q = Quaternion.Euler(v);
            transform.Translate(q * new Vector3(0.0f, 0.0f, speed2));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 v = camara.transform.rotation.eulerAngles;
            v.x = 0.0f;
            Quaternion q = Quaternion.Euler(v);
            transform.Translate(q * new Vector3(speed2, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 v = camara.transform.rotation.eulerAngles;
            v.x = 0.0f;
            Quaternion q = Quaternion.Euler(v);
            transform.Translate(q * new Vector3(0.0f, 0.0f, -speed2));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 v = camara.transform.rotation.  eulerAngles;
            v.x = 0.0f;
            Quaternion q = Quaternion.Euler(v);
            transform.Translate(q * new Vector3(-speed2, 0.0f, 0.0f));
        }
    }
}
