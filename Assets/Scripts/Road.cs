using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    static GameManager manager;
    static Vector3 startPosition;
    
    public static void SetManager(GameManager manager)
    {
        Road.manager = manager;
    }
    void Start()
    {
        if (gameObject.name != "road (2)") return;
        startPosition = transform.position;
    }

    void Update()
    {
        if (manager == null) return;
        var distToCamera = Camera.main.transform.position.y - transform.position.y;

        if (distToCamera <= manager.resetDistanceY) return;        
        ResetThis();
    }

    private void ResetThis()
    {
        transform.position += startPosition + Vector3.up * manager.resetDistanceY;
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        int total = Random.Range(0, manager.lines + 1);
        int needed = total;
        for (int i = 0; i < manager.lines; i++)
        {
            if (needed == 0) break;
            else if (!SpawnObstAtLine(i, needed, total)) continue;
            needed--;
        }
    }

    private bool SpawnObstAtLine(int lineInd,int needed, int total)
    {
        var limit = needed / (float)(manager.lines - lineInd);
        if (limit < 1 && Random.Range(0, 1f) < limit) return false;

        var x = manager.linesCentersX[lineInd];
        CreateObstacle(x, manager.GetObstacle());
        return true;
    }

    private void CreateObstacle(float posititonX, GameObject prefab)
    {
        var obsPosition = new Vector3(posititonX, transform.position.y);
        Instantiate(prefab, obsPosition, Quaternion.identity);
    }
}
