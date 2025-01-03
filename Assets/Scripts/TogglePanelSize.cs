using UnityEngine;
using UnityEngine.UI;
using TMPro; // 如果使用 TextMeshPro

public class TogglePanelSize : MonoBehaviour
{
    // 原始大小
    private Vector2 originalSize;
    // 扩展后的大小
    private Vector2 expandedSize;
    // 当前状态
    private bool isExpanded = false;
    // 按钮
    public Button toggleButton;
    // 记录RectTransform
    private RectTransform rectTransform;
    // 动画时间（可选）
    public float animationDuration = 0.2f;
    // 当前动画进度
    private float currentTime = 0f;
    // 目标大小
    private Vector2 targetSize;
    // 是否正在动画
    private bool isAnimating = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
        expandedSize = new Vector2(originalSize.x * 2f, originalSize.y); // 仅宽度扩展为两倍

        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleSize);
        }
    }

    void Update()
    {
        if (isAnimating)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentTime / animationDuration);
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, targetSize, t);

            if (t >= 1f)
            {
                isAnimating = false;
                rectTransform.sizeDelta = targetSize;
            }
        }
    }

    public void ToggleSize()
    {
        if (isAnimating) return; // 防止重复点击

        isExpanded = !isExpanded;
        targetSize = isExpanded ? expandedSize : originalSize;
        currentTime = 0f;
        isAnimating = true;

        // 可选：旋转按钮的三角形
        // 假设按钮内有一个Image作为三角形
        Image triangle = toggleButton.GetComponentInChildren<Image>();
        if (triangle != null)
        {
            // 旋转90度或-90度，根据扩展状态
            triangle.transform.rotation = isExpanded ? Quaternion.Euler(0, 0, 90) : Quaternion.Euler(0, 0, 0);
        }
    }
}
