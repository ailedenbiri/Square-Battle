using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Reflection;

public class BoxTween : MonoBehaviour
{
    [SerializeField] private GameObject[] boxes;
    private Vector3[] initialPositions;
  
    private void Start()
    {
        Index0();
        Index1();
        Index2();
        Index3();
    }

    private void Index0()
    {
        // INDEX 0

        initialPositions = new Vector3[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            initialPositions[i] = boxes[i].transform.position;

            Tween moveTween = DOTween.Sequence()
            .Append(boxes[0].transform.DOMoveX(2f, 4f))
            .AppendInterval(2f) 
            .Append(boxes[0].transform.DOMoveX(initialPositions[0].x, 4f))
            .SetLoops(-1);
            moveTween.SetUpdate(true);

        }
    }  

    private void Index1()
    {
        initialPositions = new Vector3[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            initialPositions[i] = boxes[i].transform.position;

            Tween moveTween = DOTween.Sequence()
            .Append(boxes[1].transform.DOMoveX(2f, 4f))
            .AppendInterval(2f)
            .Append(boxes[1].transform.DOMoveX(initialPositions[1].x, 4f))
            .SetLoops(-1);
            moveTween.SetUpdate(true);

        }
    }

    private void Index2()
    {
        initialPositions = new Vector3[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            initialPositions[i] = boxes[i].transform.position;

            Tween moveTween = DOTween.Sequence()
            .Append(boxes[2].transform.DOMoveX(5f, 5f))
            .AppendInterval(2f)
            .Append(boxes[2].transform.DOMoveX(initialPositions[2].x, 5f))
            .SetLoops(-1);
            moveTween.SetUpdate(true);

        }
    }


    private void Index3()
    {
        initialPositions = new Vector3[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            initialPositions[i] = boxes[i].transform.position;

            Tween moveTween = DOTween.Sequence()
            .Append(boxes[3].transform.DOMoveX(-3f, 5f))
            .AppendInterval(2f)
            .Append(boxes[3].transform.DOMoveX(initialPositions[3].x, 5f))
            .SetLoops(-1);
            moveTween.SetUpdate(true);

        }
    }
}



