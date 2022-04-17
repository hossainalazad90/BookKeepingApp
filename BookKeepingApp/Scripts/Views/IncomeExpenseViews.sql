
/****** Object:  View [dbo].[IncomeExpenseViews]    Script Date: 4/17/2022 7:51:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[IncomeExpenseViews]
AS
(SELECT 
	ROW_NUMBER() OVER ( ORDER BY [Year] ) AS Id,
    [Year],	
	[Head],
	(CASE WHEN Head=0 THEN 'Income' ELSE 'Cost' END) AS Description, 
    ISNULL([1],0) AS Jan,
    ISNULL([2],0)AS Feb,
    ISNULL([3],0)AS Mar,
    ISNULL([4],0)AS Apr,
    ISNULL([5],0)AS May,
    ISNULL([6],0)AS Jun,
    ISNULL([7],0)AS Jul,
    ISNULL([8],0)AS Aug,
    ISNULL([9],0)AS Sep,
    ISNULL([10],0) AS Oct,
    ISNULL([11],0) AS Nov,
    ISNULL([12],0) AS Dec
FROM
( 
SELECT
Head, 
YEAR(EntryDate) AS [Year],
MONTH(EntryDate) as TMonth,
Convert(decimal(18,2),SUM(Amount)) Amount
FROM IncomeExpenses ie
JOIN IncomeExpenseHeads ieh ON ie.IncomeExpenseHeadId=ieh.Id
	GROUP BY Year(EntryDate), Month(EntryDate) ,Head ) as Source
	
PIVOT
(
    SUM(Amount)
    FOR TMonth
    IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12] )
) 
AS MonthWiseIncome)
GO


