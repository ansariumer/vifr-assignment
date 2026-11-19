using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float reachDistance = 50f;

    public Image aim;
    public TMP_Text correct;
    public TMP_Text again;

    private bool isCompleted = false;

    public AudioSource correctAudio;
    public AudioSource againAudio;

    private Interactable currentTarget;

    void Start()
    {
        correct.gameObject.SetActive(false);
        again.gameObject.SetActive(false);

        aim.enabled = true;
    }

    void Update()
    {
        if (isCompleted)
            return;

        Ray ray = Camera.main.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0)
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            Interactable interactable =
                hit.collider.GetComponentInParent<Interactable>();

            if (interactable == currentTarget)
                return;

            currentTarget = interactable;

            again.gameObject.SetActive(false);

            if (interactable != null)
            {
                bool result = interactable.Interact();

                if (result == true)
                {
                    isCompleted = true;
                    correct.gameObject.SetActive(true);
                    if (correctAudio != null) correctAudio.Play();
                }
                else
                {
                    again.gameObject.SetActive(true);
                    if (againAudio != null) againAudio.Play();
                }
            }
        }
        else
        {
            currentTarget = null;
        }
    }
}