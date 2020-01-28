using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolable
{
    private GameObject parent;
    private List<T> list = new List<T>();
    public List<T> List { get { return list; } }

    public int poolCapacity = 20;
    private int nextTestIndex = 0;
    private int NextTestIndex
    {
        get { return nextTestIndex; }
        set
        {
            nextTestIndex = value;
            if (nextTestIndex >= poolCapacity)
                nextTestIndex = 0;
        }
    }

    private bool toDestroy;
    private int stragglerCount;

    public bool TryActivate(out T activatedObject)
    {
        if (toDestroy)
        {
            Debug.LogWarning("Cannot activate pooled objects in list " + parent.name + " (toDestroy)");
        }
        GameObject go = list[NextTestIndex].GameObject;
        // see if the next logical item is good...
        if (go && !go.activeSelf)
        {
            go.SetActive(true);
            activatedObject = list[NextTestIndex];
            activatedObject.Activate();
            ++NextTestIndex;
            return true;
        }
        // otherwise iterate for one...
        for (int i = 0; i < poolCapacity; i++)
        {
            if (this == null)
                break;
            go = list[i].GameObject;
            if (go && !go.activeSelf)
            {
                go.SetActive(true);
                activatedObject = list[i];
                activatedObject.Activate();
                NextTestIndex = i + 1;
                return true;
            }
        }
        // otherwise out null and return false
        activatedObject = default(T);
        return false;
    }

    public void Empty(int newCapacity)
    {
        if (list == null)
            return;
        list.ForEach(o => { if (this != null && o != null) GameObject.Destroy(o.GameObject); });
        list.Clear();
        list.Capacity = poolCapacity = newCapacity;
        GameObject.Destroy(parent);
    }

    public void MarkForDestruction()
    {
        toDestroy = true;

        for (int i = 0; i < list.Count; i++)
        {
            //if (this != null && list != null && list[i] != null && list[i].GameObject != null && list[i].GameObject.activeSelf)
            if (list[i].GameObject != null && list[i].GameObject.activeSelf)
            {
                ++stragglerCount;
                list[i].OnDeactivate += HandleStragglerDeactivated;
            }
        }
        if (stragglerCount == 0)
        {
            Empty(0);
        }
    }

    private void HandleStragglerDeactivated()
    {
        --stragglerCount;
        if (stragglerCount <= 0)
        {
            Empty(0);
        }
    }

    public void Populate(GameObject original, string suffix = "")
    {
        parent = new GameObject(string.Format("OBJECT POOL [{0}][{1}]", original.name, suffix));
        for (int i = 0; i < poolCapacity; i++)
        {
            GameObject g = GameObject.Instantiate(original, parent.transform);
            g.SetActive(false);
            list.Add(g.GetComponent<T>());
        }
    }

    public ObjectPool() { }

    public ObjectPool(int capacity)
    {
        list.Capacity = poolCapacity = capacity;
    }

    //public ObjectPool(int capacity, GameObject original)
    //{
    //    Empty(capacity);
    //    Populate(original);
    //}
}
