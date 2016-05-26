using Rocket.Core.Permissions;
using Rocket.Core.Assets;
using Rocket.API.Serialisation;
using NUnit.Framework;
using System.IO;
using Rocket.API;
using System;
using System.Collections.Generic;

namespace Rocket.Core.Tests
{
    [TestFixture]
    public class RocketPermissionsHelperTest
    {
        RocketPermissionsHelper target = new RocketPermissionsHelper(new XMLFileAsset<RocketPermissions>(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Permissions.config.xml")));

        TestingPlayer p = new TestingPlayer();
        TestingPlayer p2 = new TestingPlayer("2");
        TestingPlayer p3 = new TestingPlayer("3",true);


        [Test]
        public void HasPermission()
        {
            Assert.IsTrue(target.HasPermission(p, "p"));
            Assert.IsFalse(target.HasPermission(p, "p.reload"));
            Assert.IsTrue(target.HasPermission(p, "kit"));
            Assert.IsTrue(target.HasPermission(p, "kit.test"));
            Assert.IsTrue(target.HasPermission(p, "kit.test2"));
            Assert.IsTrue(target.HasPermission(p, "kit.test2.test3"));

            Assert.IsTrue(target.HasPermission(p2, "p"));
            Assert.IsFalse(target.HasPermission(p2, "p.reload"));
            Assert.IsTrue(target.HasPermission(p2, "kit"));
            Assert.IsFalse(target.HasPermission(p2, "kit.test"));
            Assert.IsTrue(target.HasPermission(p2, "kit.test2"));

            Assert.IsTrue(target.HasPermission(p3, "p", p3.IsAdmin));
            Assert.IsTrue(target.HasPermission(p3, "p.reload", p3.IsAdmin));
            Assert.IsTrue(target.HasPermission(p3, "kit", p3.IsAdmin));
            Assert.IsTrue(target.HasPermission(p3, "kit.test", p3.IsAdmin));
            Assert.IsTrue(target.HasPermission(p3, "kit.test2", p3.IsAdmin));
            Assert.IsTrue(target.HasPermission(p3, "kit.test2.test3", p3.IsAdmin));
            Assert.IsTrue(target.HasPermission(p3, "dummy",p3.IsAdmin));
        }
    }
}
