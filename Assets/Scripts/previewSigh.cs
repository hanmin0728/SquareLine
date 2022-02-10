using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class previewSigh : MonoBehaviour {
    //다른객체에서도 할수있게 인터페이스로?
    SpriteRenderer sprite;
   
    public Color[] colorSet = new Color[2];
    int idx = 0;
    public bool isColorComplet = false;
    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    //시리얼라이즈는 매니저로?
    [Serializable]
    public class SignColor {
        public string name;
        public int num;
        public Color[] color;
    }
    [SerializeField] SignColor[] sings;
    //여기에서 실행이 아닌 외부로 실행?

    //여기서 직렬화해가지고 번호와 색깔? 로 하면 되지 않을까?
    //hookRing의 RingMove를 가져와서 널이 아니라면 
    //그리고 색깔도 바꾸게

    
    public IEnumerator ColorToggle(int num = 0) {



        //이걸 이제 Enum으로 하면 더편하나? 프로그래밍할때는 자연어로 프로그래밍해보고 자연어 한줄마다 도전해보는수밖에 없구만
        //뭔가 막히면 인터넷 검색해서 해결하는 방법을 모으고 이떄 알고리즘을 공부해가지고 검색이나 자료구조같은걸로 하는거구만 수학도 그렇고 


   
        switch (num) {
            case 0:
            colorSet = sings[num].color; //이것도 숫자보다는 매니저로 해가지고 이름을 적으면 그색깔에 맞게 해야겠다.
           
            break;
            case 1:
            colorSet = sings[num].color; 
            break;
            case 2:
            colorSet = sings[num].color;
            break;

        }

  

        for (int i = 0; i < 4; i++) {

            sprite.color = colorSet[0];
            yield return new WaitForSeconds(0.15f);
            sprite.color = colorSet[1];
            yield return new WaitForSeconds(0.15f);

        }


        isColorComplet = true;

        gameObject.SetActive(false);

        //불로 하는방법이랑 함수로 이걸 받아가지고 이걸하는방법
    }


    private void OnDisable() {
        PoolManager.ReturnToPool(gameObject);

    }
}
