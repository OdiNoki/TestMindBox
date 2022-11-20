CREATE TABLE [dbo].[Products] (
	[ProductID] [UNIQUEIDENTIFIER] PRIMARY KEY CLUSTERED,
	[ProductName] [VARCHAR](255) NOT NULL
	--, (здесь могут быть другие пол€, но дл€ задачи несущественно)
)

CREATE TABLE [dbo].[Categories] (
	[CategoryID] [INT] PRIMARY KEY CLUSTERED IDENTITY(1, 1),
	[CategoryName] [VARCHAR](255) UNIQUE NOT NULL
	--, (здесь могут быть другие пол€, но дл€ задачи несущественно)
)

-- “ак как продукты с категори€ми соотнос€тс€ как "многие-ко-многим", то нужна промежуточна€ таблица

CREATE TABLE [dbo].[ProductCategory] (
	[ProductID] [UNIQUEIDENTIFIER] NOT NULL
		REFERENCES [dbo].[Products] ([ProductID]),
	[CategoryID] [INT] NOT NULL
		REFERENCES [dbo].[Categories] ([CategoryID]),
	INDEX [ProductID_ix] NONCLUSTERED ([ProductID]),
	INDEX [CategoryID_ix] NONCLUSTERED ([CategoryID])
)


-- ¬ыборка
SELECT
	p.[ProductName]								AS [»м€ продукта],
	ISNULL(c.[CategoryName], '(Ѕез категории)')	AS [»м€ категории]
FROM [dbo].[Products] AS p (NOLOCK)
LEFT OUTER JOIN [dbo].[ProductCategory] AS pc (NOLOCK)
	ON p.[ProductID] = pc.ProductID
LEFT OUTER JOIN [dbo].[Categories] AS c (NOLOCK)
	ON pc.[CategoryID] = c.[CategoryID]
ORDER BY
	p.[ProductName]