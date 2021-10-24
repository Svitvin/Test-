using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapModel : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectFallse;
    [SerializeField] private GameObject gameObjectTrue;
    private MoveBallShot moveBall;

    private void Awake()
    {


    }
    private async void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("BallShot"))
        {
            gameObjectTrue.active = true;
            gameObjectFallse.active = false;
            moveBall =  other.GetComponent<MoveBallShot>();
        }*/
    }

}
