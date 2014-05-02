using System;
using JPBetley.Foundry.Exceptions;
using JPBetley.Foundry.Test.BadTestStubs;
using JPBetley.Foundry.Test.GoodTestStubs;
using NUnit.Framework;

namespace JPBetley.Foundry.Test
{
    [TestFixture]
    public class FoundryTest
    {
        [Test]
        public void it_should_build_an_object_from_executing_test_assembly()
        {
            var result = Foundry.Cast<TestClass>();
            Assert.AreEqual("test", result.TestValue);
        }

        [Test]
        [ExpectedException(typeof(CastingMoldNotFoundException))]
        public void it_should_fail_if_it_does_not_find_a_casting_from_executing_test_assembly()
        {
            var result = Foundry.Cast<NonExistent>();
        }

        [Test]
        [ExpectedException(typeof(MultipleCastingMoldsDefinedException))]
        public void it_should_fail_if_it_finds_more_than_one_castring_from_executing_test_assembly()
        {
            var result = Foundry.Cast<Multiple>();
        }

        [Test]
        public void built_objects_should_be_overridable()
        {
            var result = Foundry.Cast<TestClass>(x =>
            {
                x.TestValue = "changed";
                x.Id = 100;
            });
            Assert.AreEqual("changed", result.TestValue);
            Assert.AreEqual(100, result.Id);
        }
    }
}
