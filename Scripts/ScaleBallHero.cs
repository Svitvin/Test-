using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScaleBallHero : MonoBehaviour
{
    [SerializeField] private GameObject _shotBall;
    [SerializeField] private Transform _spawnPoint;
    private bool isNotShot;
    private bool createShot;
    [SerializeField] private int countShot;
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite win;
    [SerializeField] private Sprite lose;
    private GameObject _copyShotBall;
    private Transform _transform;
    private bool spawn;
    private bool winers;
    private bool checkLose;
    private int countsShots;

    private float moveX;
    private float moveY;
    private int shot;

    private void Awake()
    {
        checkLose = false;
    }

    public int CountsShots
    {
        get => countsShots;
        set => countsShots = value;
    }

    public float MoveX
    {
        get => moveX;
        set => moveX = value;
    }

    public float MoveY
    {
        get => moveY;
        set => moveY = value;
    }

    public bool Spawn
    {
        get => spawn;
        set => spawn = value;
    }

    public bool Winers
    {
        get => winers;
        set => winers = value;
    }

    public bool IsNotShot
    {
        get => isNotShot;
        set => isNotShot = value;
    }

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        CountsShots = countShot;
        checkLose = false;
        shot = countShot;
        _text.text = ""+shot;
        MoveX = 50;
        MoveY = 50;
        Winers = false;
        isNotShot = true;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    async void Update()
    {
        if (transform.localScale.x > 1 && countShot > 0) createShot = true;
        else createShot = false;

    }

    private void OnMouseDown()
    {
        if (Winers == false)
        {
            if (createShot)
            {
                shot--;
                _text.text = ""+shot; 
                Spawn = true;
                _copyShotBall = Instantiate(_shotBall, _spawnPoint.parent);
            }
        }
    }

    private void OnMouseDrag()
    {
        if (Winers == false)
        {
            if (createShot) 
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.7f* Time.deltaTime, transform.localScale.y - 0.7f* Time.deltaTime,
                    transform.localScale.z - 0.7f * Time.deltaTime);
                _copyShotBall.transform.localScale = new Vector3(_copyShotBall.transform.localScale.x + 4f* Time.deltaTime, _copyShotBall.transform.localScale.y + 4f* Time.deltaTime,
                    _copyShotBall.transform.localScale.z + 4f * Time.deltaTime);

            }   
        }
    }
    private async void OnMouseUp()
    {
        
        if (Spawn)
        {
            IsNotShot = false; 
            MoveBallShot firstChildren = _copyShotBall.GetComponentInChildren<MoveBallShot>();
            SphereCollider sphereCollider = firstChildren.SphereCollider; ;
            sphereCollider.isTrigger = true;
            countShot--;
            spawn = false;
            await Task.Delay(10000);
            CountsShots--;
            if (checkLose == false)
            {
                if (CountsShots <= 0)
                {
                    if (Winers == false)
                    {
                        Debug.Log("Restarts");
                        _image.sprite = lose;
                        _image.color = new Color(1, 1, 1, 1);
                        await Task.Delay(2000);
                        Restart restart = new Restart();
                        restart.RestartSceneButton();
                        checkLose = true;
                    }
                }
            }
        }
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            if (Winers)
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(MoveX, MoveY, 0, ForceMode.Impulse);
            }
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            _image.sprite = lose;
            _image.color = new Color(1, 1, 1, 1);
            await Task.Delay(2000);
            Restart restart = new Restart();
            restart.RestartSceneButton();
        }

        if (other.gameObject.CompareTag("Win"))
        {
            MoveX = 0;
            MoveY = 0;
            _image.sprite = win;
            _image.color = new Color(1, 1, 1, 1);
            await Task.Delay(2000);
            Restart restart = new Restart();
            restart.RestartSceneButton();
        }
    }
}
