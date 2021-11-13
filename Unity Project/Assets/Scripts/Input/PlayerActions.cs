// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerKeyboard"",
            ""id"": ""00b5fead-8259-4acb-984a-536e6b583467"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c3411ab1-5246-4dc1-8039-3826e6445fc6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""e979434c-7330-4131-996d-bc14ee9f69fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""8555bed1-fe10-404f-bd8d-05d924141775"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c1ceffcc-b448-460f-89c9-66d4ff0abc4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionA"",
                    ""type"": ""Button"",
                    ""id"": ""aa74f212-906a-4f4d-9343-58ff50b546c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionB"",
                    ""type"": ""Button"",
                    ""id"": ""45eadb1f-832e-4680-9942-eaf2604e8ed0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""84226c60-17a7-4523-878a-b2c05081f385"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5ba347be-2ab1-4111-af5e-40d2450f69bd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BuildingPlacement"",
                    ""type"": ""Button"",
                    ""id"": ""8a8b0ab8-7941-4040-9a8d-5e15ce82d456"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EquipmentMenu"",
                    ""type"": ""Button"",
                    ""id"": ""33708342-dbad-4166-8019-d3aa6a158fc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CharacterMenu"",
                    ""type"": ""Button"",
                    ""id"": ""9c8f3e32-1084-4e45-8b33-0a3cb3a9113b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BuildMenu"",
                    ""type"": ""Button"",
                    ""id"": ""8258cfcc-6b83-4397-b8e7-52eed828efed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JourneyMenu"",
                    ""type"": ""Button"",
                    ""id"": ""99b01bfe-4465-4dd4-8511-8a4a7d4ec052"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapMenu"",
                    ""type"": ""Button"",
                    ""id"": ""c34852fb-e04a-485e-b781-e39e67b3c273"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FacultiesMenu"",
                    ""type"": ""Button"",
                    ""id"": ""afdf9619-e13c-4956-a8de-20cdced46eeb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2c24f6fd-7f83-4b79-985d-037ac8d092eb"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""03bee663-d17b-46c3-97fc-61e0122d82e2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7392d9b6-0e2b-4682-bbe1-cde4571aae7f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6008ce20-aea7-47ee-ad65-8c764c1b5e6c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""744c9f4e-a24e-4af1-b985-70381b16c357"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c78192ea-e5b4-47c2-aba3-349f08b5e6e3"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0eaeb3f7-d83a-4cb4-8ef9-39799e67bb09"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92e8cbdf-ba77-40f5-b602-fdb1ecc4d85c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""794c6031-d0e7-473f-bdbb-1bd2f499fb89"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4db3c2d-4e06-4fe8-9df5-7602ce57234f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6d9fa90-2013-4675-821e-3a8e99ace72a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EquipmentMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7aa2d082-d7b7-4d78-abaa-4e7b9c362518"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""553d5ed8-8feb-4a66-8c09-68a073365027"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JourneyMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bdd7d1a-a0ee-414b-bcf3-11c67a312104"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BuildMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d255ea34-d2f9-48a6-be57-87249f1cd8b0"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MapMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""100158f2-2c3c-4afe-b1a1-b8c7d155648e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d19a70e-6e0a-49db-a845-e7030e1da5b9"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b140c9a5-45f8-46b8-b4ee-8041b94f75b7"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FacultiesMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""865ae6c6-d9f4-4a02-9407-35b5d5c16b28"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BuildingPlacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5386bbe-b93d-4ca2-8a0f-d1e2e02795e3"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BuildingPlacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99d60496-1513-464c-891f-799ddc1692a5"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BuildingPlacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerKeyboard
        m_PlayerKeyboard = asset.FindActionMap("PlayerKeyboard", throwIfNotFound: true);
        m_PlayerKeyboard_Movement = m_PlayerKeyboard.FindAction("Movement", throwIfNotFound: true);
        m_PlayerKeyboard_Run = m_PlayerKeyboard.FindAction("Run", throwIfNotFound: true);
        m_PlayerKeyboard_Walk = m_PlayerKeyboard.FindAction("Walk", throwIfNotFound: true);
        m_PlayerKeyboard_Jump = m_PlayerKeyboard.FindAction("Jump", throwIfNotFound: true);
        m_PlayerKeyboard_ActionA = m_PlayerKeyboard.FindAction("ActionA", throwIfNotFound: true);
        m_PlayerKeyboard_ActionB = m_PlayerKeyboard.FindAction("ActionB", throwIfNotFound: true);
        m_PlayerKeyboard_MouseDelta = m_PlayerKeyboard.FindAction("MouseDelta", throwIfNotFound: true);
        m_PlayerKeyboard_MousePosition = m_PlayerKeyboard.FindAction("MousePosition", throwIfNotFound: true);
        m_PlayerKeyboard_BuildingPlacement = m_PlayerKeyboard.FindAction("BuildingPlacement", throwIfNotFound: true);
        m_PlayerKeyboard_EquipmentMenu = m_PlayerKeyboard.FindAction("EquipmentMenu", throwIfNotFound: true);
        m_PlayerKeyboard_CharacterMenu = m_PlayerKeyboard.FindAction("CharacterMenu", throwIfNotFound: true);
        m_PlayerKeyboard_BuildMenu = m_PlayerKeyboard.FindAction("BuildMenu", throwIfNotFound: true);
        m_PlayerKeyboard_JourneyMenu = m_PlayerKeyboard.FindAction("JourneyMenu", throwIfNotFound: true);
        m_PlayerKeyboard_MapMenu = m_PlayerKeyboard.FindAction("MapMenu", throwIfNotFound: true);
        m_PlayerKeyboard_FacultiesMenu = m_PlayerKeyboard.FindAction("FacultiesMenu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerKeyboard
    private readonly InputActionMap m_PlayerKeyboard;
    private IPlayerKeyboardActions m_PlayerKeyboardActionsCallbackInterface;
    private readonly InputAction m_PlayerKeyboard_Movement;
    private readonly InputAction m_PlayerKeyboard_Run;
    private readonly InputAction m_PlayerKeyboard_Walk;
    private readonly InputAction m_PlayerKeyboard_Jump;
    private readonly InputAction m_PlayerKeyboard_ActionA;
    private readonly InputAction m_PlayerKeyboard_ActionB;
    private readonly InputAction m_PlayerKeyboard_MouseDelta;
    private readonly InputAction m_PlayerKeyboard_MousePosition;
    private readonly InputAction m_PlayerKeyboard_BuildingPlacement;
    private readonly InputAction m_PlayerKeyboard_EquipmentMenu;
    private readonly InputAction m_PlayerKeyboard_CharacterMenu;
    private readonly InputAction m_PlayerKeyboard_BuildMenu;
    private readonly InputAction m_PlayerKeyboard_JourneyMenu;
    private readonly InputAction m_PlayerKeyboard_MapMenu;
    private readonly InputAction m_PlayerKeyboard_FacultiesMenu;
    public struct PlayerKeyboardActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerKeyboardActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerKeyboard_Movement;
        public InputAction @Run => m_Wrapper.m_PlayerKeyboard_Run;
        public InputAction @Walk => m_Wrapper.m_PlayerKeyboard_Walk;
        public InputAction @Jump => m_Wrapper.m_PlayerKeyboard_Jump;
        public InputAction @ActionA => m_Wrapper.m_PlayerKeyboard_ActionA;
        public InputAction @ActionB => m_Wrapper.m_PlayerKeyboard_ActionB;
        public InputAction @MouseDelta => m_Wrapper.m_PlayerKeyboard_MouseDelta;
        public InputAction @MousePosition => m_Wrapper.m_PlayerKeyboard_MousePosition;
        public InputAction @BuildingPlacement => m_Wrapper.m_PlayerKeyboard_BuildingPlacement;
        public InputAction @EquipmentMenu => m_Wrapper.m_PlayerKeyboard_EquipmentMenu;
        public InputAction @CharacterMenu => m_Wrapper.m_PlayerKeyboard_CharacterMenu;
        public InputAction @BuildMenu => m_Wrapper.m_PlayerKeyboard_BuildMenu;
        public InputAction @JourneyMenu => m_Wrapper.m_PlayerKeyboard_JourneyMenu;
        public InputAction @MapMenu => m_Wrapper.m_PlayerKeyboard_MapMenu;
        public InputAction @FacultiesMenu => m_Wrapper.m_PlayerKeyboard_FacultiesMenu;
        public InputActionMap Get() { return m_Wrapper.m_PlayerKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerKeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerKeyboardActions instance)
        {
            if (m_Wrapper.m_PlayerKeyboardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMovement;
                @Run.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnRun;
                @Walk.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnWalk;
                @Jump.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnJump;
                @ActionA.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnActionA;
                @ActionA.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnActionA;
                @ActionA.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnActionA;
                @ActionB.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnActionB;
                @ActionB.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnActionB;
                @ActionB.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnActionB;
                @MouseDelta.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMouseDelta;
                @MousePosition.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMousePosition;
                @BuildingPlacement.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnBuildingPlacement;
                @BuildingPlacement.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnBuildingPlacement;
                @BuildingPlacement.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnBuildingPlacement;
                @EquipmentMenu.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnEquipmentMenu;
                @EquipmentMenu.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnEquipmentMenu;
                @EquipmentMenu.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnEquipmentMenu;
                @CharacterMenu.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnCharacterMenu;
                @CharacterMenu.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnCharacterMenu;
                @CharacterMenu.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnCharacterMenu;
                @BuildMenu.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnBuildMenu;
                @BuildMenu.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnBuildMenu;
                @BuildMenu.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnBuildMenu;
                @JourneyMenu.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnJourneyMenu;
                @JourneyMenu.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnJourneyMenu;
                @JourneyMenu.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnJourneyMenu;
                @MapMenu.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMapMenu;
                @MapMenu.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMapMenu;
                @MapMenu.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMapMenu;
                @FacultiesMenu.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnFacultiesMenu;
                @FacultiesMenu.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnFacultiesMenu;
                @FacultiesMenu.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnFacultiesMenu;
            }
            m_Wrapper.m_PlayerKeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ActionA.started += instance.OnActionA;
                @ActionA.performed += instance.OnActionA;
                @ActionA.canceled += instance.OnActionA;
                @ActionB.started += instance.OnActionB;
                @ActionB.performed += instance.OnActionB;
                @ActionB.canceled += instance.OnActionB;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @BuildingPlacement.started += instance.OnBuildingPlacement;
                @BuildingPlacement.performed += instance.OnBuildingPlacement;
                @BuildingPlacement.canceled += instance.OnBuildingPlacement;
                @EquipmentMenu.started += instance.OnEquipmentMenu;
                @EquipmentMenu.performed += instance.OnEquipmentMenu;
                @EquipmentMenu.canceled += instance.OnEquipmentMenu;
                @CharacterMenu.started += instance.OnCharacterMenu;
                @CharacterMenu.performed += instance.OnCharacterMenu;
                @CharacterMenu.canceled += instance.OnCharacterMenu;
                @BuildMenu.started += instance.OnBuildMenu;
                @BuildMenu.performed += instance.OnBuildMenu;
                @BuildMenu.canceled += instance.OnBuildMenu;
                @JourneyMenu.started += instance.OnJourneyMenu;
                @JourneyMenu.performed += instance.OnJourneyMenu;
                @JourneyMenu.canceled += instance.OnJourneyMenu;
                @MapMenu.started += instance.OnMapMenu;
                @MapMenu.performed += instance.OnMapMenu;
                @MapMenu.canceled += instance.OnMapMenu;
                @FacultiesMenu.started += instance.OnFacultiesMenu;
                @FacultiesMenu.performed += instance.OnFacultiesMenu;
                @FacultiesMenu.canceled += instance.OnFacultiesMenu;
            }
        }
    }
    public PlayerKeyboardActions @PlayerKeyboard => new PlayerKeyboardActions(this);
    public interface IPlayerKeyboardActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnActionA(InputAction.CallbackContext context);
        void OnActionB(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnBuildingPlacement(InputAction.CallbackContext context);
        void OnEquipmentMenu(InputAction.CallbackContext context);
        void OnCharacterMenu(InputAction.CallbackContext context);
        void OnBuildMenu(InputAction.CallbackContext context);
        void OnJourneyMenu(InputAction.CallbackContext context);
        void OnMapMenu(InputAction.CallbackContext context);
        void OnFacultiesMenu(InputAction.CallbackContext context);
    }
}
