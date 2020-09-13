using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;

	//弾いた時の傾き
	private float flickAngle = -20;

	//押されているかフラグ
	private bool isDown = false;

	// Use this for initialization
	void Start()
	{
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update()
	{

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}

		//左フリッパーを動かす
		if (tag == "LeftFripperTag")
		{
			//カウント用
			int i = 0;

			for (i = 0; i < Input.touchCount; i++)
			{
				//画面左側をタッチされていたら
				if (Input.touches[i].position.x < Screen.width / 2)
				{
					//タッチされていない状態だったら
					if (!isDown)
					{
						isDown = true;
						SetAngle(this.flickAngle);
					}
					break;
				}
			}

			//画面左側が１つもタッチされていない状態だったら
			if (i == Input.touchCount)
			{
				//タッチされている状態だったら
				if (isDown)
				{
					isDown = false;
					SetAngle(this.defaultAngle);
				}
			}
		}

		//右フリッパーを動かす
		if (tag == "RightFripperTag")
		{
			int i = 0;

			for (i = 0; i < Input.touchCount; i++)
			{
				//画面右側をタッチされていたら
				if (Input.touches[i].position.x >= Screen.width / 2)
				{
					//タッチされていない状態だったら
					if (!isDown)
					{
						isDown = true;
						SetAngle(this.flickAngle);
					}
					break;
				}
			}

			//画面右側が１つもタッチされていない状態だったら
			if (i == Input.touchCount)
			{
				//タッチされている状態だったら
				if (isDown)
				{
					isDown = false;
					SetAngle(this.defaultAngle);
				}
			}
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle(float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}