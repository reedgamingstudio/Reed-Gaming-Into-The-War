using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FMG
	{
	public class LevelSelect : MonoBehaviour {
		public GameObject levelButton;
		public Vector3 startPos = new Vector3(-80,130,0);
		public Vector3 offset = new Vector3(80,80,0);

		public int nomPerRow = 3;
		public int nomPerCol = 3;
		public int levelIndex = 0;
		private int m_nomPages = 0;

		private GameObject[] m_pages;
		public void onCommand(string str)
		{
			if(str.Equals("LevelSelectNext"))
			{
				m_pages[levelIndex].SetActive(false);
				levelIndex++;
				if(levelIndex>m_pages.Length-1)
				{
					levelIndex=0;
				}
				m_pages[levelIndex].SetActive(true);
			}

			if(str.Equals("LevelSelectPrev"))
			{
				m_pages[levelIndex].SetActive(false);
				levelIndex--;
				if(levelIndex<0)
				{
					levelIndex=m_pages.Length-1;
				}
				m_pages[levelIndex].SetActive(true);
			}
			Debug.Log ("levelIndex " + levelIndex);
		}

		void Awake () {

			int cellsPerPage = nomPerCol * nomPerRow;
			int tmpNomLevels = Application.levelCount-1;
			while(tmpNomLevels > 0)
			{
				tmpNomLevels-=cellsPerPage;
				m_nomPages++;
			}
			m_pages = new GameObject[m_nomPages];
			int offset = 0;
			for(int i=0 ;i<m_nomPages; i++)
			{
				m_pages[i] = spawnButtons(offset);
				if(i!=0)
				{
					m_pages[i].SetActive(false);
				}
				offset += cellsPerPage;
			}
		}

		GameObject spawnButtons(int indexoffset)
		{
			int n = indexoffset + 1;
			GameObject newPage = new GameObject();
			newPage.transform.parent = transform;
			newPage.transform.localPosition =  Vector3.zero;
			newPage.transform.localScale=new Vector3(1,1,1);
			
			
			Vector3 pos = startPos;
			for(int i=0; i<nomPerRow; i++)
			{
				pos.x = startPos.x;
				for(int j=0; j<nomPerCol; j++)
				{
					if(n<Application.levelCount)
					{
						GameObject newObject = (GameObject)Instantiate(levelButton,Vector3.zero,Quaternion.identity);
						newObject.transform.parent = newPage.transform;

						Button button = newObject.GetComponent<Button>();
						if(n > Constants.getMaxLevel())
						{
							button.interactable=false;
						}

						LevelButton lb = newObject.GetComponent<LevelButton>();
						lb.levelIndex = n;

						Text text = newObject.GetComponentInChildren<Text>();
						text.text = n.ToString();
						pos.x += offset.x;
						
						
						RectTransform rt = newObject.GetComponent<RectTransform>();
						rt.localPosition = pos;
						rt.localScale = new Vector3(1,1,1);
					}
					n++;
				}
				pos.y += offset.y;
			}
			return newPage;
		}
		

	}
}