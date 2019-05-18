
using UnityEngine;

class GameManager : MonoBehaviour
{
    [SerializeField]
    private float enemySpawnDuration;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private EnemyController enemyPrefab;

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + enemySpawnDuration;
    }

    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.SetPlayer(playerController);
            enemy.transform.RotateAround(playerController.transform.position, Vector3.forward, Random.value * 360f);

            nextSpawnTime += enemySpawnDuration;
        }
    }
}

