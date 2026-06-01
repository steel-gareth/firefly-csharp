using System.Text.Json;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.Attachments;
using Firefly.Models.Bills;
using Firefly.Models.Budgets;
using Firefly.Models.Chart.Account;
using Firefly.Models.Configuration;
using Firefly.Models.Currencies;
using Firefly.Models.Data;
using Firefly.Models.Data.Export;
using Firefly.Models.Recurrences;
using Firefly.Models.Rules;
using Firefly.Models.Search;
using Firefly.Models.Transactions;
using Firefly.Models.UserGroups;
using Firefly.Models.Webhooks;
using Balance = Firefly.Models.Chart.Balance;
using Users = Firefly.Models.Users;

namespace Firefly.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, ChartDataSetPeriod>(),
            new ApiEnumConverter<string, Period>(),
            new ApiEnumConverter<string, Preselected>(),
            new ApiEnumConverter<string, Balance::Period>(),
            new ApiEnumConverter<string, Balance::Preselected>(),
            new ApiEnumConverter<string, Objects>(),
            new ApiEnumConverter<string, ExportFileFilter>(),
            new ApiEnumConverter<string, AccountRoleProperty>(),
            new ApiEnumConverter<string, AccountTypeFilter>(),
            new ApiEnumConverter<string, CreditCardTypeProperty>(),
            new ApiEnumConverter<string, InterestPeriodProperty>(),
            new ApiEnumConverter<string, LiabilityDirectionProperty>(),
            new ApiEnumConverter<string, LiabilityTypeProperty>(),
            new ApiEnumConverter<string, ShortAccountTypeProperty>(),
            new ApiEnumConverter<string, TransactionTypeFilter>(),
            new ApiEnumConverter<string, AttachableType>(),
            new ApiEnumConverter<string, BillRepeatFrequency>(),
            new ApiEnumConverter<string, AutoBudgetPeriod>(),
            new ApiEnumConverter<string, AutoBudgetType>(),
            new ApiEnumConverter<string, AccountTypeProperty>(),
            new ApiEnumConverter<string, RecurrenceRepetitionType>(),
            new ApiEnumConverter<string, RecurrenceTransactionType>(),
            new ApiEnumConverter<string, RuleActionKeyword>(),
            new ApiEnumConverter<string, RuleTriggerKeyword>(),
            new ApiEnumConverter<string, RuleTriggerType>(),
            new ApiEnumConverter<bool, CurrencyUpdateParamsPrimary>(),
            new ApiEnumConverter<string, TransactionTypeProperty>(),
            new ApiEnumConverter<string, Role>(),
            new ApiEnumConverter<string, Field>(),
            new ApiEnumConverter<string, ConfigValueFilter>(),
            new ApiEnumConverter<string, Name>(),
            new ApiEnumConverter<string, Users::UserBlockedCode>(),
            new ApiEnumConverter<string, Users::UserRole>(),
            new ApiEnumConverter<string, Users::BlockedCode>(),
            new ApiEnumConverter<string, Users::Role>(),
            new ApiEnumConverter<string, Users::UserUpdateParamsBlockedCode>(),
            new ApiEnumConverter<string, Users::UserUpdateParamsRole>(),
            new ApiEnumConverter<string, WebhookDelivery>(),
            new ApiEnumConverter<string, WebhookResponse>(),
            new ApiEnumConverter<string, WebhookTrigger>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="FireflyInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
