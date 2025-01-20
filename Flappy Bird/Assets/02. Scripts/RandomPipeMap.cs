using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomPipeMap : MonoBehaviour
{
    public enum PIPE_TYPE { TOP, BOTTOM, ALL }
    public PIPE_TYPE pipeType;

    public GameObject[] pipes;
    public float pipeSpeed = 10f;

    void Start()
    {
        RandomPipeType();
    }

    private void RandomPipeType()
    {
        var randomPipeType = Random.Range(0, 3);

        pipeType = (PIPE_TYPE)randomPipeType;
		// // 추가
        float randomHeight = Random.Range(-3f, 2f);
        transform.position = new Vector3(transform.position.x, randomHeight, transform.position.z);
        
        ActivePipe();
    }

    private void ActivePipe()
    {
        if (pipeType == PIPE_TYPE.BOTTOM)
        {
            pipes[0].SetActive(true);
            pipes[1].SetActive(false);
        }
        else if (pipeType == PIPE_TYPE.TOP)
        {
            pipes[0].SetActive(false);
            pipes[1].SetActive(true);
        }
        else if (pipeType == PIPE_TYPE.ALL)
        {
            pipes[0].SetActive(true);
            pipes[1].SetActive(true);
        }
    }

    void Update()
    {
        foreach (var pipe in pipes)
        {
		        pipe.transform.position -= Vector3.right * pipeSpeed * Time.deltaTime;

            if (pipe.transform.position.x <= -10f)
            {
                RandomPipeType();
                pipe.transform.position = new Vector3(10f, pipe.transform.position.y, pipe.transform.position.z);
            }
        }
    }
}