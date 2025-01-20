using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTag : MonoBehaviour
{
    public string tag;

    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(tag))
            PlayercController.Instance.AddObserver(tag, gameObject);
    }
}