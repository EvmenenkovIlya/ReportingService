CREATE TABLE [dbo].[Transaction]
(
	Id bigint NOT NULL,
	AccountId bigint NOT NULL,
	Date datetime2 NOT NULL,
	TransactionType tinyint NOT NULL,
	Ammount decimal(14,4) NOT NULL,
	Currency smallint NOT NULL,
	Rate decimal(6,4) NOT NULL,
  CONSTRAINT [PK_TANSACTION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
);