using UnityEngine;
using UnityEngine.UI;  // 引入UI命名空间以便使用Image和Button

public class ToggleMusic : MonoBehaviour
{
    public AudioSource audioSource;  // 音乐播放源
    public Image buttonImage;        // 按钮的Image组件
    public Sprite playIcon;          // 播放图标
    public Sprite pauseIcon;         // 暂停图标

    private bool isMusicPlaying = true;  // 当前音乐播放状态

    // 在按钮点击时调用
    public void ToggleAudio()
    {
        if (isMusicPlaying)
        {
            // 如果音乐正在播放，则暂停音乐
            audioSource.Pause();
            buttonImage.sprite = playIcon;  // 更换为播放图标
        }
        else
        {
            // 如果音乐没有播放，则播放音乐
            audioSource.Play();
            buttonImage.sprite = pauseIcon;  // 更换为暂停图标
        }

        // 切换播放状态
        isMusicPlaying = !isMusicPlaying;
    }
}
