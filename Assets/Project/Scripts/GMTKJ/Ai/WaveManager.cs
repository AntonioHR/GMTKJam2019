using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GMTKJ.Ai
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObject[] waves;
        [SerializeField]
        private float waveInitialDelay = 1f;
        [SerializeField]
        private float timeBetweenWaves = 10f;
        [SerializeField]
        private Text currentWaveText;

        public void Begin ()
        {
            StartCoroutine(DelayWave());
        }

        IEnumerator DelayWave()
        {
            yield return new WaitForSeconds(waveInitialDelay);
            StartCoroutine(Run());
        }

        IEnumerator Run()
        {
            
            foreach (Wave w in waves)
            {
                StartCoroutine(NewWave(w));
                if(currentWaveText != null)
                    currentWaveText.text = w.name;
                yield return new WaitForSeconds(w.TotalTime());
            }
        }

        IEnumerator NewWave(Wave wave)
        {
            AudioManager.Instance.PlayFx("NewWave");
            foreach (WaveSection ws in wave.waveSections)
            {
                StartCoroutine(NewSection(ws));
                float sectionTotalTime = ws.Size * ws.timeBewteenEnemies + wave.timeBewteenSections;
                yield return new WaitForSeconds(sectionTotalTime);
            }
        }

        IEnumerator NewSection(WaveSection waveSection)
        {
            foreach (GameObject g in waveSection.enemyPrefabs)
            {
                AddEnemy(g);
                yield return new WaitForSeconds(waveSection.timeBewteenEnemies);
            }   
        }
        
        void AddEnemy(GameObject prefab)
        {
            GameObject e = Instantiate(prefab, this.transform);
        }
    }
}