using UnityEngine;
public class RespawnEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys;
    private EnemyScript currentEnemy;
    public EnemyScript CurrentEnemy { get => currentEnemy; }
    private void Start()
    {
        Respawn();
    }
    private EnemyScript SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemys[Random.Range(0, enemys.Length)]);
        return newEnemy.GetComponent<EnemyScript>();
    }
    public void Respawn()
    {
        currentEnemy = SpawnEnemy();
    }    
}