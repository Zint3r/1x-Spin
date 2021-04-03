using UnityEngine;
public class SpinPirceScript : MonoBehaviour
{
    [SerializeField, Range(1, 5)] private int multiplier = 1;    
    public int GetMultipier()
    {
        return multiplier;
    }
}