using System.Collections;
using UnityEngine;

public class UpgradeButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private Gun _playerGun;
    [SerializeField] private PlayerEffects _effect;

    private Animator[] _objectsOnPanel;

    private void OnEnable()
    {
        _objectsOnPanel = GetComponentsInChildren<Animator>();

        StartCoroutine(PlayButtonsAnimCoroutine(true));
        StartCoroutine(SetTimeScale());
    }

    private IEnumerator PlayButtonsAnimCoroutine(bool isAnimatorActive)
    {        
        for (int i = 0; i < _objectsOnPanel.Length; i++)
        {
            if (isAnimatorActive)
                _objectsOnPanel[i].SetBool(AnimatorUpgradePanelController.Params.IsActive, true);
            else
                _objectsOnPanel[i].SetBool(AnimatorUpgradePanelController.Params.IsActive, false);

            yield return new WaitForSeconds(0.1f);
        }

        _upgradePanel.SetActive(isAnimatorActive);
    }

    private IEnumerator SetTimeScale()
    {
        yield return new WaitForSeconds(0.55f);
        Time.timeScale = 0;
    }

    public void OnIncreaseShootingSpeed()
    {
        StartCoroutine(PlayButtonsAnimCoroutine(false));

        Time.timeScale = 1;

        _playerGun.IncreaseShootingSpeed();
        _effect.PlayUpgradeEffect();
    }
}
