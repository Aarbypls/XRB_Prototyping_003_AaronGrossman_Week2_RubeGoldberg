using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField] private GameObject _garageDoor;
    [SerializeField] private GameObject _moveToPointObject;
    [SerializeField] private float _speed = 0.5f;
    private bool _moveDoor = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            _moveDoor = true;
        }
    }

    private void Update()
    {
        if (_moveDoor)
        {
            if (Vector3.Distance(_garageDoor.transform.position, _moveToPointObject.transform.position) < .1f)
            {
                Debug.Log("This");

                _garageDoor.transform.position = _moveToPointObject.transform.position;
                _moveDoor = false;
            }
            
            _garageDoor.transform.position = Vector3.MoveTowards(_garageDoor.transform.position,
                _moveToPointObject.transform.position, Time.fixedDeltaTime * _speed);
        }
    }
}
