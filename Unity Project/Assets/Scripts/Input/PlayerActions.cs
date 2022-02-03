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
            ""name"": ""PlayerCharacterMovement"",
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
                    ""path"": ""<Keyboard>/alt"",
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
                }
            ]
        },
        {
            ""name"": ""PlayerMenus"",
            ""id"": ""c123fcbd-ad3c-4d62-963b-6d99824cd6bf"",
            ""actions"": [
                {
                    ""name"": ""FacultiesMenu"",
                    ""type"": ""Button"",
                    ""id"": ""d6cf9d83-2e9a-4f5b-8f59-4971d06c51f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MapMenu"",
                    ""type"": ""Button"",
                    ""id"": ""fd375436-96a9-4dfe-b30b-a229ef5bc802"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JourneyMenu"",
                    ""type"": ""Button"",
                    ""id"": ""1266183a-e0f0-4125-8f79-c79389486bd4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BuildMenu"",
                    ""type"": ""Button"",
                    ""id"": ""6d86a1fc-c234-4b11-874e-069e30ce11a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CharacterMenu"",
                    ""type"": ""Button"",
                    ""id"": ""8a7750c9-cd5f-4173-9b51-335c21368ebd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EquipmentMenu"",
                    ""type"": ""Button"",
                    ""id"": ""6df29046-b516-418e-87ea-6ea4daafa300"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""72c5d177-27a2-4220-b05a-74611a105acb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e4a969ed-08e5-4e0d-85aa-435ae02b6d6f"",
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
                    ""id"": ""046cb291-453e-41c1-8d06-73967c3fb5c0"",
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
                    ""id"": ""f21544f2-2f0b-479b-956f-431a3b3a5888"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BuildMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5eb7fecd-c063-405d-8f49-df8cd5ddc055"",
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
                    ""id"": ""4359b362-377c-4c67-b5c3-a7057e2d55ed"",
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
                    ""id"": ""7f3cf129-6e78-4191-8045-bb61ea475cd7"",
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
                    ""id"": ""273a0c91-9390-4307-bc3f-90b29ebd221d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerBuilding"",
            ""id"": ""b749afd2-40a6-4412-9e6a-2d393d659937"",
            ""actions"": [
                {
                    ""name"": ""VerticalRotation"",
                    ""type"": ""Button"",
                    ""id"": ""f52694d6-3a31-4a72-8ae3-e285a4207bde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HorizontalRotation"",
                    ""type"": ""Button"",
                    ""id"": ""42974bb1-f4da-4ff7-a834-b606f1a05629"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""5cfa411c-5496-4ef1-9787-938b92404ff0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""c7bc5fb5-1d54-4bb2-828c-20e2ad8c3c16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a80b8936-c42d-42ff-ad0d-2a233f812651"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""262be9ab-b4dd-4178-aaf5-b011106db9fb"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06aae37e-6a0b-4f28-9e9c-aa68b82c0cec"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b21ffede-36a5-4b80-a86f-9961779cafa2"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f69cfd9-b766-49cd-a228-d1dcec36b4e6"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65334884-8720-4ef0-80b0-bdde4d377511"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""869ff873-a096-410c-9b8f-3db1f83990c1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerCharacterCombat"",
            ""id"": ""9b021f48-dc27-4227-8c70-f1719ecaabbe"",
            ""actions"": [
                {
                    ""name"": ""AttackA"",
                    ""type"": ""Button"",
                    ""id"": ""96ec7881-ba61-4c9d-b8ad-9647f36c8d20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackB"",
                    ""type"": ""Button"",
                    ""id"": ""68a664b4-4b64-4e25-a363-db2fe41b0409"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""9303e959-bb97-4e49-ae53-dfae53234f7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1bd43e9-6aee-49be-b10b-b2102adb04b2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b53e26f7-0cc6-40d9-baf4-ba4cdf4e80db"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94b3a73a-dd51-4f71-bcf7-f4573afae4c6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerCharacterAction"",
            ""id"": ""c863dcc8-d259-4f1e-9150-8c842415ad1a"",
            ""actions"": [
                {
                    ""name"": ""ActionA"",
                    ""type"": ""Button"",
                    ""id"": ""e91cd2b4-3876-46e6-a4d8-a799206c3310"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionB"",
                    ""type"": ""Button"",
                    ""id"": ""2a69c00b-ac13-4d8f-a449-5d1a52ca69f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionC"",
                    ""type"": ""Button"",
                    ""id"": ""cecef904-b380-4bb1-be09-4f2615121a9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionD"",
                    ""type"": ""Button"",
                    ""id"": ""cf412005-6441-43da-adbb-93abed98e43c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""f611b35d-c06a-4586-a220-b3464c8ba745"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropLeftItem"",
                    ""type"": ""Button"",
                    ""id"": ""6764478b-14ad-4e8b-a8db-1632ab966891"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropRightItem"",
                    ""type"": ""Button"",
                    ""id"": ""a1e2b58d-baac-4588-bb54-24935974b752"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Take"",
                    ""type"": ""Button"",
                    ""id"": ""5497d63e-2181-4239-98ce-00962c57b383"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54be63e1-2297-41fb-8c77-43aa67c6dd5b"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""80df146d-8fc9-44cc-9cca-1c576b22927f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropLeftItem"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0d07ea92-267e-4b88-bd35-88deb747e38a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropLeftItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e0afb05e-9de1-4a1b-a931-6964eb017f1b"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropLeftItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""e0d9fd50-9df2-4615-abc1-d0ff80921769"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropRightItem"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""18991c67-b0f6-44d1-8dca-c38ebbca3044"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropRightItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""bdafe7a9-e14e-47af-beee-62fcfb961fe1"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropRightItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""952b208b-2683-445c-b054-5b68d1b2db41"",
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
                    ""id"": ""7f18016b-3eca-4aad-9ffa-fd835ddf1106"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18d8bc24-56a4-4f42-8154-c1bc296ccafd"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c9d0920d-4d9c-4753-9562-5130aa445c2a"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""f3d6dd0b-8be6-41b8-9fd5-f4329cab07b7"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""756d74cd-8fbe-476f-a3f3-af59e4709421"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f960ca5f-de63-4554-869f-5407b8f9e572"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Take"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerCharacterMovement
        m_PlayerCharacterMovement = asset.FindActionMap("PlayerCharacterMovement", throwIfNotFound: true);
        m_PlayerCharacterMovement_Movement = m_PlayerCharacterMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerCharacterMovement_Run = m_PlayerCharacterMovement.FindAction("Run", throwIfNotFound: true);
        m_PlayerCharacterMovement_Walk = m_PlayerCharacterMovement.FindAction("Walk", throwIfNotFound: true);
        m_PlayerCharacterMovement_Jump = m_PlayerCharacterMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerCharacterMovement_MouseDelta = m_PlayerCharacterMovement.FindAction("MouseDelta", throwIfNotFound: true);
        m_PlayerCharacterMovement_MousePosition = m_PlayerCharacterMovement.FindAction("MousePosition", throwIfNotFound: true);
        // PlayerMenus
        m_PlayerMenus = asset.FindActionMap("PlayerMenus", throwIfNotFound: true);
        m_PlayerMenus_FacultiesMenu = m_PlayerMenus.FindAction("FacultiesMenu", throwIfNotFound: true);
        m_PlayerMenus_MapMenu = m_PlayerMenus.FindAction("MapMenu", throwIfNotFound: true);
        m_PlayerMenus_JourneyMenu = m_PlayerMenus.FindAction("JourneyMenu", throwIfNotFound: true);
        m_PlayerMenus_BuildMenu = m_PlayerMenus.FindAction("BuildMenu", throwIfNotFound: true);
        m_PlayerMenus_CharacterMenu = m_PlayerMenus.FindAction("CharacterMenu", throwIfNotFound: true);
        m_PlayerMenus_EquipmentMenu = m_PlayerMenus.FindAction("EquipmentMenu", throwIfNotFound: true);
        m_PlayerMenus_Cancel = m_PlayerMenus.FindAction("Cancel", throwIfNotFound: true);
        // PlayerBuilding
        m_PlayerBuilding = asset.FindActionMap("PlayerBuilding", throwIfNotFound: true);
        m_PlayerBuilding_VerticalRotation = m_PlayerBuilding.FindAction("VerticalRotation", throwIfNotFound: true);
        m_PlayerBuilding_HorizontalRotation = m_PlayerBuilding.FindAction("HorizontalRotation", throwIfNotFound: true);
        m_PlayerBuilding_Cancel = m_PlayerBuilding.FindAction("Cancel", throwIfNotFound: true);
        m_PlayerBuilding_LeftClick = m_PlayerBuilding.FindAction("LeftClick", throwIfNotFound: true);
        // PlayerCharacterCombat
        m_PlayerCharacterCombat = asset.FindActionMap("PlayerCharacterCombat", throwIfNotFound: true);
        m_PlayerCharacterCombat_AttackA = m_PlayerCharacterCombat.FindAction("AttackA", throwIfNotFound: true);
        m_PlayerCharacterCombat_AttackB = m_PlayerCharacterCombat.FindAction("AttackB", throwIfNotFound: true);
        m_PlayerCharacterCombat_Aim = m_PlayerCharacterCombat.FindAction("Aim", throwIfNotFound: true);
        // PlayerCharacterAction
        m_PlayerCharacterAction = asset.FindActionMap("PlayerCharacterAction", throwIfNotFound: true);
        m_PlayerCharacterAction_ActionA = m_PlayerCharacterAction.FindAction("ActionA", throwIfNotFound: true);
        m_PlayerCharacterAction_ActionB = m_PlayerCharacterAction.FindAction("ActionB", throwIfNotFound: true);
        m_PlayerCharacterAction_ActionC = m_PlayerCharacterAction.FindAction("ActionC", throwIfNotFound: true);
        m_PlayerCharacterAction_ActionD = m_PlayerCharacterAction.FindAction("ActionD", throwIfNotFound: true);
        m_PlayerCharacterAction_Grab = m_PlayerCharacterAction.FindAction("Grab", throwIfNotFound: true);
        m_PlayerCharacterAction_DropLeftItem = m_PlayerCharacterAction.FindAction("DropLeftItem", throwIfNotFound: true);
        m_PlayerCharacterAction_DropRightItem = m_PlayerCharacterAction.FindAction("DropRightItem", throwIfNotFound: true);
        m_PlayerCharacterAction_Take = m_PlayerCharacterAction.FindAction("Take", throwIfNotFound: true);
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

    // PlayerCharacterMovement
    private readonly InputActionMap m_PlayerCharacterMovement;
    private IPlayerCharacterMovementActions m_PlayerCharacterMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerCharacterMovement_Movement;
    private readonly InputAction m_PlayerCharacterMovement_Run;
    private readonly InputAction m_PlayerCharacterMovement_Walk;
    private readonly InputAction m_PlayerCharacterMovement_Jump;
    private readonly InputAction m_PlayerCharacterMovement_MouseDelta;
    private readonly InputAction m_PlayerCharacterMovement_MousePosition;
    public struct PlayerCharacterMovementActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerCharacterMovementActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerCharacterMovement_Movement;
        public InputAction @Run => m_Wrapper.m_PlayerCharacterMovement_Run;
        public InputAction @Walk => m_Wrapper.m_PlayerCharacterMovement_Walk;
        public InputAction @Jump => m_Wrapper.m_PlayerCharacterMovement_Jump;
        public InputAction @MouseDelta => m_Wrapper.m_PlayerCharacterMovement_MouseDelta;
        public InputAction @MousePosition => m_Wrapper.m_PlayerCharacterMovement_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCharacterMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCharacterMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerCharacterMovementActions instance)
        {
            if (m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMovement;
                @Run.started -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnRun;
                @Walk.started -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnWalk;
                @Jump.started -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnJump;
                @MouseDelta.started -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMouseDelta;
                @MousePosition.started -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_PlayerCharacterMovementActionsCallbackInterface = instance;
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
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public PlayerCharacterMovementActions @PlayerCharacterMovement => new PlayerCharacterMovementActions(this);

    // PlayerMenus
    private readonly InputActionMap m_PlayerMenus;
    private IPlayerMenusActions m_PlayerMenusActionsCallbackInterface;
    private readonly InputAction m_PlayerMenus_FacultiesMenu;
    private readonly InputAction m_PlayerMenus_MapMenu;
    private readonly InputAction m_PlayerMenus_JourneyMenu;
    private readonly InputAction m_PlayerMenus_BuildMenu;
    private readonly InputAction m_PlayerMenus_CharacterMenu;
    private readonly InputAction m_PlayerMenus_EquipmentMenu;
    private readonly InputAction m_PlayerMenus_Cancel;
    public struct PlayerMenusActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerMenusActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @FacultiesMenu => m_Wrapper.m_PlayerMenus_FacultiesMenu;
        public InputAction @MapMenu => m_Wrapper.m_PlayerMenus_MapMenu;
        public InputAction @JourneyMenu => m_Wrapper.m_PlayerMenus_JourneyMenu;
        public InputAction @BuildMenu => m_Wrapper.m_PlayerMenus_BuildMenu;
        public InputAction @CharacterMenu => m_Wrapper.m_PlayerMenus_CharacterMenu;
        public InputAction @EquipmentMenu => m_Wrapper.m_PlayerMenus_EquipmentMenu;
        public InputAction @Cancel => m_Wrapper.m_PlayerMenus_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMenus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMenusActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMenusActions instance)
        {
            if (m_Wrapper.m_PlayerMenusActionsCallbackInterface != null)
            {
                @FacultiesMenu.started -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnFacultiesMenu;
                @FacultiesMenu.performed -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnFacultiesMenu;
                @FacultiesMenu.canceled -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnFacultiesMenu;
                @MapMenu.started -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnMapMenu;
                @MapMenu.performed -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnMapMenu;
                @MapMenu.canceled -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnMapMenu;
                @JourneyMenu.started -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnJourneyMenu;
                @JourneyMenu.performed -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnJourneyMenu;
                @JourneyMenu.canceled -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnJourneyMenu;
                @BuildMenu.started -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnBuildMenu;
                @BuildMenu.performed -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnBuildMenu;
                @BuildMenu.canceled -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnBuildMenu;
                @CharacterMenu.started -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnCharacterMenu;
                @CharacterMenu.performed -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnCharacterMenu;
                @CharacterMenu.canceled -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnCharacterMenu;
                @EquipmentMenu.started -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnEquipmentMenu;
                @EquipmentMenu.performed -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnEquipmentMenu;
                @EquipmentMenu.canceled -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnEquipmentMenu;
                @Cancel.started -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerMenusActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_PlayerMenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FacultiesMenu.started += instance.OnFacultiesMenu;
                @FacultiesMenu.performed += instance.OnFacultiesMenu;
                @FacultiesMenu.canceled += instance.OnFacultiesMenu;
                @MapMenu.started += instance.OnMapMenu;
                @MapMenu.performed += instance.OnMapMenu;
                @MapMenu.canceled += instance.OnMapMenu;
                @JourneyMenu.started += instance.OnJourneyMenu;
                @JourneyMenu.performed += instance.OnJourneyMenu;
                @JourneyMenu.canceled += instance.OnJourneyMenu;
                @BuildMenu.started += instance.OnBuildMenu;
                @BuildMenu.performed += instance.OnBuildMenu;
                @BuildMenu.canceled += instance.OnBuildMenu;
                @CharacterMenu.started += instance.OnCharacterMenu;
                @CharacterMenu.performed += instance.OnCharacterMenu;
                @CharacterMenu.canceled += instance.OnCharacterMenu;
                @EquipmentMenu.started += instance.OnEquipmentMenu;
                @EquipmentMenu.performed += instance.OnEquipmentMenu;
                @EquipmentMenu.canceled += instance.OnEquipmentMenu;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public PlayerMenusActions @PlayerMenus => new PlayerMenusActions(this);

    // PlayerBuilding
    private readonly InputActionMap m_PlayerBuilding;
    private IPlayerBuildingActions m_PlayerBuildingActionsCallbackInterface;
    private readonly InputAction m_PlayerBuilding_VerticalRotation;
    private readonly InputAction m_PlayerBuilding_HorizontalRotation;
    private readonly InputAction m_PlayerBuilding_Cancel;
    private readonly InputAction m_PlayerBuilding_LeftClick;
    public struct PlayerBuildingActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerBuildingActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @VerticalRotation => m_Wrapper.m_PlayerBuilding_VerticalRotation;
        public InputAction @HorizontalRotation => m_Wrapper.m_PlayerBuilding_HorizontalRotation;
        public InputAction @Cancel => m_Wrapper.m_PlayerBuilding_Cancel;
        public InputAction @LeftClick => m_Wrapper.m_PlayerBuilding_LeftClick;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBuilding; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBuildingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerBuildingActions instance)
        {
            if (m_Wrapper.m_PlayerBuildingActionsCallbackInterface != null)
            {
                @VerticalRotation.started -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnVerticalRotation;
                @VerticalRotation.performed -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnVerticalRotation;
                @VerticalRotation.canceled -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnVerticalRotation;
                @HorizontalRotation.started -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnHorizontalRotation;
                @HorizontalRotation.performed -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnHorizontalRotation;
                @HorizontalRotation.canceled -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnHorizontalRotation;
                @Cancel.started -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnCancel;
                @LeftClick.started -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_PlayerBuildingActionsCallbackInterface.OnLeftClick;
            }
            m_Wrapper.m_PlayerBuildingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @VerticalRotation.started += instance.OnVerticalRotation;
                @VerticalRotation.performed += instance.OnVerticalRotation;
                @VerticalRotation.canceled += instance.OnVerticalRotation;
                @HorizontalRotation.started += instance.OnHorizontalRotation;
                @HorizontalRotation.performed += instance.OnHorizontalRotation;
                @HorizontalRotation.canceled += instance.OnHorizontalRotation;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
            }
        }
    }
    public PlayerBuildingActions @PlayerBuilding => new PlayerBuildingActions(this);

    // PlayerCharacterCombat
    private readonly InputActionMap m_PlayerCharacterCombat;
    private IPlayerCharacterCombatActions m_PlayerCharacterCombatActionsCallbackInterface;
    private readonly InputAction m_PlayerCharacterCombat_AttackA;
    private readonly InputAction m_PlayerCharacterCombat_AttackB;
    private readonly InputAction m_PlayerCharacterCombat_Aim;
    public struct PlayerCharacterCombatActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerCharacterCombatActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackA => m_Wrapper.m_PlayerCharacterCombat_AttackA;
        public InputAction @AttackB => m_Wrapper.m_PlayerCharacterCombat_AttackB;
        public InputAction @Aim => m_Wrapper.m_PlayerCharacterCombat_Aim;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCharacterCombat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCharacterCombatActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerCharacterCombatActions instance)
        {
            if (m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface != null)
            {
                @AttackA.started -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAttackA;
                @AttackA.performed -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAttackA;
                @AttackA.canceled -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAttackA;
                @AttackB.started -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAttackB;
                @AttackB.performed -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAttackB;
                @AttackB.canceled -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAttackB;
                @Aim.started -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_PlayerCharacterCombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AttackA.started += instance.OnAttackA;
                @AttackA.performed += instance.OnAttackA;
                @AttackA.canceled += instance.OnAttackA;
                @AttackB.started += instance.OnAttackB;
                @AttackB.performed += instance.OnAttackB;
                @AttackB.canceled += instance.OnAttackB;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public PlayerCharacterCombatActions @PlayerCharacterCombat => new PlayerCharacterCombatActions(this);

    // PlayerCharacterAction
    private readonly InputActionMap m_PlayerCharacterAction;
    private IPlayerCharacterActionActions m_PlayerCharacterActionActionsCallbackInterface;
    private readonly InputAction m_PlayerCharacterAction_ActionA;
    private readonly InputAction m_PlayerCharacterAction_ActionB;
    private readonly InputAction m_PlayerCharacterAction_ActionC;
    private readonly InputAction m_PlayerCharacterAction_ActionD;
    private readonly InputAction m_PlayerCharacterAction_Grab;
    private readonly InputAction m_PlayerCharacterAction_DropLeftItem;
    private readonly InputAction m_PlayerCharacterAction_DropRightItem;
    private readonly InputAction m_PlayerCharacterAction_Take;
    public struct PlayerCharacterActionActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerCharacterActionActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ActionA => m_Wrapper.m_PlayerCharacterAction_ActionA;
        public InputAction @ActionB => m_Wrapper.m_PlayerCharacterAction_ActionB;
        public InputAction @ActionC => m_Wrapper.m_PlayerCharacterAction_ActionC;
        public InputAction @ActionD => m_Wrapper.m_PlayerCharacterAction_ActionD;
        public InputAction @Grab => m_Wrapper.m_PlayerCharacterAction_Grab;
        public InputAction @DropLeftItem => m_Wrapper.m_PlayerCharacterAction_DropLeftItem;
        public InputAction @DropRightItem => m_Wrapper.m_PlayerCharacterAction_DropRightItem;
        public InputAction @Take => m_Wrapper.m_PlayerCharacterAction_Take;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCharacterAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCharacterActionActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerCharacterActionActions instance)
        {
            if (m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface != null)
            {
                @ActionA.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionA;
                @ActionA.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionA;
                @ActionA.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionA;
                @ActionB.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionB;
                @ActionB.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionB;
                @ActionB.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionB;
                @ActionC.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionC;
                @ActionC.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionC;
                @ActionC.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionC;
                @ActionD.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionD;
                @ActionD.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionD;
                @ActionD.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnActionD;
                @Grab.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnGrab;
                @DropLeftItem.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnDropLeftItem;
                @DropLeftItem.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnDropLeftItem;
                @DropLeftItem.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnDropLeftItem;
                @DropRightItem.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnDropRightItem;
                @DropRightItem.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnDropRightItem;
                @DropRightItem.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnDropRightItem;
                @Take.started -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnTake;
                @Take.performed -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnTake;
                @Take.canceled -= m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface.OnTake;
            }
            m_Wrapper.m_PlayerCharacterActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ActionA.started += instance.OnActionA;
                @ActionA.performed += instance.OnActionA;
                @ActionA.canceled += instance.OnActionA;
                @ActionB.started += instance.OnActionB;
                @ActionB.performed += instance.OnActionB;
                @ActionB.canceled += instance.OnActionB;
                @ActionC.started += instance.OnActionC;
                @ActionC.performed += instance.OnActionC;
                @ActionC.canceled += instance.OnActionC;
                @ActionD.started += instance.OnActionD;
                @ActionD.performed += instance.OnActionD;
                @ActionD.canceled += instance.OnActionD;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @DropLeftItem.started += instance.OnDropLeftItem;
                @DropLeftItem.performed += instance.OnDropLeftItem;
                @DropLeftItem.canceled += instance.OnDropLeftItem;
                @DropRightItem.started += instance.OnDropRightItem;
                @DropRightItem.performed += instance.OnDropRightItem;
                @DropRightItem.canceled += instance.OnDropRightItem;
                @Take.started += instance.OnTake;
                @Take.performed += instance.OnTake;
                @Take.canceled += instance.OnTake;
            }
        }
    }
    public PlayerCharacterActionActions @PlayerCharacterAction => new PlayerCharacterActionActions(this);
    public interface IPlayerCharacterMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IPlayerMenusActions
    {
        void OnFacultiesMenu(InputAction.CallbackContext context);
        void OnMapMenu(InputAction.CallbackContext context);
        void OnJourneyMenu(InputAction.CallbackContext context);
        void OnBuildMenu(InputAction.CallbackContext context);
        void OnCharacterMenu(InputAction.CallbackContext context);
        void OnEquipmentMenu(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
    public interface IPlayerBuildingActions
    {
        void OnVerticalRotation(InputAction.CallbackContext context);
        void OnHorizontalRotation(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
    }
    public interface IPlayerCharacterCombatActions
    {
        void OnAttackA(InputAction.CallbackContext context);
        void OnAttackB(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IPlayerCharacterActionActions
    {
        void OnActionA(InputAction.CallbackContext context);
        void OnActionB(InputAction.CallbackContext context);
        void OnActionC(InputAction.CallbackContext context);
        void OnActionD(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnDropLeftItem(InputAction.CallbackContext context);
        void OnDropRightItem(InputAction.CallbackContext context);
        void OnTake(InputAction.CallbackContext context);
    }
}
