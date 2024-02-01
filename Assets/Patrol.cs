using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float verticalPingPong;
    [SerializeField] private float horizontalPingPong;
    
    private void Start()
    {
        StartCoroutine(Patrolling());
    }

    IEnumerator Patrolling()
    {
        while (true)
        {
            var vert = Mathf.PingPong(Time.time, verticalPingPong);
            var hor = Mathf.PingPong(Time.time, horizontalPingPong);
            transform.localPosition = new Vector3(horizontalPingPong > 0 ? hor : 0, verticalPingPong > 0 ? vert : 0);
            
            yield return null;
        }
    }
}
