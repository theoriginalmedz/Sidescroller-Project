using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public float offset;
    private Transform playerTrans;

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

        tempPos.x += offset;
        tempPos.y += offset;


        transform.position = tempPos;

    }
}
