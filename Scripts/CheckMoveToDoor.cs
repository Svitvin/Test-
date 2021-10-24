using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMoveToDoor : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private Rigidbody _rigidbody;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(_gameObject.transform.localScale.x, _gameObject.transform.localScale.y, _gameObject.transform.localScale.z);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Borov"))
        {
            Debug.Log("Nazad");
            transform.position = new Vector3(-20.5f, 2f, -7.5f);
        }
        else if(other.gameObject.CompareTag("Winers"))
        {
            speed = 0;
            ScaleBallHero scaleBallHero = _gameObject.GetComponent<ScaleBallHero>();
            scaleBallHero.Winers = true;
            _rigidbody = _gameObject.GetComponent<Rigidbody>();
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(50, 50, 0, ForceMode.Impulse);
        }
    }
}
