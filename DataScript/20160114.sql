USE [JWMSH_2016]
GO
/****** Object:  StoredProcedure [dbo].[proc_GenerateProductLabel]    Script Date: 2016/1/14 23:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		upjd
-- Create date: 20160114
-- Description:	创建成品序列号
-- =============================================
CREATE PROCEDURE [dbo].[proc_GenerateProductLabel]
	@cSerialNumber nvarchar(30),
	@iQuantity int,
	@SerialQty int,
	@cMemo nvarchar(255)
AS
BEGIN
	declare @MaxID int,@maxBarCode nvarchar(30),@i int;
	set @maxBarCode=(select top 1 cBarCode from ProductLabel where cSerialNumber=@cSerialNumber order by AutoID desc);
	if @maxBarCode='' or @maxBarCode is null
		set @MaxID=1;
	else
		set @MaxID=CONVERT(int,right(@maxBarCode,4))+1;


	set @i=0;
	while(@i<@SerialQty)
	begin
		INSERT INTO [dbo].[ProductLabel]
           ([cSerialNumber]
           ,[cBarCode]
           ,[iQuantity]
           ,[cDefine1]
           ,[cDefine2]
           ,[cDefine3]
           ,[cDefine4]
           ,[cMemo])
     VALUES
           (@cSerialNumber,
		   @cSerialNumber+right('0000'+Convert(nvarchar(30),@MaxID+@i),4),
		   @iQuantity,
		   '',
		   '',
		   '',
		   '',
		   @cMemo)
		set @i=@i+1;
	end

		

END

GO
/****** Object:  Table [dbo].[ProductLabel]    Script Date: 2016/1/14 23:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductLabel](
	[AutoID] [bigint] IDENTITY(1,1) NOT NULL,
	[cSerialNumber] [nvarchar](30) NULL,
	[cBarCode] [nvarchar](50) NULL,
	[iQuantity] [int] NULL,
	[cDefine1] [nvarchar](255) NULL,
	[cDefine2] [nvarchar](255) NULL,
	[cDefine3] [nvarchar](255) NULL,
	[cDefine4] [nvarchar](255) NULL,
	[cMemo] [nvarchar](255) NULL,
 CONSTRAINT [PK_ProductLabel] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
