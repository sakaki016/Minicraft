using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class SearchBlock : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    Block block;
    public int Search(string name)
    {
        var list = new List<string>();
        list.AddRange(blocks);
        int num = list.IndexOf(name);
        Debug.Log(num);
        //return num;
        block = blocks[num].GetComponent<Block>();
        return block.hp;
    }
}
