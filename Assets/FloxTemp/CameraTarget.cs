using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour 
{
    public GameObject _Camera;
    public GameObject _target;

    public float camDistance = 100f;

    public float rotateSpeed = 30f;
    public float translateSpeed = 30f;

    void Start(){

        _Camera.transform.position = new Vector3(0, camDistance, -camDistance);
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
           _target.transform.Translate(Vector3.forward * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _target.transform.Translate(Vector3.forward * -translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _target.transform.Translate(Vector3.right * -translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _target.transform.Translate(Vector3.right * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _target.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            _target.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
    }


}
