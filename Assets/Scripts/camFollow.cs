using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    // Start is called before the first frame update

    
    private Transform playerTrans;
    public float xAxis;
    public float yAxis;

    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 tempPos = transform.position;

        tempPos.x = playerTrans.position.x;
        tempPos.y = playerTrans.position.y;

        tempPos.x += xAxis;
        tempPos.y += yAxis;


        transform.position = tempPos;

    }
}
