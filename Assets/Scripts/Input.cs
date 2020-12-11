using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Input : MonoBehaviour
{
    // Start is called before the first frame update
    public List<UnityEngine.XR.InputDevice> leftController = new List<UnityEngine.XR.InputDevice>();
 
    public List<UnityEngine.XR.InputDevice> rightController = new List<UnityEngine.XR.InputDevice>();

    private UnityEngine.XR.InputDevice leftDevice, rightDevice;
    void Start()
    {
       
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left, leftController);
        foreach (var device in leftController)
        {
            Debug.Log(string.Format("Device found with name '{0}' and has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }
        if (leftController.Count>0)
        {
            leftDevice = leftController[0];
        }
       
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right, rightController);    
        
        foreach (var device in rightController)
        {
            Debug.Log(string.Format("Device found with name '{0}' and has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }

        if (rightController.Count>0)
        {
            rightDevice = rightController[0];
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        leftDevice.TryGetFeatureValue(CommonUsages.trigger, out float primaryButtonState);
        
        if (primaryButtonState > 0.7)
        {
            Debug.Log("Trigger pressed");
        }
    }
}
