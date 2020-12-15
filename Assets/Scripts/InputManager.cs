using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<UnityEngine.XR.InputDevice> leftController = new List<UnityEngine.XR.InputDevice>();
    public List<UnityEngine.XR.InputDevice> rightController = new List<UnityEngine.XR.InputDevice>();

    public GameObject leftControllerObject, rightControllerObject, barrelLoc;
    public BulletPoolManager bulletPoolManager;

    private UnityEngine.XR.InputDevice leftDevice, rightDevice;
    public bool isFiring = false;

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
        
        StartCoroutine("FireBullet");
    }

    // Update is called once per frame
    void Update()
    {
        rightDevice.TryGetFeatureValue(CommonUsages.trigger, out float primaryButtonState);
        
        if (primaryButtonState > 0.7)
        {
            isFiring = true;
            Debug.Log("Trigger pressed!");
        }

        else
        {
            isFiring = false;
        }

    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.15f);
            if (isFiring)
            {
                GameObject refBullet = bulletPoolManager.GetBullet();
                refBullet.transform.position = barrelLoc.transform.position;
                refBullet.transform.rotation = barrelLoc.transform.rotation;
            }
        }
    }

   
}
