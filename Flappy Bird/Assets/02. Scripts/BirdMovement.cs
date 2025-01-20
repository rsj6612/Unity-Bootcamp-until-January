using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D myRigid;
    public float flyPower = 10f;
    public float limitPower = 5f;

    public TMP_Text tmpText;
    private float timer = 0f;
    public SoundManager soundManager;

    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Fly();
        Timer();
    }

    private void Fly()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            soundManager.OnEventSound(2);
            myRigid.AddForce(Vector3.up * flyPower, ForceMode2D.Impulse);
            if (myRigid.velocity.y >= limitPower)
            {
                myRigid.velocity = new Vector3(myRigid.velocity.x, limitPower);
            }
        }

        var playerEulerAngle = transform.eulerAngles;
        playerEulerAngle.z = myRigid.velocity.y * 5f;

        transform.eulerAngles = playerEulerAngle;
    }

    private void Timer()
    {
        timer += Time.deltaTime;

        tmpText.text = "Time : " + timer.ToString("F1") + " sec";
    }
}