using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameObject leafPrefab;            // 引用叶子Prefab
    public int initialLeafCount = 20;        // 初始生成叶子的数量
    public float spawnInterval = 2f;         // 生成叶子的间隔时间
    public Vector3 spawnArea = new Vector3(3f, 3f,3f); // 生成区域范围
    public Transform targetParent;

    public Vector2 randomScaleRange = new Vector2(2.5f, 3.5f);   // 随机缩放范围
    public Vector2 randomRotationRange = new Vector2(-30f, 30f); // 随机旋转范围

    private float timer;                     // 计时器

    void Start()
    {
        // 初始批量生成叶子
        for (int i = 0; i < initialLeafCount; i++)
        {
            SpawnLeaf();
        }

        targetParent = GameObject.FindGameObjectWithTag("MainCylindre").transform;

    }

    void Update()
    {
        // 根据 spawnInterval 定时生成叶子
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnLeaf();
            timer = 0;
        }
    }

    void SpawnLeaf()
    {
        // 随机生成叶子的初始位置
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x , spawnArea.x),
             spawnArea.y,
            //Random.Range(5, spawnArea.y),
            spawnArea.z
        );

        // 实例化叶子对象
        GameObject leaf = Instantiate(leafPrefab, spawnPosition, Quaternion.identity, targetParent);

        // 设置随机缩放
        float randomScale = Random.Range(randomScaleRange.x, randomScaleRange.y);
        leaf.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        // 设置随机旋转
        float randomRotationZ = Random.Range(randomRotationRange.x, randomRotationRange.y);
        leaf.transform.rotation = Quaternion.Euler(0f, 0f, randomRotationZ);
    }
}
