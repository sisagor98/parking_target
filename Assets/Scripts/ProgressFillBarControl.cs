using UnityEngine;
using UnityEngine.UI;

public class ProgressFillBarControl : MonoBehaviour
{
    public Image fillImage; 
    public float fillSpeed = 1f; 

    private float targetProgress = 0f; 
    private float currentProgress = 0f; 

    private void Start()
    {  
        SetProgress(0.5f);
    }

    private void Update()
    {
        if (currentProgress != targetProgress)
        {
            currentProgress = Mathf.MoveTowards(currentProgress, targetProgress, fillSpeed * Time.deltaTime);
            fillImage.fillAmount = currentProgress;
        }
    }

    public void SetProgress(float progress)
    {
        targetProgress = Mathf.Clamp01(progress);
    }
}


