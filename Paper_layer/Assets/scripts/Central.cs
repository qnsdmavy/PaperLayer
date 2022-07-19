using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Central : MonoBehaviour
{
    public Transform firstIcon;
    public Transform secondIcon;
    public Transform thirdIcon;
    public Transform invisibleIcon;

    public static int firstIndex;
    public static int secondIndex;
    public static int thirdindex;

    public AudioSource swap;

    List<Arranger> arrangers;

    void Start()
    {
        // 다중의 Arranger를 관리하기위한 리스트
        arrangers = new List<Arranger>();
        var arrs = transform.GetComponentsInChildren<Arranger>();
        for(int i = 0; i< arrs.Length; i++)
        {
            arrangers.Add(arrs[i]);
        }
        // 아이콘 이동 시 소리
        swap = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    // 아이콘의 위치 변경 함수
    public static void SwapIcons(Transform sour, Transform dest)
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        int sourIndex = sour.GetSiblingIndex();
        int destIndex = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destIndex);

        dest.SetParent(sourParent);
        dest.SetSiblingIndex(sourIndex);
    }

    void SwapIconsInHierarchy(Transform sour, Transform dest)
    {
        SwapIcons(sour, dest);
        arrangers.ForEach(t=>t.UpdateChildren());
    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos);
    }

    // 드래그가 시작될 때 함수
    void BeginDrag(Transform icon)
    {
        //Debug.Log("BeginDrag :" + icon.name);

        SwapIconsInHierarchy(invisibleIcon, icon);
    }
    // 드래그 중일 때
    void Drag(Transform icon)
    {
        //Debug.Log("Drag :" + icon.name);

        var whichArrangerIcon = arrangers.Find(t => ContainPos(t.transform as RectTransform, icon.position));

        if(whichArrangerIcon == null)
        {
            //Debug.Log(whichArrangerIcon.name);
        }
        else
        {
            //Debug.Log(whichArrangerIcon.GetIndexByPosition(icon, invisibleIcon.GetSiblingIndex()));
            int invisibleIconIndex = invisibleIcon.GetSiblingIndex();
            int targetIndex = whichArrangerIcon.GetIndexByPosition(icon, invisibleIconIndex);

            if(invisibleIconIndex != targetIndex)
            {
                whichArrangerIcon.SwapIcon(invisibleIconIndex, targetIndex);
            }
        }
    }
    // 드래그가 끝날 때
    void EndDrag(Transform icon)
    {
        //Debug.Log("EndDrag :" + icon.name);

        SwapIconsInHierarchy(invisibleIcon, icon);
        swap.Play();

        firstIndex = firstIcon.GetSiblingIndex();
        secondIndex = secondIcon.GetSiblingIndex();
        thirdindex = thirdIcon.GetSiblingIndex();
        if(SceneManager.GetActiveScene().name == "Scene1")
        {
            BroadcastMessage("ChangeLayer");
        }
        if(SceneManager.GetActiveScene().name == "Scene2")
        {
            BroadcastMessage("ChangeLayer2");
        }
        
    }

    // 종료
    public void Quit()
    {
        Application.Quit();
    }
}
