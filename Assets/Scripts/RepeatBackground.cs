using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 stratPos;
    private float repeatWith;
    // Start is called before the first frame update
    void Start()
    {
        stratPos = transform.position;
        repeatWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < stratPos.x - repeatWith)
        {
            transform.position = stratPos;
        }
    }
}
