

/****** Object:  View [dbo].[ReconcilationViews]    Script Date: 4/17/2022 7:50:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[ReconcilationViews]
	AS 
	(SELECT
	 ROW_NUMBER() OVER (ORDER BY Head) Id,
	 0 AS [Year],
	 rhd.Head,
	 rhd.TypeName AS Description,
	 ISNULL(r.Jan,0) AS Jan,
	 ISNULL(r.Feb,0) AS Feb,
	 ISNULL(r.Mar,0) AS Mar,
	 ISNULL(r.Apr,0) AS Apr,
	 ISNULL(r.May,0) AS May,
	 ISNULL(r.Jun,0) AS Jun,
	 ISNULL(r.Jul,0) AS Jul,
	 ISNULL(r.Aug,0) AS Aug,
	 ISNULL(r.Sep,0) AS Sep,
	 ISNULL(r.Oct,0) AS Oct,
	 ISNULL(r.Nov,0) AS Nov,
	 ISNULL(r.Dec,0) AS Dec
	 FROM ReconcilationHeadTypes rhd 
	LEFT JOIN Reconcilations r  on rhd.Id=r.Id 	
	)
GO


