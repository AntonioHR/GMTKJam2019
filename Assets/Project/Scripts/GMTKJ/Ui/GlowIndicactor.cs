using UnityEngine;

namespace GMTKJ.Ui
{
    public class GlowIndicactor : MonoBehaviour
    {
        public Gradient gradient;
        public string property ;
        public int index;
        public MeshRenderer[] meshRenderers;

        public void SetTo(float val)
        {
            var color = gradient.Evaluate(val);
            foreach(var mr in meshRenderers)
            {
                mr.materials[index].SetColor(property, color);
            }
        }
    }
}