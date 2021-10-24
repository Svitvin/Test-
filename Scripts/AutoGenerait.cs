using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerait : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 Vector3Max;
    [SerializeField] private Vector3 Vector3Min;
    [SerializeField] private int Count;
     void Start()
     {
         Transform vector3 = _transform;

         for (int i = 0; i < Count; i++)
        {
            float xMove = Random.Range(Vector3Min.x, Vector3Max.x);
            float zMove = Random.Range(Vector3Min.z, Vector3Max.z);
            vector3.position = new Vector3(xMove,0.5f,zMove);
            Instantiate(_transform, vector3.parent);
        }
    }

}
