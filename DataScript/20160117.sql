USE [JWMSH_2016]
GO
/****** Object:  StoredProcedure [dbo].[Query_RmTrackingUseInProduct]    Script Date: 2016/1/15 23:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE [JWMSH_2016]
GO
/****** Object:  StoredProcedure [dbo].[Query_RmTrackingUseInProduct]    Script Date: 2016/1/15 23:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

INSERT INTO [dbo].[BFunction]
           ([cFunction]
           ,[cModule]
           ,[bMenu]
           ,[cClass])
     VALUES
           ('仓位标签打印'
           ,'原料入库管理'
           ,1
           ,'JWMSH.WorkStockPlaceLabelPrint')
GO