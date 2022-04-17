
/****** Object:  View [dbo].[CumulativeIncomeExpenseViews]    Script Date: 4/17/2022 7:51:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[CumulativeIncomeExpenseViews]
 AS
SELECT  
    ROW_NUMBER() OVER ( ORDER BY [Year] ) AS Id,
    [Year],	
	[Head],
	(CASE WHEN Head=0 THEN 'Cumulative Income' ELSE 'Cumulative Cost' END) AS Description, 
    ISNULL([1],0) AS Jan,
    ISNULL([2],ISNULL([1],0)) AS Feb,
    ISNULL([3],ISNULL([2],ISNULL([1],0)))AS Mar,
    ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0))))AS Apr,
    ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0))))) AS May,
    ISNULL([6],ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0)))))) AS Jun,
    ISNULL([7],ISNULL([6],ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0)))))))AS Jul,
    ISNULL([8],ISNULL([7],ISNULL([6],ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0))))))))AS Aug,
    ISNULL([9],ISNULL([8],ISNULL([7],ISNULL([6],ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0)))))))))AS Sep,
    ISNULL([10],ISNULL([9],ISNULL([8],ISNULL([7],ISNULL([6],ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0)))))))))) AS Oct,
    ISNULL([11],ISNULL([10],ISNULL([9],ISNULL([8],ISNULL([7],ISNULL([6],ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0))))))))))) AS Nov,
    ISNULL([12],ISNULL([11],ISNULL([10],ISNULL([9],ISNULL([8],ISNULL([7],ISNULL([6],ISNULL([5],ISNULL([4],ISNULL([3],ISNULL([2],ISNULL([1],0)))))))))))) AS Dec
FROM
(Select 
 [Head], 
 YEAR(EntryDate) AS [Year],
 MONTH(EntryDate) as TMonth ,
 Convert(decimal(18,2),SUM(Amount) OVER(PARTITION BY Head ORDER BY month(EntryDate) ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)) AS Amount
 FROM IncomeExpenses ie
JOIN IncomeExpenseHeads ieh ON ie.IncomeExpenseHeadId=ieh.Id
 ) as Source
	
PIVOT
(
    SUM(Amount)  
    FOR TMonth
    IN ( [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12] )
) 
AS MonthWiseCumlativeCost
GO


