using UnityEngine;
public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField] private Transform target;    
    public int RayCastToSpin()
    {
        RaycastHit2D hit = Physics2D.Raycast(target.position, -Vector2.up);
        if (hit.transform.GetComponent<SpinPirceScript>() != null)
        {
            SpinPirceScript targetSpin = hit.transform.GetComponent<SpinPirceScript>();
            return targetSpin.GetMultipier();
        }
        else
        {
            return 0;
        }
    }
}