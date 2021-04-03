using System.Collections;
using UnityEngine;
public class SpinRotateScript : MonoBehaviour 
{
    [SerializeField] private PlayerAttackScript playerAttackScript;
    [SerializeField] private PlayerScript playerScript;
    private bool isSpinRoatate = false;
    private int winNum = 0;
    public int GetWinNum()
    {
        return winNum;
    }
    public void StartRotate()
    {
        StartCoroutine(SpinRotateNew());
    }    
    private IEnumerator SpinRotateNew()
    {
        if (isSpinRoatate == false)
        {
            isSpinRoatate = true;
            int randomNum = Random.Range(200, 300);
            for (int i = 0; i < randomNum; i++)
            {
                if (i > Mathf.RoundToInt(randomNum * 0.9f))
                {
                    transform.Rotate(new Vector3(0, 0, -1));
                    //if (i == randomNum - 1)
                    //{
                    //    while (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
                    //    {
                    //        transform.Rotate(new Vector3(0, 0, -1));
                    //    }
                    //}
                }
                else if (i > Mathf.RoundToInt(randomNum * 0.6f))
                {
                    transform.Rotate(new Vector3(0, 0, -2));
                }
                else if (i > Mathf.RoundToInt(randomNum * 0.3f))
                {
                    transform.Rotate(new Vector3(0, 0, -3));
                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, -4));
                }
                yield return null;
            }
            winNum = playerAttackScript.RayCastToSpin();
            playerScript.PlayerAttack(winNum);
            Invoke("Cooldown", 0.5f + winNum);
        }
        else
        {
            yield break;
        }
    }
    private void Cooldown()
    {
        isSpinRoatate = false;
    }
}