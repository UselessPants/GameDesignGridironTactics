using System.Collections;
using System.Collections.Generic;
using TbsFramework.Cells;
using TbsFramework.Units;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace TbsFramework.Example4
{
   
    public class AdvWrsUnit : Unit
    {
        public string UnitName;
        public Vector3 Offset;

        public bool isStructure;

        public bool isHoldingBall;

        public GameObject ballIndicator;

        SpriteRenderer sprite;
   
    	void Start()
    	{
        	sprite = GetComponent<SpriteRenderer>();
        }
    
    	void Update()
    	{
       		if(Input.GetKeyDown(KeyCode.C))
        	{            
            	// Change the 'color' property of the 'Sprite Renderer'
           	 sprite.color = new Color (1, 0, 0, 1); 
        	}

            if (isHoldingBall) 
            {
                Instantiate(ballIndicator, transform.position, Quaternion.identity);
            }
    	}

        public override void Initialize()
        {
            base.Initialize();
            transform.localPosition += Offset;
        }

        public override void MarkAsDestroyed()
        {
        }

        protected override int Defend(Unit other, int damage)
        {
            if (isHoldingBall) 
            {
                isHoldingBall = false;
                other.GetComponent<AdvWrsUnit>().isHoldingBall = true;
            }
            return damage - (Cell as AdvWrsSquare).DefenceBoost;
        }

        protected override AttackAction DealDamage(Unit unitToAttack)
        {
            var baseVal = base.DealDamage(unitToAttack);
            var newDmg = TotalHitPoints == 0 ? 0 : (int)Mathf.Ceil(baseVal.Damage * ((float)HitPoints / TotalHitPoints));

            return new AttackAction(newDmg, baseVal.ActionCost);
        }

        public override IEnumerator Move(Cell destinationCell, IList<Cell> path)
        {
            GetComponent<SpriteRenderer>().sortingOrder += 10;
            transform.Find("Marker").GetComponent<SpriteRenderer>().sortingOrder += 10;
            transform.Find("Mask").GetComponent<SpriteRenderer>().sortingOrder += 10;
            yield return base.Move(destinationCell, path);
        }

        protected override void OnMoveFinished()
        {
            Vector3 searchOffset = new Vector3(0,0,0.1f);
            if (GameObject.FindGameObjectsWithTag("Football").Length > 0)
            {
                if (transform.position + searchOffset == GameObject.FindGameObjectWithTag("Football").transform.position)
                {
                    Destroy(GameObject.FindWithTag("Football"));
                    isHoldingBall = true;

                }
            }
            if ((transform.position + searchOffset).x >= 133 && isHoldingBall == true)
            {
                SceneManager.LoadScene(sceneName: "Player1Win");
            }
            if ((transform.position + searchOffset).x <= 7 && isHoldingBall == true)
            {
                SceneManager.LoadScene(sceneName: "Player2Win");
            }
            GetComponent<SpriteRenderer>().sortingOrder -= 10;
            transform.Find("Marker").GetComponent<SpriteRenderer>().sortingOrder -= 10;
            transform.Find("Mask").GetComponent<SpriteRenderer>().sortingOrder -= 10;
            base.OnMoveFinished();
        }

        public override bool IsCellTraversable(Cell cell)
        {
            return base.IsCellTraversable(cell) || (cell.CurrentUnits.Count > 0 && !cell.CurrentUnits.Exists(u => !(u as AdvWrsUnit).isStructure && u.PlayerNumber != PlayerNumber));
        }

        public override void SetColor(Color color)
        {
            var highlighter = transform.Find("Marker");
            var spriteRenderer = highlighter.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = color;
            }
        }

        public override bool IsUnitAttackable(Unit other, Cell otherCell, Cell sourceCell)
        {
            return base.IsUnitAttackable(other, otherCell, sourceCell) && other.GetComponent<CapturableAbility>() == null;
        }

        public override void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                base.OnMouseDown();
            }
        }

        protected override void OnMouseEnter()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                base.OnMouseEnter();
            }
            Cell.MarkAsHighlighted();
        }

        protected override void OnMouseExit()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                base.OnMouseExit();
            }
            Cell.UnMark();
        }
    }
}
