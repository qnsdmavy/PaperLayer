using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    List<Transform> children;
    void Start()
    {
        children = new List<Transform>();

        UpdateChildren();
    }

    // Arranger의 자식 업데이트 함수
    public void UpdateChildren()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            if(i == children.Count)
            {
                children.Add(null);

            }

            var child = transform.GetChild(i);

            if(child != children[i])
            {
                children[i] = child;
            }
        }

        children.RemoveRange(transform.childCount, children.Count - transform.childCount);
    }

    // 아이콘의 순서 파악 함수
    public int GetIndexByPosition(Transform icon, int skipIndex = -1)
    {
        int result = 0;

        for(int i = 0; i< children.Count; i++)
        {
            if(icon.position.y > children[i].position.y)
            {
                break;
            }
            else if(skipIndex != i)
            {
                result++;
            }
        }
        return result;
    }

    // 아이콘 스왑 함수
    public void SwapIcon(int index01, int index02)
    {
        Central.SwapIcons(children[index01], children[index02]);
        UpdateChildren();
    }
}
