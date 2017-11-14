using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using System;

namespace Test
{
    public class ETClientTest : MonoBehaviour
    {
        NetworkSession gateSession;

        void Awake()
        {
            NetworkClient.Instance.Initialize(NetworkProtocol.TCP);
            NetworkOpcodeType.Instance.Initialize();
        }

        async void Start()
        {
            NetworkSession session = null;
            try
            {
                session = NetworkClient.Instance.Create("127.0.0.1:10002");

                R2C_Login r2CLogin = await session.Call<R2C_Login>(new C2R_Login() { Account = "Test1", Password = "111111" });
                gateSession = NetworkClient.Instance.Create(r2CLogin.Address);

                G2C_LoginGate g2CLoginGate = await gateSession.Call<G2C_LoginGate>(new C2G_LoginGate() { Key = r2CLogin.Key });
                Log.Info("登陆gate成功!");
                Log.Info(g2CLoginGate.PlayerId.ToString());
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            finally
            {
                session?.Dispose();
            }
        }

        void Update()
        {

        }
    }
}
