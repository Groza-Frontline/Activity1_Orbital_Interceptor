using UnityEngine;

public class TurretTracker : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed = 3f;

    void Update()
    {
        //Rotate
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        float dotProduct = Vector3.Dot(transform.forward, directionToTarget);

        //Field of View Check
        if (dotProduct > 0.98)
        {
            Debug.DrawLine(transform.position, target.position, Color.green);
            Debug.Log("Target Locked");
        }
        else
        {
            Debug.DrawLine(transform.position, target.position, Color.red);

        }
    }
}
