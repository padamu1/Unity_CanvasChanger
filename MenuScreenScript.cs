using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenScript : MonoBehaviour
{
    private int selector;
    public void Single()
    {
        selector = 1;
        StartCoroutine(DoActive());
    }

    public void Undo()
    {
        selector = 2;
        StartCoroutine(DoActive());
    }

    IEnumerator DoActive()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
        switch (selector)
        {
            case 1:
                CanvasChanger.instance.activateScreen("single");
                break;
            case 2:
                CanvasChanger.instance.undoScreen();
                break;
            default:
                break;
        }
    }
}
