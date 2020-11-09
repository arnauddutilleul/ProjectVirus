using GameManager;
using UnityEngine;

namespace Contamination
{
    public class ContaminationManager : SingletonMb<ContaminationManager>
    {
        [SerializeField] private GameObject[] contaminationsBars;

        private GameObject _activeBar;

        public void ModifyContamination(int levelContamination)
        {
            _activeBar?.SetActive(false);
            if (levelContamination == 0)
                return;
            
            _activeBar = contaminationsBars[levelContamination - 1];
            _activeBar.SetActive(true);
        }

        protected override void Cleanup()
        {
        }

        protected override void Initialize()
        {
        }
    }
}
