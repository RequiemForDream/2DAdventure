using UnityEngine;
using System.Collections;

public class ArrowPool : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand;
    [SerializeField] private Arrow arrowPrefab;
    [SerializeField] private float TimeSpawn = 1f;
    [SerializeField] private Transform spawnPosition;
    private PoolMono<Arrow> pool;

    private void Awake()
    {
        pool = new PoolMono<Arrow>(arrowPrefab, poolCount, transform);
        pool.autoExpand = autoExpand;
        StartCoroutine(EjectArrows());
    }

    private IEnumerator EjectArrows()
    {
        while (true)
        {
            CreateArrow();
            yield return new WaitForSeconds(TimeSpawn);
        }
    }

    private void CreateArrow()
    {
        var positionX = transform.position.x;
        var positionY = transform.position.y;

        var spawnPosition = new Vector2(positionX, positionY);
        var arrow = pool.GetFreeElement();
        arrow.transform.position = this.spawnPosition.position;       
    }
}
