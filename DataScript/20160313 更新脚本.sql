--新增ProDeliveryDetail表
CREATE TABLE [dbo].[ProDeliveryDetail](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NULL,
	[cGuid] [nvarchar](50) NULL,
	[FItemID] [int] NULL,
	[cBarCode] [nvarchar](50) NULL,
	[cCode] [nvarchar](30) NULL,
	[cLotNo] [nvarchar](30) NULL,
	[cInvCode] [nvarchar](30) NULL,
	[cInvName] [nvarchar](50) NULL,
	[iQuantity] [decimal](14, 6) NULL,
	[FSPNumber] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL,
	[dScanTime] [datetime] NULL,
	[cBoxNumber] [nvarchar](50) NULL,
	[cOperator] [nvarchar](50) NULL,
	[cMemo] [nvarchar](255) NULL,
 CONSTRAINT [PK_ProDeliveryDetail] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--新增Edit Prodelivery功能


-- =============================================
-- Author:upjd
-- Create date: 20140713
-- Description:	修改产品出库单
-- =============================================
Create PROCEDURE [dbo].[EditProDelivery]
(
	@AutoID int,
	@dDate datetime = NULL,
	@cOrderCode nvarchar(30) = NULL,       
	@cCusCode nvarchar(30) = NULL,
	@cCusName nvarchar(50) = NULL,
	@cMaker nvarchar(50) = NULL,
	@cMemo nvarchar(255) = NULL,
	@cOrderType NVARCHAR(40),
	@OrderDate DATE,
	@DeliveryDate DATE,
	@cDepCode NVARCHAR(20) = NULL,
	@cDepName NVARCHAR(50) = NULL,
	@cOutType NVARCHAR(20) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [dbo].[ProDelivery]
	SET 
		   [dDate] = @dDate
		  ,[cOrderCode] = @cOrderCode
		  ,[cCusCode] = @cCusCode
		  ,[cCusName] = @cCusName
		  ,[cModifyPerson] = @cMaker
		  ,[dModifyDate] = getdate()
		  ,[cMemo] = @cMemo
		  ,[cOrderType] = @cOrderType
		  ,[OrderDate] = @OrderDate
		  ,[DeliveryDate] = @DeliveryDate
		  ,[cDepCode] = @cDepCode
		  ,[cDepName] = @cDepName
		  ,[cOutType] = @cOutType
 WHERE AutoID=@AutoID

	SET @Err = @@Error


	RETURN @Err
END




GO

--删除表RM_Produce
Drop Table RM_Produce

--新增表Rm_ProduceDetail

CREATE TABLE [dbo].[Rm_ProduceDetail](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NULL,
	[cGuid] [nvarchar](50) NULL,
	[FItemID] [int] NULL,
	[cBarCode] [nvarchar](50) NULL,
	[cCode] [nvarchar](30) NULL,
	[cLotNo] [nvarchar](30) NULL,
	[cInvCode] [nvarchar](30) NULL,
	[cInvName] [nvarchar](50) NULL,
	[iQuantity] [decimal](14, 6) NULL,
	[FSPNumber] [nvarchar](50) NULL,
	[dAddTime] [datetime] NULL,
	[dScanTime] [datetime] NULL,
	[cBoxNumber] [nvarchar](50) NULL,
	[cOperator] [nvarchar](50) NULL,
	[cMemo] [nvarchar](255) NULL,
 CONSTRAINT [PK_Rm_ProduceDetail] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



--新增存储过程Upload_RmProduceDetail


-- =============================================
-- Author:		upjd
-- Create date: 20160229
-- Description:	AddProDeliveryDetail
-- =============================================
CREATE PROCEDURE [dbo].[Upload_RmProduceDetail]
	@cGuid nvarchar(50),
	@ID int ,
	@FItemID int ,
	@cBarCode nvarchar(50) ,
	@cCode nvarchar(30) ,
	@cLotNo nvarchar(30) ,
	@cInvCode nvarchar(30) ,
	@cInvName nvarchar(50) ,
	@iQuantity decimal(14, 6) ,
	@FSPNumber nvarchar(50) ,
	@dScanTime datetime ,
	@cBoxNumber nvarchar(50) ,
	@cOperator nvarchar(50) ,
	@cMemo nvarchar(255) 
AS
BEGIN
	INSERT INTO [dbo].[Rm_ProduceDetail]
           (cGuid
		   ,[ID]
           ,[FItemID]
           ,[cBarCode]
           ,[cCode]
           ,[cLotNo]
           ,[cInvCode]
           ,[cInvName]
           ,[iQuantity]
           ,[FSPNumber]
           ,[dAddTime]
           ,[dScanTime]
           ,[cBoxNumber]
           ,[cOperator]
           ,[cMemo])
     VALUES
	 (
	 @cGuid,
		 @ID,
		 @FItemID,
		 @cBarCode,
		 @cCode,
		 @cLotNo,
		 @cInvCode,
		 @cInvName,
		 @iQuantity,
		 @FSPNumber,
		 getdate(),
		 @dScanTime,
		 @cBoxNumber,
		 @cOperator,
		 @cMemo
	  )
END


GO

--新增视图
CREATE VIEW [dbo].[View_ShiftBomDetail]
AS
SELECT   dbo.Shift.cSerialNumber, dbo.BomDetail.BomID, dbo.BomDetail.cInvCode, dbo.BomDetail.cInvName, 
                dbo.BomDetail.iQuantity * dbo.Shift.iQuantity AS iQuantity, dbo.BomDetail.cUnitID, dbo.BomDetail.cUnitName, 
                dbo.BomDetail.cInvStd, dbo.BomDetail.cFullName, dbo.BomDetail.cMemo, dbo.BomDetail.dAddTime, 
                dbo.BomDetail.cFitemID, dbo.Shift.AutoID
FROM      dbo.BomDetail INNER JOIN
                dbo.Shift ON dbo.BomDetail.BomID = dbo.Shift.BomID

GO