using UnityEngine;
public interface IPoolable
{
    void Activate();
    void StartDeactivation();
    System.Action OnDeactivate { get; set; }
    GameObject GameObject { get; }
}