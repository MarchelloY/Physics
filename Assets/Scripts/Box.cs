using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : MonoBehaviour
{
    [SerializeField] private float waterDensity = 30f;
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        var divePercent = -position.y + position.y * 0.5f;
        divePercent = Mathf.Clamp(divePercent, 0, 1f);
        
        m_Rigidbody.AddForce(Vector3.up * (divePercent * waterDensity));
        m_Rigidbody.drag = divePercent * 2f;
        m_Rigidbody.angularDrag = divePercent * 2f;
    }
}
