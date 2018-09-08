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

    public float bounds = 150f;

    void Start()
    {
        _Camera.transform.position = new Vector3(0, camDistance, -camDistance);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            _target.transform.Translate(Vector3.forward * translateSpeed * Time.deltaTime);

            CheckBounds(_target.transform.position);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _target.transform.Translate(Vector3.forward * -translateSpeed * Time.deltaTime);
            CheckBounds(_target.transform.position);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _target.transform.Translate(Vector3.right * -translateSpeed * Time.deltaTime);
            CheckBounds(_target.transform.position);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _target.transform.Translate(Vector3.right * translateSpeed * Time.deltaTime);
            CheckBounds(_target.transform.position);
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

    public void SetCamDistance(float distance)
    {
        _Camera.transform.position = new Vector3(0, distance, -distance);
    }

    public void CheckBounds(Vector3 targetPosition)
    {
        Vector3 nextPosi = targetPosition;

        bool xOutOfBounds = false;
        bool zOutOfBounds = false;
        if (nextPosi.x > bounds || (nextPosi.x < -bounds)) xOutOfBounds = true;
        if (nextPosi.y > bounds || (nextPosi.z < -bounds)) zOutOfBounds = true;

        if (xOutOfBounds && !zOutOfBounds)
        {
            if (nextPosi.x > 0) _target.transform.position = new Vector3(bounds, 0, nextPosi.z);
            else _target.transform.position = new Vector3(-bounds, 0, nextPosi.z);
        }

        if (!xOutOfBounds && zOutOfBounds)
        {
            if (nextPosi.z > 0) _target.transform.position = new Vector3(nextPosi.x, 0, bounds);
            else _target.transform.position = new Vector3(nextPosi.x, 0, -bounds);
        }

        if (xOutOfBounds && zOutOfBounds)
        {
            if (nextPosi.x > 0 && nextPosi.z > 0) _target.transform.position = new Vector3(bounds, 0, bounds);
            else if (nextPosi.x > 0 && nextPosi.z < 0) _target.transform.position = new Vector3(bounds, 0, -bounds);
            else if (nextPosi.x < 0 && nextPosi.z > 0) _target.transform.position = new Vector3(-bounds, 0, bounds);
            else if (nextPosi.x < 0 && nextPosi.z < 0) _target.transform.position = new Vector3(-bounds, 0, -bounds);
        }
    }
}
