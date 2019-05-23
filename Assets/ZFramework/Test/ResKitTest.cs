using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine;

namespace ZFramework.Tests
{
    public class ResKitTest {

        [Test]
        public void LoadAsyncExceptionTest() {
            // Use the Assert class to test conditions.
            var resLoader = new ResLoader();

            Assert.Throws<System.Exception>(() =>
            {
                resLoader.LoadAsync<Texture2D>("square", "Square",squareTexture =>
                {
                    //Debug.Log(1);
                });

                resLoader.LoadSync<Texture2D>("square","Square");
                Debug.Log(2);
            });

            resLoader.ReleaseAll();
            resLoader = null;
        }

        [UnityTest]
        public IEnumerator LoadAsyncRefCountTest()
        {
            var resLoader = new ResLoader();

            var resLoader1 = new ResLoader();

            int loadedCount = 0;

            resLoader.LoadAsync<Texture2D>("resources://BigTexture", _=> { loadedCount++; });

            resLoader.LoadAsync<Texture2D>("resources://BigTexture", _=> { loadedCount++; });

            yield return new WaitUntil(() => loadedCount == 2);

            Assert.AreEqual(ResMgr.Instance.SharedLoadedReses.Find(res => res.Name == "resources://BigTexture").RefCount, 1);

            resLoader1.LoadAsync<Texture2D>("resources://BigTexture", _ => { loadedCount++; });

            yield return new WaitUntil(() => loadedCount == 3);

            Assert.AreEqual(ResMgr.Instance.SharedLoadedReses.Find(res => res.Name == "resources://BigTexture").RefCount, 2);
        }

        [UnityTest]
        public IEnumerator LoadSyncTest()
        {
            var resLoader = new ResLoader();

            var square = resLoader.LoadSync<Texture2D>("square", "Square");

            Assert.IsNotNull(square);

            resLoader.ReleaseAll();
            resLoader = null;

            yield return null;
        }

        [UnityTest]
        public IEnumerator LoadAsyncTest()
        {
            var resLoader = new ResLoader();

            resLoader.LoadAsync<Texture2D>("square", "Square", squareTexture =>
            {
                Assert.IsNotNull(squareTexture);

                resLoader.ReleaseAll();
                resLoader = null;
            });

            yield return null;
        }
    }
}