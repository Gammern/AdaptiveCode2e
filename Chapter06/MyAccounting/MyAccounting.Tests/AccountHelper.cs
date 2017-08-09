using MyAccounting.Model;
using System;
using System.Reflection;

namespace MyAccounting.Tests
{
    internal static class AccountHelper
    {
        internal static object GetPrivateInstanceField(Type type, object instance, string fieldName)
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
