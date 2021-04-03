using System.Collections;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    private Animator anim;
    private RespawnEnemyScript respawnEnemyScript;
    private void Awake()
    {
        respawnEnemyScript = FindObjectOfType<RespawnEnemyScript>();        
        anim = GetComponent<Animator>();
    }    
    public void PlayerAttack(int num)
    {
        StartCoroutine(SeriesAttacks(num));
    }
    private void PlayerAttackAnimation()
    {
        anim.SetTrigger("IsAttack");
    }
    private IEnumerator SeriesAttacks(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (respawnEnemyScript.CurrentEnemy.LiveCheck() == true)
            {
                PlayerAttackAnimation();
                respawnEnemyScript.CurrentEnemy.ReceiveDamage(RandomDamage());
                if (respawnEnemyScript.CurrentEnemy.LiveCheck() == false)
                {
                    Invoke("PlayerRun", 3f);
                    Invoke("NextEnemy", 4f);
                }
            }
            else
            {
                yield break;
            }            
            yield return new WaitForSeconds(1f);
        }
    }
    private void PlayerRun()
    {
        if (respawnEnemyScript.CurrentEnemy == null)
        {            
            anim.SetTrigger("IsRun");            
        }
    }
    private void NextEnemy()
    {
        respawnEnemyScript.Respawn();
    }
    private int RandomDamage()
    {
        return Random.Range(70, 150);
    }   
}