using UnityEngine;

public class StencilSwitcher : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _masks;
    private int _stencilId;

    private void Start()
    {
        _stencilId = Shader.PropertyToID("_StencilMaskId");
        int a = 10;
    }
    
    public void IncreaseStencilIdLevel(int leftMask, int currentIndex) => ToggleStencilIdLevel(leftMask, currentIndex, true);

    public void DecreaseStencilIdLevel(int rightMask, int currentIndex) => ToggleStencilIdLevel(rightMask, currentIndex, false);

    private void ToggleStencilIdLevel(int targetMaskIndex, int currentMask, bool increaseMaskId)
    {
        int difference = increaseMaskId ? 1 : -1;

        var stencilMaskId = (int)_masks[currentMask].material.GetFloat(_stencilId);
        stencilMaskId = Mathf.Clamp(stencilMaskId + difference, 0, 255);
        
        _masks[targetMaskIndex].material.SetFloat(_stencilId, stencilMaskId);
    }
}