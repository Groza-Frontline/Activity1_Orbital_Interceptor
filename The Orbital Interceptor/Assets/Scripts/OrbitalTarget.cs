using UnityEngine;

public class OrbitalTarget : MonoBehaviour
{
    public Transform pointA, pointB;
    public float travelDuration;

    //   public GameManager manager;
    public MeshRenderer targetObject;

    private float timer;
    private bool toPointB = true;

    private void OnEnable()
    {
        Debug.Log($"Target ENABLED: {name}");
    }

    private void OnDisable()
    {
        Debug.Log($"Target DISABLED: {name}");
    }

    //Used Awake to access the Sphere Collider(Target) to destroy it
    private void Awake()
    {
        targetObject = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //1. Add frame time to our stopwatch
        timer += Time.deltaTime;
        float t = timer / travelDuration;

        //2. Short version of the if else statement
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

    //If target is clicked
    private void OnMouseDown()
    {
        Debug.Log("Target is DESTROYED!");

        if (GameManager.Instance != null) {

            GameManager.Instance.AddScore(10);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance is null. Score will not be added.");
        }

        Destroy(targetObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HazardZone"))
        {
            Debug.Log("Drone entered the Hazard Zone");

            if (GameManager.Instance != null)
            {

                GameManager.Instance.DeductScore(5);
            }
            else 
            {
                Debug.LogWarning("GameManager.Instance is null. Cannot deduct score.");
            }
        }
        
    }
}
