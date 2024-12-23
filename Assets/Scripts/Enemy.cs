using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private float HP = 100;

    [SerializeField] private float duration;
    [SerializeField] private float scaleMuiltiply;

    private Vector3 startScale;
    Vector3 newScale;
    private float startTime;
    private void Start()
    {
        startScale = transform.localScale;
        newScale = startScale * scaleMuiltiply;
    }
    public void ApllyDamage(float value)
    {
        HP -= value;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(animation(startScale * scaleMuiltiply, true));
    }

    IEnumerator animation(Vector3 scale, bool isStart)
    {
        startTime = Time.time;
        float t = 0;
        Vector3 tmpScale = transform.localScale;
        while (t < 1)
        {
            t = (Time.time - startTime) / duration;
            transform.localScale = Vector3.Lerp(tmpScale, scale, t);
            yield return null;
        }
        if (isStart)
        {
            StartCoroutine(animation(startScale, false));
        }
    }
}
