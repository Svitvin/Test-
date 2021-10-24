using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private bool temp;
    private int count;

    private void Start()
    {
        count = 0;
        
    }

    private async void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.CompareTag("BallHero"))
            {
                temp = true;
            }
        
    }

    private void FixedUpdate()
    {
        if (temp)
        {
            door.transform.Rotate(0f, 1f, 0f);
            count++;
        }

        if (count >= 100)
        {
            temp = false;
        }
    }
}
