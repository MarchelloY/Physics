using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    
    private void OnTriggerEnter(Collider other)
    {
        gun.GetComponent<Renderer>().material.color = Color.blue;
    }

    private void OnTriggerExit(Collider other)
    {
        gun.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }
}
