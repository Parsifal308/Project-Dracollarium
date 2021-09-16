using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICamera{
    public float CameraSensibility{ get; }
    public bool Enabled { get; set; }
    public bool IsMouseEnabled { get; set; }

    public void EnableMouseRotation(object sender, EventArgs e);
    public void DisableMouseRotation(object sender, EventArgs e);
}
