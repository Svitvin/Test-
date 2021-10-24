using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSize : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    private void FixedUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, _gameObject.transform.localScale.z);
    }
}
