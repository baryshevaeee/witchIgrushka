using UnityEngine;

public class RockGlow : MonoBehaviour
{
    private Light rockLight; // ������ �� ��������� �����

    void Start()
    {
        // �������� ��������� Light � �����
        rockLight = GetComponentInChildren<Light>();

        // ��������� ���� � ������
        if (rockLight != null)
            rockLight.enabled = false;
    }

    // ���������� ��� ������ ����� � ����
    public void OnPickUp()
    {
        if (rockLight != null)
            rockLight.enabled = true;
    }

    // ���������� ��� ���������� �����
    public void OnDrop()
    {
        if (rockLight != null)
            rockLight.enabled = false;
    }
}
