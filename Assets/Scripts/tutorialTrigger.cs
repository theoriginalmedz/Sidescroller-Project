using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialTrigger : MonoBehaviour
{

    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        text.SetActive(true);

    }

    void OnTriggerExit2D(Collider2D col)
    {
        text.SetActive(false);
    }
}
