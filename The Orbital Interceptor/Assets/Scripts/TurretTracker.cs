using UnityEngine;

public class TurretTracker : MonoBehaviour
{
    public Transform target;
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        //Movement
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // 2. Rotation with Quaternions
        Vector3  directionToTarget = (target.position - transform.position).normalized;
        if(directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        }
    }
}
