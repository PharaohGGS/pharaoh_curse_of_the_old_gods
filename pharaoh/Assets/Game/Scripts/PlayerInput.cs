//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Game/Scripts/PlayerInput.inputactions
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
                    ""path"": ""<Gamepad>/leftTrigger"",
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
                }
            ]
        },
        {
            ""name"": ""CharacterActions"",
            ""id"": ""74dc7952-b854-4390-8fb2-c53642c0cb1f"",
            ""actions"": [
                {
                    ""name"": ""Hook"",
                    ""type"": ""Button"",
                    ""id"": ""afba71f3-c9d2-413c-9b27-8049c44df9db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""ddebdad3-dc6a-4c3d-9b5d-e7417e1a4674"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HookBlock"",
                    ""type"": ""Button"",
                    ""id"": ""8dc955b4-4410-4da3-99cb-57f1265aca8e"",
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
                    ""action"": ""Hook"",
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
                    ""action"": ""Hook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6878981f-0bd3-4991-a24a-ff7db503a821"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b22a37f-88b5-4b0e-a7b5-7f83c3d794b4"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4dbe063f-81ce-4467-bd4c-88d25fc65e77"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HookBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9b8305c-bd1b-4415-a955-f13442e865a5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HookBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""3e574198-9923-4318-87b2-ff826ec950f3"",
            ""actions"": [
                {
                    ""name"": ""MainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""d65968b9-34e6-4d3c-912e-5b785e3492ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7be2df0-c006-4195-b897-f9fc3ab394d5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d600b21c-02f2-4535-8f2d-93a0de2c5ad7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainMenu"",
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
        // CharacterActions
        m_CharacterActions = asset.FindActionMap("CharacterActions", throwIfNotFound: true);
        m_CharacterActions_Hook = m_CharacterActions.FindAction("Hook", throwIfNotFound: true);
        m_CharacterActions_Grab = m_CharacterActions.FindAction("Grab", throwIfNotFound: true);
        m_CharacterActions_HookBlock = m_CharacterActions.FindAction("HookBlock", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_MainMenu = m_Game.FindAction("MainMenu", throwIfNotFound: true);
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
    public struct CharacterControlsActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControls_Move;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @Dash => m_Wrapper.m_CharacterControls_Dash;
        public InputAction @NOCLIP => m_Wrapper.m_CharacterControls_NOCLIP;
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
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

    // CharacterActions
    private readonly InputActionMap m_CharacterActions;
    private ICharacterActionsActions m_CharacterActionsActionsCallbackInterface;
    private readonly InputAction m_CharacterActions_Hook;
    private readonly InputAction m_CharacterActions_Grab;
    private readonly InputAction m_CharacterActions_HookBlock;
    public struct CharacterActionsActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterActionsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Hook => m_Wrapper.m_CharacterActions_Hook;
        public InputAction @Grab => m_Wrapper.m_CharacterActions_Grab;
        public InputAction @HookBlock => m_Wrapper.m_CharacterActions_HookBlock;
        public InputActionMap Get() { return m_Wrapper.m_CharacterActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActionsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActionsActions instance)
        {
            if (m_Wrapper.m_CharacterActionsActionsCallbackInterface != null)
            {
                @Hook.started -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHook;
                @Hook.performed -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHook;
                @Hook.canceled -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHook;
                @Grab.started -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnGrab;
                @HookBlock.started -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookBlock;
                @HookBlock.performed -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookBlock;
                @HookBlock.canceled -= m_Wrapper.m_CharacterActionsActionsCallbackInterface.OnHookBlock;
            }
            m_Wrapper.m_CharacterActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Hook.started += instance.OnHook;
                @Hook.performed += instance.OnHook;
                @Hook.canceled += instance.OnHook;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @HookBlock.started += instance.OnHookBlock;
                @HookBlock.performed += instance.OnHookBlock;
                @HookBlock.canceled += instance.OnHookBlock;
            }
        }
    }
    public CharacterActionsActions @CharacterActions => new CharacterActionsActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_MainMenu;
    public struct GameActions
    {
        private @PlayerInput m_Wrapper;
        public GameActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainMenu => m_Wrapper.m_Game_MainMenu;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @MainMenu.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @MainMenu.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
                @MainMenu.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMainMenu;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MainMenu.started += instance.OnMainMenu;
                @MainMenu.performed += instance.OnMainMenu;
                @MainMenu.canceled += instance.OnMainMenu;
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
    }
    public interface ICharacterActionsActions
    {
        void OnHook(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnHookBlock(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnMainMenu(InputAction.CallbackContext context);
    }
}
