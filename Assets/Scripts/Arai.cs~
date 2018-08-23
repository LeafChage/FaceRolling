using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LeafChage
{
    public class Arai : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameObject camera;
        [SerializeField] private Transform startPosition;
        [SerializeField] private UI ui;

        private float time = 0;
        private bool isFinish = false;

        void Start()
        {
            this.gameObject.transform.position = this.startPosition.position;
            this.ui.StartText();
            this.time = 0;
            this.isFinish = false;
        }

        void Update()
        {
            if(!this.isFinish) {
                this.time += Time.deltaTime;
                Debug.Log(this.time);
                this.ui.TimeText = (this.time / 60).ToString("00") + ":" + (this.time % 60).ToString("00") + ":" + ((this.time - (float)((int)this.time))*100).ToString("00");
            }

            this.moveCamera();

            if (Input.GetKey(KeyCode.J))
            {
                this.rb.AddForce(Vector2.right * 10);
                this.rb.MoveRotation(10);
            }

            if (Input.GetKey(KeyCode.F))
            {
                this.rb.AddForce(Vector2.left * 10);
                this.rb.MoveRotation(-10);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(!this.isJump) {
                    this.rb.AddForce(Vector2.up * 400);
                    StartCoroutine(jumpCoroutine());
                }
            }

            if(this.rb.velocity.x >= this.maxSpeed) {
                var speed = this.rb.velocity;
                speed.x = this.maxSpeed;
                this.rb.velocity = speed;
            }
        }

        private float maxSpeed = 10;

        private void moveCamera()
        {
            var arai = this.gameObject.transform.position;
            var camera = this.camera.transform.position;
            camera.x = arai.x;
            camera.y = arai.y;
            this.camera.transform.position = camera;
        }

        private bool isJump = false;
        private IEnumerator jumpCoroutine()
        {
            this.isJump = true;
            yield return new WaitForSeconds(1.5f);
            this.isJump = false;
        }

        private void end(){
            this.isFinish = true;
            this.ui.GoalText(() => {
                    this.Start();
            });
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case Const.Tag.FALL:
                    this.Start();
                    break;
                case Const.Tag.GOAL:
                    this.end();
                    break;
                case Const.Tag.DAMAGE:
                    this.Start();
                    break;
                default:
                    break;
            }
        }
    }
}
