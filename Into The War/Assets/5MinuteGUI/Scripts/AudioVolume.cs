using UnityEngine;
using System.Collections;

namespace FMG
{

	public class AudioVolume : MonoBehaviour {
		private float m_initalVol;
		void Awake () {
			m_initalVol = audio.volume;
			updateVolume();
		}


		public void updateVolume () {
			audio.volume = PlayerPrefs.GetFloat("AudioVolume",1) * m_initalVol;
		}
	}
}