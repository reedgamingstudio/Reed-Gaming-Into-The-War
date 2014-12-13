using UnityEngine;
using System.Collections;
namespace FMG
	{
	public class GameMenu : MonoBehaviour {
		public GameObject pauseMenu;
		public void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Time.timeScale = 0;
				Constants.fadeInFadeOut(pauseMenu,null);

				pauseMenu.SetActive(true);
			}
		}

		public void onCommand(string str)
		{
			if(str.Equals("Restart"))
			{
				Time.timeScale = 1;
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if(str.Equals("Unapuse"))
			{
				Time.timeScale = 1;
				Constants.fadeInFadeOut(null,pauseMenu);

			}
			if(str.Equals("MainMenu"))
			{
				Time.timeScale = 1;
				Application.LoadLevel(0);

			}
			
		}
	}
}