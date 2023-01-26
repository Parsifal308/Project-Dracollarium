using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFabricate 
{
    void Create(GameObject x);
    void Destroy();
    void Dismantle();

    void EnablePositioning();
    void DisablePositioning();
}
