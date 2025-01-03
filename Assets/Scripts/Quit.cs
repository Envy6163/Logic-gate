using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // 退出游戏的函数
    public void ExitApplication()
    {
        // 如果是运行在编辑器中，停止播放
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // 在编辑器中停止游戏
#else
        // 否则退出应用程序
        Application.Quit();  // 在构建版本中退出游戏
#endif
    }
}
