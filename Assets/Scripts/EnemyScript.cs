using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPanel = null;
    [SerializeField] private Image enemyHealthImage = null;
    [SerializeField] private Text enemyHealthText = null;
    [SerializeField] private Text receiveDamdeText = null;
    [SerializeField, Range(300, 2000)] private int maxEnemyHP = 1084;
    private bool isLive = true;
    private RespawnEnemyScript respawnEnemyScript;
    private Animator anim;    
    private int currentEnemyHP;
    private void Start()
    {
        respawnEnemyScript = FindObjectOfType<RespawnEnemyScript>();
        anim = GetComponent<Animator>();
        currentEnemyHP = maxEnemyHP;
        enemyHealthText.text = currentEnemyHP.ToString();
        ChangeEnemyPanelPosition();
    }
    public void ChangeEnemyPanelValue(int damage)
    {        
        enemyHealthImage.fillAmount -= (float)damage / (float)maxEnemyHP;
        enemyHealthText.text = currentEnemyHP.ToString();
        float enemyHpFillImage = enemyHealthImage.fillAmount;
        if (enemyHpFillImage < 0)
        {
            enemyHealthImage.fillAmount = 0;
        }        
        receiveDamdeText.transform.gameObject.SetActive(true);
        receiveDamdeText.text = damage.ToString();
        receiveDamdeText.rectTransform.position = enemyPanel.GetComponent<RectTransform>().position + new Vector3(0, 50, 0);
        StartCoroutine(ReceiveDamageTextCoroutine());
    }
    public void DisableEnemyPanel()
    {
        enemyPanel.SetActive(false);
    }    
    public void ReceiveDamage(int damage)
    {
        if (currentEnemyHP > 0 && currentEnemyHP > damage)
        {
            currentEnemyHP -= damage;
            ChangeEnemyPanelValue(damage);                    
        }
        else
        {
            currentEnemyHP = 0;
            ChangeEnemyPanelValue(damage);
            EnemyDead();
        }
    }
    public bool LiveCheck()
    {
        if (isLive == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void ChangeEnemyPanelPosition()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);        
        enemyPanel.GetComponent<RectTransform>().position = new Vector3(screenPosition.x, screenPosition.y + 600, screenPosition.z);        
    }
    private void EnemyDead()
    {
        isLive = false;
        Invoke("DisableEnemyPanel", 2f);
        anim.SetTrigger("IsDead");        
        Destroy(gameObject, 3f);
    }
    private IEnumerator ReceiveDamageTextCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < 20; i++)
            {
                receiveDamdeText.rectTransform.position += new Vector3(0, 8, 0);

                if (i == 19)
                {
                    receiveDamdeText.transform.gameObject.SetActive(false);
                    yield break;
                }
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}