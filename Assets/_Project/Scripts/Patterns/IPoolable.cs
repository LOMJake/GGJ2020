using UnityEngine;
public interface IPoolable
{
    void OnActivate();
    void Deactivate();
    System.Action OnDeactivate { get; set; }
    GameObject GameObject { get; }
}