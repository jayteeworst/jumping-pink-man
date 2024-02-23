using System;
using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Vector2 startingPosition;
    [SerializeField] private Vector2 finishPosition;
    [SerializeField] private float patrolDuration = 5f;
    [SerializeField] private float waitDuration = 1f;
    [SerializeField] private float _onHitPauseDuration = 2f;
    public bool IsPaused { get; set; }

    private void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(Patrolling(startingPosition, finishPosition));
    }

    private IEnumerator Patrolling(Vector2 startPos, Vector2 finishPos)
    {
        var startTime = Time.time;

        while ((Vector2)transform.position != finishPos)
        {
            if (IsPaused)
            {
                startTime += _onHitPauseDuration;
                yield return new WaitForSeconds(_onHitPauseDuration);
                IsPaused = false;
            }
            
            transform.position = Vector2.Lerp(startPos, finishPos, (Time.time - startTime) / patrolDuration);

            yield return null;
        }

        yield return new WaitForSeconds(waitDuration);

        StartCoroutine(Patrolling(finishPos, startPos));

        yield return null;
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawLine(transform.position, finishPosition, Color.green);
    }
}
