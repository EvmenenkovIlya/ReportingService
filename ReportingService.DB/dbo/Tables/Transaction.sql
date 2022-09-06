CREATE TABLE [dbo].[Transaction]
(
	Id bigint IDENTITY(1,1) NOT NULL,
	TransactionId bigint NOT NULL,
	AccountId int NOT NULL,
	Date datetime2 NOT NULL,
	TransactionType tinyint NOT NULL,
	Amount decimal(14,4) NOT NULL,
	Currency smallint NOT NULL,
	Rate decimal(7,4) NULL,
	RecipientId int NULL,
	RecipientAccountId int NULL,
	RecipientAmount decimal(14,4) NULL,
	RecipientCurrency tinyint NULL
  CONSTRAINT [PK_TANSACTION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);