using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrokenModel : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Rigidbody[] _rigidbodies;

    [SerializeField] private BoxCollider _boxCollider;

    [SerializeField] private Vector3 Vector3Max;
    [SerializeField] private Vector3 Vector3Min;
    private bool isBoom;

    public bool IsBoom
    {
        get => isBoom;
        set => isBoom = value;
    }

    private async void FixedUpdate()
    {
        if (isBoom)
        {
            Vector3 vector3;
            for (int i = 0; i < _rigidbodies.Length; i++)
            {

                float xMove = Random.Range(Vector3Min.x, Vector3Max.x);
                float yMove = Random.Range(Vector3Min.y, Vector3Max.y);
                float zMove = Random.Range(Vector3Min.z, Vector3Max.z);
                vector3 = new Vector3(xMove,yMove,zMove);
                _rigidbodies[i].AddForce(vector3, ForceMode.Impulse);
                _boxCollider.enabled = false;
            }
            await Task.Delay(1000);
            _gameObject.active = false;
            isBoom = false;
        }

    }

    private async void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("BallShot"))
        {
            Vector3 vector3;
            for (int i = 0; i < _rigidbodies.Length; i++)
            {

                float xMove = Random.Range(Vector3Min.x, Vector3Max.x);
                float yMove = Random.Range(Vector3Min.y, Vector3Max.y);
                float zMove = Random.Range(Vector3Min.z, Vector3Max.z);
                vector3 = new Vector3(xMove,yMove,zMove);
                _rigidbodies[i].AddForce(vector3, ForceMode.Impulse);
                _boxCollider.enabled = false;
            }
            await Task.Delay(1000);
            _gameObject.active = false;
        }*/
    }
}
