using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Recurrences;

[JsonConverter(typeof(AccountTypePropertyConverter))]
public enum AccountTypeProperty
{
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

sealed class AccountTypePropertyConverter : JsonConverter<AccountTypeProperty>
{
    public override AccountTypeProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Default account" => AccountTypeProperty.DefaultAccount,
            "Cash account" => AccountTypeProperty.CashAccount,
            "Asset account" => AccountTypeProperty.AssetAccount,
            "Expense account" => AccountTypeProperty.ExpenseAccount,
            "Revenue account" => AccountTypeProperty.RevenueAccount,
            "Initial balance account" => AccountTypeProperty.InitialBalanceAccount,
            "Beneficiary account" => AccountTypeProperty.BeneficiaryAccount,
            "Import account" => AccountTypeProperty.ImportAccount,
            "Reconciliation account" => AccountTypeProperty.ReconciliationAccount,
            "Loan" => AccountTypeProperty.Loan,
            "Debt" => AccountTypeProperty.Debt,
            "Mortgage" => AccountTypeProperty.Mortgage,
            _ => (AccountTypeProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountTypeProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountTypeProperty.DefaultAccount => "Default account",
                AccountTypeProperty.CashAccount => "Cash account",
                AccountTypeProperty.AssetAccount => "Asset account",
                AccountTypeProperty.ExpenseAccount => "Expense account",
                AccountTypeProperty.RevenueAccount => "Revenue account",
                AccountTypeProperty.InitialBalanceAccount => "Initial balance account",
                AccountTypeProperty.BeneficiaryAccount => "Beneficiary account",
                AccountTypeProperty.ImportAccount => "Import account",
                AccountTypeProperty.ReconciliationAccount => "Reconciliation account",
                AccountTypeProperty.Loan => "Loan",
                AccountTypeProperty.Debt => "Debt",
                AccountTypeProperty.Mortgage => "Mortgage",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
