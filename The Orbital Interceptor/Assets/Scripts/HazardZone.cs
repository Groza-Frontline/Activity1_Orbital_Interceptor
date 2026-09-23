using UnityEngine;

public class HazardZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Drone")
        {
            Debug.Log("Drone entered the Hazard Zone.");
        }
        GameManager.Instance.DeductScore(1);
    }
}
