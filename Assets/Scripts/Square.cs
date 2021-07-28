using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField]
    float shrinkingTime = 1;

    private void Start()
    {
    }
    public void StartShrink()
    {
        StartCoroutine(Shrinking());
    }

    IEnumerator Shrinking()
    {
        for(float elapsedTime = 0; elapsedTime + Time.deltaTime < shrinkingTime; elapsedTime += Time.deltaTime)
        {
            transform.localScale = Vector3.one * Mathf.Pow(1 - (elapsedTime / shrinkingTime), 5);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = Vector3.zero;
    }
}
