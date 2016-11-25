using UnityEngine;
using System.Collections;

// 마우스 이동값에 따라서 메인카메라 회전.
public class CameraRotate : MonoBehaviour
{
    // 회전속도(감도).
    public float rotSpeed = 1;
    // 회전값 누적.
    public float camAnglesX;
    public float camAnglesY;

    public float anglesMin = -90;
    public float anglesMax = 90;
	
	void Update ()
    {
        // 1. 마우스 입력가 가져오기.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        
        camAnglesX += mx * rotSpeed * Time.deltaTime;
        camAnglesY += my * rotSpeed * Time.deltaTime;

        camAnglesY = Mathf.Clamp(camAnglesY, anglesMin, anglesMax);

        /*
        if (camAnglesY >= 90)
        { camAnglesY = 90; }
        else if (camAnglesY <= -90)
        { camAnglesY = -90; }
        */

        transform.eulerAngles = new Vector3(-camAnglesY, camAnglesX, 0);
    }
}
