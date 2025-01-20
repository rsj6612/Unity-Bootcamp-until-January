using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    LineRenderer lineRenderer;

    public GameObject prefab;
    
    List<GameObject> points = new List<GameObject>();
    
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        StartCoroutine(TraceLine());
    }

    IEnumerator TraceLine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
            
            GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            points.Add(go);
            
            
        }
    }

    private void Update()
    {
        for (var i = 2; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i].transform.position);
        }        
    }
}
