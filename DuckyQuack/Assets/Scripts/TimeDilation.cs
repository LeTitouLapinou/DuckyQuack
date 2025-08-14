using System.Collections;
using UnityEngine;

public class TimeDilation : MonoBehaviour
{
    public float slowMotionTimeScale;

    private float startTimeScale;
    private float startFixedDeltaTime;

    private void Start()
    {
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
    }
    public void StartSlowMotion()
    {
        Time.fixedDeltaTime *= slowMotionTimeScale;
        Time.timeScale = slowMotionTimeScale;
        StartCoroutine("RemoveSlowMo");
    }
    public void StopSlowMotion()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }

    IEnumerator RemoveSlowMo()
    {
        yield return new WaitForSeconds(1);
        StopSlowMotion();
    }
}
