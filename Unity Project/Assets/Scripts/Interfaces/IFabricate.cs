using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFabricate 
{
    void Create();
    void Destroy();
    void Dismantle();
}
