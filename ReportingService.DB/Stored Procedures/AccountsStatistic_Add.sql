Create PROCEDURE [dbo].[AccountsStatistic_Add]
	@DateStatistic date,
	@Currency tinyint
	
AS
BEGIN

	INSERT INTO [dbo].[AccountsStatistic]
	(
		[DateStatistic],
		[Currency],
		[ActiveAccountCount],
		[FrozenAccountCount],
		[DeletedAccountCount]
	)
    VALUES 
	(
		@DateStatistic,
		@Currency,
		(Select Count([Id]) As ActiveAccountCount From Account Where [Account].Currency = @Currency and [Account].[Status] = 1 and [Account].IsDeleted = 0) ,
		(Select Count([Id]) As FrozenAccountCount From Account Where [Account].Currency = @Currency and [Account].[Status] = 2 and [Account].IsDeleted = 0) ,
		(Select Count([Id]) As DeletedAccountCount From Account Where [Account].Currency = @Currency and [Account].IsDeleted = 1 )

	)
SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]	

END