using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    CharController charController;
    
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponentInParent<CharController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        charController.Grounded++;
        charController.GetComponent<Animator>().Play("Idles");
        Debug.Log("OnTriggerEnter2D" + charController.Grounded);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        charController.Grounded--;
        Debug.Log("OnTriggerExit2D" + charController.Grounded);
    }
}
