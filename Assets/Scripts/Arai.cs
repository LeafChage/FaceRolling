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

        void Start()
        {
            this.gameObject.transform.position = this.startPosition.position;
            this.ui.StartText();
        }

        void Update()
        {
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
        }

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
            yield return new WaitForSeconds(1);
            this.isJump = false;
        }

        private void end(){
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
