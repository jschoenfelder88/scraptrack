Create PROC Sp_Reports
AS
BEGIN
SELECT FORMAT (dbo.Transactions.Date, 'yyyy-MMM-dd') as date, Description, quantity, weight AS unit_weight, quantity*weight AS total_weight
FROM dbo.Transaction_Details
JOIN dbo.Items
ON dbo.Transaction_Details.ItemId = dbo.Items.Id
JOIN dbo.Transactions
ON dbo.Transaction_Details.TransactionId = dbo.Transactions.Id
end