using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Accounts;

[JsonConverter(typeof(AccountTypeFilterConverter))]
public enum AccountTypeFilter
{
    All,
    Asset,
    Cash,
    Expense,
    Revenue,
    Special,
    Hidden,
    Liability,
    Liabilities,
    DefaultAccount,
    CashAccount,
    AssetAccount,
    ExpenseAccount,
    RevenueAccount,
    InitialBalanceAccount,
    BeneficiaryAccount,
    ImportAccount,
    ReconciliationAccount,
    Loan,
    Debt,
    Mortgage,
}

sealed class AccountTypeFilterConverter : JsonConverter<AccountTypeFilter>
{
    public override AccountTypeFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => AccountTypeFilter.All,
            "asset" => AccountTypeFilter.Asset,
            "cash" => AccountTypeFilter.Cash,
            "expense" => AccountTypeFilter.Expense,
            "revenue" => AccountTypeFilter.Revenue,
            "special" => AccountTypeFilter.Special,
            "hidden" => AccountTypeFilter.Hidden,
            "liability" => AccountTypeFilter.Liability,
            "liabilities" => AccountTypeFilter.Liabilities,
            "Default account" => AccountTypeFilter.DefaultAccount,
            "Cash account" => AccountTypeFilter.CashAccount,
            "Asset account" => AccountTypeFilter.AssetAccount,
            "Expense account" => AccountTypeFilter.ExpenseAccount,
            "Revenue account" => AccountTypeFilter.RevenueAccount,
            "Initial balance account" => AccountTypeFilter.InitialBalanceAccount,
            "Beneficiary account" => AccountTypeFilter.BeneficiaryAccount,
            "Import account" => AccountTypeFilter.ImportAccount,
            "Reconciliation account" => AccountTypeFilter.ReconciliationAccount,
            "Loan" => AccountTypeFilter.Loan,
            "Debt" => AccountTypeFilter.Debt,
            "Mortgage" => AccountTypeFilter.Mortgage,
            _ => (AccountTypeFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountTypeFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountTypeFilter.All => "all",
                AccountTypeFilter.Asset => "asset",
                AccountTypeFilter.Cash => "cash",
                AccountTypeFilter.Expense => "expense",
                AccountTypeFilter.Revenue => "revenue",
                AccountTypeFilter.Special => "special",
                AccountTypeFilter.Hidden => "hidden",
                AccountTypeFilter.Liability => "liability",
                AccountTypeFilter.Liabilities => "liabilities",
                AccountTypeFilter.DefaultAccount => "Default account",
                AccountTypeFilter.CashAccount => "Cash account",
                AccountTypeFilter.AssetAccount => "Asset account",
                AccountTypeFilter.ExpenseAccount => "Expense account",
                AccountTypeFilter.RevenueAccount => "Revenue account",
                AccountTypeFilter.InitialBalanceAccount => "Initial balance account",
                AccountTypeFilter.BeneficiaryAccount => "Beneficiary account",
                AccountTypeFilter.ImportAccount => "Import account",
                AccountTypeFilter.ReconciliationAccount => "Reconciliation account",
                AccountTypeFilter.Loan => "Loan",
                AccountTypeFilter.Debt => "Debt",
                AccountTypeFilter.Mortgage => "Mortgage",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
