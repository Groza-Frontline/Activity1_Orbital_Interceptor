using UnityEngine;

public class TurretTracker : MonoBehaviour
{
    public Transform target;
    public Transform turret;
    public float rotationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        //2. Rotation using Quaterions
        Vector3 directionToTarget = (target.position - turret.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotationSpeed * Time.deltaTime);
        }
        float dotProduct = Vector3.Dot(transform.forward, directionToTarget);

        if (dotProduct > 0.95)
        {
            Debug.Log("Target Locked");
        }
        else
        {
            Debug.Log("Searching");
        }
    }
}
