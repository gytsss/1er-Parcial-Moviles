using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class InputManager
{
    static InputManager instance = null;
    float giro = 0f;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
            }
            return instance;
        }
    }

    Dictionary<string, float> axisValues = new Dictionary<string, float>();
    Dictionary<string, bool> buttonsValues = new Dictionary<string, bool>();

    public void SetAxis(string inputName, float value)
    {
        if (!axisValues.ContainsKey(inputName))
            axisValues.Add(inputName, value);
        axisValues[inputName] = value;
    }

    public float GetOrAddAxis(string axis)
    {
        if (!axisValues.ContainsKey(axis))
            axisValues.Add(axis, 0f);
        return axisValues[axis];
    }

    public float GetAxis(string inputName)
    {
#if UNITY_EDITOR
        return GetOrAddAxis(inputName) + Input.GetAxis(inputName);
#elif UNITY_ANDROID || UNITY_IOS
          return GetOrAddAxis(inputName);
#elif UNITY_STANDALONE
        return Input.GetAxis(inputName);
#endif
    }

    public bool GetOrAddButton(string axis)
    {
        if (!buttonsValues.ContainsKey(axis))
            buttonsValues.Add(axis, false);
        return buttonsValues[axis];
    }

    public bool GetButton(string inputName)
    {
#if UNITY_EDITOR
        return GetOrAddButton(inputName) || Input.GetButton(inputName);
#elif UNITY_ANDROID || UNITY_IOS
          return GetOrAddButton(inputName);
#elif UNITY_STANDALONE
        return Input.GetButton(inputName);
#endif
    }


}
