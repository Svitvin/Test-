using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class TransformBorov : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectFallse;
    [SerializeField] private GameObject gameObjectTrue;
    [Space] 
    [SerializeField] private BrokenModel _brokenModel;
    [Space]
    private float transformPoint;
    private float tempPoint;
    private float deltaPoiint;

    public float TransformPoint
    {
        get => transformPoint;
        set => transformPoint = value;
    }

    [SerializeField] private Material startColorFirst;

    [Space]
    
    [SerializeField] private Material finishColorFirst;

    private Color temp;
    private float r, g ,b ,a = 0;
    private float rTemp, gTemp ,bTemp ,aTemp = 0;
    private float TVR, TVG, TVB, TVA = 1;


    private void Start()
    {
        startColorFirst.color = new Color(0.192f, 1, 0, 1);
        temp = startColorFirst.color;
    }
    private void FixedUpdate()
    {
        /*if (TransformPoint < 100)
        {
            if (temp.r > finishColorFirst.color.r)
                TVR = -1;
            if (temp.g > finishColorFirst.color.g)
                TVG = -1;
            if (temp.b > finishColorFirst.color.b)
                TVB = -1;
            if (temp.a > finishColorFirst.color.a)
                TVA = -1;

            r = Math.Abs(temp.r) - Math.Abs(finishColorFirst.color.r);
            g = Math.Abs(temp.g) - Math.Abs(finishColorFirst.color.g);
            b = Math.Abs(temp.b) - Math.Abs(finishColorFirst.color.b);
            a = Math.Abs(temp.a) - Math.Abs(finishColorFirst.color.a);

            rTemp = (r / 100) * TVR;
            gTemp = (g / 100) * TVG;
            bTemp = (b / 100) * TVB;
            aTemp = (a / 100) * TVA;

            if (TransformPoint > tempPoint)
                deltaPoiint = TransformPoint - tempPoint;

            for (int i = 0; i < deltaPoiint; i++)
            {
                startColorFirst.color = new Color(startColorFirst.color.r + rTemp, startColorFirst.color.g + gTemp,
                    startColorFirst.color.b + bTemp, startColorFirst.color.a + aTemp);
            }
            tempPoint = TransformPoint;
        }*/
        //Debug.Log("TransformBorov - " + TransformPoint);
        if (TransformPoint >= 100 )
        {
            gameObjectTrue.active = true;
            gameObjectFallse.active = false;
            _brokenModel.IsBoom = true;
        }
    }
}
