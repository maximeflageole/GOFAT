using UnityEngine;
using System.Collections;

public class KingFatAssScript : MonoBehaviour {

    float rotationIntensity;
    Vector3 horizontalAxis = Vector3.left;
    Vector3 verticalAxis = Vector3.forward;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if(transform.rotation.eulerAngles.x ­ 180)
        transform.RotateAround(transform.position, horizontalAxis, 0.1f * Time.deltaTime + transform.rotation.eulerAngles.x/180);
        transform.RotateAround(transform.position, verticalAxis, 0.1f * Time.deltaTime + transform.rotation.eulerAngles.y/180);

        Debug.Log(transform.rotation.eulerAngles);
    }
}
