using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_PlayerInputs : MonoBehaviour
{
    const string MouseXString = "Mouse X";
    const string MouseYString = "Mouse Y";
    const string MouseScrollString = "Mouse ScrollWheel";

    public static float MouseXInput { get => Input.GetAxis(MouseXString); }

    public static float MouseYInput { get => Input.GetAxis(MouseYString); }

    public static float MouseScrollInput { get => Input.GetAxis(MouseScrollString); }
}
