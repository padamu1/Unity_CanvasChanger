using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleHide : MonoBehaviour
{
    public void Hide()
    {
        StartCoroutine(DoHide());
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    IEnumerator DoHide()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;

        CanvasChanger.instance.activateScreen("menu");
    }
}
