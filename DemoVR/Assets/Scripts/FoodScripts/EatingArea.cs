using UnityEngine;

public class EatingArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.TryGetComponent(out Aliment aliment)) {
            Debug.Log(aliment.ToString() + " eaten");
            Destroy(aliment.gameObject);
        }
    }
}
