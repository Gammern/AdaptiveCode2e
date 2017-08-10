using MyAccounting.Model;
using System;
using System.Reflection;

namespace MyAccounting.Tests
{
    /// <summary>
    /// The purpose of this extension method class it to ease refactoring of unit tests 
    /// and get access to a property that became inaccessible after refactoring. 
    /// 
    /// Old unit test code like:
    ///     Assert.AreEqual(5, sut.RewardPoints);
    /// Can now be refactored into: 
    ///     Assert.AreEqual(5, sut.RewardPoints());
    /// </summary>
    internal static class AccountHelper
    {
        private static object GetPrivateInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }

        internal static int RewardPoints(this Account account)
        {
            var rewardCard = GetPrivateInstanceField(typeof(Account), account, "rewardCard") as IRewardCard;
            return rewardCard?.RewardPoints ?? 0;
        }
    }
}
