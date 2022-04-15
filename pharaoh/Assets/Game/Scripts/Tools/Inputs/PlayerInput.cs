//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Game/Scripts/Tools/Inputs/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Pharaoh.Tools.Inputs
{
    public partial class @PlayerInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""a916d374-db9b-439c-ad0e-dfd4359d595f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b7e37a11-4c67-4d95-9172-d6d0c6d2b1f5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0cbbf7fb-af1a-4c35-b0de-eba49830e318"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""b1e5cd8a-cf74-4245-a2e9-41d00c81b593"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NOCLIP"",
                    ""type"": ""Button"",
                    ""id"": ""e9fd0602-871e-43a3-83bf-44ea53b65059"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""1751c3d3-98c2-4751-a78f-f6247e1e969a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""faed6114-f770-4817-a1f2-a19239852ba3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c81c223c-a0ed-4774-97c5-333b5d087b12"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9d353579-1780-4217-b2ff-e76df687ee25"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3a439050-324f-4e15-a688-5d0e5d1980a5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b2d86cc8-5bb9-41fb-bfe6-52eeb50b5288"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c9fffeda-baf3-4793-8564-255cec8c684a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6c4757d5-eaac-4440-b53b-889b54a9a9ef"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f4565d5b-8f35-413f-9d54-a80a907079ab"",
                    ""path"": ""<Keyboard>/pageUp"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""62139ec4-b188-4bfb-9bdf-ff9bffa70793"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fcb9c1dc-053f-4977-b50d-344111eb60ef"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fb7ca47c-1c5e-4ff6-9072-a63c40e28a14"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""168a6d32-8d03-40dc-b999-bc4b40e3a63d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9f8bb53-e6a6-4413-996c-ff6f9d5fb13b"",
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
                    ""id"": ""8dea0d6a-cdeb-49f6-8d6d-8e8f5c636c12"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""278585b4-d251-4e2a-8d46-4a18bdfa9c93"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1ff6c09-7cf8-41eb-9dcc-65e3468c6b0e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f100b5b-bd23-4a2c-90bd-33a5fcf47d68"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NOCLIP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2f7e8f1-7ce5-4708-87ea-a7b182509a32"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NOCLIP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d123266-1cda-464d-b03f-6bcc479b4917"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a3f5b18-f43e-450d-a2d9-169b3007baee"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b268efc5-4037-46a4-801d-6544f8443ca9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dffcfd9f-0c4e-4e81-8a8a-4fabd70088b2"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""028abe2d-6f63-4e61-ba5a-09553198cf80"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""68200e54-8227-437c-8405-741472585cbf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""74330f14-59dc-4a38-bc8f-864ac392d943"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7615c81b-4555-43fc-bb92-897c20f2b0d3"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""CharacterActions"",
            ""id"": ""74dc7952-b854-4390-8fb2-c53642c0cb1f"",
            ""actions"": [
                {
                    ""name"": ""HookGrapple"",
                    ""type"": ""Button"",
                    ""id"": ""afba71f3-c9d2-413c-9b27-8049c44df9db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HookInteract"",
                    ""type"": ""Button"",
                    ""id"": ""5218d48e-7b1e-4f98-b056-8bf6d0915258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SandSoldier"",
                    ""type"": ""Button"",
                    ""id"": ""28626c90-eaeb-4419-ac3b-583c059df9b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""KillAllSoldiers"",
                    ""type"": ""Button"",
                    ""id"": ""00481974-5ce6-465d-83ea-231d148fbdaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65dac8c7-57c6-4d01-b9a2-af2fef8fb8ef"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HookGrapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9819100-9fcb-4748-9ea6-243d3e154666"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HookGrapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd9af54a-a94a-43e3-962e-b9574a313adf"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SandSoldier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77ee1f47-04fb-4eac-a2c3-e3a40c47e582"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SandSoldier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03ef170a-fe2a-4457-a684-09ead8b0bcf2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HookInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40942f6f-10e4-4edc-9eaa-575b53a09778"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HookInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d792acd-9e55-4fd0-adc1-b577925a9de0"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KillAllSoldiers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""b011d4cf-083d-41e0-abaa-358ab95f315a"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""c0e25642-3855-407b-a214-0f34a95cc1af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e620ead4-08fd-4ef7-aa59-f19aa23ce36a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b52e63b4-d247-4cdb-877e-6946757d3d3b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CharacterControls
            m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
            m_CharacterControls_Move = m_CharacterControls.FindAction("Move", throwIfNotFound: true);
            m_CharacterControls_Jump = m_CharacterControls.FindAction("Jump", throwIfNotFound: true);
            m_CharacterControls_Dash = m_CharacterControls.FindAction("Dash", throwIfNotFound: true);
            m_CharacterControls_NOCLIP = m_CharacterControls.FindAction("NOCLIP", throwIfNotFound: true);
            m_CharacterControls_Attack = m_CharacterControls.FindAction("Attack", throwIfNotFound: true);
            m_CharacterControls_Look = m_CharacterControls.FindAction("Look", throwIfNotFound: true);
            // CharacterActions
            m_CharacterActions = asset.FindActionMap("CharacterActions", throwIfNotFound: true);
            m_CharacterActions_HookGrapple = m_CharacterActions.FindAction("HookGrapple", throwIfNotFound: true);
            m_CharacterActions_HookInteract = m_CharacterActions.FindAction("HookInteract", throwIfNotFound: true);
            m_CharacterActions_SandSoldier = m_CharacterActions.FindAction("SandSoldier", throwIfNotFound: true);
            m_CharacterActions_KillAllSoldiers = m_CharacterActions.FindAction("KillAllSoldiers", throwIfNotFound: true);
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_Exit = m_Game.FindAction("Exit", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // CharacterControls
        private readonly InputActionMap m_CharacterControls;
        private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
        private readonly InputAction m_CharacterControls_Move;
        private readonly InputAction m_CharacterControls_Jump;
        private readonly InputAction m_CharacterControls_Dash;
        private readonly InputAction m_CharacterControls_NOCLIP;
        private readonly InputAction m_CharacterControls_Attack;
        private readonly InputAction m_CharacterControls_Look;
        public struct CharacterControlsActions
        {
            private @PlayerInput m_Wrapper;
            public CharacterControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_CharacterControls_Move;
            public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
            public InputAction @Dash => m_Wrapper.m_CharacterControls_Dash;
            public InputAction @NOCLIP => m_Wrapper.m_CharacterControls_NOCLIP;
            public InputAction @Attack => m_Wrapper.m_CharacterControls_Attack;
            public InputAction @Look => m_Wrapper.m_CharacterControls_Look;
            public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterControlsActions instance)
            {
                if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                    @Dash.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDash;
                    @NOCLIP.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnNOCLIP;
                    @NOCLIP.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnNOCLIP;
                    @NOCLIP.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnNOCLIP;
                    @Attack.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAttack;
                    @Look.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnLook;
                }
                m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @NOCLIP.started += instance.OnNOCLIP;
                    @NOCLIP.performed += instance.OnNOCLIP;
                    @NOCLIP.canceled += instance.OnNOCLIP;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                }
            }
        }
        public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

        // CharacterActions
        private readonly InputActionMap m_CharacterActions;
        private ICharacterActionsActions m_CharacterActionsActionsCallbackInterface;
        private readonly InputAction m_CharacterActions_HookGrapple;
        private readonly InputAction m_CharacterActions_HookInteract;
        private readonly InputAction m_CharacterActions_SandSoldier;
        private readonly InputAction m_CharacterActions_KillAllSoldiers;
        public struct CharacterActionsActions
        {
            private @PlayerInput m_Wrapper;
            public CharacterActionsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @HookGrapple => m_Wrapper.m_CharacterActions_HookGrapple;
            public InputAction @HookInteract => m_Wrapper.m_CharacterActions_HookInteract;
            public InputAction @SandSoldier => m_Wrapper.m_CharacterActions_SandSoldier;
            public InputAction @KillAllSoldiers => m_Wrapper.m_CharacterActions_KillAllSoldiers;
            public InputActionMap Get() { return m_Wrapper.m_CharacterActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActionsActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActionsActions instance)
            {
                if (m_Wrapper.m_CharacterActionsActionsCallbackInterface != null)
                {
                    @HookGrapple.started -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookGrapple;
                    @HookGrapple.performed -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookGrapple;
                    @HookGrapple.canceled -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookGrapple;
                    @HookInteract.started -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookInteract;
                    @HookInteract.performed -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookInteract;
                    @HookInteract.canceled -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookInteract;
                    @SandSoldier.started -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnSandSoldier;
                    @SandSoldier.performed -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnSandSoldier;
                    @SandSoldier.canceled -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnSandSoldier;
                    @KillAllSoldiers.started -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnKillAllSoldiers;
                    @KillAllSoldiers.performed -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnKillAllSoldiers;
                    @KillAllSoldiers.canceled -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnKillAllSoldiers;
                }
                m_Wrapper.m_CharacterActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @HookGrapple.started += instance.OnHookGrapple;
                    @HookGrapple.performed += instance.OnHookGrapple;
                    @HookGrapple.canceled += instance.OnHookGrapple;
                    @HookInteract.started += instance.OnHookInteract;
                    @HookInteract.performed += instance.OnHookInteract;
                    @HookInteract.canceled += instance.OnHookInteract;
                    @SandSoldier.started += instance.OnSandSoldier;
                    @SandSoldier.performed += instance.OnSandSoldier;
                    @SandSoldier.canceled += instance.OnSandSoldier;
                    @KillAllSoldiers.started += instance.OnKillAllSoldiers;
                    @KillAllSoldiers.performed += instance.OnKillAllSoldiers;
                    @KillAllSoldiers.canceled += instance.OnKillAllSoldiers;
                }
            }
        }
        public CharacterActionsActions @CharacterActions => new CharacterActionsActions(this);

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_Exit;
        public struct GameActions
        {
            private @PlayerInput m_Wrapper;
            public GameActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Exit => m_Wrapper.m_Game_Exit;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @Exit.started -= m_Wrapper.m_GameActionsCallbackInterface.OnExit;
                    @Exit.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnExit;
                    @Exit.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnExit;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Exit.started += instance.OnExit;
                    @Exit.performed += instance.OnExit;
                    @Exit.canceled += instance.OnExit;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface ICharacterControlsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnNOCLIP(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
        }
        public interface ICharacterActionsActions
        {
            void OnHookGrapple(InputAction.CallbackContext context);
            void OnHookInteract(InputAction.CallbackContext context);
            void OnSandSoldier(InputAction.CallbackContext context);
            void OnKillAllSoldiers(InputAction.CallbackContext context);
        }
        public interface IGameActions
        {
            void OnExit(InputAction.CallbackContext context);
        }
    }
}
