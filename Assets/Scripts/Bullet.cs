using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float shotForce = 100f;
    private IEnumerator Start()
    {
        var gun = GameObject.Find("Gun");
        var dir = transform.position - gun.transform.position;
        GetComponent<Rigidbody>().AddRelativeForce(dir * shotForce, ForceMode.Impulse);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Box"))
            Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Wall"))
            gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
