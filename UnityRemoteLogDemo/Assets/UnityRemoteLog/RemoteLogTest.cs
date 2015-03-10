using UnityEngine;
using System.Collections;

public class RemoteLogTest : MonoBehaviour
{
    float m_lastLogTime;
    int m_logIndex;

    // Use this for initialization
    void Start()
    {
        RemoteLog.Instance.Start("127.0.0.1", 2010);
        m_lastLogTime = Time.time;
        m_logIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - m_lastLogTime > 1)
        {
            m_lastLogTime = Time.time;
            switch (m_logIndex % 5)
            {
                case 0:
                    Debug.LogError("A Error Log " + m_logIndex);
                    break;
                case 1:
                    break;
                case 2:
                    Debug.LogWarning("A Warning Log " + m_logIndex);
                    break;
                case 3:
                    Debug.Log("A Log " + m_logIndex);
                    break;
                case 4:
                    try
                    {
                        throw new System.Exception("Test Log");
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogException(ex);
                    }
                    break;
            }

            m_logIndex++;
        }
    }
}
