using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class BallShotInfo: MonoBehaviour
{
    [SerializeField] private MoveBallShot _moveBallShot;
    private List<GameObject> _gameObjects;
    private List<float> lenghts;
    private List<Tuple<float, GameObject>> _filterGameObjects;
    private List<GameObject> _sortedGameObjects;
    [SerializeField] private float startBallPoint;
    [SerializeField] private GameObject ballShot;
    [SerializeField] private SphereCollider sphereCollider;
    private float ballPoint;
    private bool tempChek;
    private ScaleBallHero _scaleBallHero;

    private void Awake()
    {
        _scaleBallHero = GameObject.Find("BallHero").GetComponent<ScaleBallHero>();
    }

    public float BallPoint
    {
        get => ballPoint;
        set => ballPoint = value;
    }

    private TransformBorov _transformBorov = new TransformBorov();
    private void Start()
    {
        tempChek = false;
        _gameObjects = new List<GameObject>();
        _sortedGameObjects = new List<GameObject>();
        _filterGameObjects = new List<Tuple<float, GameObject>>();
        lenghts = new List<float>();
    }

    private async void FixedUpdate()
    {
        int temp = 0;
        int count = 0;
        float ballPointRemove = 0;
        if(_moveBallShot.Stop)
        {
            if (tempChek == false)
            {
                double rangX = 0;
                double rangZ = 0;
                double lenght = 0;
                for (int i = 0; i < _gameObjects.Count; i++)
                {
                    var position = ballShot.transform.position;
                    rangX = Math.Pow(position.x  -  _gameObjects[i].transform.position.x, 2);
                    rangZ = Math.Pow(position.z - _gameObjects[i].transform.position.z, 2);
                    lenght = Math.Sqrt(rangX + rangZ);
                    if ((sphereCollider.radius * ballShot.transform.localScale.x) >= lenght)
                    {
                        lenghts.Add((float)lenght);
                        _filterGameObjects.Add(new Tuple<float, GameObject>((float)lenght, _gameObjects[i]));
                    }
                }

                _filterGameObjects = _filterGameObjects.OrderBy(x => x.Item1).ToList();
                BallPoint = startBallPoint * ballShot.transform.localScale.x;
                ballPointRemove = ballShot.transform.localScale.x / startBallPoint;
                temp = (int)(BallPoint / 100);
                if (temp > _filterGameObjects.Count)
                {
                    count = _filterGameObjects.Count;
                }
                else
                {
                    count = temp;
                }
                for (int i = 0; i < count; i++)
                {
                    _transformBorov = _filterGameObjects[i].Item2.GetComponent<TransformBorov>();
                    for (int j = 0; j < 100; j++)
                    {

                        _transformBorov.TransformPoint++;
                    }
                }
                tempChek = true;
            }
            Destroy(ballShot, 1);

        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.CompareTag("RangeBorov"))
            {
                Debug.Log(other.gameObject.name);
                _gameObjects.Add(other.gameObject);
            }

    }
}
