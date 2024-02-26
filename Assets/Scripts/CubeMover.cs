using System;
using System.Linq;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private Transform[] currentCubeIndex;

    private Transform[] trueCubeIndex;
    private Transform preCubeIndex;
    
    private void Awake()
    {
       
        


    }

    private void Start()
    {
        trueCubeIndex = new Transform[currentCubeIndex.Length];
        Array.Copy(currentCubeIndex, trueCubeIndex, currentCubeIndex.Length);
        preCubeIndex = trueCubeIndex[1];


        
    }

    private void CheckWin()
    {
        if (currentCubeIndex.SequenceEqual(trueCubeIndex))
            Debug.Log("true");


        else
            Debug.Log("false");
    }



}
