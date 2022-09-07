using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private GameObject _toPointObject;
    [SerializeField] private float _speed = 0.3f;
    private GameObject _objectToMove = null;
    private bool _moveToPoint = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Rigidbody rb))
        {
            _objectToMove = other.gameObject;
            rb.useGravity = false;
            _moveToPoint = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveToPoint)
        {
            if (Vector3.Distance(_objectToMove.transform.position, _toPointObject.transform.position) < .1f)
            {
                _objectToMove.transform.position = _toPointObject.transform.position;
                _moveToPoint = false;
                _objectToMove.GetComponent<Rigidbody>().useGravity = true;
            }
            
            _objectToMove.transform.position = Vector3.MoveTowards(_objectToMove.transform.position,
                _toPointObject.transform.position, Time.deltaTime * _speed);
        }
    }
}
