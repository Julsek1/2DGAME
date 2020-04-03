using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTrap : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;

    private Vector3 nextPos;

    [SerializeField]
    private float waySpeed;

    [SerializeField]
    private float returnSpeed;


    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, waySpeed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            waySpeed = returnSpeed;
            NextDestination();
            
        }
    }

    private void NextDestination()
    {
        nextPos = nextPos != posA ? posA : posB;


    }
}
