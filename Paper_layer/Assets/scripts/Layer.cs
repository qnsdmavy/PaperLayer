using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public Transform treeLayer;
    public Transform brokenBridgeLayer;
    public Transform waterLayer;
    public GameObject help;

    public GameObject frontTree;
    public GameObject backTree;

    void Start()
    {
        frontTree.SetActive(false);
        backTree.SetActive(true);
        help.SetActive(false);
        Invoke("Help", 1);
    }

    //레이어 변경 함수
    public void ChangeLayer()
    {
        help.SetActive(false);
        treeLayer.SetSiblingIndex(Central.firstIndex);
        brokenBridgeLayer.SetSiblingIndex(Central.secondIndex);
        waterLayer.SetSiblingIndex(Central.thirdindex);
        // 트리레이어가 다리레이어보다 위에 위치할 경우
        if (treeLayer.GetSiblingIndex() > brokenBridgeLayer.GetSiblingIndex())
        {
            frontTree.SetActive(true);
            backTree.SetActive(false);
            BroadcastMessage("GameClear");
        }
    }
    // 안내문 표시 함수
    public void Help()
    {
        help.SetActive(true);
    }
}
