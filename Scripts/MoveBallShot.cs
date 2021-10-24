using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBallShot : MonoBehaviour
{

    [SerializeField] private float speedBallShot;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private SphereCollider _sphereColliderTrig;
    [SerializeField] private float moveY;
    [SerializeField] private float moveX;
    private ScaleBallHero _scaleBallHero;
    private Rigidbody rigidbody;
    private bool stop;

    public SphereCollider SphereCollider
    {
        get => _sphereCollider;
        set => _sphereCollider = value;
    }

    public bool Stop
    {
        get => stop;
        set => stop = value;
    }

    public float MoveX
    {
        get => moveX;
        set => moveX = value;
    }

    private void Awake()
    {
        _scaleBallHero = GameObject.Find("BallHero").GetComponent<ScaleBallHero>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    async void Start()
    {
        //Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (moveX <= 0)
        {
            Destroy(gameObject);
            _scaleBallHero.IsNotShot = true;
        }*/
    }

    private void FixedUpdate()
    {
    }

    private async void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Plane"))
        {
            if (moveY > 0 && speedBallShot > 0)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(MoveX, moveY, 0, ForceMode.Impulse);
            }

            if (Stop)
            {
                //await Task.Delay(200);
                rigidbody.isKinematic = true;
                rigidbody.freezeRotation = true;
            }
        }
        if(other.gameObject.CompareTag("Borov"))
        {
            Debug.Log("Stop");
            MoveX = 0;
            moveY = 0;
            rigidbody.velocity = Vector3.zero;
            Stop = true;
        }
        if(other.gameObject.CompareTag("Winers"))
        {
            Debug.Log("Stop");
            MoveX = 0;
            moveY = 0;
            rigidbody.velocity = Vector3.zero;
            Stop = true;
        }
    }
}
