using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    public float minFallSpeed = 1f;         // 最小下落速度
    public float maxFallSpeed = 2.5f;       // 最大下落速度
    public float minSwaySpeed = 0.5f;       // 最小左右摆动速度
    public float maxSwaySpeed = 1.5f;       // 最大左右摆动速度
    public float minSwayAmount = 0.5f;      // 最小摆动幅度
    public float maxSwayAmount = 2f;        // 最大摆动幅度

    private float fallSpeed;                // 实际下落速度
    private float swaySpeed;                // 实际左右摆动速度
    private float swayAmount;               // 实际摆动幅度
    private float swayOffset;               // 随机偏移，用于让每片叶子不同步

    void Start()
    {
        // 随机化下落和摆动的参数
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        swaySpeed = Random.Range(minSwaySpeed, maxSwaySpeed);
        swayAmount = Random.Range(minSwayAmount, maxSwayAmount);

        // 随机偏移左右摆动，让每片叶子不同步
        swayOffset = Random.Range(0f, 0.5f * Mathf.PI);
    }

    void Update()
    {
        // 计算叶子的左右摆动位移
        float sway = Mathf.Sin(Time.time * swaySpeed + swayOffset) * swayAmount;

        // 计算叶子的下落位置
        Vector3 fallPosition = transform.position;
        fallPosition.x += sway * Time.deltaTime;        // 更新左右位置
        fallPosition.y -= fallSpeed * Time.deltaTime;   // 更新下落位置
        fallPosition.z = Mathf.Clamp(fallPosition.z, -0.4f, 0.4f);


        // 更新叶子位置
        transform.position = fallPosition;

        // 如果叶子超出屏幕下方，可以选择重新生成到顶部（实现循环效果）
        if (fallPosition.y < -3) // 假设 -10 是屏幕下边界
        {
            Destroy(gameObject);
            //fallPosition.y = 10;  // 重新生成在顶部
            //transform.position = fallPosition;
        }
    }
}
