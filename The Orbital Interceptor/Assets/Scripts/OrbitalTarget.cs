using UnityEngine;

public class OrbitalTarget : MonoBehaviour
{
    public Transform pointA, pointB;
    public float travelDuration;

    private float timer;
    private bool toPointB = true;

    // Update is called once per frame
    void Update()
    {
        //1. Add frame time to our stopwatch
        timer += Time.deltaTime;
        float t = timer / travelDuration;

        //Short version of the if else statement
        Vector3 start = toPointB ? pointA.position : pointB.position;
        Vector3 target = toPointB ? pointB.position : pointA.position;

        //3. Apply Movement
        transform.position = Vector3.Lerp(start, target, t);

        //4. If arrived?
        if (t > 1f)
        {
            timer = 0;
            // toPointB = false;
            toPointB = !toPointB;
        }
    }
}
