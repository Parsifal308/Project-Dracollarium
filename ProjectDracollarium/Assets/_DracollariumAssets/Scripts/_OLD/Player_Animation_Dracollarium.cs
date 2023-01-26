using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dracollarium.Player
{
    //==============================================================================================
    //  ARREGLAR:
    //          Unificar un metodo que pase parametros numericos al animator, similar a lo que hace
    //      opsive con las abilities
    //
    //          Unificar los metodos para settear el parent de un objeto recogido, que un solo
    //      metodo sirva para cualquier casilla, tan solo pasando parametros.
    //===============================================================================================

    public class Player_Animation_Dracollarium : MonoBehaviour
    {
        #region FIELDS
        [Header("ANIMATION SYSTEM:"), Space(10)]
        private Animator animator;
        private PlayerManager controller_PlayerManager;

        [Header("ANIMATIONS STATES MACHINES:"), Space(10)]
        private SMGrabAnim _SMGrabAnim;

        [Header("Equipment Location:"), Space(10)]

        [SerializeField] private GameObject leftHandAxis;
        [SerializeField] private GameObject righHandAxis;
        [SerializeField] private GameObject leftShoulderAxis;
        [SerializeField] private GameObject rightShoulderAxis;
        [SerializeField] private GameObject backAxis;
        [SerializeField] private GameObject leftHipAxis;
        [SerializeField] private GameObject rightHipAxis;
        #endregion

        public GameObject BackAxis { get { return backAxis; } }

        #region ANIMATION METHODS
        public void SetMovementAnim(object sender, EventArgs e)
        {
            if ((sender as IMovement).IsMoving)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
            if ((sender as IMovement).IsSprinting)
            {
                animator.SetBool("isSprinting", true);
            }
            else
            {
                animator.SetBool("isSprinting", false);
            }
            if ((sender as IMovement).IsWalking)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
            if ((sender as IMovement).IsRunning)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        public void SetGrabbingAnim(object sender, EventArgs e)
        {
            animator.SetBool("isGrabbing", true);
        }
        public void ParentItemToRightHand(object sender, EventArgs e)
        {
            (sender as Player_ItemPickup).ObjectReached.GetComponent<Rigidbody>().useGravity = false;
            (sender as Player_ItemPickup).ObjectReached.GetComponent<Rigidbody>().isKinematic = true;
            (sender as Player_ItemPickup).ObjectReached.transform.parent = righHandAxis.transform;
            (sender as Player_ItemPickup).ObjectReached.transform.rotation = righHandAxis.transform.rotation;
            (sender as Player_ItemPickup).ObjectReached.transform.position = righHandAxis.transform.position;
        }
        public void ParentItemToLeftHand(object sender, EventArgs e)
        {
            (sender as Player_ItemPickup).ObjectReached.GetComponent<Rigidbody>().useGravity = false;
            (sender as Player_ItemPickup).ObjectReached.GetComponent<Rigidbody>().isKinematic = true;
            (sender as Player_ItemPickup).ObjectReached.transform.parent = leftHandAxis.transform;
            (sender as Player_ItemPickup).ObjectReached.transform.rotation = leftHandAxis.transform.rotation;
            (sender as Player_ItemPickup).ObjectReached.transform.position = leftHandAxis.transform.position;
        }
        public void ParentItemToBack(object sender, EventArgs e)
        {
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().useGravity = false;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().isKinematic = true;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.parent = backAxis.transform;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.rotation = backAxis.transform.rotation;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.position = backAxis.transform.position;
        }
        public void ParentItemToRightShoulder(object sender, EventArgs e)
        {
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().useGravity = false;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().isKinematic = true;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.parent = rightShoulderAxis.transform;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.rotation = rightShoulderAxis.transform.rotation;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.position = rightShoulderAxis.transform.position;
        }
        public void ParentItemToLeftShoulder(object sender, EventArgs e)
        {
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().useGravity = false;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().isKinematic = true;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.parent = leftShoulderAxis.transform;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.rotation = leftShoulderAxis.transform.rotation;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.position = leftShoulderAxis.transform.position;
        }
        public void ParentItemToLeftHip(object sender, EventArgs e)
        {
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().useGravity = false;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().isKinematic = true;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.parent = leftHipAxis.transform;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.rotation = leftHipAxis.transform.rotation;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.position = leftHipAxis.transform.position;
        }
        public void ParentItemToRightHip(object sender, EventArgs e)
        {
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().useGravity = false;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.GetComponent<Rigidbody>().isKinematic = true;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.parent = rightHipAxis.transform;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.rotation = rightHipAxis.transform.rotation;
            controller_PlayerManager.PlayerItemPickup.ObjectReached.transform.position = rightHipAxis.transform.position;
        }
        public void DropLeftItem(object sender, EventArgs e)
        {
            if (controller_PlayerManager.PlayerEquipment.LeftHandCarry != null)
            {
                controller_PlayerManager.PlayerEquipment.LeftHandCarry.transform.parent = null;
                controller_PlayerManager.PlayerEquipment.LeftHandCarry.transform.GetComponent<Rigidbody>().useGravity = true;
                controller_PlayerManager.PlayerEquipment.LeftHandCarry.transform.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (controller_PlayerManager.PlayerEquipment.LeftHand != null)
            {
                controller_PlayerManager.PlayerEquipment.LeftHand.transform.parent = null;
                controller_PlayerManager.PlayerEquipment.LeftHand.transform.GetComponent<Rigidbody>().useGravity = true;
                controller_PlayerManager.PlayerEquipment.LeftHand.transform.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        public void DropRightItem(object sender, EventArgs e)
        {
            if (controller_PlayerManager.PlayerEquipment.RightHandCarry != null)
            {
                controller_PlayerManager.PlayerEquipment.RightHandCarry.transform.parent = null;
                controller_PlayerManager.PlayerEquipment.RightHandCarry.transform.GetComponent<Rigidbody>().useGravity = true;
                controller_PlayerManager.PlayerEquipment.RightHandCarry.transform.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (controller_PlayerManager.PlayerEquipment.RightHand != null)
            {
                controller_PlayerManager.PlayerEquipment.RightHand.transform.parent = null;
                controller_PlayerManager.PlayerEquipment.RightHand.transform.GetComponent<Rigidbody>().useGravity = true;
                controller_PlayerManager.PlayerEquipment.RightHand.transform.GetComponent<Rigidbody>().isKinematic = false;
            }

        }
        public void HitAttackLight01(object sender, EventArgs e)
        {
            animator.SetBool("Hit", true);
            animator.SetBool("Hit_LightAttack", true);
        }
        #endregion


        #region MOVEMENT METHODS
        public void SetMovementInput(object sender, EventArgs e)
        {
            animator.SetFloat("MovementX", Mathf.Lerp(animator.GetFloat("MovementX"), (sender as IMovement).MoveInput.x, 0.05f));
            animator.SetFloat("MovementZ", Mathf.Lerp(animator.GetFloat("MovementZ"), (sender as IMovement).MoveInput.y, 0.05f));
        }
        #endregion


        #region UnityMethods
        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            controller_PlayerManager = GetComponent<PlayerManager>();
            animator.updateMode = AnimatorUpdateMode.Normal;
        }
        #endregion
    }
}