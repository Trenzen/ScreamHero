using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject obstacleParent;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 scaleOffset;
    [SerializeField] private float valXMinPos;
    [SerializeField] private float valXMaxPos;
    private GameObject lastSpawnPos;
    private Stack<GameObject> goStack = new Stack<GameObject>();
    private float maxHeight;
    private float maxWidth;
    private float valXScale;
    private float valYScale;


    // Start is called before the first frame update
    void Start()
    {
        lastSpawnPos = obstacle;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameConstants.Activate == true)
        {
            if (GameConstants.spawnPosition == true)
            {
                if (GameConstants.count > 0)
                {
                    int childCounter = obstacleParent.transform.childCount;
                    if (childCounter > 5)
                    {
                        for (int deletedChildren = 0; deletedChildren < 3; deletedChildren++)
                        {
                            Destroy(obstacleParent.transform.GetChild(deletedChildren).gameObject);
                        }
                    }
                    maxHeight = lastSpawnPos.transform.localScale.y;
                    maxWidth = lastSpawnPos.transform.localScale.x;
                    offset = new Vector3(Random.Range(valXMinPos, valXMaxPos), 0, 0);
                    if (maxHeight > 20f)
                    {
                        valYScale = Random.Range(-0.5f, -2f);
                    }
                    else if (maxHeight < 3f)
                    {
                        valYScale = Random.Range(0.5f, 2f);
                    }
                    else
                    {
                        valYScale = Random.Range(-0.5f, 2f);
                    }

                    if (maxWidth > 15f)
                    {
                        valXScale = Random.Range(-0.5f, -2f);
                    }
                    else if (maxWidth < 5f)
                    {
                        valXScale = Random.Range(0.5f, 2f);
                    }
                    else
                    {
                        valXScale = Random.Range(-0.5f, 2f);
                    }
                    scaleOffset = new Vector3(valXScale, valYScale, 0);
                    GameObject spawnObject = Instantiate(obstacle);
                    spawnObject.transform.localScale = lastSpawnPos.transform.localScale + scaleOffset;
                    spawnObject.transform.position = new Vector3(lastSpawnPos.GetComponent<Renderer>().bounds.max.x + (spawnObject.transform.localScale.x / 2), lastSpawnPos.transform.position.y, lastSpawnPos.transform.position.z) + offset;
                    spawnObject.transform.rotation = Quaternion.identity;
                    spawnObject.transform.parent = obstacleParent.transform;
                    if (goStack.Count != 0)
                    {
                        goStack.Pop();
                    }
                    if (lastSpawnPos != obstacle)
                    {
                        goStack.Push(lastSpawnPos.gameObject);
                    }
                    lastSpawnPos = spawnObject;
                    GameConstants.count--;
                }
            }
        }
    }
}
