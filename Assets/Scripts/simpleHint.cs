using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SimpleHint : MonoBehaviour
{
    public TextMesh hintText; // ���������� ���� ��� TextMesh

    void Start()
    {
        // �������� ��������� ��� �������
        GetComponent<XRGrabInteractable>().selectEntered.AddListener((args) => {
            hintText.GetComponent<MeshRenderer>().enabled = true;
        });

        GetComponent<XRGrabInteractable>().selectExited.AddListener((args) => {
            hintText.GetComponent<MeshRenderer>().enabled = false;
        });
    }
}
